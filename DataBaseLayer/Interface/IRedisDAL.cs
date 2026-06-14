using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface IRedisDAL
    {
        void SetData(string key, string value , int expiryMinutes);
        string GetData(string key);
        long? GetTTL(string key);


        
    }
}
