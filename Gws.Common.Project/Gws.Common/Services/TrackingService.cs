using System.Data;
using System.Text;
using Gws.Common.Enums;
using Gws.Common.Global;
using Gws.Common.Models;
using Gws.Common.Models.Meta;
using Gws.Common.Models.Track;

namespace Gws.Common.Services
{
    #nullable disable
    public interface ITrackingService
    {
        TrackingResultInfo GetTracking(MemberInfo memberCode, string param1, string param2, string param3, bool? isMobile);
    }
    
    public class TrackingService : ITrackingService
    {
        private readonly ILoggingService _logger;
        private readonly ISysService _system;
        private readonly IMemberService _member;

        public TrackingService(ISysService system, IMemberService member, ILoggingService logger)
        {
             _system = system;
             _member = member;
             _logger = logger;
             this.DefaultCheckDate = DateTime.Now.AddHours(-3).ToString(ZKMYYYYMMDDHHMMSS);
        }

        public TrackingResultInfo GetTracking(MemberInfo memberInfo, string param1, string param2, string param3, bool? isMobile)
        {
            TrackingResultInfo retVal = null;
            string ipAddress = string.Empty;
            string uriPath = string.Empty;
            string permViewName = string.Empty;
            string permViewNameMobile = string.Empty;
            string itemUniqueCode = string.Empty;
            string logisticsCode = string.Empty;
            string invoiceNo = string.Empty;
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string memberCode = string.Empty;
            DateTime startDateTime = DateTime.Now;
            try
            {
                if(memberInfo != null )
                {
                    if(string.IsNullOrEmpty(memberInfo.MemberCode) == false)
                    {
                        memberCode = memberInfo.MemberCode;
                        if(memberCode.ToLower().EndsWith("-howdy") == true)
                        {
                            memberCode = memberCode.ToLower().Replace("-howdy", "");
                            permViewName = "ssg-howdy";
                            permViewNameMobile = "ssg-howdy-mobile";
                        }

                        if(memberInfo != null)
                        {
                            if (string.IsNullOrWhiteSpace(param2) && string.IsNullOrWhiteSpace(param3))
                            {
                                itemUniqueCode = param1;
                            }
                            else if (string.IsNullOrWhiteSpace(param2) == false)
                            {
                                logisticsCode = param1;
                                invoiceNo = param2;
                            }

                            MemberWebViewConfig webViewConfig = memberInfo.MemberWebViewConfig;

                            if(webViewConfig == null)
                            {
                                webViewConfig = MemberWebViewConfig.GetDefaultValue(memberInfo);
                            }

                            if(string.IsNullOrEmpty(permViewName) == false && string.IsNullOrEmpty(permViewNameMobile) == false)
                            {
                                webViewConfig.ViewName = permViewName;
                                webViewConfig.ViewNameMobile = permViewNameMobile;
                            }

                            // TrackingResultInfo result = null;


                            // if(string.IsNullOrWhiteSpace(itemUniqueCode) == false)
                            // {

                            // }
                            // else if(string.IsNullOrWhiteSpace(logisticsCode) == false && string.IsNullOrWhiteSpace(invoiceNo) == false)
                            // {
                            
                            // }
                            retVal = GetTrackingResultInfoOnPts(memberInfo, logisticsCode, invoiceNo, false, memberInfo.MemberCommConfig.IsUseRtTracking );
                        }

                        if(retVal == null)
                        {
                            
                            if(string.IsNullOrWhiteSpace(logisticsCode) == false && string.IsNullOrWhiteSpace(invoiceNo) == false)
                            {
                                if(memberInfo.MemberCommConfig.IsUseRtTracking == true)
                                {
                                    retVal = GetTrackingResultInfoOnTime(logisticsCode, invoiceNo, false, false, 2000);
                                }
                            }
                        }

                    }
                }
                

            }
            catch(Exception ex)
            {
                string errMsg = ex.Message;
            }

           
             _logger.NInfo(string.Join(", ", ipAddress, memberCode, methodName ));
             return retVal;
        }

        private TrackingResultInfo GetTrackingResultInfoOnTime(string logisticsCode, string invoiceNo, bool checkCustoms, bool isSave, int timeOut = 2000)
        {
            TrackingResultInfo retVal = null;
            
            return retVal;
        }

