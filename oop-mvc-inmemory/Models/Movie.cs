namespace oop_mvc_inmemory.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } =  string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Year { get; set; }
    public double Rating { get; set; }
}