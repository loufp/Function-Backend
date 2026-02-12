using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ISpotify.Controller;


[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [HttpPost]
    public IActionResult Index()
    {
        return Ok();
    }
}