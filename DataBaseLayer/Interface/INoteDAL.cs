using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public  interface INoteDAL
    {
        NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId);

        List<NoteResponse>GetAllNotes(int userId);

         Notes GetNoteById(int noteId);
        



    }
}
