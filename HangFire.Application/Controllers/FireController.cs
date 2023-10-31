using HangFire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireController : ControllerBase
    {
        private readonly IHangService _hangService;

        public FireController(IHangService hangService)
        {
            _hangService = hangService;
        }

        [HttpGet("")]
        public async Task<IActionResult> FireEndForget()
        {
            await _hangService.FireAndForge();

            return Ok();
        }

        [HttpGet("schedule")]
        public async Task<IActionResult> FireEndForget([FromQuery] int minutos)
        {
            await _hangService.FireSchedule(minutos);

            return Ok();
        }
    }
}
