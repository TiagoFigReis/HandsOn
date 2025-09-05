using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Culture_Normalized_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Cultures",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2675201a-e9a7-4f09-9098-976afbedfad1"), "677bd09d-c611-4bf1-bd25-ca51a41ff883", "Owner", "OWNER" },
                    { new Guid("4d77a15f-db2a-49ef-bacd-a6b8c846f0b9"), "c08e1d7b-19f2-435d-a5f4-f2d81106609f", "Consultant", "CONSULTANT" },
                    { new Guid("74eef395-58d7-4714-9c21-b5308434676a"), "0e33ba3c-6a05-4156-877a-3952dfbd3bfa", "Collaborator", "COLLABORATOR" },
                    { new Guid("bb0cea27-99e6-48d8-98b5-6168da06b2ca"), "ed86bdab-aabb-409b-9210-18c637bebdc4", "Admin", "ADMIN" },
                    { new Guid("d1df90a3-47f7-4a17-ad45-19cba8ba6f8f"), "ef9fd51f-f194-4ee1-8c31-7abe3bc01f72", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("84d01942-4c2b-47ac-a39b-85031b25f4a4"), 0, "f377c9c6-093e-4366-b3d9-0b310bf5bce4", new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5681), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$q0/oBtIPqF7wpv4s.ElZCuxUyLXiPSOJ9TFjPtzPGezM.22mOt6ue", "(99) 99999-9994", false, "be921645-e71c-4bae-aa63-ce723dc209cd", 0, false, new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5674), "bob" },
                    { new Guid("8f1a5ff0-910d-4a03-9788-847eed34d107"), 0, "c873efcb-2d64-4dee-bc33-3b432b0166b4", new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5684), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$LizOXe1rJ2Hedjl0LP/2le6W1bri.0Bv3R2/HR5LvhA9UwZqEfY6m", "(99) 99999-9995", false, "1a4d26ae-f35e-4935-a869-eeabc50bf76c", 0, false, new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5682), "charlie" },
                    { new Guid("9bfa492b-b30c-4cf2-8eb2-7fcf0e3fa981"), 0, "8e16ca06-6af7-4637-b106-c80c86c3d759", new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5674), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$q7MBrIQmIk8EIzVnb8rpHuN5J8wWNvqD6xFe/Q5bsJh8A8kjPKZ8O", "(99) 99999-9993", false, "482b3e0a-1568-42a3-90ba-cb03e7584800", 0, false, new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5672), "alice" },
                    { new Guid("a523ea01-68a4-4b7f-b406-5453c49d9356"), 0, "c556a8dd-7b08-421e-8071-72bf1e5a5357", new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5671), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$2WIzYK587TYqFcqVLS9PfurDpvpHyun/qqN4b1/DSif/hzPAWkW8K", "(99) 99999-9992", false, "78ba8ad7-e60f-4d98-8a53-b481f529a9f4", 0, false, new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5662), "jane" },
                    { new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3"), 0, "e554be24-c867-4746-9862-d7fdf01e454f", new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(5507), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$AwHWz/U/bMs6Q4hTr8PWFOXxzflHSxUXS8W49QCNwZ.oxQNR6qUQu", "(99) 99999-9991", false, "8218786a-72fb-4b5b-ac15-c78edfbed289", 0, false, new DateTime(2025, 8, 6, 9, 41, 2, 337, DateTimeKind.Local).AddTicks(4202), "john" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                columns: new[] { "NormalizedName", "UpdatedAt" },
                values: new object[] { "", new DateTime(2025, 8, 6, 9, 41, 3, 102, DateTimeKind.Local).AddTicks(8175) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d1df90a3-47f7-4a17-ad45-19cba8ba6f8f"), new Guid("84d01942-4c2b-47ac-a39b-85031b25f4a4") },
                    { new Guid("74eef395-58d7-4714-9c21-b5308434676a"), new Guid("8f1a5ff0-910d-4a03-9788-847eed34d107") },
                    { new Guid("4d77a15f-db2a-49ef-bacd-a6b8c846f0b9"), new Guid("9bfa492b-b30c-4cf2-8eb2-7fcf0e3fa981") },
                    { new Guid("2675201a-e9a7-4f09-9098-976afbedfad1"), new Guid("a523ea01-68a4-4b7f-b406-5453c49d9356") },
                    { new Guid("bb0cea27-99e6-48d8-98b5-6168da06b2ca"), new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("05b0e091-18c0-4b2a-8003-b2886ffcf59a"), new DateTime(2025, 8, 6, 12, 41, 3, 128, DateTimeKind.Utc).AddTicks(9672), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 6, 12, 41, 3, 128, DateTimeKind.Utc).AddTicks(9672), new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3") },
                    { new Guid("dddfe759-c00d-46d1-9942-004a84d77223"), new DateTime(2025, 8, 6, 12, 41, 3, 128, DateTimeKind.Utc).AddTicks(8198), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 6, 12, 41, 3, 128, DateTimeKind.Utc).AddTicks(8489), new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d1df90a3-47f7-4a17-ad45-19cba8ba6f8f"), new Guid("84d01942-4c2b-47ac-a39b-85031b25f4a4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("74eef395-58d7-4714-9c21-b5308434676a"), new Guid("8f1a5ff0-910d-4a03-9788-847eed34d107") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d77a15f-db2a-49ef-bacd-a6b8c846f0b9"), new Guid("9bfa492b-b30c-4cf2-8eb2-7fcf0e3fa981") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2675201a-e9a7-4f09-9098-976afbedfad1"), new Guid("a523ea01-68a4-4b7f-b406-5453c49d9356") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bb0cea27-99e6-48d8-98b5-6168da06b2ca"), new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("05b0e091-18c0-4b2a-8003-b2886ffcf59a"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("dddfe759-c00d-46d1-9942-004a84d77223"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2675201a-e9a7-4f09-9098-976afbedfad1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d77a15f-db2a-49ef-bacd-a6b8c846f0b9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74eef395-58d7-4714-9c21-b5308434676a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb0cea27-99e6-48d8-98b5-6168da06b2ca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1df90a3-47f7-4a17-ad45-19cba8ba6f8f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84d01942-4c2b-47ac-a39b-85031b25f4a4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f1a5ff0-910d-4a03-9788-847eed34d107"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bfa492b-b30c-4cf2-8eb2-7fcf0e3fa981"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a523ea01-68a4-4b7f-b406-5453c49d9356"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea5c4e8-aea3-4432-92c7-efdcd1aed6d3"));

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Cultures");

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
    }
}
