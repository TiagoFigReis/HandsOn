using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Culture_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d2772420-d91e-4c16-b4bf-0234879aaccb"), new Guid("5993ab29-d692-461e-985b-a0969af53ad3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87c9b5b3-b2d4-427a-ae8b-54d3229a11ee"), new Guid("5d52838d-f602-4d4f-ac0d-1943ba530011") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6f5235ad-4d04-45c3-b4c3-70b4b51b8dde"), new Guid("5ee6f4f9-9301-47d4-ad02-479652d35869") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9c029e6d-6262-4c32-9fa0-3ce9cd2921f5"), new Guid("b4ad13fb-56aa-46d5-95e0-8d0c2af1d4b9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e89b6c14-e89d-49b8-b957-4f6b3b833835"), new Guid("c51687c9-9d41-4da6-a6cf-210fb6202211") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f5235ad-4d04-45c3-b4c3-70b4b51b8dde"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87c9b5b3-b2d4-427a-ae8b-54d3229a11ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c029e6d-6262-4c32-9fa0-3ce9cd2921f5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2772420-d91e-4c16-b4bf-0234879aaccb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e89b6c14-e89d-49b8-b957-4f6b3b833835"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5993ab29-d692-461e-985b-a0969af53ad3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5d52838d-f602-4d4f-ac0d-1943ba530011"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ee6f4f9-9301-47d4-ad02-479652d35869"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4ad13fb-56aa-46d5-95e0-8d0c2af1d4b9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c51687c9-9d41-4da6-a6cf-210fb6202211"));

            migrationBuilder.DropColumn(
                name: "CultureType",
                table: "NutrientTables");

            migrationBuilder.AddColumn<Guid>(
                name: "CultureId",
                table: "NutrientTables",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), "c704b892-62d4-414d-915d-45d2081d72be", "Consultant", "CONSULTANT" },
                    { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), "cb2a3749-7232-477a-acef-07716a160c9e", "Admin", "ADMIN" },
                    { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), "f82d0459-5ec3-4aa1-af30-cfe37a317d6c", "Collaborator", "COLLABORATOR" },
                    { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), "2f938fe1-18cc-4fb9-b71a-a3c7b00b3adc", "Manager", "MANAGER" },
                    { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), "99bff389-9dcc-440e-bb1d-0c425a689eeb", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5bb15db8-3675-4114-88e3-498597044987"), 0, "64b88d6c-b7b3-4f49-b871-636f34efa2c9", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3162), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$7wD/4vpwGaXauUd10ZPSteEp7Ue11GavfphSgmbjyf0F.ftiScqAy", "(99) 99999-9994", false, "829caa3e-3151-40ec-84a3-832d5d7a00bd", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3160), "bob" },
                    { new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e"), 0, "9e11565b-b9a9-40f9-9d64-4d311c1924b6", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3144), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$S7FQnM60rnhdhTOsHQ8Qke9.uvBHzuBVgC97RJXRoN6Fd0IwoXVdq", "(99) 99999-9992", false, "f506e0bc-84e3-4d7b-b595-1d85ec939531", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3135), "jane" },
                    { new Guid("b27ee196-032b-4f7e-853d-8ce54302a236"), 0, "942ec016-9ecc-4e84-a387-f510a4b44bf4", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(2869), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$yJRE96tE3o/jNDL8XHEKsuj9TCz/vSuucLEMJ.hoSacIqnMVEy1IO", "(99) 99999-9991", false, "2adf3690-2c71-49f8-a05a-29e83af7dbd8", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(1534), "john" },
                    { new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c"), 0, "b78f3761-d4b1-4c56-8de9-3e1fff6bc9ff", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3159), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$Qgolh1HGnTYyu5jVytslBeMdJKtilMmr/slY3K2diXAml5Z7tuEsu", "(99) 99999-9993", false, "a74fe19a-3136-4af5-8eb0-83e9fe313371", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3146), "alice" },
                    { new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838"), 0, "1a34f38a-9512-4d8c-842a-58b424d6a7c6", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3164), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$B80r9RA05hC4k5QPAZcF.OGwZ8Yi6vUH66dUE1IlEP7ftFzaWHnLe", "(99) 99999-9995", false, "ecfa68e3-faf4-49ff-a85a-fa47920911a4", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3162), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), new Guid("5bb15db8-3675-4114-88e3-498597044987") },
                    { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e") },
                    { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), new Guid("b27ee196-032b-4f7e-853d-8ce54302a236") },
                    { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c") },
                    { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutrientTables_CultureId",
                table: "NutrientTables",
                column: "CultureId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutrientTables_Cultures_CultureId",
                table: "NutrientTables",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutrientTables_Cultures_CultureId",
                table: "NutrientTables");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropIndex(
                name: "IX_NutrientTables_CultureId",
                table: "NutrientTables");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), new Guid("5bb15db8-3675-4114-88e3-498597044987") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), new Guid("b27ee196-032b-4f7e-853d-8ce54302a236") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77efed5c-12ba-497c-891a-e1b271782df0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5bb15db8-3675-4114-88e3-498597044987"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b27ee196-032b-4f7e-853d-8ce54302a236"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838"));

            migrationBuilder.DropColumn(
                name: "CultureId",
                table: "NutrientTables");

            migrationBuilder.AddColumn<string>(
                name: "CultureType",
                table: "NutrientTables",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6f5235ad-4d04-45c3-b4c3-70b4b51b8dde"), "3fde720a-c579-4810-b179-67dae6e730ec", "Collaborator", "COLLABORATOR" },
                    { new Guid("87c9b5b3-b2d4-427a-ae8b-54d3229a11ee"), "04b86c16-26a3-4edb-a813-e52d046727e8", "Owner", "OWNER" },
                    { new Guid("9c029e6d-6262-4c32-9fa0-3ce9cd2921f5"), "07c1a625-521a-4e75-86ef-f02ccb663872", "Consultant", "CONSULTANT" },
                    { new Guid("d2772420-d91e-4c16-b4bf-0234879aaccb"), "fd31f5c0-5492-4739-b927-3a06082db863", "Admin", "ADMIN" },
                    { new Guid("e89b6c14-e89d-49b8-b957-4f6b3b833835"), "ca2d712a-84d0-46b3-a390-94f6d079412b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5993ab29-d692-461e-985b-a0969af53ad3"), 0, "65c085a6-0262-4d1a-bfd5-ce1835d94ab6", new DateTime(2025, 7, 26, 10, 55, 33, 27, DateTimeKind.Local).AddTicks(9797), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$heeMnoPdP7ZXiLsFj0tdROKm0czjiuQcVhW5UfPQlmKOMQvjuOTV.", "(99) 99999-9991", false, "f3e87cfe-4194-4f12-81f7-b23bf51b217f", 0, false, new DateTime(2025, 7, 26, 10, 55, 33, 27, DateTimeKind.Local).AddTicks(7962), "john" },
                    { new Guid("5d52838d-f602-4d4f-ac0d-1943ba530011"), 0, "c8f0271e-4279-4ce2-93de-f631843239a9", new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(60), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$zobfq5AftmYw71IXlI2jZ.mvm2ztMU9y4xK1sdXEJwrmCXKmbAoDG", "(99) 99999-9992", false, "4ba05acd-cce9-40aa-89b9-5ddad8b354c2", 0, false, new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(41), "jane" },
                    { new Guid("5ee6f4f9-9301-47d4-ad02-479652d35869"), 0, "1e2d67e8-ac27-4655-8d19-d9f9b5820431", new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(86), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$zlCTUJr.DvMMLrIahYy1OOPSfEI3/y7ZBpAV7fe0hMoKVdxgPnZfa", "(99) 99999-9995", false, "e9efdac4-c913-40de-925b-c3e82e170c24", 0, false, new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(80), "charlie" },
                    { new Guid("b4ad13fb-56aa-46d5-95e0-8d0c2af1d4b9"), 0, "77d3eb6b-53c2-4838-b87d-f60abd2a8823", new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(76), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$tdtE1hdYn81ROn3c1s/pvOLAjYxk5lYfR1Zp/8bwaVhMY81/NM1Ie", "(99) 99999-9993", false, "57a4edf4-f977-45cc-b9e3-604d62d6df0e", 0, false, new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(61), "alice" },
                    { new Guid("c51687c9-9d41-4da6-a6cf-210fb6202211"), 0, "19802d21-27c0-49b2-a9c0-d2711196d93c", new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(79), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$waO7MS5dmTOS258odp18e.klacOOIuydUJpXhfQVEabREGXmJ0aEG", "(99) 99999-9994", false, "603cd154-039b-4b96-9584-7d53b9790158", 0, false, new DateTime(2025, 7, 26, 10, 55, 33, 28, DateTimeKind.Local).AddTicks(77), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d2772420-d91e-4c16-b4bf-0234879aaccb"), new Guid("5993ab29-d692-461e-985b-a0969af53ad3") },
                    { new Guid("87c9b5b3-b2d4-427a-ae8b-54d3229a11ee"), new Guid("5d52838d-f602-4d4f-ac0d-1943ba530011") },
                    { new Guid("6f5235ad-4d04-45c3-b4c3-70b4b51b8dde"), new Guid("5ee6f4f9-9301-47d4-ad02-479652d35869") },
                    { new Guid("9c029e6d-6262-4c32-9fa0-3ce9cd2921f5"), new Guid("b4ad13fb-56aa-46d5-95e0-8d0c2af1d4b9") },
                    { new Guid("e89b6c14-e89d-49b8-b957-4f6b3b833835"), new Guid("c51687c9-9d41-4da6-a6cf-210fb6202211") }
                });
        }
    }
}