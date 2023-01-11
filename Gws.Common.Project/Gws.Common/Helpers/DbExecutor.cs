using System.Data;
using System.Text;
using Gws.Common.Enums;
using Gws.Common.Global;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Gws.Common.Helpers
{
    #nullable disable
    public class DBExecutor
    {
        public readonly DBConfig _config;

        public DBExecutor(DBConfig config)
        {
            _config = config;
        }

        public DBName DBName
        {
            get
            {
                return _config.Name;
            }
        } 

        public int DBNo
        {
            get{
                return _config.No;
            }
        }

        public DataTable Select(string query, params object[] evenParams)
        {
            return this.SimpleSelect(query, () => this.MakeParams(evenParams));
        }

         public DataTable SpSelect(string query, params object[] evenParams)
        {
            return this.ExecuteCommand(DBExeType.DT, CommandType.StoredProcedure, false,
                query, () => this.MakeParams(evenParams), out SqlParam[] dummy) as DataTable;
        }


        private object MakeParam(object[] evenParams)
        {
            throw new NotImplementedException();
        }

        private DataTable SimpleSelect(string query, Func<object> value1, object value2)
        {
            throw new NotImplementedException();
        }

         public object ExecuteQuery(DBExeType exeType, bool isTransaction, string procName, Func<SqlParam[]> addParam)
            => this.ExecuteCommand(exeType, CommandType.Text, isTransaction, procName, addParam, out SqlParam[] _);
        public DataTable SimpleSelect(string procName) => this.SimpleSelect(procName, null);

        public DataTable SimpleSelect(string procName, Func<SqlParam[]> addParam) => ExecuteQuery(DBExeType.DT, false, procName, addParam) as DataTable;

        private object ExecuteCommand(DBExeType exeType, CommandType commandType, bool isTransaction, string procName, Func<SqlParam[]> addParam, out SqlParam[] outParams)
        {
            if (_config.DbProduct == DBProduct.POSTGRES)
            {
                return ExecuteCommandPGSQL(exeType, commandType, isTransaction, procName, addParam, out outParams);
            }
            else{
                return ExecuteCommandMSSQL(exeType, commandType, isTransaction, procName, addParam, out outParams); 
            }
               
        }

        private SqlParam[] MakeParams(params object[] paramNameAndValues)
        {
            if (paramNameAndValues == null)
                return null;

            List<object> evenParams = new List<object>();
            if (paramNameAndValues.Length == 1 && paramNameAndValues[0] is List<object> oneList)
                evenParams.AddRange(oneList.ToArray());
            else
                evenParams.AddRange(paramNameAndValues);

            List<SqlParam> sqlParams = new List<SqlParam>();

            if (evenParams != null && evenParams.Count % 2 == 0)
            {
                for (int i = 0; i < evenParams.Count; i += 2)
                {
                    string paramName = evenParams[i] as string;

                    if (paramName == null)
                        throw new ArgumentException("짝수(0,2,4,...)번째 파라메터는 string type");

                    object paramValue = evenParams[i + 1];

                    SqlParam p = new SqlParam(paramName, paramValue);

                    if (paramValue != null && paramValue != DBNull.Value)
                    {
                        if (paramValue.GetType() == typeof(DateTime))
                            p.DbType = System.Data.DbType.DateTime2;
                        else if (paramValue.GetType() == typeof(bool))
                            p.DbType = System.Data.DbType.Boolean;
                    }

                    sqlParams.Add(p);
                }
            }

            if (sqlParams.Count > 0)
                return sqlParams.ToArray();

            return null;

        }

        private object ExecuteCommandPGSQL(DBExeType exeType, CommandType commandType, bool isTransaction, string procName, Func<SqlParam[]> addParam, out SqlParam[] outParams)
        {
            object retVal = null;

            if(exeType == DBExeType.NQ)
                retVal = false;

             outParams = null;

            try
            {
                using(NpgsqlConnection conn = new NpgsqlConnection(_config.ConnString))
                {
                NpgsqlTransaction transaction = null;
                try
                {
               
                    conn.Open();
                    transaction = isTransaction ? conn.BeginTransaction() : conn.BeginTransaction(IsolationLevel.ReadUncommitted); //읽기만 하는 트렌젝션?

                    using(NpgsqlCommand cmd = new NpgsqlCommand(procName, conn, transaction))
                    {
                        cmd.CommandType = commandType;
                        cmd.CommandTimeout = _config.CommandTimeout;
                        cmd.Parameters.Clear();

                        SqlParam[] parameters = addParam?.Invoke();
                           if (parameters != null && parameters.Length > 0)
                                cmd.Parameters.AddRange(parameters.Select(p => p.ToNpgParam()).ToArray());

#if DEBUG
                            if (!procName.StartsWith("INSERT INTO apilog"))
                            {
                                StringBuilder sbDebug = new StringBuilder();
                                sbDebug.AppendLine($"@@@@@@@@@@ ExecuteCommand : {procName}");
                                sbDebug.AppendLine($"DBExeType : {exeType}");
                                sbDebug.AppendLine($"CommandType : {commandType}");
                                foreach (var x in cmd.Parameters)
                                    if (x is NpgsqlParameter npgParam)
                                        sbDebug.AppendLine($"   {npgParam.ParameterName} : {npgParam.NpgsqlValue}");

                                sbDebug.AppendLine($"@@@@@@@@@@ ExecuteCommand : {procName}");
                                System.Diagnostics.Debug.WriteLine(sbDebug.ToString());
                            }
#endif

                            if (exeType == DBExeType.NQ)
                            {
                                cmd.ExecuteNonQuery();
                                retVal = true;
                            }
                            else if (exeType == DBExeType.DS)
                            {
                                using NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(cmd);
                                using DataSet ds = new DataSet();
                                adapt.Fill(ds);
                                retVal = ds;
                            }
                            else if (exeType == DBExeType.DT)
                            {
                                using NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(cmd);
                                using DataTable dt = new DataTable();
                                adapt.Fill(dt);
                                retVal = dt;
                            }

                            outParams = cmd.Parameters.Cast<NpgsqlParameter>()
                                .Where(p => p.Direction == ParameterDirection.InputOutput && p.Direction == ParameterDirection.Output)
                                .Select(p => new SqlParam(p)).ToArray();
                        }
                        

                        if (transaction != null && transaction.Connection != null)
                            transaction.Commit();
                    }
                    catch (NpgsqlException ex)
                    {
                        if (transaction != null && transaction.Connection != null)
                            transaction.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null && transaction.Connection != null)
                            transaction.Rollback();
                        throw ex;
                    }
                }
                
                return retVal;
            }
            catch (NpgsqlException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Query : {procName}\r\nMessage : {ex.Message}");
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
            

        }

        private object ExecuteCommandMSSQL(DBExeType exeType, CommandType commandType, bool isTransaction, string procName, Func<SqlParam[]> addParam, out SqlParam[] outParams)
        {
            object retVal = null;

            if(exeType == DBExeType.NQ)
                retVal = false;

            outParams = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(_config.ConnString))
                {
                    SqlTransaction transaction = null;

                    try
                    {
                        conn.Open();
                        transaction = isTransaction ? conn.BeginTransaction() : conn.BeginTransaction(IsolationLevel.ReadUncommitted);

                        using(SqlCommand cmd = new SqlCommand(procName, conn, transaction))
                        {
                            cmd.CommandType = commandType;

                            #if DEBUG
                                cmd.CommandTimeout = int.MaxValue;
                            #else
                                cmd.CommandTimeout = _config.CommandTimeout;
                            #endif

                            cmd.Parameters.Clear();

                            SqlParam[] parameters = addParam?.Invoke();

                            if (parameters != null && parameters.Length > 0)
                                cmd.Parameters.AddRange(parameters.Select(p => p.ToSqlParam()).ToArray());

                            if (exeType == DBExeType.NQ)
                            {
                                cmd.ExecuteNonQuery();
                                retVal = true;
                            }
                            else if (exeType == DBExeType.DS)
                            {
                                using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                                using (DataSet ds = new DataSet())
                                {
                                    adapt.Fill(ds);
                                    retVal = ds;
                                }
                            }
                            else if (exeType == DBExeType.DT)
                            {
                                using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                                using (DataTable dt = new DataTable())
                                {
                                    adapt.Fill(dt);
                                    retVal = dt;
                                }
                            }

                            outParams = cmd.Parameters.Cast<SqlParameter>()
                                .Where(p => p.Direction == ParameterDirection.InputOutput && p.Direction == ParameterDirection.Output)
                                .Select(p => new SqlParam(p)).ToArray();
                        }

                         if (transaction != null && transaction.Connection != null)
                            transaction.Commit();
                    }
                    catch(SqlException ex)
                    {
                        string errMsg = ex.Message;
                        if(transaction != null && transaction.Connection != null)
                        transaction.Rollback();
                        throw ex;
                    }
                    catch (System.Exception ex)
                    {
                        if (transaction != null && transaction.Connection != null)
                            transaction.Rollback();
                        throw ex;
                    }
                }

                return retVal;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}