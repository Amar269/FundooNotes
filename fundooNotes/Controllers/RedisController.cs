
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fundooNotes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RedisController : ControllerBase
    {
        private readonly IRedisBLL _redisBLL;
        private readonly ICacheService _cacheService;
        public RedisController(IRedisBLL redisBLL  , ICacheService cacheService)
        {
            _redisBLL = redisBLL;
            _cacheService = cacheService;
        }

        [HttpPost("set")]
        public IActionResult SetData(string key, string value , int expiryMinutes)
        {
            _redisBLL.SetData(key, value , expiryMinutes);
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

        [HttpGet("ttl")]
        public IActionResult GetTTl(string key)
        {
            var ttl = _redisBLL.GetTTL(key); 

            if(ttl == null)
            {
                return NotFound("key not found");
            }

            return Ok($"Redming TLL : {ttl} seconds");
        }

        [HttpPost("cache/set")]
        public IActionResult SetCache()
        {
            _cacheService.SetCache(
                "TestUser",
                "Amarnath",
                30);

            return Ok("Cache Stored");
        }

        [HttpGet("cache/get")]
        public IActionResult GetCache()
        {
            var result = _cacheService.GetCache("TestUser");

            return Ok(result);
        }

        [HttpDelete("cache/remove")]
        public IActionResult RemoveCache()
        {
            _cacheService.RemoveCache("TestUser");

            return Ok("Cache Removed");
        }





    }
}
