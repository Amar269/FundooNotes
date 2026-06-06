using ModelLayer.DTO.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public  interface ILabelBLL 
    {
        bool CreateLabel(int userId, CreateLabelRequest request); 

        



    }
}
