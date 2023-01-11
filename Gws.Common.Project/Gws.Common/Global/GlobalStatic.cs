using System.Net;
using System.Net.Http.Headers;
using Gws.Common.Services;

namespace Gws.Common.Global
{
    public class GlobalStatic
    {
        public const string DATE_FORMAT_DEFAULT = "yyyy-MM-dd HH:mm:ss";

        public const string GF_JWT_COOKIENAME = "goodsFLOW-Pf-JWT-enc";

        //HeaderNames.Authorization 대신 
        public const string GF_AUTH_HEADER_KEY = "gF-Authorization";

        public const string GF_API_KEY = "gF-Api-Key";

        //public const string API_KEY_LOGIN = "Web-Login";

        //public const string ITEM_LOGGING = "Logging-Data";

        public static readonly string[] LOCAL_IP = new string[] { "::1", "127.0.0.1" };

        public static readonly KeyValuePair<string, object> DefStringObject = default(KeyValuePair<string, object>);

        public const string ErrorDefault401 = "권한이 없거나 인증정보가 만료되었습니다.";

        public const string ErrorDefaultUnhandled = "Unhandled";

        public static DateTime OldDateTime = DateTime.Parse("2012-09-29"); //DateTime.MinValue 는 나중에 db 뻑남

         public static void Init()
        {
            System.Diagnostics.Debug.WriteLine("#####################################################");
            System.Diagnostics.Debug.WriteLine("############ GlobalStatic.Init() - Begin ############");
            System.Diagnostics.Debug.WriteLine("#####################################################");

            // 여기서 ini 설정을 기본적으로 불러 와야 할까?
            // ErrorDefines = ExtractAttribute<ApiErrorDefined, ApiErrorDefinedDeclareAttribute>();

            // AccountInfoEmty = new Dictionary<AccountInfoType, object>();
            // AccountInfoEmty.Add(AccountInfoType.goodsFLOWLink, new AccountInfoGoodsflow());
            // AccountInfoEmty.Add(AccountInfoType.WebHook, new AccountInfoWebHook());
            // AccountInfoEmty.Add(AccountInfoType.Notification, new AccountInfoNotification())
            // AccountInfoEmty.Add(AccountInfoType.LogisticsContract, new AccountInfoLogisticsContract {
            //     logisticscontract = new List<AccountInfoLogisticsContractItem> { new AccountInfoLogisticsContractItem() }
            // });

            System.Diagnostics.Debug.WriteLine("#####################################################");
            System.Diagnostics.Debug.WriteLine("############ GlobalStatic.Init() - End #############");
            System.Diagnostics.Debug.WriteLine("#####################################################");
        }

        public static string DateTimeDefaultNow
        {
            get
            {
                return DateTime.Now.ToString(DATE_FORMAT_DEFAULT);
            }
        }

         public static void DI(IServiceCollection services, GlobalAppConfig appConfig, bool isApi)
        {
            services.AddHttpContextAccessor();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            // foreach (var api in appConfig.ApiUrls)
            // {
            //     services.AddHttpClient(api.Key.ToString(), client =>
            //     {
            //         string url = api.Value;
            //         if (!url.EndsWith("/")) url += "/";
            //         client.BaseAddress = new Uri(url);
            //         //일단 JSON 만 받도록?
            //         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //     });
            // }

            // configure DI for application services
             _Handler.AddDI(services, isApi);
        }

    }
}