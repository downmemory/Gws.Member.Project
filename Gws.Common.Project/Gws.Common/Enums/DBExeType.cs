using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
    /// <summary>
    /// 실행 타입
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DBExeType
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        /// <summary>
        /// NoneQuery
        /// </summary>
        NQ = 100,
        /// <summary>
        /// DataSet
        /// </summary>
        DS = 200,
        /// <summary>
        /// DataTable
        /// </summary>
        DT = 300
    }
}