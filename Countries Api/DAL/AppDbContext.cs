using Countries_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Countries_Api.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<product> Products { get; set; }
        public DbSet<category> Categorys { get; set; }
    }
}
