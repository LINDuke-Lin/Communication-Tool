
using Microsoft.Extensions.Caching.Distributed;

namespace Communication.Redis.Services
{
    public class ConnectService
    {
        public readonly IDistributedCache _distributedCache;

        public ConnectService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<bool> Set(string key,string value)
        {
            await _distributedCache.SetStringAsync(key,value);
            return true;
        }

        public async Task<string> Get(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }
    }
}
