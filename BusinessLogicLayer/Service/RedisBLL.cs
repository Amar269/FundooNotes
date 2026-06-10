using BusinessLogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer.Interface;
namespace BusinessLogicLayer.Service
{
    public class RedisBLL : IRedisBLL
    {
        public readonly IRedisDAL _redisDAL;

        public RedisBLL(IRedisDAL redisDAL)
        {
            _redisDAL = redisDAL;
        }
        public string GetData(string key)
        {
            return _redisDAL.GetData(key);
        }

        public void SetData(string key, string value)
        {
            _redisDAL.SetData(key, value);
        }
    }
}
