using System.Diagnostics.CodeAnalysis;
using ISpotify.Models;
using ISpotify.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISpotify.Controller;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IJamendoService _jamendoService;
    
    private readonly ILogger<SearchController> _logger;
    
    public SearchController(IJamendoService jamendoService, ILogger<SearchController> logger)
    {
        _jamendoService= jamendoService;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> SearchMusic([FromQuery] string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            _logger.LogInformation("User search music");
            return BadRequest("Query parameter is required.");
        }
        _logger.LogInformation("User {query}", query);
        var result = await _jamendoService.SearchTracksJamendo(query);
        return Ok(result);
    }
}