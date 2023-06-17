using Microsoft.EntityFrameworkCore;
using AppApi.Models;

namespace AppApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; } = null!;
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

    }
}