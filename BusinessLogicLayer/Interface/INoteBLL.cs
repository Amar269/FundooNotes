using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
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

        List<NoteResponse>GetAllNotes(int userId);

        Notes GetNoteById(int noteId);

        NoteResponse UpdateNote(UpdateNoteRequest updateNoteRequest , int noteId);

        bool MoveToTrash(int noteId);

        bool RestoreNote(int noteId);

        bool ArchiveNote(int noteId);




    }
}
