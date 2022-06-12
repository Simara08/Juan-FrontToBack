using JuanFronttoEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slider> Slides { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Colours> Colours { get; set; }
        public DbSet<ProductColours> ProductColours { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ProductsCategories> ProductsCategories { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Brands> Brands { get; set; }
    }

}
