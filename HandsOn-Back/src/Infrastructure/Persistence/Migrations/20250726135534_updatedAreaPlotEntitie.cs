using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedAreaPlotEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b6c8e8b1-8a18-4c95-bbae-efe94f673436"), new Guid("018f1bfe-9d35-425c-be38-03981bf67ee7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8c4e9a8e-58fa-4f60-815d-6a6db6c2de5f"), new Guid("95ad89ba-d45d-4c22-b7a8-c29a13bfbed0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a44d22c-3942-41f1-be34-5656615951ed"), new Guid("e04c6d77-7fb1-4721-bade-e5613fd00382") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0e1c0822-9cb9-478b-a85d-851eb4f294d3"), new Guid("ed1506bc-47cc-4176-9eb9-fb38d2a3493a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cb51634a-0d7c-4d74-b1b3-38c3a7113e4e"), new Guid("f842094c-3bfa-41cc-92e7-98f4308ab51f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a44d22c-3942-41f1-be34-5656615951ed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e1c0822-9cb9-478b-a85d-851eb4f294d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8c4e9a8e-58fa-4f60-815d-6a6db6c2de5f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6c8e8b1-8a18-4c95-bbae-efe94f673436"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb51634a-0d7c-4d74-b1b3-38c3a7113e4e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("018f1bfe-9d35-425c-be38-03981bf67ee7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ad89ba-d45d-4c22-b7a8-c29a13bfbed0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e04c6d77-7fb1-4721-bade-e5613fd00382"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed1506bc-47cc-4176-9eb9-fb38d2a3493a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f842094c-3bfa-41cc-92e7-98f4308ab51f"));

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Plot",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "Plot",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a44d22c-3942-41f1-be34-5656615951ed"), "c520b14a-b059-43d9-bcb0-639ff283d4e4", "Collaborator", "COLLABORATOR" },
                    { new Guid("0e1c0822-9cb9-478b-a85d-851eb4f294d3"), "de546b20-0122-4eda-98bc-d890c701eb83", "Manager", "MANAGER" },
                    { new Guid("8c4e9a8e-58fa-4f60-815d-6a6db6c2de5f"), "8e9aa16b-d511-415c-8011-34da0b34adbc", "Owner", "OWNER" },
                    { new Guid("b6c8e8b1-8a18-4c95-bbae-efe94f673436"), "60f31f7c-fea0-4a8b-8801-c43d3da65452", "Consultant", "CONSULTANT" },
                    { new Guid("cb51634a-0d7c-4d74-b1b3-38c3a7113e4e"), "1ed0ca82-b257-4085-a12e-44e338519fdf", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("018f1bfe-9d35-425c-be38-03981bf67ee7"), 0, "50ac3510-7b6b-4537-b8bd-8d036ac43e39", new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9324), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$pZHVpqCS/sXbckaKIbG2z.IuK1BDWSksWExdSWoQB7ShZM4o6iGpG", "(99) 99999-9993", false, "366d7cda-8df5-4f0d-af26-f19251e63630", 0, false, new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9321), "alice" },
                    { new Guid("95ad89ba-d45d-4c22-b7a8-c29a13bfbed0"), 0, "0a907594-e619-49ab-97a8-3e5539f74009", new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9320), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$qVQtKjTJ8saLO3YmM6FfdeEYrBSOI3SB9nH9TizB3w.30XkokrZj.", "(99) 99999-9992", false, "30d916cd-bd9f-4c6b-8b82-81bfdc26d7a0", 0, false, new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9303), "jane" },
                    { new Guid("e04c6d77-7fb1-4721-bade-e5613fd00382"), 0, "c2aa223c-f8e3-4955-8058-f89d8adb7aff", new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9337), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$dhkIzi6pdIb7bTnGtNzVSebEeihofMPvk2RJuiwhlpzton5.v3yO6", "(99) 99999-9995", false, "ce2a0b9c-1e3e-452b-8239-9118e3915fb2", 0, false, new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9333), "charlie" },
                    { new Guid("ed1506bc-47cc-4176-9eb9-fb38d2a3493a"), 0, "465590ff-0c7b-4f73-a22a-56150f3f1e2e", new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9333), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$IBqnuV/PThw9qacWjsjJY.TurYgoBP5/B4Pcz199VW1HoGJj65zja", "(99) 99999-9994", false, "2472f273-bcac-427c-af62-1f964f06f9c1", 0, false, new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9325), "bob" },
                    { new Guid("f842094c-3bfa-41cc-92e7-98f4308ab51f"), 0, "e0d5262c-bc00-4b12-ac39-b70a46992b8c", new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(9053), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$GorV7ODHJ0NQT0Jy/YMhCe4kZoo6vL5Jz3LW6mmAfAWgmV74xixTm", "(99) 99999-9991", false, "47c1d108-624a-4f91-ad12-488284ed1545", 0, false, new DateTime(2025, 7, 26, 10, 28, 5, 561, DateTimeKind.Local).AddTicks(7287), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b6c8e8b1-8a18-4c95-bbae-efe94f673436"), new Guid("018f1bfe-9d35-425c-be38-03981bf67ee7") },
                    { new Guid("8c4e9a8e-58fa-4f60-815d-6a6db6c2de5f"), new Guid("95ad89ba-d45d-4c22-b7a8-c29a13bfbed0") },
                    { new Guid("0a44d22c-3942-41f1-be34-5656615951ed"), new Guid("e04c6d77-7fb1-4721-bade-e5613fd00382") },
                    { new Guid("0e1c0822-9cb9-478b-a85d-851eb4f294d3"), new Guid("ed1506bc-47cc-4176-9eb9-fb38d2a3493a") },
                    { new Guid("cb51634a-0d7c-4d74-b1b3-38c3a7113e4e"), new Guid("f842094c-3bfa-41cc-92e7-98f4308ab51f") }
                });
        }
    }
}
