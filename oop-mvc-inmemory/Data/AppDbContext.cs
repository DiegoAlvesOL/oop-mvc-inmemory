using Microsoft.EntityFrameworkCore;
using oop_mvc_inmemory.Models;


namespace oop_mvc_inmemory.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Movie> Movies => Set<Movie>();
}