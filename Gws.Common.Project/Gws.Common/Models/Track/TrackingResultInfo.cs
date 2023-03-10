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


                //???????????? ?????? SMS-20220510
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
        /// ??????????????????
        /// </summary>
        public string LogisticsCode { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string LogisticsName { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// ????????? ??????????????????
        /// </summary>
        public string LogisticsTelephone { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string PickupDateTime { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string DlvDateTime { get; set; }

        /// <summary>
        /// ?????????
        /// </summary>
        public string Taker { get; set; }

        /// <summary>
        /// ??????(?????????)
        /// </summary>
        public string LastDlvStatName { get; set; }

        /// <summary>
        /// ????????????(????????????)
        /// </summary> 
        public string LastDlvStatType { get; set; }

        /// <summary>
        /// ??????????????????
        /// </summary>
        public string LastProcDateTime { get; set; }

        /// <summary>
        /// ????????? ???
        /// </summary> 
        public string SendName { get; set; }

        /// <summary>
        /// ?????? ???
        /// </summary> 
        public string RecvName { get; set; }

        /// <summary>
        /// ?????????
        /// </summary> 
        public string ItemName { get; set; }

        /// <summary>
        /// ??????
        /// </summary> 
        public string ItemCount { get; set; }

        /// <summary>
        /// ????????? ????????????1
        /// </summary> 
        public string RecvTel1 { get; set; }

        /// <summary>
        /// ????????? ????????????2
        /// </summary> 
        public string RecvTel2 { get; set; }

        /// <summary>
        /// ????????????????????????
        /// </summary>
        public string FromTelephone { get; set; }

        /// <summary>
        /// ???????????????????????????
        /// </summary>
        public string FromMobile { get; set; }

        /// <summary>
        /// ?????????????????????
        /// </summary>
        public string ToTelephone { get; set; }

        /// <summary>
        /// ????????????????????????
        /// </summary>
        public string ToMobile { get; set; }

        /// <summary>
        /// ????????? ????????????
        /// </summary> 
        public string RecvZipcode { get; set; }

        /// <summary>
        /// ?????? ??????1
        /// </summary> 
        public string RecvAddr1 { get; set; }

        /// <summary>
        /// ?????? ??????2
        /// </summary>
        public string RecvAddr2 { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string OrderDateTime { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        
        public string OrderNo { get; set; }

        /// <summary>
        /// remark
        /// </summary>
        
        public string Remark { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public int OrderLn { get; set; }

        /// <summary>
        /// ????????????
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// ???????????????
        /// </summary>
        //[XmlElementAttribute("ErrorTypeName")]
        public string ErrorTypeName { get; set; }

        //[XmlElementAttribute("TraceReqDateTime")]
        public string TraceReqDateTime { get; set; }


        
        //public string ItemUniqueCodeList { get; set; }

        /// <summary>
        /// ????????????1
        /// </summary>
        
        public string Dummy1 { get; set; }

        /// <summary>
        /// ????????????2
        /// </summary>
        
        public string Dummy2 { get; set; }

        /// <summary>
        /// ????????????3
        /// </summary>
        
        public string Dummy3 { get; set; }

        /// <summary>
        /// ?????????????????????
        /// </summary>
        public string OriginCountryCode { get; set; }

        /// <summary>
        /// ?????????????????????
        /// </summary>
        public string DestinationCountryCode { get; set; }

        /// <summary>
        /// ??????????????????
        /// </summary>
        public bool? FromAbroad { get; set; } = null;

        /// <summary>
        /// ?????? ??????
        /// </summary>
        
        public bool IsSuccess { get; set; }

        /// <summary>
        /// ?????? ?????? ???????????? ?????? ??????
        /// </summary>
        
        public bool IsReset { get; set; }

        /// <summary>
        /// ?????? ?????????
        /// </summary>
        
        public string ErrorMsg { get; set; }

        /// <summary>
        /// ?????? ??????????????? ????????? ??????
        /// </summary>
        
        public string ObjectRequestDateTime { get; set; }


        /// <summary>
        /// ?????? ??????????????? ????????? ??????
        /// </summary>
        
        public string ObjectCreateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string ElapsedTimeDesc { get; set; }


        /// <summary>
        /// ?????? ?????? ?????????
        /// </summary>
         public List<TrackingResultDetail> Details { get; set; }

        // [JsonIgnore]
        // public List<ServerInfoBase> ServerInfo { get; set; }

    }
    
}