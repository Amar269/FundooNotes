using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ModelLayer.DTO.Label;
using ModelLayer.Entity;
using System.Security.Claims;
namespace fundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelControllers : ControllerBase

    {
        private readonly ILabelBLL _labelBLL;

        public LabelControllers (ILabelBLL labelBLL)
        {
            _labelBLL = labelBLL;   
        }



        [HttpPost("Create")]
        public IActionResult CreateLabel(CreateLabelRequest request)
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = _labelBLL.CreateLabel(userId, request);

            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult UpdateLabel(int labelId, UpdateLabelRequest request)
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = _labelBLL.UpdateLabel(labelId, userId, request);

            return Ok(result);
        }


        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult DeleteLabel(int labelId)
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = _labelBLL.DeleteLabel(labelId, userId);

            return Ok(result);
        }


        [HttpDelete("RemoveFromNote")]
        public IActionResult RemoveLabelFromNote(int noteId, int labelId)
        {
            int userId = Convert.ToInt32(
                User.FindFirst("UserId")?.Value);

            var result = _labelBLL.RemoveLabelFromNote(
                noteId,
                labelId,
                userId);

            return Ok(result);
        }
    }
}
