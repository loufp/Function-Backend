namespace ISpotify.Models;

public class JemendoAPI
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("name")]
    
    public string Name { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("artist_name")]
    public string ArtistName {get ; set; }
    [System.Text.Json.Serialization.JsonPropertyName("audio")]
    public string Audio { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("audio_download")]
    public string AudioDownload { get; set; }
    
    
}