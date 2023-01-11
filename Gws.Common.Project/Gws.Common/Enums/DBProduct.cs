using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
     [JsonConverter(typeof(StringEnumConverter))]
    public enum DBProduct
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        MSSQL = 10,
        
        POSTGRES = 20
    }
}