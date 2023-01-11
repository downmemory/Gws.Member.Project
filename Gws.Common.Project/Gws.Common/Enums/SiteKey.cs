using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
     [JsonConverter(typeof(StringEnumConverter))]
    public enum SiteKey
    {
         /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Api
        /// </summary>
        Api = 100,

        /// <summary>
        /// Landing
        /// </summary>
        Landing = 200,

        /// <summary>
        /// Member
        /// </summary>
        Member = 300,

        /// <summary>
        /// Admin
        /// </summary>
        Admin = 400,

    }
}