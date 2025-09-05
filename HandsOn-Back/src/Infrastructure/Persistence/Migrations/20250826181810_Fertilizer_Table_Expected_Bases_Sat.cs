using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fertilizer_Table_Expected_Bases_Sat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<float>(
                name: "ExpectedBasesSaturation",
                table: "FertilizerTables",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), "a1813bbb-4837-42b2-ab6c-6670819509fa", "Consultant", "CONSULTANT" },
                    { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), "e90c3be0-d9b6-4175-99ef-8b483aa11aef", "Admin", "ADMIN" },
                    { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), "d1e856b7-b513-4e11-838e-39323191d644", "Manager", "MANAGER" },
                    { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), "fa8cf61d-d2a3-4e28-988a-9de6ded3f956", "Collaborator", "COLLABORATOR" },
                    { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), "4a8226d9-0556-4623-9606-c4ceea0db4ee", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6"), 0, "b7511e86-df7f-453f-afff-6ea2ee7b1799", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3866), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Nw9DSOj7QT0yr7VigHBrU.Oa8PQULiPouHO9e6btccjvwIyJjF1Ve", "(99) 99999-9994", false, "eb669343-10ca-4ff9-9884-003b46878687", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3863), "bob" },
                    { new Guid("935db416-f736-47aa-a5c3-b96f98bcd195"), 0, "6669fdaa-e89f-45ea-afb3-51113bbacdbd", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3657), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$MDFHHwQuT8BbRSuOmqR9qOXeGlgcMmaSIenpF7M7wKSDTP/NRM7Lq", "(99) 99999-9991", false, "04d4cc10-817c-4560-932a-66844d2d5d5c", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(2228), "john" },
                    { new Guid("a6f57896-0ef3-4946-9036-9e70934b6005"), 0, "12bc27a6-be26-4948-a9a1-04dd80d30054", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3869), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$P5xunVtKaXq8pj7KuBKey.P0cxwev0L.EMm02vRoEYQ1QfUHUYU8W", "(99) 99999-9995", false, "477cfe70-03e1-4078-8b8a-7ff7a790cb29", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3867), "charlie" },
                    { new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9"), 0, "9a60cd09-ca58-47d3-8f8e-33ccc14535fe", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3853), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$34yzDMKz//uYvfpGRQUhx.NYprGRzfNlq357lAJQpuLMgpjKJV.VC", "(99) 99999-9992", false, "c8017f6a-88fd-48c9-98d1-7849a1405277", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3840), "jane" },
                    { new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9"), 0, "a8b25e01-5731-43ea-b817-424259fe1856", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3862), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$71ngCni6yCWpOWOUKXl0/ehdZsAKZFK5KYoGemDI8bO509uFKm4Vq", "(99) 99999-9993", false, "2cc960ad-9506-4c71-8325-beeaec00ef7d", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3854), "alice" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 26, 15, 18, 10, 105, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6") },
                    { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), new Guid("935db416-f736-47aa-a5c3-b96f98bcd195") },
                    { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), new Guid("a6f57896-0ef3-4946-9036-9e70934b6005") },
                    { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9") },
                    { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), new Guid("935db416-f736-47aa-a5c3-b96f98bcd195") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), new Guid("a6f57896-0ef3-4946-9036-9e70934b6005") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99537fb9-272a-4cff-87cb-a56136635590"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("935db416-f736-47aa-a5c3-b96f98bcd195"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a6f57896-0ef3-4946-9036-9e70934b6005"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9"));

            migrationBuilder.DropColumn(
                name: "ExpectedBasesSaturation",
                table: "FertilizerTables");

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
        }
    }
}
