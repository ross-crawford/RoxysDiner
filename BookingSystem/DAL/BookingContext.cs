using BookingSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookingSystem.DAL
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("BookingContext")
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<TableModel> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}