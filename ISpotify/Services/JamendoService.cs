using ISpotify.Models;

namespace ISpotify.Services;

public class JamendoService: IJamendoService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<JamendoService> _logger;
    private readonly string _client;
    

    public JamendoService(HttpClient httpClient, IConfiguration config,ILogger<JamendoService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _httpClient.BaseAddress=new Uri(config["Jamendo:BaseUrl"]);
        _client = config["Jamendo:ClientId"];   
    }

    public async Task<IEnumerable<JemendoAPI>> SearchTracksJamendo(string query, int limit = 10)
    {
        var response = await _httpClient.GetAsync
            ($"tracks/?client_id={_client}&format=json&limit={limit}&search={query}&namesearch={query}&audioformat=mp32");
        
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("API Response: {Content}", content);
        
        var JemendoResponse = System.Text.Json.JsonSerializer.Deserialize<JamendoResponse>(content);

        if (JemendoResponse?.Results == null || !JemendoResponse.Results.Any())
        {
            return Enumerable.Empty<JemendoAPI>();
        }

        var tracks = JemendoResponse.Results.Select(t => new JemendoAPI
        {
            Id = t.Id,
            Name = t.Name,
            ArtistName = t.ArtisName,
            Audio = t.Audio,
            AudioDownload = t.AudioDownload
            
        });

        return tracks;
    }

}