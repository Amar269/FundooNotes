using BusinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class NoteBLL : INoteBLL
    {
        private readonly INoteDAL _noteDAL;

        public NoteBLL(INoteDAL noteDAL)
        {
            _noteDAL = noteDAL;
        }

        public NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId)
        {
            if (string.IsNullOrEmpty(createNoteRequest.Title))
            {
                throw new Exception("Title Required");
            }

            return _noteDAL.CreateNote(createNoteRequest, userId);

        }
    }
}
