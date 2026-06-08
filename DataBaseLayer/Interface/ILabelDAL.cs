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

        bool UpdateLabel(int labelId, int userId, UpdateLabelRequest request);

        bool DeleteLabel(int labelId, int userId);

        bool RemoveLabelFromNote(int noteId, int labelId, int userId);





    }
}
