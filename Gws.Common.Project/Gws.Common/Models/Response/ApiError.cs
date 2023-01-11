namespace Gws.Common.Models.Response
{
    #nullable disable
    public class ApiError
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string DetailMessage { get; set; }
        public ApiError()
        {
            Status = ApiErrorStatus.Success;
            Message = ApiErrorStatusName.Success;
        }
    }

    public class ApiError<T> : ApiError
    {
        public ApiError()
        {
            Details = default(T);
        }
        public T Details { get; set; }
    }
}