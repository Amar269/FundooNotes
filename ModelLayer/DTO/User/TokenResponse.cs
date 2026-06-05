using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.User
{
    public  class TokenResponse
    {
        public string Token { get; set; }

        public string Message { get; set; }

    }
}
