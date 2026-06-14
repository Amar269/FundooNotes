using BusinessLogicLayer.Exceptions;
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
                throw new ValidationException("Label name cannot be empty.");
                
            }

            return _labelDAL.CreateLabel(userId, request);

        }

        public bool DeleteLabel(int labelId, int userId)
        {
            if (labelId <= 0)
            {
                throw new ValidationException("Invalid Label Id");
            }

            return _labelDAL.DeleteLabel(labelId, userId);
        }

        public bool RemoveLabelFromNote(int noteId, int labelId, int userId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }

            if (labelId <= 0)
            {
                throw new ValidationException("Invalid Label Id");
            }

            return _labelDAL.RemoveLabelFromNote(noteId, labelId, userId);
        }

        public bool UpdateLabel(int labelId, int userId, UpdateLabelRequest request)
        {
            if (labelId <= 0)
            {
                throw new ValidationException("Invalid Label Id");
            }

            if (string.IsNullOrWhiteSpace(request.LabelName))
            {
                throw new ValidationException("Label Name Cannot Be Empty");
            }

            return _labelDAL.UpdateLabel(labelId, userId, request);

        }
    }
}
