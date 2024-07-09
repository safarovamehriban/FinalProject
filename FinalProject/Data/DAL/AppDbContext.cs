using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions opt) : base(opt) { }
        
            
      
        public DbSet<Product> Products { get; set; }    
        public DbSet<AppUser> Users { get; set; }
        //public DbSet<Basket> Baskets { get; set; }
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    //    base.OnModelCreating(builder);
    //}

}
