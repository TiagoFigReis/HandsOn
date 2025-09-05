using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedPlotEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), new Guid("96a73925-019d-42c8-8e88-28c42e730ade") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), new Guid("f291fb87-5f54-402d-9942-0516538d3fbf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96a73925-019d-42c8-8e88-28c42e730ade"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f291fb87-5f54-402d-9942-0516538d3fbf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), "6f9ce3de-36cb-4da2-96c2-12891e07d5f6", "Admin", "ADMIN" },
                    { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), "020f22ee-eb5a-4156-93ec-da5c797573ed", "Manager", "MANAGER" },
                    { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), "083ef659-fd9e-4cee-9b6a-90f407b4ae93", "Consultant", "CONSULTANT" },
                    { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), "31583cc4-c4f4-473d-ba4c-aa5eebd75b67", "Owner", "OWNER" },
                    { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), "a2f77774-f310-4385-abe1-f92dff27b3ff", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf"), 0, "a03c4728-cb33-41b8-88fc-3b3def255a66", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4627), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$dk4B1kUz2HjojlPltefFS.aJKgWPtrs71uegEsNScmLqIfL9tgj82", "(99) 99999-9994", false, "de7d515a-f5ec-4aad-ab53-28bf961437bd", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4620), "bob" },
                    { new Guid("96a73925-019d-42c8-8e88-28c42e730ade"), 0, "30d59c7b-ac35-4efc-a0e7-73329c16e0cb", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4615), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$lxOspefcfMXwHRvkR40hB.Q81i5rRA.E6.AlYLpqHNdCj9UTWKfTy", "(99) 99999-9992", false, "c7c94a71-386e-41b6-84c0-34f3d0289db9", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4599), "jane" },
                    { new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f"), 0, "81227539-2505-4952-8f6e-088aae0cff14", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4631), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$1ljlE6O//xT4tD.MvI57KeXHXOQn.nkZ52/tiegiXsAbR3357fiJi", "(99) 99999-9995", false, "bd2055b5-29a0-444f-83c7-9b1faf2e2705", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4628), "charlie" },
                    { new Guid("f291fb87-5f54-402d-9942-0516538d3fbf"), 0, "4bf2b5b1-898b-4a23-8546-96acd8c008a3", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4358), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$CNNSKsNCqnVBGsaJ56blReS14G9qtrc8zDZB1kmyVeOHR27zeKmO2", "(99) 99999-9991", false, "e3562644-b938-476c-86d6-13b8bd374281", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(2581), "john" },
                    { new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9"), 0, "7d298ae9-c51a-440a-94c9-a386dabe835f", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4620), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$KXVO7Qv0bdS6n.LAcx27Xeqkxn7S3JTLpDSyStosIl6mUUa/qIcJS", "(99) 99999-9993", false, "c9617269-1b36-4c12-8da4-c7cb9be23666", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4616), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf") },
                    { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), new Guid("96a73925-019d-42c8-8e88-28c42e730ade") },
                    { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f") },
                    { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), new Guid("f291fb87-5f54-402d-9942-0516538d3fbf") },
                    { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9") }
                });
        }
    }
}
