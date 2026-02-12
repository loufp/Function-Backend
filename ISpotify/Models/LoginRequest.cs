using System.ComponentModel.DataAnnotations;

namespace ISpotify.Models;

public class LoginRequest
{
    public int Id { get; set; }
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [Required(ErrorMessage = "Email is required")] 
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage = "Password can only contain Latin letters and digits")]
    public string Password { get; set; } 
}