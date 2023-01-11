using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
    /// <summary>
    /// DB이름
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DBName
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE = 0,

        MainDB = 10,
        MONITOR = 100,
        LAPS = 110,
        ZKM = 120,
        PTS = 130,
        // LAPS = 110,
        // ZKM0 = 110,
        // LAPS1 = 120,
        // ZKM1 = 130,
        // ZKM2 = 140,
        // ZKM3 = 150,
        // PTS0 = 160,
        // PTS1 = 170,
        VNS = 140,
        LOGMS = 150,
        IISLOG = 160
    
    }
}