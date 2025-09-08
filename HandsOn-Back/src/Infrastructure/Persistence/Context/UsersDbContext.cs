using System.Text.Json;
using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class UsersDbContext(DbContextOptions<UsersDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options), IUsersDbContext
    {
        public DbSet<User> IdentityUsers { get; set; }
        public DbSet<Analise> Analise { get; set; }
        public DbSet<NutrientTable> NutrientTables { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<FertilizerTable> FertilizerTables { get; set; }
        public DbSet<FormulationTable> FormulationTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Guid> roleIds = [];
            Dictionary<string, object> roles = [];

            foreach (var role in RoleExtension.GetValues())
            {
                var roleId = Guid.NewGuid();
                roles.Add(role.ToFriendlyString(), new
                {
                    Id = roleId,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper()
                });
                roleIds.Add(roleId);
            }

            foreach (var role in roles)
            {
                modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
                {
                    Id = (Guid)role.Value.GetType().GetProperty("Id")!.GetValue(role.Value)!,
                    Name = (string)role.Value.GetType().GetProperty("Name")!.GetValue(role.Value)!,
                    NormalizedName = role.Value.GetType().GetProperty("NormalizedName")!.GetValue(role.Value)!.ToString()!.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }

            List<User> users =
            [
                new User("John", "Doe", "example1@gmail.com", "(99) 99999-9991"),
                new User("Jane", "Doe", "example2@gmail.com", "(99) 99999-9992"),
                new User("Alice", "Anderson", "example3@gmail.com", "(99) 99999-9993"),
                new User("Bob", "Anderson", "example4@gmail.com", "(99) 99999-9994"),
                new User("Charlie", "Smith", "example5@gmail.com", "(99) 99999-9995")
            ];

            foreach (var user in users)
            {
                user.UserName = user.FirstName.ToLower();
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email!.ToUpper();
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("test123");
            }

            modelBuilder.Entity<User>().HasData(users);

            for (int i = 0; i < users.Count; i++)
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
                {
                    UserId = users[i].Id,
                    RoleId = roleIds[i]
                });
            }

            Guid coffeeCultureId = new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a");
            Guid systemUserId = users[0].Id;


            modelBuilder.Entity<Culture>().HasData(
                new Culture { Id = coffeeCultureId, Name = "Café", NormalizedName = "cafe" }
            );

            modelBuilder.Entity<NutrientTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Culture).WithMany().HasForeignKey(e => e.CultureId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.LeafData).HasColumnType("LONGTEXT");
            });


            modelBuilder.Entity<Analise>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Lab).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Proprietario).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Propriedade).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DataAnalise).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                modelBuilder.Entity<Analise>()
                .Property(e => e.DadosAnalise)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<PlotsData>(v, (JsonSerializerOptions?)null)!
                )
                .HasColumnType("LONGTEXT");

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}