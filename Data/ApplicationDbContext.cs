using Dummymvc3.Models;
using Microsoft.EntityFrameworkCore;

namespace Dummymvc3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Emp> emps { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
