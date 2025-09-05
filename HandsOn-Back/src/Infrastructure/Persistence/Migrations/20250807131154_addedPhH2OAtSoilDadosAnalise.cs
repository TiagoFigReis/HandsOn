using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedPhH2OAtSoilDadosAnalise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), "6159faaa-d131-49b5-84c6-d319b2b45e52", "Owner", "OWNER" },
                    { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), "131333c6-a6d1-43ca-8a99-1b2ca49e0871", "Manager", "MANAGER" },
                    { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), "3c0f2afe-c48b-47a9-9dbd-2fee749b3aa9", "Consultant", "CONSULTANT" },
                    { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), "89d4c643-5285-4faf-b3a1-39dfedee40bb", "Admin", "ADMIN" },
                    { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), "dce73cc2-88a7-4255-8309-1e6da93a7c1f", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("20db1d65-fb40-4e95-935c-e64d52871136"), 0, "1765411f-426e-42ac-a1ae-37e250bab11b", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1897), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$dO2mniqe4mkNc4Xwo7df.OmXVDkP/qnQhqpqYCEwnnwKszHJ40/pC", "(99) 99999-9993", false, "2c7cdbb9-ca1f-4b83-b21a-6cda4baa723d", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1889), "alice" },
                    { new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce"), 0, "7015c8d4-48a0-4b46-94b7-8951a43a0711", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1904), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$GW79apfYUpVkF1O2Wl0jeuzijNrusKyD.LKkI7YGCJD2jvZWJzWjW", "(99) 99999-9995", false, "c500bca3-da5e-411a-b950-01a13d31e188", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1901), "charlie" },
                    { new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b"), 0, "53f64e7a-ad8a-4186-a4fc-fa9d1e138bcd", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1888), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$o8VgU7q13jWhDo51Z0SB6OHJsRCp21la.ONCxM7FplIshUFe/lW4G", "(99) 99999-9992", false, "986ff782-d24d-4904-8c70-8e78dcd970dd", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1870), "jane" },
                    { new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab"), 0, "bcc06076-a60b-4b68-a143-88939193e05c", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1513), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$9HEN4IdZ6EFuZJ.N2qTsze6bEmHBoZbJ06DkEuVmIsJoSBQkCq4ma", "(99) 99999-9991", false, "523b1d4c-f604-41ed-a49f-d21df2c00752", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 447, DateTimeKind.Local).AddTicks(9724), "john" },
                    { new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c"), 0, "1c8c4eac-d2ad-4a9e-9db4-0b9767936cbb", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1900), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$4UmOxd9B9npjTpoTVaues.OIBrnZ99YG3sgVPeN2DZw8TO2TthCW.", "(99) 99999-9994", false, "9a9afd16-123a-4a6c-8c12-30e91a9f2282", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1897), "bob" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 7, 10, 11, 54, 215, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), new Guid("20db1d65-fb40-4e95-935c-e64d52871136") },
                    { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce") },
                    { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b") },
                    { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") },
                    { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4e6d9c6a-0cc9-47ed-97e1-3ceedd72faae"), new DateTime(2025, 8, 7, 13, 11, 54, 254, DateTimeKind.Utc).AddTicks(8318), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 7, 13, 11, 54, 254, DateTimeKind.Utc).AddTicks(8647), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") },
                    { new Guid("deaec80a-34c1-4193-890d-24f2dcbd2b09"), new DateTime(2025, 8, 7, 13, 11, 54, 255, DateTimeKind.Utc).AddTicks(180), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 7, 13, 11, 54, 255, DateTimeKind.Utc).AddTicks(181), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), new Guid("20db1d65-fb40-4e95-935c-e64d52871136") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("4e6d9c6a-0cc9-47ed-97e1-3ceedd72faae"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("deaec80a-34c1-4193-890d-24f2dcbd2b09"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed210b5f-776e-4bdb-900d-007562377db7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("20db1d65-fb40-4e95-935c-e64d52871136"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c"));

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
    }
}
