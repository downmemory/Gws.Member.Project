using System.Data;
using System.Reflection;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class MemberInfo : Member
    {
        public MemberInfo()
        {
        }

        public MemberInfo(Member parent)
        {
            foreach (PropertyInfo prop in parent.GetType().GetProperties()){
                 GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(parent, null), null);
            }
               
        }

        /// <summary>
        /// LAPS 서버 분리로 인해 LAPS 서버를 사용하는 (배송서비스) 회원사인지 체크한다.
        /// </summary>
        /// <returns></returns>
        public bool CheckTransService()
        {
            bool retVal = false;

            if (MemberCommConfig.IsUseTrans == true || MemberCommConfig.IsUseC2c == true || MemberCommConfig.IsUseCoTrans == true || MemberCommConfig.IsUsePrivateReturn == true ||
                MemberCommConfig.IsUsePrt == true || MemberCommConfig.IsUseRtn == true || MemberCommConfig.IsUseCoPrt == true || MemberCommConfig.IsUseCoRtn == true)
            {
                retVal = true;
            }

            return retVal;
        }

        public MemberCommConfig MemberCommConfig{ get; set;}
        public MemberWebViewConfig MemberWebViewConfig { get; set; }
        public MemberInterfaceConfig MemberInterfaceConfig {get; set;}

    }
}