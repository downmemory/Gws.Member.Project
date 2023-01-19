using Microsoft.AspNetCore.Mvc;
using Gws.Common;
using Gws.Common.Services;
using Gws.Common.Models;
using Gws.Common.Controllers;
using Gws.Common.Models.Track;
using Gws.Common.Models.Response;
using Gws.Common.Models.Meta;

namespace Gws.Member.Api.Zkm.Controllers;
#nullable disable

[ApiController]
[Route("tracking")]
public class TrackingController : _ApiControllerBase
{
    private string ClientIP {get { return HttpContext.Connection.RemoteIpAddress.ToString(); }}
    private string ApiKey {get { return HttpContext.Request.Query["goodsFLOW-Api-Key"].ToString(); }}
    
    private readonly ILogger<TrackingController> _logger;
    private readonly ITrackingService _tracking;
    private readonly IAuthService _auth;
    private readonly IHttpContextAccessor _context;
    private readonly IMemberService _member;


     public TrackingController(ITrackingService tracking, IAuthService auth, ILogger<TrackingController> logger, IHttpContextAccessor context, IMemberService member) //  
    {
        _tracking = tracking;
        _logger = logger;
        _auth = auth;
        _context = context;
        _member = member;
    }

    [HttpGet("v1/trace/{memberCode}/{param1}/{param2}")]
     public IActionResult Tracking(string memberCode, string param1, string param2, string param3) => this.CreateResult(GetTracking(memberCode, param1, param2, param3));

    [HttpGet("v1/where/{memberCode}")]
    public IActionResult Where(string memberCode) => this.CreateResult(GetWhere(memberCode));
    private TrackingResultInfo GetTracking(string memberCode, string param1, string param2, string param3)
    {
        TrackingResultInfo retVal = null;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        ApiError error = new ApiError();
        string apiKey = _context.HttpContext.Request.Headers["goodsFLOW-Api-Key"];
        string clientIp = _context.HttpContext.Connection.RemoteIpAddress.ToString();

        if(string.IsNullOrEmpty(memberCode) == false){
            
            MemberInfo memberInfo = _member.GetMemberInfo(memberCode, true);
            if(memberInfo != null)
            {
                _auth.SetMemberInfo(memberInfo);
                if(_auth.CheckAuth(apiKey, methodName, clientIp, ref error) == true)
                {
                    retVal = _tracking.GetTracking(memberInfo, param1, param2, param3, false);
                }
            }
        }
        else
        {
            Console.WriteLine("멤버코드를 입력 해야지.");
        }
       
        
        return retVal;
    }

    private string GetWhere(string memberCode)
    {
        string retVal = string.Empty;
        return retVal;
    }
}
