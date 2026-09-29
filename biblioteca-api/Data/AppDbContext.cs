using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Livro> Livros => Set<Livro>();
}
