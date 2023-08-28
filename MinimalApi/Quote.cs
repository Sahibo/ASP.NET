namespace MinimalApi;

public class Quote
{
    public int Id { get; set; }
    public string QuoteText { get; set; }
    public string Author { get; set; }
    public bool IsFavorite { get; set; }
}