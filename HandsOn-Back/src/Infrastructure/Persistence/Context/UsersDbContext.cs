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

            //Criação das tabelas
            AddNutrientTable(modelBuilder, systemUserId, coffeeCultureId);
            AddFertilizerTable(modelBuilder, systemUserId, coffeeCultureId);

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

        private void AddNutrientTable(ModelBuilder modelBuilder, Guid userId, Guid cultureId)
        {
            var nutrientTableId = new Guid("b28c4809-f53e-49af-a6c4-0657610b603b");

            var leafNutrientRows = new List<NutrientRowData>
            {
                new NutrientRowData
                {
                    NutrientColumns = new List<NutrientColumnData>
                    {
                        new NutrientColumnData { Header = NutrientHeader.N, Min = 28, Max = 31 },
                        new NutrientColumnData { Header = NutrientHeader.P, Min = 1.7f, Max = 1.9f },
                        new NutrientColumnData { Header = NutrientHeader.K, Min = 22, Max = 25 },
                        new NutrientColumnData { Header = NutrientHeader.Ca, Min = 10, Max = 13 },
                        new NutrientColumnData { Header = NutrientHeader.Mg, Min = 2.7f, Max = 3.5f },
                        new NutrientColumnData { Header = NutrientHeader.S, Min = 1.8f, Max = 2.3f },
                        new NutrientColumnData { Header = NutrientHeader.Zn, Min = 10, Max = 20 },
                        new NutrientColumnData { Header = NutrientHeader.B, Min = 50, Max = 60 },
                        new NutrientColumnData { Header = NutrientHeader.Cu, Min = 10, Max = 15 },
                        new NutrientColumnData { Header = NutrientHeader.Mn, Min = 100, Max = 150 },
                        new NutrientColumnData { Header = NutrientHeader.Fe, Min = 120, Max = 200 },
                        new NutrientColumnData { Header = NutrientHeader.NP, Min = 15, Max = 18 },
                        new NutrientColumnData { Header = NutrientHeader.NK, Min = 1.1f, Max = 1.4f },
                        new NutrientColumnData { Header = NutrientHeader.NS, Min = 12, Max = 17 },
                        new NutrientColumnData { Header = NutrientHeader.NB, Min = 467, Max = 620 },
                        new NutrientColumnData { Header = NutrientHeader.NCu, Min = 1867, Max = 3100 },
                        new NutrientColumnData { Header = NutrientHeader.PMg, Min = 0.5f, Max = 0.7f },
                        new NutrientColumnData { Header = NutrientHeader.PZn, Min = 85, Max = 190 },
                        new NutrientColumnData { Header = NutrientHeader.KCa, Min = 1.7f, Max = 2.5f },
                        new NutrientColumnData { Header = NutrientHeader.KMg, Min = 6, Max = 9 },
                        new NutrientColumnData { Header = NutrientHeader.KMn, Min = 146, Max = 250 },
                        new NutrientColumnData { Header = NutrientHeader.CaMg, Min = 2.8f, Max = 4.8f },
                        new NutrientColumnData { Header = NutrientHeader.CaMn, Min = 67, Max = 130 },
                        new NutrientColumnData { Header = NutrientHeader.FeMn, Min = 0.8f, Max = 2.0f }
                    }
                }
            };

            var soilNutrientRow = new NutrientRowData
            {
                NutrientColumns = new List<NutrientColumnData>
                {
                    new NutrientColumnData { Header = NutrientHeader.P, Min = 10, Max = 30 },
                    new NutrientColumnData { Header = NutrientHeader.K, Min = 0.15f, Max = 0.3f },
                    new NutrientColumnData { Header = NutrientHeader.Ca, Min = 2.0f, Max = 5.0f },
                    new NutrientColumnData { Header = NutrientHeader.Mg, Min = 0.5f, Max = 1.5f },
                    new NutrientColumnData { Header = NutrientHeader.S, Min = 5, Max = 20 },
                    new NutrientColumnData { Header = NutrientHeader.Zn, Min = 2, Max = 6 },
                    new NutrientColumnData { Header = NutrientHeader.B, Min = 0.5f, Max = 2 },
                    new NutrientColumnData { Header = NutrientHeader.Cu, Min = 0.5f, Max = 10 },
                    new NutrientColumnData { Header = NutrientHeader.Mn, Min = 10, Max = 100 },
                    new NutrientColumnData { Header = NutrientHeader.Fe, Min = 10, Max = 40 },
                    new NutrientColumnData { Header = NutrientHeader.PhH2O, Min = 5, Max = 6.5f },
                    new NutrientColumnData { Header = NutrientHeader.AlSaturation, Inverted = true, Min = 0.2f, Med1 = 0.5f, Med2 = 1.0f, Max = 2.0f },
                    new NutrientColumnData { Header = NutrientHeader.PotentialAcidity, Inverted = true, Min = 1.0f, Med1 = 2.5f, Med2 = 5.0f, Max = 9.0f },
                    new NutrientColumnData { Header = NutrientHeader.OrganicMatter, Min = 0.7f, Med1 = 2.0f, Med2 = 4.0f, Max = 7.0f },
                    new NutrientColumnData { Header = NutrientHeader.SumBases, Min = 0.6f, Med1 = 1.8f, Med2 = 3.6f, Max = 6.0f },
                    new NutrientColumnData { Header = NutrientHeader.CTCpH7, Min = 1.6f, Med1 = 4.3f, Med2 = 8.6f, Max = 15.0f },
                    new NutrientColumnData { Header = NutrientHeader.BasesSaturation, Min = 20, Med1 = 40, Med2 = 60, Max = 80 }
                }
            };

            string leafData = JsonSerializer.Serialize(leafNutrientRows);
            string soilData = JsonSerializer.Serialize(soilNutrientRow);

            modelBuilder.Entity<NutrientTable>().HasData(
                new NutrientTable
                {
                    Id = nutrientTableId,
                    Standard = true,
                    Division = NutrientTableDivision.Annual,
                    LeafData = leafData,
                    SoilData = soilData,
                    CultureId = cultureId,
                    UserId = userId
                }
            );
        }

        private void AddFertilizerTable(ModelBuilder modelBuilder, Guid userId, Guid cultureId)
        {
            var fertilizerTableId = new Guid("b28c4810-f53e-49af-a6c4-0657610b603b");

            var leafFertilizerRow = new LeafFertilizerRowData
            {
                LeafFertilizerColumns = new List<LeafFertilizerColumnData>
                {
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.N,
                        Products = new List<LeafFertilizerProductData>
                        {

                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.P,
                        Products = new List<LeafFertilizerProductData>
                        {

                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.K,
                        Products = new List<LeafFertilizerProductData>
                        {

                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Ca,
                        Products = new List<LeafFertilizerProductData>
                        {

                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Mg,
                        Products = new List<LeafFertilizerProductData>
                        {

                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.S,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "enxofre líquido",
                                Solid = false,
                                MinConcentration = 0.5f,
                                MaxConcentration = 1.0f
                            }
                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Zn,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "sulfato de zinco",
                                Solid = true,
                                MinConcentration = 1.0f,
                                MaxConcentration = 2.0f
                            },
                            new LeafFertilizerProductData
                            {
                                Name = "zinco líquido",
                                Solid = false,
                                MinConcentration = 0.5f,
                                MaxConcentration = 1.0f
                            }
                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.B,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "ácido bórico",
                                Solid = true,
                                MinConcentration = 1.0f,
                                MaxConcentration = 2.0f
                            },
                            new LeafFertilizerProductData
                            {
                                Name = "boro líquido",
                                Solid = false,
                                MinConcentration = 0.5f,
                                MaxConcentration = 1.0f
                            }
                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Cu,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "fungicida cúprico",
                                Solid = false,
                                MinConcentration = 1.0f,
                                MaxConcentration = 2.0f
                            }
                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Mn,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "sulfato de manganês",
                                Solid = true,
                                MinConcentration = 1.0f,
                                MaxConcentration = 2.0f
                            }
                        }
                    },
                    new LeafFertilizerColumnData
                    {
                        Header = NutrientHeader.Fe,
                        Products = new List<LeafFertilizerProductData>
                        {
                            new LeafFertilizerProductData
                            {
                                Name = "ferro quelatizado",
                                Solid = false,
                                MinConcentration = 1.0f,
                                MaxConcentration = 2.0f
                            }
                        }
                    }
                }
            };

            var soilFertilizerRows = new List<SoilFertilizerRowData>
            {
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 2.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 56, Value2 = 45 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 10, Value2 = 6, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 46, Value2 = 37, Value3 = 27, Value4 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)7, NumberOfValues = 4, Value1 = 6, Value2 = 4, Value3 = 0, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 4.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 72, Value2 = 58 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 13, Value2 = 9, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 65, Value2 = 51, Value3 = 38, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 6.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 88, Value2 = 70 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 16, Value2 = 11, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 83, Value2 = 66, Value3 = 50, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 8.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 104, Value2 = 83 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 19, Value2 = 13, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 102, Value2 = 81, Value3 = 61, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 10.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 120, Value2 = 96 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 22, Value2 = 15, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 119, Value2 = 96, Value3 = 72, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 12.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 136, Value2 = 109 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 26, Value2 = 18, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 138, Value2 = 110, Value3 = 82, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 14.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 152, Value2 = 122 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 29, Value2 = 20, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 156, Value2 = 125, Value3 = 94, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 16.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 168, Value2 = 134 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 32, Value2 = 22, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 174, Value2 = 140, Value3 = 105, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 18.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 184, Value2 = 147 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 35, Value2 = 24, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 193, Value2 = 154, Value3 = 116, Value4 = 0 }
                    }
                },
                new SoilFertilizerRowData
                {
                    ExpectedProductivity = 20.0f,
                    SoilFertilizerColumns = new List<SoilFertilizerColumnData>
                    {
                        new SoilFertilizerColumnData { Header = (NutrientHeader)0, NumberOfValues = 2, Value1 = 200, Value2 = 160 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)1, NumberOfValues = 3, Value1 = 38, Value2 = 26, Value3 = 0 },
                        new SoilFertilizerColumnData { Header = (NutrientHeader)2, NumberOfValues = 4, Value1 = 211, Value2 = 170, Value3 = 127, Value4 = 0 }
                    }
                }
            };

            string leafParameters = JsonSerializer.Serialize(leafFertilizerRow);
            string soilParameters = JsonSerializer.Serialize(soilFertilizerRows);

            modelBuilder.Entity<FertilizerTable>().HasData(
                new FertilizerTable
                {
                    Id = fertilizerTableId,
                    Standard = true,
                    ExpectedBasesSaturation = 70f,
                    LeafParameters = leafParameters,
                    SoilParameters = soilParameters,
                    CultureId = cultureId,
                    UserId = userId
                }
            );
        }
    }
}