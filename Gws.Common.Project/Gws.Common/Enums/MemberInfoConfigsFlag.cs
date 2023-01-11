using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Gws.Common.Enums
{
     [Flags]
    public enum MemberInfoConfigsFlag
    {
        Default = 0,
        InterfaceConfig = 1,
        TraceConfig = 2,
        LogisticsTraceConfig = 4,
        AlimiConfig = 8,
        BillConfig = 16,
        MemberWebViewConfig = 32,
        MemberVnsConfig = 64,
        All = 1023 
    }
}