using Microsoft.AspNetCore.Mvc;

namespace ISpotify.Controller;

[ApiController]
[Route("api/[controller]")]
public class CoreMainPageController : ControllerBase
{
    [HttpGet]
    public IActionResult MainPage()
    {
        return Ok();
    }
}