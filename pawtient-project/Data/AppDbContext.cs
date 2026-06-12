using Microsoft.EntityFrameworkCore;
using pawtient_project.Models;

namespace pawtient_project.Data;

public class AppDbContext: DbContext
{
    public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Tabla1> Tabla1 { get; set; }
  
}
