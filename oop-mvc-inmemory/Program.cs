using Microsoft.EntityFrameworkCore;
using oop_mvc_inmemory.Data;
using oop_mvc_inmemory.Models;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MovieDb"));

var app = builder.Build();

// Seed inicial
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Movie { Title = "Inception", Genre = "Sci-Fi", Year = 2016, Rating = 8.5 },
            new Movie { Title = "The Godfather", Genre = "Comedy", Year = 2017, Rating = 8.5 },
            new Movie { Title = "The Dark Knight", Genre = "Action", Year = 2018, Rating = 10.0 }
        );
        db.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();