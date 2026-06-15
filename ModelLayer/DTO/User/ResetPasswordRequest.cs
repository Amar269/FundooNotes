using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.User
{
    public  class ResetPasswordRequest
    {
        public string NewPassword { get; set; }

        public string ConfirmPassword{get; set;}


    }
}
