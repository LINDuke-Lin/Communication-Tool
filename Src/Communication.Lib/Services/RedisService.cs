using Communication.Redis.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Communication.Lib.Services
{
    public interface IRedisService
    {
        bool Set(string key, object data);

        T Get<T>(string key) where T : class;
    }

    public class RedisService : IRedisService
    {
        private const string keyHead = "thisResids";

        private readonly ConnectService connectService;

        public RedisService(IDistributedCache distributedCache)
        {
            connectService = new ConnectService(distributedCache);
        }

        public T Get<T>(string key) where T : class
        {
            string jsonData = connectService.Get(key).Result;
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public bool Set(string key, object data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            return connectService.Set(key, jsonData).Result;
        }
    }
}
