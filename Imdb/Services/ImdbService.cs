using Imdb.Models;
using Newtonsoft.Json;

namespace Imdb.Services;

public class ImdbService
{
    public async Task<ImdbModel> GetMovieInfoAsync(string title)
    {
        HttpClient client = new();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={title}"),
            Headers =
            {
                { "X-RapidAPI-Key", "9495ed9410msh7befb35f01562fcp16940cjsnd0f895b9ede1" },
                { "X-RapidAPI-Host", "imdb8.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var json = content.ToString();
            var result = JsonConvert.DeserializeObject<ImdbModel>(json);
            return result;
        }
        
    }
}