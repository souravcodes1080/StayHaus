using Backend.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetApp()
        {
            // throw new Exception("This is a custom exception for testing");
            return Ok(new ApiResponse<Array>(true, "API is running.", null));
        }
    }
}