using BusinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class LabelBLL : ILabelBLL

    {
        public readonly ILabelDAL _labelDAL;

        public LabelBLL(ILabelDAL labelDAL)
        {
            _labelDAL = labelDAL;
        }

        public bool CreateLabel(int userId, CreateLabelRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.LabelName))
            {
                throw new Exception("Label name cannot be empty.");
            }

            return _labelDAL.CreateLabel(userId, request);

        }
    }
}
