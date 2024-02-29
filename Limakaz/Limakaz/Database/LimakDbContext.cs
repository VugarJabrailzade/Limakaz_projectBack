using Limakaz.Database.DomainModels;
using Limakaz.Database.DomainModelsı;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Limakaz.Database
{
    public class LimakDbContext : DbContext
    {
        public LimakDbContext(DbContextOptions<LimakDbContext> options) : base(options)
        { }

           public DbSet<Officies> Officies {  get; set; }
           public DbSet<AbroadAddressTr> AbdroadAddressTr { get; set; }
           public DbSet<AbroadAddressUs> AbdroadAddressUs { get; set; }
           public DbSet<Contact> Contacts { get; set; }
           public DbSet<Order> Order { get; set; }
           public DbSet<Country> Countries { get; set; }
           public DbSet<OrderStatus> OrderStatus { get; set; }
           public DbSet<Tariff> Tariffs { get; set; }
           public DbSet<User> Users { get; set; }
           public DbSet<UserRole> UserRoles { get; set; }
    }
}
