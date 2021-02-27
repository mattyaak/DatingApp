using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        //We need to generate a constructor : VS Code or C Sharp extension is smart enough to look inside the DBContext class and see what different constructors it has available.
        //One of them is to generate DBContextOptions
        //We will pass some options here from the Startup configuration

        public DataContext(DbContextOptions options) : base(options)
        {
        }

    // we also need a DBSet it takes the type of the class that we want to create a DBSet for...
    //in this case it's our AppUser class
    //We call the table inside our DB users   
        public DbSet<AppUser> Users { get; set; }
    }
}