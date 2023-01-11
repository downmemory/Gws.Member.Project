using System.Net;
using Gws.Common.Models.Meta;
using Gws.Common.Models.Response;
using Gws.Common.Utils;

namespace Gws.Common.Services
{
    #nullable disable
    public interface IAuthService
    {
        bool CheckAuth(string ApiKey, string methodName, string clientIP, ref ApiError error);
        void SetMemberInfo(MemberInfo memberInfo);
    }

    public class AuthService : IAuthService
    {
    //    private readonly ILoggingService _logging;
       private readonly IMemberService _member;
       private MemberInfo _memberInfo;
       public AuthService(IMemberService member, IHttpContextAccessor context )
       {
         _member = member;
       }

       public void SetMemberInfo(MemberInfo memberInfo)
       {
            _memberInfo = memberInfo;
       }

        public bool CheckAuth(string apiKey, string methodName, string clientIP, ref ApiError error)
        {
            bool retVal = false;

             if(_memberInfo != null)
             {
                if(string.IsNullOrEmpty(_memberInfo.MemberCode) == false)
                {
                    if(string.IsNullOrEmpty(apiKey) == false)
                    {

                        if(CheckFreePass(clientIP) == true)
                        {
                            return true;
                        }
                        else
                        {
                            if(CheckAccessAddress(clientIP) == true)
                            {
                            if (CheckApiKey(apiKey) == true)
                            {
                                retVal = true;
                            }
                            else
                            {
                                error.Status = ApiErrorStatus.Unauthorized;
                                error.Message = ApiErrorStatusName.Unauthorized;
                                error.DetailMessage = string.Format("ApiKey 정보가 올바르지 않습니다.");
                            }
                            }
                            else
                            {
                                error.Status = ApiErrorStatus.Unauthorized;
                                error.Message = ApiErrorStatusName.Unauthorized;
                                error.DetailMessage = string.Format("접근이 허용되지 않은 주소입니다.");
                            }
                        }
                    }
                    else
                    {
                        error.Status = ApiErrorStatus.Unauthorized;
                        error.Message = ApiErrorStatusName.Unauthorized;
                        error.DetailMessage = string.Format("ApiKey 정보가 존재하지 않습니다.");
                        // apikey가 없음..
                    }
                }
                else{
                    //memberCode가 없음.;
                    error.Status = ApiErrorStatus.Unauthorized;
                    error.Message = ApiErrorStatusName.Unauthorized;
                    error.DetailMessage = string.Format("AgentMemberCode 정보가 존재하지 않습니다.");
                }
             }
            // else
            // {
            //     error.Status = ApiErrorStatus.RequestError;
            //     error.Message = ApiErrorStatusName.RequestError;
            //     error.DetailMessage = "파라메터정보 없음";
            // }
            

            return retVal;
        }

        public bool CheckApiKey(string apiKey)
        {
            bool retVal = false;
            
            foreach (string key in _memberInfo.MemberCommConfig.ApiKey.Split(';'))
            {
                if (key.Equals(apiKey, StringComparison.OrdinalIgnoreCase) == true)
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public bool CheckAccessAddress(string ipAddress)
        {
            bool retVal = false;
            string allowAddresses = Util.IsNull(_memberInfo.MemberInterfaceConfig.AllowedIpList, "*");
            List<string> allows = allowAddresses.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (allows.Count > 0)
            {
                if (allows.Contains(ipAddress, StringComparer.OrdinalIgnoreCase) == true)
                {
                    retVal = true;
                }
                else if (allows.Contains("all", StringComparer.OrdinalIgnoreCase) == true ||
                         allows.Contains("*", StringComparer.OrdinalIgnoreCase) == true)
                {
                    retVal = true;
                }
                else
                {
                    foreach (string cidrAddress in allows)
                    {
                        if (Util.CheckIpAddress(ipAddress.Trim(), cidrAddress.Trim()) == true)
                        {
                            retVal = true;
                            break;
                        }
                    }
                }
            }

            return retVal;
        }

        public bool CheckFreePass(string ipAddress)
        {
            bool retVal = false;

            if(_memberInfo.MemberInterfaceConfig.AllowedIpList != null)
            {
                List<string> allows = _memberInfo.MemberInterfaceConfig.AllowedIpList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if(allows.Count > 0)
                {
                    IPAddress address;
    
                    if (IPAddress.TryParse(ipAddress, out address))
                    {
                        switch (address.AddressFamily)
                        {
                            case System.Net.Sockets.AddressFamily.InterNetwork:
                                // IPv4
                                ipAddress = allows[0];
                                break;
                            case System.Net.Sockets.AddressFamily.InterNetworkV6:
                                // IPv6
    
                                break;
                            default:
                                break;
                        }
                    }
                }
                
                if (ipAddress != null)
                        {
                            if (allows.Contains(ipAddress, StringComparer.OrdinalIgnoreCase) == true)
                            //if (allows.Contains(splitRequestAddress[0], StringComparer.OrdinalIgnoreCase) == true)
                            {
                                retVal = true;
                            }
                            else if (allows.Contains("all", StringComparer.OrdinalIgnoreCase) == true ||
                                     allows.Contains("*", StringComparer.OrdinalIgnoreCase) == true)
                            {
                                retVal = true;
                            }
                            else
                            {
                                foreach (string cidrAddress in allows)
                                {
                                    if (Util.CheckIpAddress(ipAddress, cidrAddress) == true)
                                    //if (Util.CheckIpAddress(splitRequestAddress[0], cidrAddress) == true)
                                    {
                                        retVal = true;
                                        break;
                                    }
                                }
                            }
                        }
            }
            

            return retVal;
        }
    }
}