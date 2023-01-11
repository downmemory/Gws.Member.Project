using System.Data;
using System.Text;
using Gws.Common.Enums;
using Gws.Common.Models.Meta;
using Newtonsoft.Json;
// using System.Reflection;

namespace Gws.Common.Services
{
    #nullable disable
    public interface IMemberService
    {
        MemberInfo GetMemberInfo(string memberCode, bool isUse);

        Member GetMember(string memberCode, bool isUse);

        MemberCommConfig GetMemberCommConfig(string memberCode, bool is_use);

        MemberInterfaceConfig GetMemberInterfaceConfig(string memberCode, bool is_use);

        MemberWebViewConfig GetMemberWebViewConfig(string memberCode, bool isUse);
    }

    public class MemberService : IMemberService
    {
        private readonly ISysService _system;

        public MemberService(ISysService system)
        {
            _system = system;
        }
        
        public MemberInfo GetMemberInfo(string memberCode, bool isUse)
        {
           MemberInfo retVal = null;

           if(string.IsNullOrEmpty(memberCode) == false)
           {
             retVal = new MemberInfo(GetMember(memberCode, true));
             retVal.MemberCommConfig = GetMemberCommConfig(memberCode, true);
             retVal.MemberInterfaceConfig = GetMemberInterfaceConfig(memberCode, true);
             retVal.MemberWebViewConfig = GetMemberWebViewConfig(memberCode, true);
           
           } 
           
           return retVal;
        }

        public Member GetMember(string memberCode, bool isUse)
        {
            Member retVal = null;
            List<Object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_is_use");
            parameters.Add(1);
            
            StringBuilder sbQuery = new StringBuilder(@"SELECT a.*");
            sbQuery.AppendLine(" FROM MD_MEMBER a");
            sbQuery.AppendLine(" INNER JOIN MD_MEMBER_COMM_CONFIG b");
            sbQuery.AppendLine(" ON a.member_id = b.member_id");
            sbQuery.AppendLine(" WHERE (@p_member_code IS NULL OR a.member_code = @p_member_code)");
            sbQuery.AppendLine(" AND  (@p_is_use IS NULL OR b.is_use = @p_is_use)");

            using(DataTable dt = _system.MainDB.Select(sbQuery.ToString(), parameters.ToArray()) ){

                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new Member();

                    foreach(DataRow row in dt.Rows)
                    {
                        retVal = Member.ToMemberObject(row);
                    }
                }
            }

            return retVal;
        }

        public MemberCommConfig GetMemberCommConfig(string memberCode, bool isUse)
        {
            MemberCommConfig retVal = null;
            List<Object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_is_use");
            parameters.Add(true);
            
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine("SELECT  a.member_id          as member_id");
            sbQuery.AppendLine(",		a.member_code       as member_code");
            sbQuery.AppendLine(",		a.member_name       as member_name");
            sbQuery.AppendLine(",		b.*");
            sbQuery.AppendLine("FROM MD_MEMBER a");
            sbQuery.AppendLine("LEFT OUTER JOIN MD_MEMBER_COMM_CONFIG b");
            sbQuery.AppendLine("ON a.member_id = b.member_id");
            sbQuery.AppendLine("WHERE (@p_member_code IS NULL OR a.member_code = @p_member_code)");
            sbQuery.AppendLine("AND   (@p_is_use IS NULL OR b.is_use = @p_is_use)");

            using(DataTable dt = _system.MainDB.Select(sbQuery.ToString(), parameters.ToArray()) ){

                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new MemberCommConfig();

                    foreach(DataRow row in dt.Rows)
                    {
                        retVal = MemberCommConfig.ToMemberCommConfigObject(row);
                    }
                }
            }

