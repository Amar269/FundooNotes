
using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ModelLayer.DTO.Notes;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public  class NoteDAL : INoteDAL
    {
        private readonly UserDbContext _dbContext;
        public NoteDAL(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public NoteResponse CreateNote(CreateNoteRequest createNoteRequest, int userId)
        {
            Notes note = new Notes()
            {
                Title = createNoteRequest.Title,
                Description = createNoteRequest.Description,
                Reminder = createNoteRequest.Reminder,
                Colour = createNoteRequest.Colour,
                Image = createNoteRequest.Image,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();

            return new NoteResponse()
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

       
        public List<NoteResponse> GetAllNotes(int userId)
        {
            var notes = _dbContext.Notes
               .Where(n => n.UserId == userId && !n.IsTrash)// only active notes are shown 
               .Select(n => new NoteResponse
               {
                   NotesId = n.NotesId,
                   Title = n.Title,
                   Description = n.Description,
                   Reminder = n.Reminder,
                   Colour = n.Colour,
                   Image = n.Image,
                   IsArchive = n.IsArchive,
                   IsPin = n.IsPin,
                   IsTrash = n.IsTrash,
                   CreatedAt = n.CreatedAt,
                   UpdatedAt = n.UpdatedAt,
                   UserId = n.UserId

               }).ToList();

            return notes;

        }

        public Notes GetNoteById(int noteId)
        {
            return _dbContext.Notes.FirstOrDefault(n => n.NotesId == noteId && !n.IsTrash);

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
