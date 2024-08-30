using Microsoft.EntityFrameworkCore;

namespace Bckend.entities;

public class AppDataContext: DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) :
        base(options)
    { }
    
    public DbSet<Appuser> Appusers { get; set; }

}