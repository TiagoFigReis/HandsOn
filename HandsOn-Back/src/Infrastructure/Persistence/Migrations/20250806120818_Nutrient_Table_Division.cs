using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Nutrient_Table_Division : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d443fc7-3a35-4780-ae35-d536df5781fa"), new Guid("031329d8-f3fc-49e2-b549-a92d225e0614") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a278773-fddb-4a50-be01-ef0edacce3ef"), new Guid("16b192e1-3fee-4508-9d1d-8d2cd5c7b98c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e513fb40-2b12-4d3f-b573-3be4563b88df"), new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2ee36fec-d40f-4292-9c5f-790f5cbe3e38"), new Guid("cbe12b20-c475-4e71-8830-34ba44aa8d5d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a6147d0-cc80-4f5c-af3c-60166cb0547c"), new Guid("e1250007-f5fa-412e-901d-5cda7a066763") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("48679a34-23ab-4763-9efe-a58e566ca5fc"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("622bf951-1beb-4b5b-a7bb-731897287218"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a278773-fddb-4a50-be01-ef0edacce3ef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ee36fec-d40f-4292-9c5f-790f5cbe3e38"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a6147d0-cc80-4f5c-af3c-60166cb0547c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d443fc7-3a35-4780-ae35-d536df5781fa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e513fb40-2b12-4d3f-b573-3be4563b88df"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("031329d8-f3fc-49e2-b549-a92d225e0614"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16b192e1-3fee-4508-9d1d-8d2cd5c7b98c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbe12b20-c475-4e71-8830-34ba44aa8d5d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e1250007-f5fa-412e-901d-5cda7a066763"));

            migrationBuilder.AddColumn<int>(
                name: "Division",
                table: "NutrientTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("28454785-f7f8-4966-ad06-1ce19b537d37"), "b0bd5a7b-e862-4840-9c13-de313279878f", "Consultant", "CONSULTANT" },
                    { new Guid("73b744be-876b-43fe-a265-2584200c1498"), "2a336377-5ee9-4851-929a-d7ca813de724", "Collaborator", "COLLABORATOR" },
                    { new Guid("ae733f8b-1ec5-49ef-88fb-ab2fcbc56e9f"), "c8a2d348-bf91-4042-9693-cd75021763b8", "Admin", "ADMIN" },
                    { new Guid("c7b20e15-7d74-4332-8452-83648d374a44"), "5e5a8462-5e38-43aa-a27a-37606f15f299", "Owner", "OWNER" },
                    { new Guid("f2f1b046-3023-47d7-b57f-08022d5a020c"), "106bcc60-ffb5-4d1e-b56e-ef900238c194", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("04b27642-b736-4c13-b33d-d9cb2e9ffcba"), 0, "42f0cbfe-fe55-45ef-863e-c21fd2d580a9", new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(323), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$WBWDgbn.IVrLe/.70L8gsOmgV0EnfgO5Ad7efklxWH/OiPctblMq6", "(99) 99999-9993", false, "8abd3764-319b-4ad8-8a62-c31a7117ab13", 0, false, new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(321), "alice" },
                    { new Guid("26092305-6eb1-4b29-8a56-0a72204af290"), 0, "2f197210-9b92-46b4-b91c-9bdea54b97f2", new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(151), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$kRVbA6XlbQLOmgd9rNpmtuyTUSlrL0FmMSNGxHQ6ULPFdyLeaYhAe", "(99) 99999-9991", false, "d7010e98-c4d2-4f3f-9245-a18d11f2f17d", 0, false, new DateTime(2025, 8, 6, 9, 8, 16, 792, DateTimeKind.Local).AddTicks(8475), "john" },
                    { new Guid("3ed07723-de21-42d0-979f-c892cd1bdbf7"), 0, "787fa3de-bb45-46e4-a26c-bf38334cebb9", new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(320), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$vaiAoEuNoe4WBtgAKAXOPOpmNSBVYnluB8fM2vbWEkvqHRLQEMhJy", "(99) 99999-9992", false, "a17266ca-c89c-470d-83b5-8d64e5032608", 0, false, new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(312), "jane" },
                    { new Guid("75b34a59-9106-42a4-bdd9-3b2efb085ac7"), 0, "ed0b6e30-09e3-45f4-a6fb-004cdab13a7b", new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(326), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$sUIMfZeQJ9ry1VBhRaOrHeuygunacWAwUHa3iyhgq7rfIrOCo.b72", "(99) 99999-9994", false, "0f4af8a2-5b8c-4b4c-8496-9156e437cef7", 0, false, new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(324), "bob" },
                    { new Guid("98a11a37-d0d5-43a3-a0ab-2ee5c9c1ce79"), 0, "2cfb6039-faa2-4623-8f2e-fb93dfa6a841", new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(331), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JiP6QeAykUnAQvYRVsRpHOqb2.crTRBIN77CgKRgeZR6sJD2mCxNy", "(99) 99999-9995", false, "3d94c808-faf0-43fa-97f4-0d950abdffb9", 0, false, new DateTime(2025, 8, 6, 9, 8, 16, 793, DateTimeKind.Local).AddTicks(326), "charlie" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 6, 9, 8, 17, 557, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("28454785-f7f8-4966-ad06-1ce19b537d37"), new Guid("04b27642-b736-4c13-b33d-d9cb2e9ffcba") },
                    { new Guid("ae733f8b-1ec5-49ef-88fb-ab2fcbc56e9f"), new Guid("26092305-6eb1-4b29-8a56-0a72204af290") },
                    { new Guid("c7b20e15-7d74-4332-8452-83648d374a44"), new Guid("3ed07723-de21-42d0-979f-c892cd1bdbf7") },
                    { new Guid("f2f1b046-3023-47d7-b57f-08022d5a020c"), new Guid("75b34a59-9106-42a4-bdd9-3b2efb085ac7") },
                    { new Guid("73b744be-876b-43fe-a265-2584200c1498"), new Guid("98a11a37-d0d5-43a3-a0ab-2ee5c9c1ce79") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("480bc58e-462d-445c-84fd-289b310ee1c8"), new DateTime(2025, 8, 6, 12, 8, 17, 584, DateTimeKind.Utc).AddTicks(2519), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 6, 12, 8, 17, 584, DateTimeKind.Utc).AddTicks(2777), new Guid("26092305-6eb1-4b29-8a56-0a72204af290") },
                    { new Guid("bbbc4ce6-8789-435e-a811-06025b109d9b"), new DateTime(2025, 8, 6, 12, 8, 17, 584, DateTimeKind.Utc).AddTicks(3905), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 6, 12, 8, 17, 584, DateTimeKind.Utc).AddTicks(3905), new Guid("26092305-6eb1-4b29-8a56-0a72204af290") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("28454785-f7f8-4966-ad06-1ce19b537d37"), new Guid("04b27642-b736-4c13-b33d-d9cb2e9ffcba") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ae733f8b-1ec5-49ef-88fb-ab2fcbc56e9f"), new Guid("26092305-6eb1-4b29-8a56-0a72204af290") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c7b20e15-7d74-4332-8452-83648d374a44"), new Guid("3ed07723-de21-42d0-979f-c892cd1bdbf7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f2f1b046-3023-47d7-b57f-08022d5a020c"), new Guid("75b34a59-9106-42a4-bdd9-3b2efb085ac7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("73b744be-876b-43fe-a265-2584200c1498"), new Guid("98a11a37-d0d5-43a3-a0ab-2ee5c9c1ce79") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("480bc58e-462d-445c-84fd-289b310ee1c8"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("bbbc4ce6-8789-435e-a811-06025b109d9b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("28454785-f7f8-4966-ad06-1ce19b537d37"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("73b744be-876b-43fe-a265-2584200c1498"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae733f8b-1ec5-49ef-88fb-ab2fcbc56e9f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7b20e15-7d74-4332-8452-83648d374a44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2f1b046-3023-47d7-b57f-08022d5a020c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("04b27642-b736-4c13-b33d-d9cb2e9ffcba"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26092305-6eb1-4b29-8a56-0a72204af290"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ed07723-de21-42d0-979f-c892cd1bdbf7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75b34a59-9106-42a4-bdd9-3b2efb085ac7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98a11a37-d0d5-43a3-a0ab-2ee5c9c1ce79"));

            migrationBuilder.DropColumn(
                name: "Division",
                table: "NutrientTables");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a278773-fddb-4a50-be01-ef0edacce3ef"), "28a311e5-e7a9-4e58-88d3-d4c8289d2f33", "Collaborator", "COLLABORATOR" },
                    { new Guid("2ee36fec-d40f-4292-9c5f-790f5cbe3e38"), "16f0a98a-1aaf-4e75-9285-fcd23db055fd", "Owner", "OWNER" },
                    { new Guid("3a6147d0-cc80-4f5c-af3c-60166cb0547c"), "64bdbdc1-1f45-49ed-b394-8eb5b6979c15", "Manager", "MANAGER" },
                    { new Guid("7d443fc7-3a35-4780-ae35-d536df5781fa"), "c4b58f37-915c-4b8a-a481-746518dbecb6", "Consultant", "CONSULTANT" },
                    { new Guid("e513fb40-2b12-4d3f-b573-3be4563b88df"), "fb097666-9d52-467c-93d6-426752aef16f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("031329d8-f3fc-49e2-b549-a92d225e0614"), 0, "7304b9dd-3216-43a9-af53-9d8915263e3f", new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8866), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$8r104c1hGWezQ55O9FvlVejvf7XmpBEfaFiBTer.P.K5IXaYTjtq.", "(99) 99999-9993", false, "225ee619-e8b6-414f-9312-1f9208671142", 0, false, new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8850), "alice" },
                    { new Guid("16b192e1-3fee-4508-9d1d-8d2cd5c7b98c"), 0, "1e17bce3-542a-45bb-bbd1-37a1f7d189ae", new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8872), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$MgLpmYEr5QXjlgJvXQSQveaeSdk5DKxOS8W/dGjNWi6HRu5w9mQMO", "(99) 99999-9995", false, "9ed2b56a-c6e4-41d6-8cfd-717e855ae57c", 0, false, new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8870), "charlie" },
                    { new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01"), 0, "e64736c4-5b4d-4734-94ca-4581ccdadd93", new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8670), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$mkWBlht.lPUpcg5g/KhX/eGCiYwSWRdgxgz1zvuPp9kuB50cNZ42u", "(99) 99999-9991", false, "cd98f31c-ca9e-45e0-be04-ac3eb694426d", 0, false, new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(7227), "john" },
                    { new Guid("cbe12b20-c475-4e71-8830-34ba44aa8d5d"), 0, "24f1fa3d-4e93-498b-b4d1-4dff68f2c5ea", new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8850), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$6QgENSgVQ9AMqBjGO4qZvuHjWPJSPgPPpOyJOVPO/UoAQvK87Cr3S", "(99) 99999-9992", false, "299fc160-c261-478e-bd3e-c1b9901164e3", 0, false, new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8841), "jane" },
                    { new Guid("e1250007-f5fa-412e-901d-5cda7a066763"), 0, "84c027c5-bdb0-42d0-96cf-48b22eebe41a", new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8869), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$PKTPFy1TIe0rFQTENuSWX.4O4VUJsp8VxOgAQvXl8td/cYylAcHde", "(99) 99999-9994", false, "f25a34a0-7143-4d58-a0b7-838b98e1c8b5", 0, false, new DateTime(2025, 8, 5, 23, 26, 30, 272, DateTimeKind.Local).AddTicks(8867), "bob" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 5, 23, 26, 31, 105, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7d443fc7-3a35-4780-ae35-d536df5781fa"), new Guid("031329d8-f3fc-49e2-b549-a92d225e0614") },
                    { new Guid("0a278773-fddb-4a50-be01-ef0edacce3ef"), new Guid("16b192e1-3fee-4508-9d1d-8d2cd5c7b98c") },
                    { new Guid("e513fb40-2b12-4d3f-b573-3be4563b88df"), new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01") },
                    { new Guid("2ee36fec-d40f-4292-9c5f-790f5cbe3e38"), new Guid("cbe12b20-c475-4e71-8830-34ba44aa8d5d") },
                    { new Guid("3a6147d0-cc80-4f5c-af3c-60166cb0547c"), new Guid("e1250007-f5fa-412e-901d-5cda7a066763") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("48679a34-23ab-4763-9efe-a58e566ca5fc"), new DateTime(2025, 8, 6, 2, 26, 31, 136, DateTimeKind.Utc).AddTicks(6665), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "{\"LeafNutrientRows\":[{\"MonthRange\":6,\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRows\":[]}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 6, 2, 26, 31, 136, DateTimeKind.Utc).AddTicks(6837), new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01") },
                    { new Guid("622bf951-1beb-4b5b-a7bb-731897287218"), new DateTime(2025, 8, 6, 2, 26, 31, 136, DateTimeKind.Utc).AddTicks(8101), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "{\"LeafNutrientRows\":[{\"MonthRange\":6,\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRows\":[]}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 6, 2, 26, 31, 136, DateTimeKind.Utc).AddTicks(8102), new Guid("b64e79ec-a7ab-4fa3-9793-30632aefab01") }
                });
        }
    }
}
