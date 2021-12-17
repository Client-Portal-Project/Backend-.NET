using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using REST.Models;

namespace REST.DataLayer
{
    public class BatchesDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationsTopicsJoin> OccupationsTopicsJoins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public BatchesDBContext() { }


        public BatchesDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             //  modelBuilder.Entity<Clients>()
             //    .HasKey(cl => cl.ClientId);

             //  modelBuilder.Entity<Occupations>()
             //   .HasKey(c => c.OccupationId);

             //  modelBuilder.Entity<Orders>()
             //  .HasKey(o=> o.OrderId);

             //  modelBuilder.Entity<OrderDetails>()
             // .HasKey(od => od.DetailsId);

             //  modelBuilder.Entity<Topics>()
             // .HasKey(t => t.TopicId);

             //  modelBuilder.Entity<OccupationsTopicsJoin>()
             //.HasKey(ctj => ctj.JoinId);


        }


    }
}