        private TrackingResultInfo GetTrackingResultInfoOnPts(MemberInfo memberInfo, string logisticsCode, string invoiceNo, bool CheckCustoms, bool isUseRtTracking = true,  int serverNo = 0 )
        {
            TrackingResultInfo retVal = null;
            DateTime startDateTime = DateTime.Now;
            StringBuilder sbElapsedTimeDesc = new StringBuilder();
            
            List<Object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberInfo.MemberCode);
            parameters.Add("@p_logistics_code");
            parameters.Add(logisticsCode);
            parameters.Add("@p_invoice_no");
            parameters.Add(invoiceNo);
            parameters.Add("@p_include_detils");
            parameters.Add(true);
            

            using(DataTable dt = _system.GetDB(DBName.PTS, serverNo).SpSelect(DBFunc.usp_select_trace_info_by_member_code, parameters.ToArray()) ){

                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new TrackingResultInfo();

                    foreach(DataRow row in dt.Rows)
                    {
                        retVal = TrackingResultInfo.ToTrackingResultInfoObject(row);
                    }
                }
            }

            if(retVal == null)
            {
                if(memberInfo.CheckTransService() == true)
                {
                    retVal = GetTrackingResultInfoOnLaps(memberInfo.MemberCode, logisticsCode, invoiceNo, DBName.ZKM, memberInfo.MemberCommConfig.LapsServerNo);
                }

                if(memberInfo.MemberCommConfig.IsUseTrace == true)
                {
                    if(memberInfo.MemberCommConfig.ZkmServerNo == 0)
                    {
                        retVal = GetTrackingResultInfoOnZkm(memberInfo.MemberCode, logisticsCode, invoiceNo, DBName.ZKM, DBFunc.usp_laps_select_tracking_info_by_invoice_no.ToString(), memberInfo.MemberCommConfig.ZkmServerNo);
                    }
                    else
                    {
                        retVal = GetTrackingResultInfoOnZkm(memberInfo.MemberCode, logisticsCode, invoiceNo, DBName.ZKM, DBFunc.usp_select_tracking_info.ToString(), memberInfo.MemberCommConfig.ZkmServerNo);
                    }
                }
            }

            return retVal;
        }

        private TrackingResultInfo GetTrackingResultInfoOnLaps(string memberCode, string logisticsCode, string invoiceNo, DBName dbName, int serverNo, bool includeDetails = true )
        {
            TrackingResultInfo retVal = null;
            DateTime startDateTime = DateTime.Now;
            StringBuilder sbElapsedTimeDesc = new StringBuilder();
            
            List<Object> parameters = new List<Object>();
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_logistics_code");
            parameters.Add(logisticsCode);
            parameters.Add("@p_invoice_no");
            parameters.Add(invoiceNo);
            parameters.Add("@p_include_details");
            parameters.Add(1);
            

            using(DataTable dt = _system.GetDB(DBName.ZKM, 0).SpSelect(DBFunc.usp_zkm_select_tracking_info_by_invoice_no, parameters.ToArray()) ){

                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new TrackingResultInfo();

                    foreach(DataRow row in dt.Rows)
                    {
                        retVal = TrackingResultInfo.ToTrackingResultInfoObject(row);
                    }
                }
            }
            return retVal;
        }

        private TrackingResultInfo GetTrackingResultInfoOnZkm(string memberCode, string logisticsCode, string invoiceNo, DBName dbName, string dbf, int serverNo, bool includeDetails = true)
        {
            TrackingResultInfo retVal = null;
            DateTime startDateTime = DateTime.Now;
            StringBuilder sbElapsedTimeDesc = new StringBuilder();
            
            List<Object> parameters = new List<Object>();
            parameters.Add("@p_logistics_code");
            parameters.Add(logisticsCode);
            parameters.Add("@p_invoice_no");
            parameters.Add(invoiceNo);
            parameters.Add("@p_member_code");
            parameters.Add(memberCode);
            parameters.Add("@p_include_details");
            parameters.Add(includeDetails);
            
            using(DataTable dt = _system.GetDB(dbName, serverNo).SpSelect(dbf, parameters.ToArray()) ){

                if(dt != null && dt.Rows.Count > 0)
                {
                    retVal = new TrackingResultInfo();

                    foreach(DataRow row in dt.Rows)
                    {
                        retVal = TrackingResultInfo.ToTrackingResultInfoObject(row);
                    }
                }
            }
            return retVal;
        }

        public string DefaultCheckDate
        {
        get;
        private set;
        }

        public const string ZKMYYYYMMDDHHMMSS = "yyyyMMddHHmmss";

        
    }

    
}