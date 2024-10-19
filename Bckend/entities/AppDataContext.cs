using Microsoft.EntityFrameworkCore;

namespace Bckend.entities;

public class AppDataContext (DbContextOptions options) : DbContext(options)
{
 
    public DbSet<Appuser> Appusers { get; set; }
}