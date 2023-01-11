using System.Data;
using System.Text.Json.Serialization;

namespace Gws.Common.Models.Meta
{
    #nullable disable
    public class MetadataBase
    {
        public DateTime? CreateDateTime { get; set; } //timestamp without time zone
        public DateTime? UpdateDateTime { get; set; } //timestamp without time zone
        public int? CreateUserId { get; set; }  //integer
        public int? UpdateUserId { get; set; }  //integer
        public string CreateIp { get; set; }   //character varying(30)
        public string UpdateIp { get; set; }	//character varying(30)

        [JsonIgnore]
        public DateTime ObjectLoadDateTime { get; set; }


        public static void SetBaseData(MetadataBase value, DataRow row)
        {
            
            if (row != null)
            {
                if (row.Table.Columns.Contains("created_at") == true)
                {
                    value.CreateDateTime = row.Field<DateTime?>("created_at");
                }
                else
                {
                    value.CreateDateTime = row.Field<DateTime?>("create_datetime");
                }

                if (row.Table.Columns.Contains("updated_at") == true)
                {
                    value.UpdateDateTime = row.Field<DateTime?>("updated_at");
                }
                else
                {
                    value.UpdateDateTime = row.Field<DateTime?>("update_datetime");
                }


                value.CreateUserId = row.Field<int?>("create_user_id");
                value.UpdateUserId = row.Field<int?>("update_user_id");

                value.CreateIp = row.Field<string>("create_ip");
                value.UpdateIp = row.Field<string>("update_ip");

            }
        }
    }
}
