using System.Data;
using Gws.Common.Utils;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class MemberWebViewConfig
    {
        public int MemberId { get; set; }
        public string MemberCode { get; set; }
        public string MemberName { get; set; }
        //public string MemberAlias { get; set; }   //삭제 MemberInfo 내 정보 이동 -SMS 20200618
        public string MemberNameDisplay { get; set; }
        public string ViewName { get; set; }
        public string ViewNameMobile { get; set; }
        public string ViewCaption { get; set; }
        public bool IsHideCaption { get; set; }
        public bool IsHidePrivateInfo { get; set; }

        public static MemberWebViewConfig GetDefaultValue(Member member)
        {
            MemberWebViewConfig retVal = new MemberWebViewConfig()
            {
                MemberId = member.MemberId,
                MemberCode = member.MemberCode,
                MemberName = member.MemberName,
                MemberNameDisplay = member.MemberName,
                IsHideCaption = false,
                IsHidePrivateInfo = false
            };

            return retVal;
        }

        public static MemberWebViewConfig ToMemberWebViewConfigObject(DataRow row)
        {
            MemberWebViewConfig retVal = null;

            if(row != null)
            {
                retVal = new MemberWebViewConfig();
                retVal.MemberId = row.Field<int>("member_id");
                retVal.MemberCode = row.Field<string>("member_code");
                retVal.MemberNameDisplay = row.Field<string>("member_name_display");
                retVal.ViewName = row.Field<string>("view_name");
                retVal.ViewNameMobile = row.Field<string>("view_name_mobile");
                retVal.ViewCaption = row.Field<string>("view_caption");
                retVal.IsHideCaption =  Util.IsNull(row["is_hide_caption"], false); 
                retVal.IsHidePrivateInfo = Util.IsNull(row["is_hide_private_info"], false); 
            }

            return retVal;
        }
    }
}