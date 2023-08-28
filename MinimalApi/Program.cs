using MinimalApi;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () =>
{
    return Results.Redirect("/index.html");
});

app.MapGet("/api/quotes", () =>
{
    List<Quote> quotes = LoadQuotesFromJson("Quotes.json");
    return Results.Ok(quotes);
}).WithName("GetAllQuotes");

app.MapGet("/api/quotes/favorites", () =>
{
    List<Quote> quotes = LoadQuotesFromJson("Quotes.json");
    List<Quote> favoriteQuotes = quotes.FindAll(q => q.IsFavorite);
    return Results.Ok(favoriteQuotes);
}).WithName("GetFavoriteQuotes");

//app.Run();

List<Quote> LoadQuotesFromJson(string filePath)
{
    string jsonText = File.ReadAllText(filePath);
    List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(jsonText);
    return quotes;
}

app.Run();