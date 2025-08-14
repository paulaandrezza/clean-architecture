using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Aggregates.AddressAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IPasswordHasher _bcryptPasswordHasher = new BCryptPasswordHasher();
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string hashedPassword = _bcryptPasswordHasher.HashPassword("admin123");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@email.com",
                    Password = hashedPassword,
                    Role = Role.Admin
                }
            );
        }
    }
}
