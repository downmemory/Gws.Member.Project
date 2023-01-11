using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

namespace Gws.Common.Services
{

    public interface IMemCacheService
    {
        MemberInfo GetMemberInfo(string memberCode, bool isUse);
    }
    public class MemCacheService : IMemCacheService
    {
        private readonly IMemoryCache _memcache;
        
        private readonly IMemberService _member;

        public MemCacheService(IMemoryCache memcache, IMemberService member)
        {
            _memcache = memcache;
            _member = member;
        }

       

        MemberInfo IMemCacheService.GetMemberInfo(string memberCode, bool isUse)
        {
            throw new NotImplementedException();
        }
    }
}