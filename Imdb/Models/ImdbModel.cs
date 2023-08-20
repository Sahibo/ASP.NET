namespace Imdb.Models;


// public class Item
// {
//     public int Height { get; set; }
//     public string ImageUrl { get; set; }
//     public int Width { get; set; }
// }
//
// public class Data
// {
//     public Item Item { get; set; }
//     public string Id { get; set; }
//     public string Label { get; set; }
//     public string Source { get; set; }
//     public string Query { get; set; }
//     public string QueryId { get; set; }
//     public int? Rank { get; set; }
//     public int? Year { get; set; }
//     public string YearString { get; set; }
// }
//
// public class RootObject
// {
//     public List<Data> DataList { get; set; }
//     public string Query { get; set; }
//     public int Version { get; set; }
// }

public class D
{
    public I i { get; set; }
    public string id { get; set; }
    public string l { get; set; }
    public string s { get; set; }
    public string q { get; set; }
    public string qid { get; set; }
    public int? rank { get; set; }
    public int? y { get; set; }
    public string yr { get; set; }
    //public List<I> img { get; set; }
}

public class I
{
    public int height { get; set; }
    public string imageUrl { get; set; }
    public int width { get; set; }
}

public class Root
{
    public List<D> d { get; set; }
    public string q { get; set; }
    public int v { get; set; }
}

public class ImdbModel
{
    public List<D> Datas { get; set; }
}