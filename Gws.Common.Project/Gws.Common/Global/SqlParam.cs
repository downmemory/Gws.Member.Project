using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Gws.Common.Global
{
    #nullable disable
    public class SqlParam
    {
        #region 생성자

        public SqlParam()
        {
        }

        public SqlParam(SqlParameter sqlParam)
            : this(sqlParam.ParameterName, sqlParam.DbType, sqlParam.Size, sqlParam.Value)
        {
            this.Scale = sqlParam.Scale;
            this.Precision = sqlParam.Precision;
        }

        public SqlParam(NpgsqlParameter sqlParam)
            : this(sqlParam.ParameterName, sqlParam.DbType, sqlParam.Size, sqlParam.Value)
        {
            this.Scale = sqlParam.Scale;
            this.Precision = sqlParam.Precision;
        }

        public SqlParam(string parameterName, DbType parameterType, int size, object value)
            : this(parameterName, parameterType, value)
        {
            this.Size = size;
        }

        public SqlParam(string parameterName, DbType parameterType, object value)
            : this(parameterName, value)
        {
            this.DbType = parameterType;
        }

        public SqlParam(string parameterName, object value)
        {
            this.ParameterName = parameterName;
            this.Value = value;

            if (value == null)
                this.Value = DBNull.Value;
            else
            {
                if (value.GetType() == typeof(int))
                    this.DbType = DbType.Int32;
                else if (value.GetType() == typeof(long))
                    this.DbType = DbType.Int64;
                else if (value.GetType() == typeof(double))
                    this.DbType = DbType.Double;
                else if (value.GetType() == typeof(string))
                    this.DbType = DbType.String;
            }
        }

        #endregion 생성자

        #region 메서드

        public SqlParameter ToSqlParam()
        {
            return new SqlParameter(this.ParameterName, this.Value)
            {
                DbType = this.DbType,
                Size = this.Size,
                Scale = this.Scale,
                Precision = this.Precision
            };
        }

        public NpgsqlParameter ToNpgParam()
        {
            return new NpgsqlParameter(this.ParameterName, this.Value)
            {
                DbType = this.DbType,
                Size = this.Size,
                Scale = this.Scale,
                Precision = this.Precision
            };
        }

        #endregion 메서드


        #region 프로퍼티

        public string ParameterName
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public DbType DbType
        {
            get;
            set;
        }

        public int Size
        {
            get;
            set;
        }

        public byte Scale
        {
            get;
            set;
        }

        public byte Precision
        {
            get;
            set;
        }

        #endregion 프로퍼티
    }
}