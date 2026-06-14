using BusinessLogicLayer.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _database;

        public CacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public string GetCache(string key)
        {
            return _database.StringGet(key);
        }

        public void RemoveCache(string key)
        {
            _database.KeyDelete(key);
        }

        public void SetCache(string key, string value, int expiryMinutes)
        {
            _database.StringSet(key, value, TimeSpan.FromMinutes(expiryMinutes));
        }
    }
}
