using System.Data;
using Gws.Common.Utils;
using Newtonsoft.Json;

namespace Gws.Common.Models.Track
{
    #nullable disable
    public class TrackingResultInfo
    {
        public TrackingResultInfo()
        {
            LogisticsCode = string.Empty;
            InvoiceNo = string.Empty;
            PickupDateTime = string.Empty;
            DlvDateTime = string.Empty;
            Taker = string.Empty;
            LastDlvStatName = string.Empty;
            LastDlvStatType = string.Empty;
            SendName = string.Empty;
            RecvName = string.Empty;
            ItemName = string.Empty;
            ItemCount = string.Empty;
            RecvTel1 = string.Empty;
            RecvTel2 = string.Empty;
            FromTelephone = string.Empty;
            FromMobile = string.Empty;
            ToTelephone = string.Empty;
            ToMobile = string.Empty;
            RecvZipcode = string.Empty;
            RecvAddr1 = string.Empty;
            IsSuccess = true;
            ErrorMsg = string.Empty;
            OrderNo = string.Empty;
            Remark = string.Empty;
            OriginCountryCode = string.Empty;
            DestinationCountryCode = string.Empty;
            Details = new List<TrackingResultDetail>();
        }

        public static TrackingResultInfo ToTrackingResultInfoObject(DataRow row)
        {
            TrackingResultInfo retVal = null;
            try
            {
                retVal = JsonConvert.DeserializeObject<TrackingResultInfo>(Util.IsNull(row["json_data"], string.Empty));


                if (retVal != null)
                {
                    retVal.LogisticsName = Util.IsNull(row["logistics_name"], string.Empty);

                    if (string.IsNullOrEmpty(retVal.LogisticsTelephone) == true)
                    {
                        retVal.LogisticsTelephone = Util.IsNull(row["logistics_rep_tel"], string.Empty);
                    }

                    retVal.ItemName = Util.IsNull(row["item_name"], retVal.ItemName);
                    retVal.ItemCount = Util.IsNull(row["item_cnt"], retVal.ItemCount);
                    retVal.OrderNo = Util.IsNull(row["order_no"], retVal.OrderNo);

                    if (row.Table.Columns.Contains("unique_code") == true)
                    {
                        retVal.Dummy1 = Util.IsNull(row["unique_code"], string.Empty);
                    }

                    try
                    {
                        DateTime? tmpDateTime = row.Field<DateTime?>("order_datetime");
                        if (tmpDateTime != null)
                        {
                            retVal.OrderDateTime = tmpDateTime.ToString(); //"yyyy-MM-dd HH:mm:ss"
                        }
                    }
                    catch
                    {
                        ;
                    }

                    try
                    {
                        DateTime? tmpDateTime = row.Field<DateTime?>("last_trace_datetime");
                        if (tmpDateTime != null)
                        {
                            retVal.ObjectCreateDateTime = tmpDateTime.ToString(); //"yyyy-MM-dd HH:mm:ss"
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
                else
                {
                    retVal = new TrackingResultInfo()
                    {
                        LogisticsCode = Util.IsNull(row["logistics_code"], string.Empty),
                        InvoiceNo = Util.IsNull(row["invoice_no"], string.Empty),
                        LogisticsName = Util.IsNull(row["logistics_name"], string.Empty),
                        LogisticsTelephone = Util.IsNull(row["logistics_rep_tel"], string.Empty),
                        LastDlvStatType = Util.IsNull(row["last_dlv_stat_type"], string.Empty),
                        LastDlvStatName = Util.IsNull(row["last_dlv_stat_type_name"], string.Empty),
                        ItemName = Util.IsNull(row["item_name"], string.Empty),
                        ItemCount = Util.IsNull(row["item_cnt"], string.Empty),
                        OrderNo = Util.IsNull(row["order_no"], string.Empty),
                        Dummy1 = Util.IsNull(row["unique_code"], string.Empty),
                        SendName = Util.IsNull(row["from_name"], string.Empty),
                        RecvName = Util.IsNull(row["to_name"], string.Empty),
                        RecvAddr1 = Util.IsNull(row["to_addr"], string.Empty),
                        ToMobile = Util.IsNull(row["to_tel1"], string.Empty),
                        ToTelephone = Util.IsNull(row["to_tel2"], string.Empty),
                        Taker = Util.IsNull(row["taker"], string.Empty),
                        LastProcDateTime = Util.IsNull(row["last_proc_datetime"], string.Empty),
                        PickupDateTime = Util.IsNull(row["pickup_datetime"], string.Empty),
                        DlvDateTime = Util.IsNull(row["dlv_datetime"], string.Empty)
                    };

                    try
                    {
                        DateTime? tmpDateTime = row.Field<DateTime?>("order_datetime");
                        if (tmpDateTime != null)
                        {
                            retVal.OrderDateTime = tmpDateTime.ToString(); //"yyyy-MM-dd HH:mm:ss"
                        }
                    }
                    catch
                    {
                        ;
                    }

                    try
                    {
                        DateTime? tmpDateTime = row.Field<DateTime?>("last_trace_datetime");
                        if (tmpDateTime != null)
                        {
                            retVal.ObjectCreateDateTime = tmpDateTime.ToString(); //"yyyy-MM-dd HH:mm:ss"
                        }
                    }
                    catch
                    {
                        ;
                    }
                }


                //서버정보 추가 SMS-20220510
                // if (row.Table.Columns.Contains("server_info") == true && string.IsNullOrEmpty(row.Field<string>("server_info")) == false)
                // {
                //     var settings = new JsonSerializerSettings();
                //     settings.ContractResolver = new ServerInfoContractResolver();
                //     try
                //     {
                //         retVal.ServerInfo = JsonConvert.DeserializeObject<List<ServerInfoBase>>(row.Field<string>("server_info"), settings);
                //     }
                //     catch
                //     {
                //         ;
                //     }
                // }
            }
            catch
            {
                ;
            }

            return retVal;
        }
         /// <summary>
        /// 배송사아이디
        /// </summary>
        public string LogisticsCode { get; set; }

        /// <summary>
        /// 배송사명
        /// </summary>
        public string LogisticsName { get; set; }

        /// <summary>
        /// 송장번호
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 배송사 대표전화번호
        /// </summary>
        public string LogisticsTelephone { get; set; }

        /// <summary>
        /// 집화일자
        /// </summary>
        public string PickupDateTime { get; set; }

        /// <summary>
        /// 배달일자
        /// </summary>
        public string DlvDateTime { get; set; }

        /// <summary>
        /// 인수자
        /// </summary>
        public string Taker { get; set; }

        /// <summary>
        /// 상태(사이트)
        /// </summary>
        public string LastDlvStatName { get; set; }

        /// <summary>
        /// 상태정보(굿스플로)
        /// </summary> 
        public string LastDlvStatType { get; set; }

        /// <summary>
        /// 최종상태일시
        /// </summary>
        public string LastProcDateTime { get; set; }

        /// <summary>
        /// 보내는 분
        /// </summary> 
        public string SendName { get; set; }

        /// <summary>
        /// 받는 분
        /// </summary> 
        public string RecvName { get; set; }

        /// <summary>
        /// 상품명
        /// </summary> 
        public string ItemName { get; set; }

        /// <summary>
        /// 수량
        /// </summary> 
        public string ItemCount { get; set; }

        /// <summary>
        /// 받는분 전화번호1
        /// </summary> 
        public string RecvTel1 { get; set; }

        /// <summary>
        /// 받는분 전화번호2
        /// </summary> 
        public string RecvTel2 { get; set; }

        /// <summary>
        /// 보내는분전화번호
        /// </summary>
        public string FromTelephone { get; set; }

        /// <summary>
        /// 보내는분휴대폰번호
        /// </summary>
        public string FromMobile { get; set; }

        /// <summary>
        /// 받는분전화번호
        /// </summary>
        public string ToTelephone { get; set; }

        /// <summary>
        /// 받는분휴대폰번호
        /// </summary>
        public string ToMobile { get; set; }

        /// <summary>
        /// 받는분 우편번호
        /// </summary> 
        public string RecvZipcode { get; set; }

        /// <summary>
        /// 받는 주소1
        /// </summary> 
        public string RecvAddr1 { get; set; }

        /// <summary>
        /// 받는 주소2
        /// </summary>
        public string RecvAddr2 { get; set; }

        /// <summary>
        /// 주문일시
        /// </summary>
        public string OrderDateTime { get; set; }

        /// <summary>
        /// 주문번호
        /// </summary>
        
        public string OrderNo { get; set; }

        /// <summary>
        /// remark
        /// </summary>
        
        public string Remark { get; set; }

        /// <summary>
        /// 주문순번
        /// </summary>
        public int OrderLn { get; set; }

        /// <summary>
        /// 오류코드
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// 오류코드명
        /// </summary>
        //[XmlElementAttribute("ErrorTypeName")]
        public string ErrorTypeName { get; set; }

        //[XmlElementAttribute("TraceReqDateTime")]
        public string TraceReqDateTime { get; set; }


        
        //public string ItemUniqueCodeList { get; set; }

        /// <summary>
        /// 추가자료1
        /// </summary>
        
        public string Dummy1 { get; set; }

        /// <summary>
        /// 추가자료2
        /// </summary>
        
        public string Dummy2 { get; set; }

        /// <summary>
        /// 추가자료3
        /// </summary>
        
        public string Dummy3 { get; set; }

        /// <summary>
        /// 출발지국가코드
        /// </summary>
        public string OriginCountryCode { get; set; }

        /// <summary>
        /// 도착지국가코드
        /// </summary>
        public string DestinationCountryCode { get; set; }

        /// <summary>
        /// 해외발송여부
        /// </summary>
        public bool? FromAbroad { get; set; } = null;

        /// <summary>
        /// 저장 성공
        /// </summary>
        
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 기존 정보 무시하고 새로 저장
        /// </summary>
        
        public bool IsReset { get; set; }

        /// <summary>
        /// 오류 메시지
        /// </summary>
        
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 현재 오브젝트를 요청한 시간
        /// </summary>
        
        public string ObjectRequestDateTime { get; set; }


        /// <summary>
        /// 현재 오브젝트가 생성된 시간
        /// </summary>
        
        public string ObjectCreateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string ElapsedTimeDesc { get; set; }


        /// <summary>
        /// 종적 정보 리스트
        /// </summary>
         public List<TrackingResultDetail> Details { get; set; }

        // [JsonIgnore]
        // public List<ServerInfoBase> ServerInfo { get; set; }

    }
    
}