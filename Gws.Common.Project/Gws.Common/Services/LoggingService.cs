using System.Diagnostics;
using System.Net;
using Gws.Common.Models.Meta;
using Gws.Common.Models.Response;
using Gws.Common.Utils;
using NLog;

namespace Gws.Common.Services
{
    public interface ILoggingService
    {
        NLog.Logger NLogger { get; }

        void NDebug(string message);

        void NInfo(string message);

        void NWarn(string message);

        void NError(string message);

        void NError(Exception ex, string message = null);

    }

    public class LoggingService : ILoggingService
    {
        private readonly NLog.Logger _nLogger;
        private readonly ISysService _system;

        public LoggingService(ISysService system)
        {
            _system = system;
            
            NLog.LogManager.AutoShutdown = true;
            var nlogConfig = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config");
            var assembly = System.Reflection.Assembly.GetEntryAssembly();

            // if(assembly.GetName().Name == "Gws.Member.Api.Zkm")
            // {
            //     _nLogger = nlogConfig.GetLogger("Api");
            // }
            _nLogger = nlogConfig.GetLogger(assembly.GetName().Name);
        }
        
        
        #region NLogger
        public NLog.Logger NLogger { get => this._nLogger; }
        public void NDebug(string message) => NLogger.Debug(ClassAndMethod() + message);

        public void NInfo(string message) => NLogger.Info(ClassAndMethod() + message);

        public void NWarn(string message) => NLogger.Warn(ClassAndMethod() + message);

        public void NError(string message) => NLogger.Error(ClassAndMethod() + message);
        #endregion

        private string ClassAndMethod()
        {
            var mth = new StackTrace().GetFrame(2).GetMethod();
            var cls = mth.ReflectedType.Name;

            return $"{cls}::{mth.Name}|";
        }

        public void NError(Exception ex, string message = null)
        {
            if (message == null)
                message = string.Empty;

            NLogger.Error(ex, ClassAndMethod() + message);
        }
    }


}