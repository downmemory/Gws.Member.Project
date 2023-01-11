using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceScope
    {
          /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Singleton
        /// </summary>
        Singleton = 100,

        /// <summary>
        /// Transient
        /// </summary>
        Transient = 200,

        /// <summary>
        /// Scoped
        /// </summary>
        Scoped = 300,
    }
}