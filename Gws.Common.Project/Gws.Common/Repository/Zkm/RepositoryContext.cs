using System.Collections.Concurrent;

namespace Gws.Common.Repository.Zkm
{
    public class RepositoryContext
    {
        public static string DEFAULT_INSTANCE_NAME = "zkmapi";
        public static string INSTANCE_NAME = "ZkmApi";

        private static ConcurrentDictionary<string, object> _context = null;

        public static void Initialize()
        {
            // string logDir = Path.Combine()
            string test = "";
            string logFileName = "ZkmApi.log";

            _context = new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            
        }
    }
}