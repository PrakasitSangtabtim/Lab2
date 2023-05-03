using Microsoft.EntityFrameworkCore; //Import EF
using WebApplication1.Models;  //Import Models

namespace WebApplication1.Databases
{
    public class DataDbContext:DbContext
    {
        // Constructure Method
        public DataDbContext(DbContextOptions<DataDbContext> options):base(options){ }
        //Table manufacturers
        public DbSet<manufacturers> manufacturers { get; set; } //Table 
        //Table devices
        public DbSet<devices> devices { get; set; }
        
    }
}
