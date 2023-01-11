using Gws.Common.Helpers;

namespace Gws.Common.Services
{
    public class _Handler
    {
        internal static void AddDI(IServiceCollection services, bool isWeb)
        {
            services.AddDI(Enums.ServiceScope.Singleton, "ISysService", "SysService");
            services.AddDI(Enums.ServiceScope.Scoped, "IAuthService", "AuthService");
            services.AddDI(Enums.ServiceScope.Scoped, "ITrackingService", "TrackingService");
            services.AddDI(Enums.ServiceScope.Scoped, "IMemberService", "MemberService");
            services.AddDI(Enums.ServiceScope.Scoped, "ILoggingService", "LoggingService");
            //test
        }
    }
}