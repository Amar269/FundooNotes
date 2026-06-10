
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace fundooNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisController : ControllerBase
    {
        private readonly IRedisBLL _redisBLL;
        public RedisController(IRedisBLL redisBLL)
        {
            _redisBLL = redisBLL;
        }

        [HttpPost("set")]
        public IActionResult SetData(string key, string value)
        {
            _redisBLL.SetData(key, value);
            return Ok("Data stored in Redis");
        }

        [HttpGet("get")]
        public IActionResult GetData(string key)
        {
            var result = _redisBLL.GetData(key);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound("Key not found");
            }

            return Ok(result);

        }



    }
}
