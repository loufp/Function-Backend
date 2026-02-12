using Microsoft.AspNetCore.Mvc;

namespace ISpotify.Controller;

public class PrivateLibraryController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok();
    }
}