using ISpotify.DataBase;
using ISpotify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISpotify.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    
    private readonly ILogger<LoginController> _logger;
    private readonly DBContext _context;

    public LoginController(ILogger<LoginController> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Email))
        {
            return BadRequest(new {message="Email and Password are required"});
        }

        var user = await _context.SignupUsers
            .Where(u => u.Email == request.Email && u.Password == request.Password)
            .FirstOrDefaultAsync();
        if (ModelState.IsValid && user!=null)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Пользователь {Email} прошел проверку ,допущен",request.Email);
        }
        _logger.LogInformation("\n Login Successful {Email}",request.Email);
        return Ok(new {message = "Login Successful"});
    }
}

