namespace Gws.Common.Models.Response
{
    public class ApiErrorStatus
    {
        /// <summary>
        /// 성공 (HttpStatusCode.OK 에 해당)
        /// </summary>
        public static int Success = 200;

        /// <summary>
        /// 성공 - 컨턴츠 없음(HttpStatusCode.NoContent)
        /// </summary>
        public static int NoContent = 204;

        /// <summary>
        /// 서버에서 요청을 인식할 수 없는 경우에 표시 (HttpStatusCode.BadRequest 에 해당)
        /// </summary>
        public static int RequestError = 400;

        /// <summary>
        /// 리소스에 인증이 필요한 경우에 표시 (HttpStatusCode.Unauthorized 에 해당)
        /// </summary>
        public static int Unauthorized = 401;

        /// <summary>
        /// 일반 오류 (HttpStatusCode.InternalServerError 에 해당)
        /// </summary>
        public static int ResponseError = 500;

        /// <summary>
        /// 오류(구현되지 않음) (HttpStatusCode.NotImplemented 에 해당)
        /// </summary>
        public static int ResponseNotImplemented = 501;
    }

    public class ApiErrorStatusName
    {
        /// <summary>
        /// 성공 (HttpStatusCode.OK 에 해당)
        /// </summary>
        public static string Success = "성공";

        /// <summary>
        /// 성공 - 컨턴츠 없음(HttpStatusCode.NoContent)
        /// </summary>
        public static string NoContent = "컨텐츠 없음";

        /// <summary>
        /// 서버에서 요청을 인식할 수 없는 경우에 표시 (HttpStatusCode.BadRequest 에 해당)
        /// </summary>
        public static string RequestError = "서버에서 요청을 처리할 수 없음";

        /// <summary>
        /// 리소스에 인증이 필요한 경우에 표시 (HttpStatusCode.Unauthorized 에 해당)
        /// </summary>
        public static string Unauthorized = "리소스에 인증이 필요함";

        /// <summary>
        /// 일반 오류 (HttpStatusCode.InternalServerError 에 해당)
        /// </summary>
        public static string ResponseError = "일반 오류";

        /// <summary>
        /// 오류(구현되지 않음) (HttpStatusCode.NotImplemented 에 해당)
        /// </summary>
        public static string ResponseNotImplemented = "오류(구현되지 않음)";

        public static string GetName(int status)
        {
            string retVal = Success;

            switch (status)
            {
                //ApiErrorStatus.Success
                case 200 :
                    retVal = Success;
                    break;
                //ApiErrorStatus.NoContent
                case 204:
                    retVal = NoContent;
                    break;
                //ApiErrorStatus.RequestError
                case 400:
                    retVal = RequestError;
                    break;
                //ApiErrorStatus.Unauthorized
                case 401:
                    retVal = Unauthorized;
                    break;
                //ApiErrorStatus.ResponseError
                case 500:
                    retVal = ResponseError;
                    break;
                //ApiErrorStatus.ResponseNotImplemented
                case 501:
                    retVal = ResponseNotImplemented;
                    break;
                default:
                    break;
            }

            return retVal;
        }
    }
}