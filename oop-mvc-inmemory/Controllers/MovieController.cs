using Microsoft.AspNetCore.Mvc;
using oop_mvc_inmemory.Data;
using oop_mvc_inmemory.Models;

namespace oop_mvc_inmemory.Controllers;

public class MovieController : Controller
{
    private readonly AppDbContext _dbContext;
    public MovieController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        
        
        List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi",Year = 2016, Rating = 8.5 },
            new Movie { Id = 2,  Title = "The Godfather", Genre = "Comedy", Year = 2017, Rating = 8.5 },
            new Movie{ Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2018, Rating = 10.0 },
            
        };
        return View(movies);
    }
    
}