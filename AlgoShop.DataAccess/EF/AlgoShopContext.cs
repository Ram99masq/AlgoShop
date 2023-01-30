using AlgoShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess.EF
{
    public class AlgoShopContext : DbContext
    {
        IConfiguration configuration;
        
        public AlgoShopContext(DbContextOptions<AlgoShopContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=Smile;Database=Shop;Trusted_Connection=True;");
                 optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnection").ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }            

        //public MyDbContext() : base() { }
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //	base.OnConfiguring(optionsBuilder);
        //	// HACK: Requires putting Startup in this project
        //	optionsBuilder.UseSqlServer(Startup.Configuration["Data:DefaultConnection"]);
        //}

        public DbSet<Order> Order { get; set; }
        public DbSet<Stock> Stock { get; set; }
    }
}
