using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedNitrogenFromSoilAnalysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d0c02abb-770b-4f4b-af39-41ee5db0aa3f"), new Guid("598c409b-8986-40f0-b3df-19e1cd0c97ba") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6160569e-15e7-4bd3-bb88-aa58c2bc09da"), new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9de87d70-7393-4ce3-a68f-4dfaacca10c6"), new Guid("9a4211fe-c829-4fad-b74b-98265e8cdce1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("83bfde82-dab8-4cf0-adb6-004ee83fe798"), new Guid("bc21f968-c58c-4063-aa67-fe365b5a9075") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("90c386d2-7eae-4127-8a62-9acc19d2ec71"), new Guid("c93da19f-fb40-4a70-b7c0-7259422714a5") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("4171edc5-187d-4072-b7f6-fa5b33e49099"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("f5d5881e-1a03-4b33-aebf-6a7c79617f51"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6160569e-15e7-4bd3-bb88-aa58c2bc09da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83bfde82-dab8-4cf0-adb6-004ee83fe798"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("90c386d2-7eae-4127-8a62-9acc19d2ec71"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9de87d70-7393-4ce3-a68f-4dfaacca10c6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0c02abb-770b-4f4b-af39-41ee5db0aa3f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("598c409b-8986-40f0-b3df-19e1cd0c97ba"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a4211fe-c829-4fad-b74b-98265e8cdce1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc21f968-c58c-4063-aa67-fe365b5a9075"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c93da19f-fb40-4a70-b7c0-7259422714a5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("119c7dff-94e3-4fdc-98f4-dd9329992f90"), "e5f6d260-0956-4590-a1ec-791f62ea1da8", "Admin", "ADMIN" },
                    { new Guid("2ed7d81b-1403-4242-b053-aee5cb32691c"), "cfb93757-5275-4f0f-812d-d260c4836337", "Collaborator", "COLLABORATOR" },
                    { new Guid("ab172423-b900-4d87-828a-d6fba952bc0c"), "114b0dff-5d94-4111-9b4e-c333ca2a7b93", "Manager", "MANAGER" },
                    { new Guid("b1951976-661f-4344-8213-0b5be038a2ea"), "d01e4895-5675-47a5-8cbb-4ddda232ac40", "Consultant", "CONSULTANT" },
                    { new Guid("d6cb9122-5c68-44b1-8864-238594674949"), "8b161bc9-3915-429f-b125-f0a1d0c648f2", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("224ff668-7628-4436-b522-2bb85e193851"), 0, "e04a143c-dcd1-4780-a36b-13fc4fdadda2", new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4583), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$Zi7j/MDqqVqs8Ii9Ka/UsOjfMqvly7XnxnSqe7hBBhmA/y6rub912", "(99) 99999-9991", false, "86418725-4f6f-4599-8098-a816157b41b3", 0, false, new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(2543), "john" },
                    { new Guid("5325e4cd-0734-4a44-86f0-e4b01e5db006"), 0, "7b9ee371-1b60-4c13-b61c-1d0c6c92b579", new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4860), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$sfTIQXGVEsBzGOXp9EwEkef3qS./sLwzrYuvcortRihaMoskf8ZNW", "(99) 99999-9993", false, "981cb83f-fa22-4ba2-886e-f4808bc16813", 0, false, new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4856), "alice" },
                    { new Guid("96d814cb-7e5b-4ba8-afcd-b0bce565f2a0"), 0, "b9b6db63-2c57-4c66-9153-498369b00639", new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4864), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$4bXCnDwyArwOfVQho01.c.xUkUKtv6tjrECxPIcx6ap/i7NdCfVtK", "(99) 99999-9994", false, "fa2e34a8-c880-4850-841e-e9da55069baf", 0, false, new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4861), "bob" },
                    { new Guid("b29005b7-a27a-40b0-a3f6-e1256843cc37"), 0, "c1cacce5-ca14-4bbb-86c1-365e126bb970", new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4872), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$vs.6ksPyUD1.i8/joGX0BOITwsz/ZQQFRRDaVVBFdINLm1BDQDWa2", "(99) 99999-9995", false, "f339fede-ba8e-4b6f-99e5-de71d435b615", 0, false, new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4864), "charlie" },
                    { new Guid("e008325f-f83c-489b-913a-bde35fcdf91f"), 0, "5cd7bcff-ab6d-42f3-b78e-5be2fb090a53", new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4855), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$buRAXH1XtZrWfUnHSjeDW..oqCaobFhzoD1NRrFKD7Hp4t1GJsZya", "(99) 99999-9992", false, "d23af3a0-4419-4e12-862a-38432fbb6416", 0, false, new DateTime(2025, 8, 7, 8, 4, 29, 921, DateTimeKind.Local).AddTicks(4837), "jane" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 7, 8, 4, 30, 669, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("119c7dff-94e3-4fdc-98f4-dd9329992f90"), new Guid("224ff668-7628-4436-b522-2bb85e193851") },
                    { new Guid("b1951976-661f-4344-8213-0b5be038a2ea"), new Guid("5325e4cd-0734-4a44-86f0-e4b01e5db006") },
                    { new Guid("ab172423-b900-4d87-828a-d6fba952bc0c"), new Guid("96d814cb-7e5b-4ba8-afcd-b0bce565f2a0") },
                    { new Guid("2ed7d81b-1403-4242-b053-aee5cb32691c"), new Guid("b29005b7-a27a-40b0-a3f6-e1256843cc37") },
                    { new Guid("d6cb9122-5c68-44b1-8864-238594674949"), new Guid("e008325f-f83c-489b-913a-bde35fcdf91f") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("bc89cb00-c066-4098-a676-fade1a0a8e5e"), new DateTime(2025, 8, 7, 11, 4, 30, 708, DateTimeKind.Utc).AddTicks(9116), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 7, 11, 4, 30, 708, DateTimeKind.Utc).AddTicks(9116), new Guid("224ff668-7628-4436-b522-2bb85e193851") },
                    { new Guid("db708ea4-956b-4fd4-9fe6-e8fe8e2da7f6"), new DateTime(2025, 8, 7, 11, 4, 30, 708, DateTimeKind.Utc).AddTicks(7092), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 7, 11, 4, 30, 708, DateTimeKind.Utc).AddTicks(7342), new Guid("224ff668-7628-4436-b522-2bb85e193851") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("119c7dff-94e3-4fdc-98f4-dd9329992f90"), new Guid("224ff668-7628-4436-b522-2bb85e193851") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b1951976-661f-4344-8213-0b5be038a2ea"), new Guid("5325e4cd-0734-4a44-86f0-e4b01e5db006") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab172423-b900-4d87-828a-d6fba952bc0c"), new Guid("96d814cb-7e5b-4ba8-afcd-b0bce565f2a0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2ed7d81b-1403-4242-b053-aee5cb32691c"), new Guid("b29005b7-a27a-40b0-a3f6-e1256843cc37") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d6cb9122-5c68-44b1-8864-238594674949"), new Guid("e008325f-f83c-489b-913a-bde35fcdf91f") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("bc89cb00-c066-4098-a676-fade1a0a8e5e"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("db708ea4-956b-4fd4-9fe6-e8fe8e2da7f6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("119c7dff-94e3-4fdc-98f4-dd9329992f90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ed7d81b-1403-4242-b053-aee5cb32691c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab172423-b900-4d87-828a-d6fba952bc0c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1951976-661f-4344-8213-0b5be038a2ea"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6cb9122-5c68-44b1-8864-238594674949"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("224ff668-7628-4436-b522-2bb85e193851"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5325e4cd-0734-4a44-86f0-e4b01e5db006"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96d814cb-7e5b-4ba8-afcd-b0bce565f2a0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b29005b7-a27a-40b0-a3f6-e1256843cc37"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e008325f-f83c-489b-913a-bde35fcdf91f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6160569e-15e7-4bd3-bb88-aa58c2bc09da"), "7e6b4a1e-5add-4db0-ae70-92bc8bbfc77e", "Admin", "ADMIN" },
                    { new Guid("83bfde82-dab8-4cf0-adb6-004ee83fe798"), "1ccddc6b-a876-48c6-a3c8-565208f85366", "Collaborator", "COLLABORATOR" },
                    { new Guid("90c386d2-7eae-4127-8a62-9acc19d2ec71"), "e406630e-8a2d-489f-a294-b288ef1aa749", "Owner", "OWNER" },
                    { new Guid("9de87d70-7393-4ce3-a68f-4dfaacca10c6"), "0cb719a6-bc58-4996-aac6-b08a2f505b3a", "Consultant", "CONSULTANT" },
                    { new Guid("d0c02abb-770b-4f4b-af39-41ee5db0aa3f"), "498abd36-f981-402f-af80-81d82200a43b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("598c409b-8986-40f0-b3df-19e1cd0c97ba"), 0, "2012b677-3b47-48da-8202-21272217c98e", new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1882), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$SZj8l.21xZJ9FlZ.o7NvTuEh4xPc3jN3aqxpGP4Rb3WnwkVzbLtZq", "(99) 99999-9994", false, "81e04e1c-67f9-4a80-930a-172808ee5746", 0, false, new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1874), "bob" },
                    { new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d"), 0, "2bb3e4da-aa32-4dda-acf0-583e819b8da8", new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1588), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$RslxNQHQ9JmVCqYlQII2i.SvsWYjzFSiVxGtPyzYPRonGmQ8pmgB2", "(99) 99999-9991", false, "46508511-0060-4992-918c-b533ee3220ae", 0, false, new DateTime(2025, 8, 7, 7, 34, 44, 302, DateTimeKind.Local).AddTicks(9584), "john" },
                    { new Guid("9a4211fe-c829-4fad-b74b-98265e8cdce1"), 0, "b584168f-110e-41c5-867d-882e6b69e6f9", new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1873), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$5CivxRfE2ujRRu1GB4KNl.WDS2EigwjA2XhN0S38uUjHi/tSf2xQu", "(99) 99999-9993", false, "03a135c7-bfb7-4e67-ab9b-c5749d1adaa3", 0, false, new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1869), "alice" },
                    { new Guid("bc21f968-c58c-4063-aa67-fe365b5a9075"), 0, "000b1749-f0f8-4626-859e-17b6103654e7", new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1885), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$aArfhVzKWBJA5eZTutVlpeD3t9YRNQUe.RDfJukVq3p2USNOweiPu", "(99) 99999-9995", false, "840b5a1d-647a-4c59-9890-721d00e7bb9d", 0, false, new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1882), "charlie" },
                    { new Guid("c93da19f-fb40-4a70-b7c0-7259422714a5"), 0, "5b8768b4-45cf-466c-96d1-1b516b5287af", new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1869), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$jzqLINB0anp86nk3PiQuve80mJEzGSnchqjcSBAf0xwCX3ERZm/mG", "(99) 99999-9992", false, "137c4e10-fc4c-4594-a3e0-a8631d739222", 0, false, new DateTime(2025, 8, 7, 7, 34, 44, 303, DateTimeKind.Local).AddTicks(1849), "jane" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 7, 7, 34, 45, 176, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d0c02abb-770b-4f4b-af39-41ee5db0aa3f"), new Guid("598c409b-8986-40f0-b3df-19e1cd0c97ba") },
                    { new Guid("6160569e-15e7-4bd3-bb88-aa58c2bc09da"), new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d") },
                    { new Guid("9de87d70-7393-4ce3-a68f-4dfaacca10c6"), new Guid("9a4211fe-c829-4fad-b74b-98265e8cdce1") },
                    { new Guid("83bfde82-dab8-4cf0-adb6-004ee83fe798"), new Guid("bc21f968-c58c-4063-aa67-fe365b5a9075") },
                    { new Guid("90c386d2-7eae-4127-8a62-9acc19d2ec71"), new Guid("c93da19f-fb40-4a70-b7c0-7259422714a5") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4171edc5-187d-4072-b7f6-fa5b33e49099"), new DateTime(2025, 8, 7, 10, 34, 45, 226, DateTimeKind.Utc).AddTicks(8850), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 7, 10, 34, 45, 226, DateTimeKind.Utc).AddTicks(9139), new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d") },
                    { new Guid("f5d5881e-1a03-4b33-aebf-6a7c79617f51"), new DateTime(2025, 8, 7, 10, 34, 45, 227, DateTimeKind.Utc).AddTicks(668), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 7, 10, 34, 45, 227, DateTimeKind.Utc).AddTicks(669), new Guid("65b5f4ad-cbb8-4599-a084-66aa3319ae8d") }
                });
        }
    }
}
