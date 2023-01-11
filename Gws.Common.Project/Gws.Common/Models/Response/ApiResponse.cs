namespace Gws.Common.Models.Response
{
    #nullable disable
    public class ApiResponseBase
    {
        public bool Success { get; set; }   
        public string Context { get; set; }    

        public ApiResponseBase()
        {
            Success = false;
        }
    }
    
    public class ApiResponse : ApiResponseBase
    {
        public ApiError Error { get; set; }
        public ApiResponse() : base()
        {
            Error = new ApiError();
        }
    }

    public class ApiResponse<T> : ApiResponseBase
    {
        public ApiResponse()
            : base()
        {
            Error = new ApiError<T>();
        }
        public ApiError<T> Error { get; set; }
    }

    public class ApiResponseWithData : ApiResponse
    {
        public ApiResponseWithData(object pData)
            : base()
        {
            // Data = default(T);
            Data = pData;
            base.Success = true;
        }
        public object Data { get; set; }
    }
}