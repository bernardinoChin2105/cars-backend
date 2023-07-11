using Microsoft.EntityFrameworkCore;
using CarsDemo.Models;

namespace CarsDemo
{
    public class AppContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
