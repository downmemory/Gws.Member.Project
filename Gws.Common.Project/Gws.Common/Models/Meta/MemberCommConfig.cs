using System.Data;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class MemberCommConfig
    {
        public int? MemberId { get; set; }               // integer NOT NULL,
        public string MemberCode { get; set; }
        public string MemberName { get; set; }
        public int LapsServerNo { get; set; } = 0;  // integer NOT NULL
        public int ZkmServerNo { get; set; }          // integer NOT NULL
        public bool IsUse { get; set; }                 // boolean NOT NULL
        public bool IsMajor { get; set; }
        public bool IsTest { get; set; }                // boolean NOT NULL
        public bool IsUseTrace { get; set; }            // boolean NOT NULL
        public bool IsUseTrans { get; set; }            // boolean NOT NULL
        public bool IsUseC2c { get; set; }              // boolean NOT NULL
        public bool IsUsePrivateReturn { get; set; }              // boolean NOT NULL
        public bool IsUseCoTrans { get; set; }              // boolean NOT NULL

        //신규로 정리
        public bool IsUseZkm { get; set; }            // boolean NOT NULL
        public bool IsUsePrt { get; set; }            // boolean NOT NULL
        public bool IsUseRtn { get; set; }            // boolean NOT NULL
        public bool IsUseCoPrt { get; set; }              // boolean NOT NULL
        public bool IsUseCoRtn { get; set; }              // boolean NOT NULL
        public bool IsUseAlimi { get; set; }            // boolean NOT NULL
        public bool IsUseRtTracking { get; set; }       // boolean NOT NULL
        //public bool IsUseSendMsg { get; set; }          // boolean NOT NULL
        public bool IsUseMiss { get; set; }             // boolean NOT NULL
        public bool IsUseVns { get; set; }              // boolean NOT NULL
        public bool HasDailyReport { get; set; }        // boolean NOT NULL
        public bool HasWeeklyReport { get; set; }       // boolean NOT NULL
        public bool HasMonthlyReport { get; set; }      // boolean NOT NULL
        public bool HasTaxBill { get; set; }            // boolean NOT NULL 
        public decimal PricePerTalk { get; set; }       // numeric(12,2)
        public decimal PricePerSms { get; set; }        // numeric(12,2)
        public decimal PricePerLms { get; set; }        // numeric(12,2)
        public string ApiKey { get; set; }              // character varying(50) NOT NULL
        public string AlimiServiceType { get; set; }              // character varying(1) NOT NULL
        public string AlimiApiCode { get; set; }
        public string AlimiApiKey { get; set; }
        public bool CheckCustoms { get; set; }          // 우체국 송장의 경우 관세청 정보를 가져올지 여부 결정

        /// <summary>
        /// 정산 마감 사용 여부
        /// </summary>
        public bool HasBillDeadline { get; set; }

        /// <summary>
        /// 0 - Reqular(정규)
        /// 1 - Immediate(즉시)
        /// </summary>
        public string ReturnTransferType { get; set; }

        /// <summary>
        /// API 사용 시 동기식/비동기식으로 저장할지 여부를 결정
        /// 동기식(true) : 바로 DB에 데이터를 저장 후 리턴(응답).
        /// 비동기식(false) : 로컬(웹서버) 디스크에 데이터를 저장하고 리턴(응답)
        /// </summary>
        public bool IsSaveAsSync { get; set; } = false;              // boolean NOT NULL

        public static MemberCommConfig ToMemberCommConfigObject(DataRow row)
        {
            MemberCommConfig retVal = null;

            if(row != null )
            {
                retVal = new MemberCommConfig();
                retVal.MemberId = row.Field<int?>("member_id");
                retVal.MemberCode = row.Field<string>("member_code");
                retVal.MemberName = row.Field<string>("member_name");
                retVal.ZkmServerNo = row.Field<int>("zkm_server_no");
                retVal.IsUse = row.Field<bool>("is_use");
                retVal.IsMajor = row.Field<bool>("is_major");
                retVal.IsTest = row.Field<bool>("is_test");
                retVal.IsUseTrace = row.Field<bool>("is_use_trace");
                retVal.IsUseTrans = row.Field<bool>("is_use_trans");
                retVal.IsUseC2c = row.Field<bool>("is_use_c2c");
                retVal.IsUsePrivateReturn = row.Field<bool>("is_use_private_return");
                retVal.IsUseCoTrans = row.Field<bool>("is_use_co_trans");
                // retVal.IsUseZkm = row.Field<bool>("is_use_zkm");
                // retVal.IsUsePrt = row.Field<bool>("is_use_prt");
                // retVal.IsUseRtn = row.Field<bool>("is_use_rtn");
                // retVal.IsUseCoRtn = row.Field<bool>("is_use_co_rtn");
                // retVal.IsUseCoPrt = row.Field<bool>("is_use_co_prt");
                retVal.IsUseAlimi = row.Field<bool>("is_use_alimi");
                retVal.IsUseRtTracking = row.Field<bool>("is_use_rt_tracking");
                retVal.IsUseMiss = row.Field<bool>("is_use_miss");
                retVal.IsUseVns = row.Field<bool>("is_use_vns");
                retVal.HasDailyReport = row.Field<bool>("has_daily_report");
                retVal.HasWeeklyReport = row.Field<bool>("has_weekly_report");
                retVal.HasMonthlyReport = row.Field<bool>("has_monthly_report");
                retVal.HasTaxBill = row.Field<bool>("has_tax_bill");
                retVal.PricePerTalk = row.Field<decimal>("price_per_talk");
                retVal.PricePerSms = row.Field<decimal>("price_per_sms");
                retVal.PricePerLms = row.Field<decimal>("price_per_lms");
                retVal.ApiKey = row.Field<string>("api_key");
                retVal.AlimiServiceType = row.Field<string>("alimi_service_type");
                retVal.AlimiApiCode = row.Field<string>("alimi_api_code");
                retVal.AlimiApiKey = row.Field<string>("alimi_api_key");
                retVal.CheckCustoms = row.Field<bool>("check_customs");
                retVal.HasBillDeadline = row.Field<bool>("has_bill_deadline");
                // retVal.ReturnTransferType = row.Field<string>("return_transfer_type");    //정규
            }

            return retVal;
        }
        public static MemberCommConfig GetDefaultValue(MemberInfo member, int zkmServerNo)
        {
            MemberCommConfig retVal = new MemberCommConfig();

            retVal.MemberId = null;
            retVal.MemberCode = member.MemberCode;
            retVal.MemberName = member.MemberName;
            retVal.ZkmServerNo = zkmServerNo;
            retVal.IsUse = true;
            retVal.IsMajor = false;
            retVal.IsTest = false;
            retVal.IsUseTrace = true;
            retVal.IsUseTrans = false;
            retVal.IsUseC2c = false;
            retVal.IsUsePrivateReturn = false;
            retVal.IsUseCoTrans = false;


            // retVal.IsUseZkm = true;
            // retVal.IsUsePrt = false;
            // retVal.IsUseRtn = false;
            // retVal.IsUseCoRtn = false;
            // retVal.IsUseCoPrt = false;

            retVal.IsUseAlimi = false;
            retVal.IsUseRtTracking = false;
            retVal.IsUseMiss = false;
            retVal.IsUseVns = false;
            retVal.HasDailyReport = false;
            retVal.HasWeeklyReport = false;
            retVal.HasMonthlyReport = false;
            retVal.HasTaxBill = false;
            retVal.PricePerTalk = 0.0M;
            retVal.PricePerSms = 0.0M;
            retVal.PricePerLms = 0.0M;
            retVal.ApiKey = null;
            retVal.AlimiServiceType = null;
            retVal.AlimiApiCode = null;
            retVal.AlimiApiKey = null;
            retVal.CheckCustoms = false;
            retVal.HasBillDeadline = false;
            retVal.ReturnTransferType = "0";    //정규

            return retVal;

        }


    }
}