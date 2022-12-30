using Impar.Cars.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Impar.Cars.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Car> Car { get; set; }

        public DbSet<Photo> Photo { get; set; }
       
    }
}
