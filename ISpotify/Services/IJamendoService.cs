using ISpotify.Models;
namespace ISpotify.Services;

public interface IJamendoService
{
    Task<IEnumerable<JemendoAPI>> SearchTracksJamendo(string query, int limit = 10);
}