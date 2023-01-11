namespace Gws.Common.Global
{
    public static class DBFunc
    {
        #region MSSQL-LAPS
        public const string usp_select_trace_info_by_member_code = "usp_select_trace_info_by_member_code_v2";
        public const string usp_zkm_select_tracking_info_by_invoice_no = "usp_v3_zkm_select_tracking_info_by_invoice_no";
        public const string usp_laps_select_tracking_info_by_invoice_no = "usp_v3_laps_select_tracking_info_by_invoice_no";
        #endregion
       
        #region POSTGRES-ZKM
        public const string usp_select_tracking_info = "usp_select_tracking_info";
        #endregion
        
        
    }
}