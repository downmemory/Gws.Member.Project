using System.Data;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class Member : MetadataBase
    {
        public int MemberId { get; set; }   // integer NOT NULL,
        public string MemberCode { get; set; } //character varying(20) NOT NULL	
        public string MemberName { get; set; } //character varying(50) NOT NULL	
        public string MemberAlias { get; set; }    //character varying(50) NOT NULL
        public string MemberType { get; set; } //character varying(5) NOT NULL
        public string BizCompanyName { get; set; }    //character varying(100) NOT NULL
        public string BizNo { get; set; }  //character varying(13)
        public string BizZipCode { get; set; }    //character varying(10)
        public string BizAddr { get; set; }    //text
        public string BizAddrDetail { get; set; } //character varying(100)
        public string BizTelephone { get; set; }   //character varying(50)
        public string BizFax { get; set; } //character varying(50)
        public string BizCeoName { get; set; }    //character varying(50)
        public string BizCondition { get; set; }   //character varying(200)
        public string BizCategory { get; set; }    //character varying(200)
        public string BizUrl { get; set; } //text
        public string BillType { get; set; }   //character varying(5) NOT NULL
        public string BillDate { get; set; }   //character varying(8) NOT NULL
        public string BillCompanyName { get; set; }
        public string BillDept { get; set; }    //character varying(20)
        public string BillManager { get; set; }    //character varying(50)
        public string BillManagerMobile { get; set; } //character varying(20)
        public string BillManagerTelephone { get; set; }  //character varying(20)
        public string BillManagerEmail { get; set; }  //character varying(50)
        public string BillTypeRemark { get; set; }      //text
        public string TaxCompanyName { get; set; }    //character varying(50)
        public string TaxBizNo { get; set; }  //character varying(13)
        public string TaxBizSubNo { get; set; }  //character varying(2)	
        public string TaxCeoName { get; set; }    //character varying(50)
        public string TaxAddr { get; set; }    //text
        public string TaxAddrDetail { get; set; } //character varying(100)
        public string TaxBizCondition { get; set; }   //character varying(100)
        public string TaxBizCategory { get; set; }    //character varying(100)
        public string TaxDept { get; set; }    //character varying(50)
        public string TaxManager { get; set; } //character varying(50)
        public string TaxManagerMobile { get; set; }   //character varying(20)
        public string TaxManagerTelephone { get; set; }   //character varying(20)
        public string TaxManagerEmail { get; set; }   //character varying(200)

        public static Member ToMemberObject(DataRow row)
        {
            Member retVal = null;

            if (row != null)
            {
                retVal = new Member();
                retVal.MemberId = row.Field<int>("member_id");
                retVal.MemberCode = row.Field<string>("member_code");
                retVal.MemberName = row.Field<string>("member_name");
                retVal.MemberAlias = row.Field<string>("member_alias");
                retVal.MemberType = row.Field<string>("member_type");
                retVal.BizCompanyName = row.Field<string>("biz_company_name");
                retVal.BizNo = row.Field<string>("biz_no");
                retVal.BizZipCode = row.Field<string>("biz_zip_code");
                retVal.BizAddr = row.Field<string>("biz_addr");
                retVal.BizAddrDetail = row.Field<string>("biz_addr_detail");
                retVal.BizTelephone = row.Field<string>("biz_telephone");
                retVal.BizFax = row.Field<string>("biz_fax");
                retVal.BizCeoName = row.Field<string>("biz_ceo_name");
                retVal.BizCondition = row.Field<string>("biz_condition");
                retVal.BizCategory = row.Field<string>("biz_category");
                retVal.BizUrl = row.Field<string>("biz_url");
                retVal.BillType = row.Field<string>("bill_type");
                retVal.BillDate = row.Field<string>("bill_date");
                retVal.BillCompanyName = row.Field<string>("bill_company_name");
                retVal.BillManager = row.Field<string>("bill_manager");
                retVal.BillDept = row.Field<string>("bill_dept");
                retVal.BillManagerMobile = row.Field<string>("bill_manager_mobile");
                retVal.BillManagerTelephone = row.Field<string>("bill_manager_telephone");
                retVal.BillManagerEmail = row.Field<string>("bill_manager_email");
                retVal.BillTypeRemark = row.Field<string>("bill_type_remark");
                retVal.TaxCompanyName = row.Field<string>("tax_company_name");
                retVal.TaxBizNo = row.Field<string>("tax_biz_no");
                retVal.TaxBizSubNo = row.Field<string>("tax_biz_sub_no");
                retVal.TaxCeoName = row.Field<string>("tax_ceo_name");
                retVal.TaxAddr = row.Field<string>("tax_addr");
                retVal.TaxAddrDetail = row.Field<string>("tax_addr_detail");
                retVal.TaxBizCondition = row.Field<string>("tax_biz_condition");
                retVal.TaxBizCategory = row.Field<string>("tax_biz_category");
                retVal.TaxDept = row.Field<string>("tax_dept");
                retVal.TaxManager = row.Field<string>("tax_manager");
                retVal.TaxManagerMobile = row.Field<string>("tax_manager_mobile");
                retVal.TaxManagerTelephone = row.Field<string>("tax_manager_telephone");
                retVal.TaxManagerEmail = row.Field<string>("tax_manager_email");
                
                if (row.Table.Columns.Contains("create_datetime") == true)
                {
                    retVal.CreateDateTime = row.Field<DateTime?>("create_datetime");
                }
                else if (row.Table.Columns.Contains("created_at") == true)
                {
                    retVal.CreateDateTime = row.Field<DateTime?>("created_at");
                }

                if (row.Table.Columns.Contains("update_datetime") == true)
                {
                    retVal.UpdateDateTime = row.Field<DateTime?>("update_datetime");
                }
                else if (row.Table.Columns.Contains("updated_at") == true)
                {
                    retVal.UpdateDateTime = row.Field<DateTime?>("updated_at");
                }

                retVal.CreateUserId = row.Field<int?>("create_user_id");
                retVal.UpdateUserId = row.Field<int?>("update_user_id");
                retVal.CreateIp = row.Field<string>("create_ip");
                retVal.UpdateIp = row.Field<string>("update_ip");

            }
            return retVal;
        }
    }

    
}