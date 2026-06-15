using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fundooNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBLL _collaboratorBLL;

        public CollaboratorController(ICollaboratorBLL collaboratorBLL)
        {
            _collaboratorBLL = collaboratorBLL;
        }

        [HttpPost("{noteId}/collaborators")]
        public IActionResult AddCollaborator(int noteId, string email)
        {
            try
            {
                int ownerUserId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

                var result = _collaboratorBLL.AddCollaborator(ownerUserId, noteId, email);

                return Ok(new
                {
                    Success = true,
                    Message = "Collaborator added successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }


        }

        [HttpGet("{noteId}/collaborators")]
        public IActionResult GetCollaborators(int noteId)
        {
            var result = _collaboratorBLL.GetCollaborators(noteId);

            return Ok(new
            {
                success = true,
                data = result
            });
        }








    }
}