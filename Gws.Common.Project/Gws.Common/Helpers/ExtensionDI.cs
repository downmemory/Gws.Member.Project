using System.Reflection;
using Gws.Common.Enums;

namespace Gws.Common.Helpers
{
    #nullable disable
    public static class ExtensionDI
    {
         private static Dictionary<string, Type> _CurrentTypes = null;

        public static Dictionary<string, Type> CurrentTypes
        {
            get
            {
                if (_CurrentTypes == null)
                {
                    _CurrentTypes = Assembly.GetAssembly(typeof(ExtensionDI))
                        .GetTypes()
                        .ToDictionary(t => t.FullName, t => t, StringComparer.OrdinalIgnoreCase);
                }

                return _CurrentTypes;
            }
        }
         public static Type GetServiceType(this string clazzName)
        {
            const string DEF_PREFIX = "Gws.Common.Services.";

            if (!clazzName.Contains('.'))
                clazzName = DEF_PREFIX + clazzName.Trim();

            if (CurrentTypes.TryGetValue(clazzName, out Type type))
                return type;

            return null;
        }

         public static void AddDI(this IServiceCollection services, ServiceScope scope, string interfaceName, string implementName)
        {
            Type tInterface = interfaceName.GetServiceType();
            Type tClazz = implementName.GetServiceType();

            if (scope == ServiceScope.Singleton)
                services.AddSingleton(tInterface, tClazz);
            else if (scope == ServiceScope.Transient)
                services.AddTransient(tInterface, tClazz);
            else if (scope == ServiceScope.Scoped)
                services.AddScoped(tInterface, tClazz);
        }
    }
}