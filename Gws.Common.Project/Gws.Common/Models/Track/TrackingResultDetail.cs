using Gws.Common.Utils;

namespace Gws.Common.Models.Track
{
    #nullable disable
    public class TrackingResultDetail
    {
        public TrackingResultDetail()
        {
            Seq = string.Empty;
            ProcDateTime = string.Empty;
            FromBranCode = string.Empty;
            FromBranName = string.Empty;
            FromBranTelNo = string.Empty;
            FromCountryCode = string.Empty;
            ToBranCode = string.Empty;
            ToBranName = string.Empty;
            ToBranTelNo = string.Empty;
            ToCountryCode = string.Empty;
            EmpName = string.Empty;
            EmpTelNo = string.Empty;
            Remark = string.Empty;
            DlvStatType = string.Empty;
            DlvStatName = string.Empty;
            SiteDlvStatType = string.Empty;
            SiteDlvStatName = string.Empty;
            ExceptionType = string.Empty;
            ExceptionName = string.Empty;
            SiteExceptionName = string.Empty;
            DlvStatDesc = string.Empty;
            DefCode1 = string.Empty;
            DefCode2 = string.Empty;
            InvoiceNo = string.Empty;
        }

        /// <summary>
        /// 순번
        /// </summary>
        //[XmlElementAttribute("Seq")]
        public string Seq { get; set; }

        /// <summary>
        /// 처리일시
        /// </summary>
        //[XmlElementAttribute("ProcDateTime")]
        public string ProcDateTime { get; set; }

        /// <summary>
        /// 처리점소코드
        /// </summary>
        //[XmlElementAttribute("FromBranCode")]
        public string FromBranCode { get; set; }

        /// <summary>
        /// 처리점소
        /// </summary>
        //[XmlElementAttribute("FromBranName")]
        public string FromBranName { get; set; }

        /// <summary>
        /// 처리지점전화번호
        /// </summary>
        //[XmlElementAttribute("FromBranTelNo")]
        public string FromBranTelNo { get; set; }

        /// <summary>
        /// 처리지점국가코드
        /// </summary>
        public string FromCountryCode { get; set; }

        /// <summary>
        /// 상대점소코드
        /// </summary>
        //[XmlElementAttribute("ToBranCode")]
        public string ToBranCode { get; set; }

        /// <summary>
        /// 상대점소
        /// </summary>
        //[XmlElementAttribute("ToBranName")]
        public string ToBranName { get; set; }

        /// <summary>
        /// 상대지점전화번호
        /// </summary>
        //[XmlElementAttribute("ToBranTelNo")]
        public string ToBranTelNo { get; set; }

        /// <summary>
        /// 상대지점국가코드
        /// </summary>
        public string ToCountryCode { get; set; }

        /// <summary>
        /// 상태코드(사이트)
        /// </summary>
        //[XmlElementAttribute("SiteDlvStatType")]
        public string SiteDlvStatType { get; set; }

        /// <summary>
        /// 상태(사이트)
        /// </summary>
        //[XmlElementAttribute("SiteDlvStatName")]
        public string SiteDlvStatName { get; set; }

        //[XmlElementAttribute("DlvStatDesc")]
        public string DlvStatDesc { get; set; }

        /// <summary>
        /// 상태정보(굿스플로)
        /// </summary>
        //[XmlElementAttribute("DlvStatType")]
        public string DlvStatType { get; set; }

        /// <summary>
        /// 상태정보명(굿스플로)
        /// </summary>
        //[XmlElementAttribute("DlvStatName")]
        public string DlvStatName { get; set; }

        /// <summary>
        /// 담당자
        /// </summary>
        //[XmlElementAttribute("EmpName")]
        public string EmpName { get; set; }

        /// <summary>
        /// 담당자전화번호
        /// </summary>
        //[XmlElementAttribute("EmpTelNo")]
        public string EmpTelNo { get; set; }

        //[XmlElementAttribute("EmpMsg")]
        public string EmpMsg { get; set; }

        /// <summary>
        /// 비고(오류 등)
        /// </summary>
        //[XmlElementAttribute("Remark")]
        public string Remark { get; set; }


        /// <summary>
        /// 미집하 사유(굿스플로)
        /// 미배송 사유(굿스플로)
        /// 반송 사유(굿스플로)
        /// 취소 사유(굿스플로)
        /// 미출고 사유(굿스플로)
        /// </summary>
        //[XmlElementAttribute("ExceptionType")]
        public string ExceptionType { get; set; }

        /// <summary>
        /// 미집하 사유(굿스플로)
        /// 미배송 사유(굿스플로)
        /// 반송 사유(굿스플로)
        /// 취소 사유(굿스플로)
        /// 미출고 사유(굿스플로)
        /// </summary>
        //[XmlElementAttribute("ExceptionName")]
        public string ExceptionName { get; set; }

        /// 미집하 사유(사이트)
        /// 미배송 사유(사이트)
        /// 반송 사유(사이트)
        /// 취소 사유(사이트)
        /// 미출고 사유(사이트)
        //[XmlElementAttribute("SiteExceptionType")]
        public string SiteExceptionType { get; set; }

        /// 미집하 사유(사이트)
        /// 미배송 사유(사이트)
        /// 반송 사유(사이트)
        /// 취소 사유(사이트)
        /// 미출고 사유(사이트)
        //[XmlElementAttribute("SiteExceptionName")]
        public string SiteExceptionName { get; set; }

        public string ExceptionDesc { get; set; }

        /// <summary>
        /// 타배송사로 이관하여 처리하는 경우 대상 배송사코드
        /// </summary>
        //[XmlElementAttribute("TransferLogisticsCode")]
        public string TransferLogisticsCode { get; set; }

        /// <summary>
        /// 타배송사로 이관하여 처리하는 경우 운송장번호
        /// </summary>
        //[XmlElementAttribute("TransferInvoiceNo")]
        public string TransferInvoiceNo { get; set; }

        /// <summary>
        /// 사용자정의코드 1 (배송예정시간)
        /// </summary>
        //[XmlElementAttribute("DefCode1")]
        public string DefCode1 { get; set; }

        /// <summary>
        /// 사용자정의코드 2
        /// </summary>
        //[XmlElementAttribute("DefCode2")]
        public string DefCode2 { get; set; }

        /// <summary>
        /// 운송장번호
        /// </summary>
        //[XmlIgnore]
        public string InvoiceNo { get; set; }

        public int GetDlvStatTypeMainNumber()
        {
            int retVal = 0;
            retVal = Util.IsNull(Util.IsNullOrEmpty(DlvStatType, "00").Substring(0, 1), 0);
            retVal = (retVal == 4 || retVal == 6) ? 5 : retVal;    //6번대이면 5번대로 바꿔 리턴

            return retVal;
        }
    }
}