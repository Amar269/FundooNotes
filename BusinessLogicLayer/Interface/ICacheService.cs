using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
     public interface ICacheService
     {
        void SetCache(string key, string value, int expiryMinutes);

        string GetCache(string key);

        void RemoveCache(string key);
     }
}
