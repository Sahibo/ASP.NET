using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Imdb.Services;
using Imdb.Models;
using System.Text.Json;

namespace Imdb.Pages;

public class IndexModel : PageModel
{
    public string movieTitle { get; set; }
    public ImdbModel ImdbResponse { get; set; } = new();

    private ImdbService _imdbService;
    public IndexModel(ImdbService imdbService)
    {
        _imdbService = imdbService;
    }

    public async Task<IActionResult> OnGet()
    {
        try
        {
            movieTitle = Request.Query["movieTitle"];
            ImdbResponse = await _imdbService.GetMovieInfoAsync(movieTitle);
        }
        catch (Exception ex)
        {
            throw new JsonException(ex.Message);
        }
        return Page();
    }
}