using System.ComponentModel.DataAnnotations;
using Gws.Common.Global;
using Newtonsoft.Json;

namespace Gws.Common.Models.Response
{
    #nullable disable
    public class ResponseDefault
   {
        public ResponseDefault(object pData) : this()
        {
            this.Data = pData;
        }

        public ResponseDefault()
        {
            this.Success = true;
            this.Datetime = GlobalStatic.DateTimeDefaultNow;
        }

        [Required]
        [JsonProperty(Order = -2)]
        public bool Success { get; set; }

        [JsonProperty(Order = -2)]
        public string Datetime { get; set; }

        [JsonProperty(Order = 0)]
        public object Data { get; set; }
    }
}