using System.Collections;
using Gws.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gws.Common.Controllers
{
    #nullable disable
    public class _ApiControllerBase : ControllerBase
    {   
        protected IActionResult CreateResult()
        {
            return this.StatusCode(200);
        }

        protected IActionResult CreateResult(object data)
        {
            if(data == null)
            {
                return this.StatusCode(200, new ApiResponse());
            }
            else if (data is ResponseDefault)
            {
                return this.StatusCode(200, data);
            }
            else
            {
                // if(data is ICollection collection)
                // {
                //     return this.StatusCode(200, new ResponseDefaultTotalCount(data, collection.Count));
                // }
                // else if(!(data is string) && data is IEnumerable enumerable)
                // {
                //     long count = 0;
                //     foreach (object val in enumerable) count++;
                //     return this.StatusCode(200, new ResponseDefaultTotalCount(data, count));
                // }

                
                return this.StatusCode(200, new ApiResponseWithData(data));
            }
        }

       
    }
}