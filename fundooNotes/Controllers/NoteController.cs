using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ModelLayer.DTO.Notes;
using System.Security.Claims;

namespace fundooNotes.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBLL _noteBLL;

        public NoteController(INoteBLL noteBLL)
        {
            _noteBLL = noteBLL;


        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult CreateNote(CreateNoteRequest createNoteRequest)
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = _noteBLL.CreateNote(
                createNoteRequest,
                userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAllNotes()
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            var result = _noteBLL.GetAllNotes(userId);
            return Ok(result);
        }

        [HttpGet("GetID/{noteId}")]
        public IActionResult GetNoteById(int noteId)
        {
            var result = _noteBLL.GetNoteById(noteId);
             return Ok(result);
            //try
            //{
            //    var result = _noteBLL.GetNoteById(noteId);
            //    return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);

            //}
        }

        [HttpPut("Update/{noteId}")]

        public IActionResult UpdateNote(int noteId, UpdateNoteRequest updateNoteRequest)
        {
            var result = _noteBLL.UpdateNote(updateNoteRequest, noteId);
            {
                return Ok(result);

            }
        }


        [HttpDelete("Trash/{noteId}")]
        public IActionResult MoveTrash(int noteId)
        {
            bool result = _noteBLL.MoveToTrash(noteId);
            return Ok(result);
        }


        [HttpPut("Restore/{noteId}")]
        public IActionResult RestoreNote(int noteId)
        {
            bool result = _noteBLL.RestoreNote(noteId);
            return Ok(result);

        }

        [HttpPut("Archive/{noteId}")]
        public IActionResult ArchiveNote(int noteId)
        {
            bool result = _noteBLL.ArchiveNote(noteId);
            return Ok(result);
        }

        [HttpPut("UnArchive/{noteId}")]
        public IActionResult UnArchiveNote(int noteId)
        {
            bool result = _noteBLL.UnArchiveNote(noteId);
            return Ok(result);

        }

        [HttpPut("Pin/{noteId}")]
        public IActionResult PinNote(int noteId)
        {
            bool result = _noteBLL.pinNote(noteId);
            return Ok(result);

        }

        [HttpPut("UnPin/{noteId}")]
        public IActionResult UnpinNote(int noteId)
        {
            bool result = _noteBLL.UnpinNote(noteId);
            return Ok(result);
            

        }


        [HttpDelete("Delete/{noteId}")]
        public IActionResult PermanentDelete(int noteId)
        {
                bool result = _noteBLL.permanentDelete(noteId);
                return Ok(result);
           
            
        }


        [HttpPut("Colour/{noteId}")]
        public IActionResult ChangeColour(int noteId, ChangeColourRequest changeColourRequest)
        {
            
                bool result = _noteBLL.ChangeColour(changeColourRequest, noteId);
                return Ok(result);
        }
        















    }
}
