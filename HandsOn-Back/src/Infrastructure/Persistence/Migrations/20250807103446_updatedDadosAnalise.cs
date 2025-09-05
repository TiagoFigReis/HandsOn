using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedDadosAnalise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 6, 15, 8, 2, 190, DateTimeKind.Local).AddTicks(9462));

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
    }
}
