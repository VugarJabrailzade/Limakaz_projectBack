using Limakaz.Database.DomainModels;
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
    }
}
