using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace ISpotify.Models;

public class JamendoResponse
{
    [JsonPropertyName("results")]
    public List<JemendoTracks> Results { get; set; } 
}

public class JemendoTracks
{
    [JsonPropertyName("id")]
    public string Id{get;set;}
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("artist_name")]
    public string ArtisName { get; set; }
    
    [JsonPropertyName("audio")]
    public string Audio { get; set; }
    
    [JsonPropertyName("audio_download")]
    public string AudioDownload { get; set; }
    
}