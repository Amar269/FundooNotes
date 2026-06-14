using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using DataBaseLayer.Migrations;
using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class NoteBLL : INoteBLL
    {
        private readonly INoteDAL _noteDAL;

        private readonly ICacheService _cacheService;

        public NoteBLL(INoteDAL noteDAL , ICacheService cacheService)
        {
            _noteDAL = noteDAL;
            _cacheService = cacheService;
        }

        public bool ArchiveNote(int noteId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }
            Notes note = _noteDAL.GetNoteById(noteId);
            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            note.IsArchive = true;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;


        }
        

        public bool ChangeColour(ChangeColourRequest changeColourRequest, int noteId)
        {
            if(noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }

            Notes note = _noteDAL.GetNoteById(noteId);

            if(note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            note.Colour = changeColourRequest.Colour;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;

        }
        

        public NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId)
        {

            if (string.IsNullOrEmpty(createNoteRequest.Title))
            {
                throw new ValidationException("Title Required");
            }

            var result =  _noteDAL.CreateNote(createNoteRequest, userId);
            _cacheService.RemoveCache($"Notes_{userId}");
            return result;

        }


        public List<NoteResponse> GetAllNotes(int userId)
        {
            string cacheKey = $"Notes_{userId}";

            string cachedData = _cacheService.GetCache(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<List<NoteResponse>>(cachedData) ?? new List<NoteResponse>();
            }

            var notes = _noteDAL.GetAllNotes(userId);

            string jsonData = JsonSerializer.Serialize(notes);

            _cacheService.SetCache(cacheKey, jsonData, 30);

            return notes;


            //return _noteDAL.GetAllNotes(userId);
        }

        public Notes GetNoteById(int noteId)
        {
            //throw new ValidationException("Testing Global Exception");
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }

            Notes note = _noteDAL.GetNoteById(noteId);

            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            return note;
        }

        public bool MoveToTrash(int noteId)
        {
            if(noteId<= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }
            Notes note = _noteDAL.GetNoteById(noteId);
            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            note.IsTrash = true;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;

        }

        public bool permanentDelete(int noteId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");

            }

            Notes note = _noteDAL.GetNoteById(noteId);
            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }
            note.IsPin = true;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.DeleteNote(note);
            _noteDAL.SaveChanges();
            
            return true;

        }

        public bool pinNote(int noteId)
        {
            if(noteId <=0)
            {
                throw new ValidationException("Invalid Note Id");

            }

            Notes note = _noteDAL.GetNoteById(noteId);
            if(note == null)
            {
                throw new NotFoundException("Note Not Found");
            }
            note.IsPin = true;
            note.UpdatedAt= DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;

        }

        public bool RestoreNote(int noteId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }
            Notes note = _noteDAL.GetNoteById(noteId);
            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            note.IsTrash = false;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;

        }

        public bool UnArchiveNote(int noteId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");
            }

            Notes note = _noteDAL.GetNoteById(noteId);

            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }

            note.IsArchive = false;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;

        }

        public bool UnpinNote(int noteId)
        {
            if (noteId <= 0)
            {
                throw new ValidationException("Invalid Note Id");

            }

            Notes note = _noteDAL.GetNoteById(noteId);
            if (note == null)
            {
                throw new NotFoundException("Note Not Found");
            }
            note.IsPin = false;
            note.UpdatedAt = DateTime.Now;

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");
            return true;
        }

        public NoteResponse UpdateNote(UpdateNoteRequest updateNoteRequest, int noteId)
        {
            if(noteId <= 0) 
            {
                throw new ValidationException("Invalid Note Id");
            }

            Notes note = _noteDAL.GetNoteById(noteId);
            if(note == null)
            {
                throw new NotFoundException("Note Not Found");
            }
            note.Title= updateNoteRequest.Title;
            note.Description = updateNoteRequest.Description;
            note.Reminder = updateNoteRequest.Reminder;
            note.Colour = updateNoteRequest.Colour;
            note.Image = updateNoteRequest.Image;
            note.UpdatedAt = DateTime.Now;
        

            _noteDAL.SaveChanges();
            _cacheService.RemoveCache($"Notes_{note.UserId}");


            return new NoteResponse
            {
                NotesId = note.NotesId,
                Title = note.Title,
                Description = note.Description,
                Reminder = note.Reminder,
                Colour = note.Colour,
                Image = note.Image,
                IsArchive = note.IsArchive,
                IsPin = note.IsPin,
                IsTrash = note.IsTrash,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                UserId = note.UserId

            };
            
        }
    }
}
