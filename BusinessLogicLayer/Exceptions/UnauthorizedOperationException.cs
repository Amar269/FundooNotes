using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class UnauthorizedOperationException : Exception
    {
        public UnauthorizedOperationException(string message ) : base(message)
        {

        }
    }
}
