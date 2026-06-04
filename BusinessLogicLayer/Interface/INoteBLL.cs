using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface INoteBLL
    {
        NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId);

    }
}
