using Microsoft.EntityFrameworkCore;
using PostgresHelloWorldApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todo { get; set; }
}