            return retVal;
        }


        public MemberWebViewConfig GetMemberWebViewConfig(string memberCode, bool isUse)
        {
            MemberWebViewConfig retVal = null;
            List<object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_is_use");
            parameters.Add(1);
                
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine(" SELECT a.member_id                                     as member_id");
            sbQuery.AppendLine(" ,		a.member_code                                   as member_code");
            sbQuery.AppendLine(" ,		a.member_name                                   as member_name");
            sbQuery.AppendLine(" ,		COALESCE(c.member_name_display, a.member_name)    as member_name_display");
            sbQuery.AppendLine(" ,		c.view_name");
            sbQuery.AppendLine(" ,		c.view_name_mobile");
            sbQuery.AppendLine(" ,		c.view_caption                                  as view_caption");
            sbQuery.AppendLine(" ,		COALESCE(c.is_hide_caption, 1)                     as is_hide_caption");
            sbQuery.AppendLine(" ,		COALESCE(c.is_hide_private_info, 1)                as is_hide_private_info");
            sbQuery.AppendLine(" ,		c.create_datetime");
            sbQuery.AppendLine(" ,		c.update_datetime");
            sbQuery.AppendLine(" ,		c.create_user_id");
            sbQuery.AppendLine(" ,		c.update_user_id");
            sbQuery.AppendLine(" ,		c.create_ip");
            sbQuery.AppendLine(" ,		c.update_ip");
            sbQuery.AppendLine(" FROM MD_MEMBER a");
            sbQuery.AppendLine(" INNER JOIN MD_MEMBER_COMM_CONFIG b");
            sbQuery.AppendLine(" ON a.member_id = b.member_id");
            sbQuery.AppendLine(" INNER JOIN MD_MEMBER_WEBVIEW_CONFIG c");
            sbQuery.AppendLine(" ON a.member_id = c.member_id");
            sbQuery.AppendLine("WHERE (@p_member_code IS NULL OR a.member_code = @p_member_code)");
            sbQuery.AppendLine("AND (@p_is_use IS NULL OR b.is_use = @p_is_use)");

            using(DataTable dt = _system.MainDB.Select(sbQuery.ToString(), parameters.ToArray()))
            {
                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new MemberWebViewConfig();
                    foreach(DataRow dr in dt.Rows)
                    {
                        retVal = MemberWebViewConfig.ToMemberWebViewConfigObject(dr);
                    }
                }
            }
                return retVal;
        }

        public MemberInterfaceConfig GetMemberInterfaceConfig(string memberCode, bool is_use)
        {
            MemberInterfaceConfig retVal = null;
            List<object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_is_use");
            parameters.Add(true);
                
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine("SELECT  a.member_code       as member_code");
            sbQuery.AppendLine(",		a.member_name       as member_name");
            sbQuery.AppendLine(",		c.*");
            sbQuery.AppendLine("FROM md_member a");
            sbQuery.AppendLine("INNER JOIN md_member_comm_config b");
            sbQuery.AppendLine("ON a.member_id = b.member_id");
            sbQuery.AppendLine("INNER JOIN md_member_interface_config c");
            sbQuery.AppendLine("ON a.member_id = c.member_id");
            sbQuery.AppendLine("WHERE 1=1");
            sbQuery.AppendLine("AND (@p_member_code IS NULL OR a.member_code = @p_member_code)");
            sbQuery.AppendLine("AND (@p_is_use IS NULL OR b.is_use = @p_is_use)");

            using(DataTable dt = _system.MainDB.Select(sbQuery.ToString(), parameters.ToArray()))
            {
                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new MemberInterfaceConfig();
                    foreach(DataRow dr in dt.Rows)
                    {
                        retVal = MemberInterfaceConfig.ToMemberInterfaceConfigObject(dr);
                    }
                }
            }
            return retVal;
        }


        // private IEnumerable<object> GetListOfMemberInfo(string memberCode, MemberInfoConfigsFlag flag)
        // {
        //     if(flag == MemberInfoConfigsFlag.Default)
        //     {
        //        return this.GetMemberInfo(memberCode);
        //     }
        // }

    }
}