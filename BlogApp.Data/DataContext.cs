using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Data
{
    public class DataContext : DbContext
    {
         protected readonly IConfiguration Configuration;

         public DataContext(IConfiguration configuration)
         {
             Configuration = configuration;
         }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}