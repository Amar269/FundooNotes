using ModelLayer.DTO.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface ILabelDAL 
    {
        bool CreateLabel(int userId, CreateLabelRequest request);




    }
}
