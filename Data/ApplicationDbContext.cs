using CreditelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditelApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Credit> Credits => Set<Credit>();
}
