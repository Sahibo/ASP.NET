namespace Imdb.Models;

public class Image
{
    public int height { get; set; }
    public string id { get; set; }
    public string url { get; set; }
    public int width { get; set; }
}

public class Meta
{
    public string operation { get; set; }
    public string requestId { get; set; }
    public double serviceTimeMs { get; set; }
}

public class Principal
{
    public string id { get; set; }
    public string legacyNameText { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public List<string> characters { get; set; }
}

public class Result
{
    public string id { get; set; }
    public Image image { get; set; }
    public string title { get; set; }
    public string titleType { get; set; }
    public int year { get; set; }
    public List<Principal> principals { get; set; }
}

public class ImdbModel
{
    public List<Result> results { get; set; }
}