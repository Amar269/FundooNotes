using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public  interface IRedisBLL
    {
        void SetData(string key, string value , int expiryMinutes);
        string GetData(string key);

        long? GetTTL(string key);

    }
}
