using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Leaf_Soil_Nutrient_Headers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0565cf30-e4c8-4b99-ad24-a3e42f8c0669"), "9014d107-ac09-4dbc-9e99-7b0837e0961b", "Manager", "MANAGER" },
                    { new Guid("3923a968-afad-4f2f-a90a-6c2aa814983a"), "42f1ad21-7fa4-4873-85f5-618b11a49e29", "Admin", "ADMIN" },
                    { new Guid("79dc683c-d307-40ec-9c15-990a70101193"), "73f188f8-db9e-4acf-a9c4-31977eff4b02", "Collaborator", "COLLABORATOR" },
                    { new Guid("b3745783-92f8-412b-9730-e9832876b842"), "79e7aac2-dcb6-4ae8-b9f5-804f3f8efc9b", "Owner", "OWNER" },
                    { new Guid("b461d7d0-49d8-4aeb-a593-b34fb2b95c04"), "ea40ea13-55a8-49a8-9d07-fdd8c978caca", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("075db71d-f8e5-4196-bbe0-1bbbc46aa18d"), 0, "4bce13cd-881f-4f43-b4f8-45367ed40916", new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7690), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$GY3WszX8O4PPPALPJ5AUgeRMgbagjfCY7HCIltRaJBs.4zuEqp4fW", "(99) 99999-9995", false, "da4e9388-9f83-48e5-b87d-e18abab4cc6f", 0, false, new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7684), "charlie" },
                    { new Guid("50bcda95-4cf4-454c-b886-ce08d3929274"), 0, "146c186a-51c3-401c-8091-5bf75d4198de", new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7678), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$PAu..Khf140CgmQqCwhKt.LTu/hcliLPTCefdRCO0MOqXi7oehaYG", "(99) 99999-9992", false, "3f53bef4-3765-4cd0-950f-3aa8baec904d", 0, false, new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7668), "jane" },
                    { new Guid("570ace98-c272-4fb1-bd7b-bf26e596a9e2"), 0, "d798c955-e5ca-4ed8-a7ae-c191ee6687bc", new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7681), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$EinxZS9Pw1jikW1i0jkw4eUNR.hGFnT/4/lGhotvWQ1lt1mqEXeT2", "(99) 99999-9993", false, "0fbe299d-b679-43b6-8323-46f24f0ce549", 0, false, new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7679), "alice" },
                    { new Guid("a424c16d-bae6-4bf2-ae15-9779b175f59d"), 0, "3ff6309c-a094-4515-a9f5-5a8df64707a9", new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7683), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$5Dz97oHDHVaIl8bcvUIsk.C0f73ABToNTfPsB7L64sMe8bK23U//O", "(99) 99999-9994", false, "2fa9df73-2c16-4738-a664-ec8c53d07e66", 0, false, new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7681), "bob" },
                    { new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79"), 0, "ed892256-9d79-4256-9474-5845c9dfe60f", new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(7504), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$qu.zj.B7E7zgP17og/FQFOg7C.e.de0OWwCcJce9XbWq3aFeee3rm", "(99) 99999-9991", false, "f0db1182-e044-4e52-9691-6517f48262cc", 0, false, new DateTime(2025, 8, 6, 15, 8, 1, 424, DateTimeKind.Local).AddTicks(6035), "john" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                columns: new[] { "NormalizedName", "UpdatedAt" },
                values: new object[] { "cafe", new DateTime(2025, 8, 6, 15, 8, 2, 190, DateTimeKind.Local).AddTicks(9462) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("79dc683c-d307-40ec-9c15-990a70101193"), new Guid("075db71d-f8e5-4196-bbe0-1bbbc46aa18d") },
                    { new Guid("b3745783-92f8-412b-9730-e9832876b842"), new Guid("50bcda95-4cf4-454c-b886-ce08d3929274") },
                    { new Guid("b461d7d0-49d8-4aeb-a593-b34fb2b95c04"), new Guid("570ace98-c272-4fb1-bd7b-bf26e596a9e2") },
                    { new Guid("0565cf30-e4c8-4b99-ad24-a3e42f8c0669"), new Guid("a424c16d-bae6-4bf2-ae15-9779b175f59d") },
                    { new Guid("3923a968-afad-4f2f-a90a-6c2aa814983a"), new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d78b928-8bcf-4e01-87e6-4beae619ffd0"), new DateTime(2025, 8, 6, 18, 8, 2, 219, DateTimeKind.Utc).AddTicks(7049), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 6, 18, 8, 2, 219, DateTimeKind.Utc).AddTicks(7050), new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79") },
                    { new Guid("c5601dd2-8818-489f-a54a-8a3d8825560c"), new DateTime(2025, 8, 6, 18, 8, 2, 219, DateTimeKind.Utc).AddTicks(5759), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 6, 18, 8, 2, 219, DateTimeKind.Utc).AddTicks(5928), new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("79dc683c-d307-40ec-9c15-990a70101193"), new Guid("075db71d-f8e5-4196-bbe0-1bbbc46aa18d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b3745783-92f8-412b-9730-e9832876b842"), new Guid("50bcda95-4cf4-454c-b886-ce08d3929274") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b461d7d0-49d8-4aeb-a593-b34fb2b95c04"), new Guid("570ace98-c272-4fb1-bd7b-bf26e596a9e2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0565cf30-e4c8-4b99-ad24-a3e42f8c0669"), new Guid("a424c16d-bae6-4bf2-ae15-9779b175f59d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3923a968-afad-4f2f-a90a-6c2aa814983a"), new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("4d78b928-8bcf-4e01-87e6-4beae619ffd0"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("c5601dd2-8818-489f-a54a-8a3d8825560c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0565cf30-e4c8-4b99-ad24-a3e42f8c0669"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3923a968-afad-4f2f-a90a-6c2aa814983a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79dc683c-d307-40ec-9c15-990a70101193"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3745783-92f8-412b-9730-e9832876b842"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b461d7d0-49d8-4aeb-a593-b34fb2b95c04"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("075db71d-f8e5-4196-bbe0-1bbbc46aa18d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50bcda95-4cf4-454c-b886-ce08d3929274"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("570ace98-c272-4fb1-bd7b-bf26e596a9e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a424c16d-bae6-4bf2-ae15-9779b175f59d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f9d37fbd-8af5-42b3-9a5e-f2026f34fc79"));

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
    }
}
