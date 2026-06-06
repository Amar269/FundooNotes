using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Notes;
using System.Security.Claims;

namespace fundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                var result = _noteBLL.GetNoteById(noteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("Update/{noteId}")]

        public IActionResult UpdateNote(int noteId, UpdateNoteRequest updateNoteRequest)
        {
            try
            {
                var result = _noteBLL.UpdateNote(updateNoteRequest, noteId);
                {
                    return Ok(result);

                }
            }
            catch (Exception ex)
            {
                return BadRequest("ex.Message");
            }
        }


        [HttpDelete("Trash/{noteId}")]
        public IActionResult MoveTrash(int noteId)
        {
            try
            {
                bool result = _noteBLL.MoveToTrash(noteId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("Restore/{noteId}")]
        public IActionResult RestoreNote(int noteId)
        {
            try
            {
                bool result = _noteBLL.RestoreNote(noteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        

    }
}