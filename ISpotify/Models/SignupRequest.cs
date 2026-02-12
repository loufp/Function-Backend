using System.ComponentModel.DataAnnotations;

namespace ISpotify.Models;

public class SignupRequest
{
    public int Id { get; set; }
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    
    
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage = "Password can only contain Latin letters and digits")]
    public string Password { get; set; } //example:123321Abc!
    
    
    [Required(ErrorMessage = "Confirm Password is required")]
    public string? ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Username can only contain Latin letters")]
    public string Username { get; set; }
    
    public ICollection<Photo> Photos { get; set; }
}