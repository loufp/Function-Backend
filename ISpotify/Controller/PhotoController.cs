using System.Data.Entity;
using System.Data.Entity.Infrastructure.Design;
using ISpotify.DataBase;
using ISpotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISpotify.Controller;

[ApiController]
[Route("api/[controller]")]
public class PhotoAvatarController : ControllerBase
{
    
    private readonly DBContext _context;

    public PhotoAvatarController(DBContext context)
    {
        _context = context;
    }
    
    [HttpPost("upload-photo")]
    public async Task<IActionResult> DPhoto(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }
        var userValid = await _context.SignupUsers.AnyAsync(u => u.Email == User.Identity.Name);
        
        if (!userValid)
        {
            return BadRequest("User not found");
        }
        
        var uploads= Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        
        if (!Directory.Exists(uploads))
        {
            Directory.CreateDirectory(uploads);
        }
        
        var dowlPhoto = Path.Combine(uploads, file.FileName);

        using (var stream = new FileStream(dowlPhoto, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        
        var photo = new Photo
        {
            DowlandPhoto = fileName,
            PathPhoto = dowlPhoto,
            TimeDowland = DateTime.UtcNow,
            UserId = userId
        };
        
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();
        
        return Ok(new {filename = file.FileName});
    }

    public async Task<IActionResult> GetPhoto(int userId)
    {

        var photo = await _context.Photos
            ;
    }
    
    
    private string GetContentType(string fileName)
    {
        var extension = Path.GetExtension(fileName.ToLowerInvariant());
        
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _ => "application/octet-stream"
        };
    }
}