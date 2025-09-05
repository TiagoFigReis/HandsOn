using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fertilizer_Table_Remodelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), new Guid("263ef84e-d882-4819-85ec-1311de268273") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("263ef84e-d882-4819-85ec-1311de268273"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4"));

            migrationBuilder.AddColumn<bool>(
                name: "Standard",
                table: "FertilizerTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FertilizerTables",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4c4c2eaa-4689-4d1f-9c1a-2a4a8cb36aa4"), "b98b8a55-5aaf-41e0-a20c-644b9060d3c6", "Manager", "MANAGER" },
                    { new Guid("5e9273e4-f06f-4d48-b549-ae2173a4ab41"), "3c2661b1-22e7-43f5-84ab-2318ef460113", "Admin", "ADMIN" },
                    { new Guid("aa7490be-7745-4687-a9e2-dfb95cf068a6"), "84c5a886-af56-45e5-96a6-8b683be74331", "Collaborator", "COLLABORATOR" },
                    { new Guid("ef219ec4-812a-448d-973e-6ef2a52111ce"), "d87a50e3-da59-483e-9aae-4296fe329df6", "Owner", "OWNER" },
                    { new Guid("fb28b206-1076-43d9-b51c-222f187ae75a"), "7399b61a-baab-4571-bad3-ce25a7f1b7af", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("1031ded5-633a-4efe-8ae3-28b3ccb4127c"), 0, "4e0c3345-9d31-4679-8b4e-21a5460a8190", new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1598), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$HlyMVjAfI2y155VjCKDUG.3Ra.0sV/LxEvTvYi5b0v7/OkW8ixn1e", "(99) 99999-9991", false, "6cffb58d-b642-4d65-b376-1d27ca86a06e", 0, false, new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(206), "john" },
                    { new Guid("82d8ca60-1e93-4d04-94e4-6fb7e1f1aec7"), 0, "b46ad9b3-1650-4945-b789-fc75b41fff61", new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1811), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$Rq6JbUDYUcznA183xdogb.nMsC7McHub/0APnjQ9tgpR8HaepkPs.", "(99) 99999-9995", false, "fb1dd4fb-1818-401b-86bc-b26dee3d7c14", 0, false, new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1808), "charlie" },
                    { new Guid("8ac84508-ccbd-4222-90e9-129626288ab9"), 0, "d86e8ebc-59b7-45a5-bc59-ab2b807af96d", new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1801), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$2rx6H/Goh4oeFk1c3eDjFePWZNZZf2mWBvYsqwydNJERlCEWikDoO", "(99) 99999-9992", false, "a7fff78d-e057-4cc3-85dd-ba69d02704ac", 0, false, new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1784), "jane" },
                    { new Guid("941c7f33-352c-4f94-afd6-45ee8c25d7b3"), 0, "fd89ea24-7747-47b1-924f-4b24f2f31b1f", new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1808), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$cgSJFnxdQmtaTqJwwNkkrepvQmWU5BaS0rnL7TEk8ITE9kfK9IwQu", "(99) 99999-9994", false, "b2c6c52d-bfcd-4f14-9f94-acd169ccc26a", 0, false, new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1805), "bob" },
                    { new Guid("a55bb64c-d075-4ff0-b548-a24580936ec9"), 0, "0a8c3fd3-d164-4c09-9dec-fd610ee201bc", new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1804), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$rr4lSbYYlzxOXHchgvSpweauha6ah5g4fh3BIY7R45p7TYGTk5fXO", "(99) 99999-9993", false, "c049f1b4-0cad-4f0d-b4ae-e354b880b0d0", 0, false, new DateTime(2025, 8, 23, 8, 18, 19, 799, DateTimeKind.Local).AddTicks(1802), "alice" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 23, 8, 18, 20, 554, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e9273e4-f06f-4d48-b549-ae2173a4ab41"), new Guid("1031ded5-633a-4efe-8ae3-28b3ccb4127c") },
                    { new Guid("aa7490be-7745-4687-a9e2-dfb95cf068a6"), new Guid("82d8ca60-1e93-4d04-94e4-6fb7e1f1aec7") },
                    { new Guid("ef219ec4-812a-448d-973e-6ef2a52111ce"), new Guid("8ac84508-ccbd-4222-90e9-129626288ab9") },
                    { new Guid("4c4c2eaa-4689-4d1f-9c1a-2a4a8cb36aa4"), new Guid("941c7f33-352c-4f94-afd6-45ee8c25d7b3") },
                    { new Guid("fb28b206-1076-43d9-b51c-222f187ae75a"), new Guid("a55bb64c-d075-4ff0-b548-a24580936ec9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerTables_UserId",
                table: "FertilizerTables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerTables_AspNetUsers_UserId",
                table: "FertilizerTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerTables_AspNetUsers_UserId",
                table: "FertilizerTables");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerTables_UserId",
                table: "FertilizerTables");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e9273e4-f06f-4d48-b549-ae2173a4ab41"), new Guid("1031ded5-633a-4efe-8ae3-28b3ccb4127c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("aa7490be-7745-4687-a9e2-dfb95cf068a6"), new Guid("82d8ca60-1e93-4d04-94e4-6fb7e1f1aec7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef219ec4-812a-448d-973e-6ef2a52111ce"), new Guid("8ac84508-ccbd-4222-90e9-129626288ab9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4c4c2eaa-4689-4d1f-9c1a-2a4a8cb36aa4"), new Guid("941c7f33-352c-4f94-afd6-45ee8c25d7b3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fb28b206-1076-43d9-b51c-222f187ae75a"), new Guid("a55bb64c-d075-4ff0-b548-a24580936ec9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c4c2eaa-4689-4d1f-9c1a-2a4a8cb36aa4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e9273e4-f06f-4d48-b549-ae2173a4ab41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa7490be-7745-4687-a9e2-dfb95cf068a6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef219ec4-812a-448d-973e-6ef2a52111ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb28b206-1076-43d9-b51c-222f187ae75a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1031ded5-633a-4efe-8ae3-28b3ccb4127c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("82d8ca60-1e93-4d04-94e4-6fb7e1f1aec7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8ac84508-ccbd-4222-90e9-129626288ab9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("941c7f33-352c-4f94-afd6-45ee8c25d7b3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a55bb64c-d075-4ff0-b548-a24580936ec9"));

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "FertilizerTables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FertilizerTables");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), "8bbdc0bf-82fb-436b-b531-eaa3d16da31f", "Consultant", "CONSULTANT" },
                    { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), "d36b53fd-f8b1-4006-a9a5-9f1feaefb0bb", "Manager", "MANAGER" },
                    { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), "c4fd2c74-feb3-4186-8198-2af38defbc0d", "Owner", "OWNER" },
                    { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), "99436396-4186-4b35-afbb-c0aa47e6b7e7", "Admin", "ADMIN" },
                    { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), "a37a9900-3e32-4835-b835-e60660dbcec8", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("263ef84e-d882-4819-85ec-1311de268273"), 0, "e661439c-6b1e-4faa-bfe3-cf562ab1b28f", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7430), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$MghBhXwj2MRnO3h5HQt/4.ulpIfHjxPIx.ibBr3IuFBlgXEEThnte", "(99) 99999-9994", false, "4afbbb85-9341-438e-90c4-7c81b82746d2", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7424), "bob" },
                    { new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c"), 0, "baa0b31b-4500-4fd7-9efe-ea3983eaa9ce", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7433), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$e5mNp/Wd29.CRbHlaSAUKO532mNhRGAmntR5Lz3gGTehLByChryWi", "(99) 99999-9995", false, "21751865-a8fd-44b3-8b3e-a08271b9f2df", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7431), "charlie" },
                    { new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96"), 0, "155df36a-09dd-4d27-b80e-a3a137af5f03", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7423), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$cs/JjAenjCDgTb2gR1lcyegD8TZlP4RSZ48VK91rgswxxVLeKl4Dq", "(99) 99999-9993", false, "76d06b10-e5a9-4c41-82ca-e32467510cef", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7419), "alice" },
                    { new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1"), 0, "0cfa5a35-c803-4afc-ab10-dc4ba173c9b9", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7418), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$DkQmU8.Qhl/n7twmais0vOkjstcq37cnuD4ZI3i5bLCsXbAy8.ZAm", "(99) 99999-9992", false, "807039a5-8c15-4a3c-b4aa-87de9dedde96", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7403), "jane" },
                    { new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4"), 0, "98e4902d-2e76-4dde-b3f1-43d8f5e52e12", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7200), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$5mC6TIo9nfw.44kEw2e4NORH62eXSHxTRR9S72ArZ8zYbN5YMN6Ma", "(99) 99999-9991", false, "2aed3e51-9e63-4f0f-87fd-a71a9b0cbae4", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(5783), "john" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 20, 6, 52, 51, 908, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), new Guid("263ef84e-d882-4819-85ec-1311de268273") },
                    { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c") },
                    { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96") },
                    { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1") },
                    { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4") }
                });
        }
    }
}
