using System.Text.Json.Serialization;
using Gws.Common.Enums;

namespace Gws.Common.Global
{
    #nullable disable
    public class GlobalAppConfig
    {
       private List<KeyValuePair<string, Exception>> _InitializeExceptions = null;

        [JsonIgnore]
        public List<KeyValuePair<string, Exception>> InitializeExceptions
        {
            get
            {
                if (_InitializeExceptions == null)
                    _InitializeExceptions = new List<KeyValuePair<string, Exception>>();

                return _InitializeExceptions;
            }
        }

        public Dictionary<HttpRequestUrl, string> ApiUrls { get; set; }

        public DBConfig MainDB { get; set; }

         public List<DBConfig> DatabaseList { get; set; }
    }
}