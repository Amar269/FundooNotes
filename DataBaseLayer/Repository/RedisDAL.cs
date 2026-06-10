using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer.Interface;
using StackExchange.Redis;

namespace DataBaseLayer.Repository
{
    public class RedisDAL : IRedisDAL
    {
        private readonly IDatabase _databse;

        public RedisDAL(IConnectionMultiplexer  redis)
        {
            _databse = redis.GetDatabase();
        }


        public string GetData(string key)
        {
           return  _databse.StringGet(key);
        }

        public void SetData(string key, string value)
        {
            _databse.StringSet(key, value);

        }
    }
}
