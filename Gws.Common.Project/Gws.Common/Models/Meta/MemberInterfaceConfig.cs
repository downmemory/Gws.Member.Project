using System.Data;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class MemberInterfaceConfig : MetadataBase
    {
        public int? MemberId { get; set; }               // integer NOT NULL
        public string MemberCode { get; set; }
        public string MemberName { get; set; }
        public string MemberAlias { get; set; }
        public string ConnectType { get; set; }     // character varying(5) NOT NULL
        public string TargetAddress { get; set; }       // text
        public int TargetPort { get; set; }          // integer
        public string LoginId { get; set; }         // character varying(30)
        public string LoginPwd { get; set; }            // character varying(30)
        public string DbType { get; set; }              // character varying(10)
        public string DbConnString { get; set; }        // text
        public string ServiceName { get; set; }        // character varying(50)
        public string HomeDir { get; set; }         // character varying(100)
        public string InDir { get; set; }               // character varying(50)
        public string InBakDir { get; set; }            // character varying(50)
        public string OutDir { get; set; }              // character varying(50)
        public string OutBakDir { get; set; }           // character varying(50)
        public string TargetInDir { get; set; }     // character varying(50)
        public string TargetOutDir { get; set; }        // character varying(50)
        public string TargetInBakDir { get; set; }  // character varying(50)
        public string TargetOutBakDir { get; set; } // character varying(50)
        public string InTrcFilePrefix { get; set; } // character varying(10)
        public string InTrnFilePrefix { get; set; } // character varying(10)
        public string OutFilePrefix { get; set; }       // character varying(10)
        public string ResFilePrefix { get; set; }       // character varying(10)
        public string C2cFilePrefix { get; set; }       // character varying(10)
        public string C2cCancelPrefix { get; set; } // character varying(10)
        public string MailList { get; set; }            // text
        public string AllowedIpList { get; set; }		// text

        //public string InterfaceCategory { get; set; }

        //결과 전송 Callback 관련 Property
        public string CallbackHttpMethod { get; set; }
        public string CallbackHttpContentType { get; set; }
        public string CallbackHttpHeader { get; set; }
        public string CallbackTransResultUrl { get; set; }
        public string CallbackZkmResultUrl { get; set; }

        public string CallbackTransResultAllUrl { get; set; }
        public string CallbackZkmResultAllUrl { get; set; }

         public static MemberInterfaceConfig GetDefaultValue(MemberInfo member)
        {
            MemberInterfaceConfig retVal = new MemberInterfaceConfig();
            retVal.MemberId = null;
            retVal.MemberCode = member.MemberCode;
            retVal.MemberName = member.MemberName;
            retVal.ConnectType = "API";
            retVal.TargetAddress = null;
            retVal.TargetPort = 0;
            retVal.LoginId = null;
            retVal.LoginPwd = null;
            retVal.DbType = null;
            retVal.DbConnString = null;
            retVal.ServiceName = null;
            retVal.HomeDir = null;
            retVal.InDir = "IN";
            retVal.InBakDir = "INBAK";
            retVal.OutDir = "OUT";
            retVal.OutBakDir = "OUTBAK";
            retVal.TargetInDir = null;
            retVal.TargetOutDir = null;
            retVal.TargetInBakDir = null;
            retVal.TargetOutBakDir = null;
            retVal.InTrcFilePrefix = "TRC";
            retVal.InTrnFilePrefix = "TRN";
            retVal.OutFilePrefix = "RSLT";
            retVal.ResFilePrefix = "CHKRSLT";
            retVal.C2cFilePrefix = "C2C";
            retVal.C2cCancelPrefix = "C2CCancl";
            retVal.MailList = "tm.zkm@goodsflow.com";
            retVal.AllowedIpList = "*";
            retVal.CallbackHttpMethod = null;
            retVal.CallbackHttpContentType = null;
            retVal.CallbackHttpHeader = null;
            retVal.CallbackTransResultUrl = null;
            retVal.CallbackZkmResultUrl = null;
            retVal.CallbackTransResultAllUrl = null;
            retVal.CallbackZkmResultAllUrl = null;

            return retVal;
        }

         public static MemberInterfaceConfig ToMemberInterfaceConfigObject(DataRow row)
        {
            MemberInterfaceConfig retVal = null;

            if(row != null)
            {
            retVal = new MemberInterfaceConfig();
            retVal.MemberId = row.Field<int>("member_id");
            retVal.MemberCode = row.Field<string>("member_code");
            retVal.MemberName = row.Field<string>("member_name");
            retVal.ConnectType = row.Field<string>("connect_type");
            retVal.TargetAddress = row.Field<string>("target_address");
            retVal.TargetPort = row.Field<int>("target_port");
            retVal.LoginId = row.Field<string>("login_id");
            retVal.LoginPwd = row.Field<string>("login_pwd");
            retVal.DbType = row.Field<string>("db_type");
            retVal.DbConnString = row.Field<string>("db_conn_string");
            retVal.ServiceName = row.Field<string>("service_name");
            retVal.HomeDir = row.Field<string>("home_dir");
            retVal.InDir = row.Field<string>("in_dir");
            retVal.InBakDir = row.Field<string>("in_bak_dir");
            retVal.OutDir = row.Field<string>("out_dir");
            retVal.OutBakDir = row.Field<string>("out_bak_dir");
            retVal.TargetInDir = row.Field<string>("target_in_dir");
            retVal.TargetOutDir = row.Field<string>("target_out_dir");
            retVal.TargetInBakDir = row.Field<string>("target_in_bak_dir");
            retVal.TargetOutBakDir = row.Field<string>("target_out_bak_dir");
            retVal.InTrcFilePrefix = row.Field<string>("in_trc_file_prefix");
            retVal.InTrnFilePrefix = row.Field<string>("in_trn_file_prefix");
            retVal.OutFilePrefix = row.Field<string>("out_file_prefix");
            retVal.ResFilePrefix = row.Field<string>("res_file_prefix");
            retVal.C2cFilePrefix =row.Field<string>("c2c_file_prefix");
            retVal.C2cCancelPrefix = row.Field<string>("c2c_cancel_prefix");
            retVal.MailList = row.Field<string>("mail_list");
            retVal.AllowedIpList = row.Field<string>("allowed_ip_list");;
            retVal.CallbackHttpMethod = row.Field<string>("callback_http_method");
            retVal.CallbackHttpContentType = row.Field<string>("callback_http_content_type");
            retVal.CallbackHttpHeader = row.Field<string>("callback_http_header");
            retVal.CallbackTransResultUrl = row.Field<string>("callback_trans_result_url");
            retVal.CallbackZkmResultUrl = row.Field<string>("callback_zkm_result_url");
            retVal.CallbackTransResultAllUrl = row.Field<string>("callback_trans_result_all_url");
            retVal.CallbackZkmResultAllUrl = row.Field<string>("callback_zkm_result_all_url");
            }
            

            return retVal;
        }
    }
}