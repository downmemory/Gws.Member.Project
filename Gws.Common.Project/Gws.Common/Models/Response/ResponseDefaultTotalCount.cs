

using Gws.Common.Models.Response;
using Newtonsoft.Json;

namespace Gws.Common.Models.Response
{
    public class ResponseDefaultTotalCount : ResponseDefault
    {
        public ResponseDefaultTotalCount(object pData, long totalCount) : this()
        {
            this.Data = pData;
            this.TotalCount = totalCount;
        }

        public ResponseDefaultTotalCount() : base()
        {

        }

        [JsonProperty(Order = -1)]
        public long TotalCount { get; set; }
    }
}