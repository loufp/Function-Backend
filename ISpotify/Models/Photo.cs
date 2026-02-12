namespace ISpotify.Models;

public class Photo
{
    public int Id { get; set; }
    
    public string DowlandPhoto { get; set; }
    
    public string PathPhoto { get; set; }
    
    public DateTime TimeDowland { get; set; }
    public int UserId { get; set; }
    public SignupRequest User { get; set; }
}