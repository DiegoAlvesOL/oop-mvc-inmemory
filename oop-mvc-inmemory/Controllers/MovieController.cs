using Microsoft.AspNetCore.Mvc;
using oop_mvc_inmemory.Data;
using oop_mvc_inmemory.Models;

namespace oop_mvc_inmemory.Controllers;

public class MovieController : Controller
{
    private readonly AppDbContext _db;

    public MovieController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View(_db.Movies.ToList());
    }

    // CREATE
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        _db.Movies.Add(movie);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // EDIT
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        _db.Movies.Update(movie);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    //DETAILS
    [HttpGet]
    public IActionResult Details(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }
    
    
    //DELETE
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }


    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movie != null)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
    
}