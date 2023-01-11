using Gws.Common.Enums;

namespace Gws.Common.Global
{
    public class DBConfig
    {
        public DBProduct DbProduct { get; set; }

        public DBName Name { get; set; }
        public int No {get; set;}
        public string? ConnString { get; set; }

        public int CommandTimeout { get; set; }
    }
}