using ModelLayer.DTO.Notes;
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



    }
}
