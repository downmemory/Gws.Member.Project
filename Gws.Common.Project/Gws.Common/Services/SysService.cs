using System.Collections.Concurrent;
using System.Data;
using Gws.Common.Enums;
using Gws.Common.Global;
using Gws.Common.Helpers;
using Microsoft.Extensions.Options;

namespace Gws.Common.Services
{
    #nullable disable
    public interface ISysService
    {
        DBExecutor MainDB { get; }
        DBExecutor GetDB(DBName name);
        DBExecutor GetDB(DBName name, int no);
        DBExecutor GetDB(string name);
        GlobalAppConfig AppConfig { get; }
        
    }

    public class SysService : ISysService
    {
        private readonly GlobalAppConfig _app;
        
        public SysService(IOptions<GlobalAppConfig> app) //IOptions<GlobalAppConfig> app, IHttpRequestHelperService httpRequest
        {
            _app = app.Value;
            this.MainDB = new Helpers.DBExecutor(_app.MainDB);
            this.DatabaseList = new List<DBExecutor>();

            foreach (DBConfig config in _app.DatabaseList)
            {
                this.DatabaseList.Add(new DBExecutor(config));
            }

        }
          public GlobalAppConfig AppConfig
        {
            get
            {
                return _app;
            }
        }

        public DBExecutor MainDB
        {
            get;
            private set;
        }

        public DBExecutor GetDB(DBName name)
        {
            return this.GetDB(name.ToString());
        }
        public DBExecutor GetDB(DBName name, int no)
        {
            return this.GetDB(name.ToString(), no);
        }


        public List<DBExecutor> DatabaseList
        {
            get;
            private set;
        }

         private DBStatus _DatabaseStatus = null;

        public void ReloadMainDBStatus()
        {
            // string error = "dbstatus data not found";

            // try
            // {
            //     // using(DataTable dt = MainDB.SpSelect)
            // }
        }

          public DBStatus MainDBStatus
        {
            get
            {
                if (_DatabaseStatus == null)
                    ReloadMainDBStatus();

                return _DatabaseStatus;
            }
        }

        public DBExecutor GetDB(string name)
        {
            return this.DatabaseList.Where(db => db.DBName.ToString() == name.ToUpper() ).FirstOrDefault();
        }

        public DBExecutor GetDB(string name, int no)
        {
            return this.DatabaseList.Where(db => db.DBName.ToString() == name.ToUpper() && db.DBNo == no).FirstOrDefault(); 
        }


    }
    
}