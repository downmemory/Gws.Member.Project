using Gws.Common.Enums;

namespace Gws.Common.Global
{
    #nullable disable
    public class DBStatus
    {
        public DateTime FromDatetime { get; set; }

        public bool IsOk { get; set; }

        public string Description { get; set; }

        public string EmailValidateInterval { get; set; }

        public DateTime ReadDatetime { get; set; }

        public Dictionary<SiteKey, string> Sites { get; set; }
    }
}