using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using ISpotify.DataBase;
using Microsoft.AspNetCore.Mvc;
using ISpotify.Models;
using Microsoft.EntityFrameworkCore;

namespace ISpotify.Controller;

[ApiController]
[Route("api/[controller]")]
public class SignupController : ControllerBase
{
    private readonly ILogger<SignupController> _logger;
    private readonly DBContext _context;

    public SignupController(ILogger<SignupController> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    // // // //
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] SignupRequest request)
    {

        var emailRegisterNow = await _context.SignupUsers
            .Where(i => request.Email == i.Email)
            .FirstOrDefaultAsync();
        
        if (emailRegisterNow != null)
        {
            
            _logger.LogInformation("Email {Email} is already registered", request.Email);
            return BadRequest((new {message ="Email is already registered"}));
        }
        
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new {message="Email and Password requires"});
        }

        if (string.IsNullOrEmpty(request.Username))
        {
            return BadRequest(new { message = "Username reqiures" });
        }
        
        // Отладочная информация
        _logger.LogInformation("Password: '{Password}', ConfirmPassword: '{ConfirmPassword}'", 
            request.Password, request.ConfirmPassword);
            
        if (string.IsNullOrEmpty(request.ConfirmPassword))
        {
            return BadRequest(new {message="ConfirmPassword is required"}); //
        }
        
        if (!string.Equals(request.Password, request.ConfirmPassword, StringComparison.Ordinal))
        {
            return BadRequest(new {message="Password and Confirm Password do not match"});
        }
        
        try
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Пользователь {Username} {Email}", request.Username, request.Email);
            return Ok(new {message="User registered successfully"});
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Error",ex.Message);
            return StatusCode(500);
        }
    }
}