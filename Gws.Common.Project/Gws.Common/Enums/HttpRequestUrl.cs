using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
     [JsonConverter(typeof(StringEnumConverter))]
    public enum HttpRequestUrl
    {
          /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        /// <summary>
        /// 랩스
        /// </summary>
        Laps = 10,

           /// <summary>
        /// 지키미
        /// </summary>
        Zkm = 20,
    }
}