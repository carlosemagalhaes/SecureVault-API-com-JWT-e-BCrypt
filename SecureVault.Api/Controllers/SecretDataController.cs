using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SecureVault.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecretDataController : Controller
    {
        [HttpGet("info")]
        [Authorize]
        public IActionResult GetInfo() => Ok("Informações basicas para todos.");

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult ResetSystem()
        {
            return Ok("SISTEMA REINICIADO PELO ADMINISTRADOR");
        }
    }
}
