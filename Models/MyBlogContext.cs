using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MigrationsExample.Models
{
    public class MyBlogContext : IdentityDbContext<AppUser>
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> option) : base(option)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var Entity in builder.Model.GetEntityTypes())
            {
               if( Entity.GetTableName().StartsWith("Aspnet"))
               {
                Entity.SetTableName(Entity.GetTableName().Substring(6));
               }
            }
        }
        public DbSet<Article> article {set; get;}


    } 
}