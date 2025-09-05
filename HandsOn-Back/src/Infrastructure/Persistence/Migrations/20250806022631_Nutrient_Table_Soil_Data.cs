using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Nutrient_Table_Soil_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0c15fec0-1556-4245-8a63-cfc343c5f9aa"), new Guid("0f9403de-8f4e-4745-8ee9-e3404c878fe3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("136289e3-b6e0-4747-b350-afae18a8552b"), new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bc440105-e520-4427-b9b9-86583723abda"), new Guid("d42b02f3-92d8-470a-8f6a-32c805421de0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0079602d-40cd-4bea-af8b-356db4901f08"), new Guid("e04c4ea1-9b92-446d-bd69-d220483831a9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8fb55404-99f4-48ba-aeb3-b2e575383029"), new Guid("ed99a995-42d5-454f-8e3b-d47c0f9fda76") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("1c6ccabd-1252-42e3-b1db-6994cf026d5a"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("ea3a2cb7-9ec9-4202-bef5-a3ac74c78cd1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0079602d-40cd-4bea-af8b-356db4901f08"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c15fec0-1556-4245-8a63-cfc343c5f9aa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("136289e3-b6e0-4747-b350-afae18a8552b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fb55404-99f4-48ba-aeb3-b2e575383029"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bc440105-e520-4427-b9b9-86583723abda"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9403de-8f4e-4745-8ee9-e3404c878fe3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d42b02f3-92d8-470a-8f6a-32c805421de0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e04c4ea1-9b92-446d-bd69-d220483831a9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed99a995-42d5-454f-8e3b-d47c0f9fda76"));

            migrationBuilder.RenameColumn(
                name: "TableData",
                table: "NutrientTables",
                newName: "LeafData");

            migrationBuilder.AddColumn<string>(
                name: "SoilData",
                table: "NutrientTables",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SoilData",
                table: "NutrientTables");

            migrationBuilder.RenameColumn(
                name: "LeafData",
                table: "NutrientTables",
                newName: "TableData");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0079602d-40cd-4bea-af8b-356db4901f08"), "ca4d02d6-daa6-451e-80fc-4db8bd534714", "Consultant", "CONSULTANT" },
                    { new Guid("0c15fec0-1556-4245-8a63-cfc343c5f9aa"), "06aa3083-7e22-4cef-97c3-60296f4c4490", "Manager", "MANAGER" },
                    { new Guid("136289e3-b6e0-4747-b350-afae18a8552b"), "38f2f5fe-8c7f-4f04-aa5a-64b518fb10b7", "Admin", "ADMIN" },
                    { new Guid("8fb55404-99f4-48ba-aeb3-b2e575383029"), "a3bd28ba-0741-47e2-b09c-63aad4105593", "Owner", "OWNER" },
                    { new Guid("bc440105-e520-4427-b9b9-86583723abda"), "cd5a5e58-163e-4db8-abe7-9c1d7b2ff874", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0f9403de-8f4e-4745-8ee9-e3404c878fe3"), 0, "511616e5-fa51-4ac4-92d5-7400c1c468e0", new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1257), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$iKp6jUIcbVw7Xnjngkjtaeosed0QyObtej4g8PnR/Vy7DtjViWN0K", "(99) 99999-9994", false, "07114ef2-6a6b-4fb2-8b7a-a83020134576", 0, false, new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1254), "bob" },
                    { new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d"), 0, "d02cdd5a-d6f2-48a4-ae4d-203e7f4625ea", new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(924), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$jw.KEsjzFJ8B1dN9edOGT.59J7edijvnFzYPlGk14S3w2wPEgulo6", "(99) 99999-9991", false, "08859aed-6bb7-4a18-b5e3-9f7c36530a77", 0, false, new DateTime(2025, 8, 2, 11, 47, 9, 942, DateTimeKind.Local).AddTicks(9160), "john" },
                    { new Guid("d42b02f3-92d8-470a-8f6a-32c805421de0"), 0, "5f8df434-ca4f-497d-9455-1d3e708c7841", new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1260), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$UdNCUObM.vwHbOO2ziYmDuAwuJCDnY2KsSPBSqSZF5k5Sm6qiHkeC", "(99) 99999-9995", false, "4de248a5-7ba1-45b3-b8e0-55603a496d5b", 0, false, new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1257), "charlie" },
                    { new Guid("e04c4ea1-9b92-446d-bd69-d220483831a9"), 0, "eb9438ce-20b8-4511-bc5e-50c88efaeb35", new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1253), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$dyCNjoL8dKzAwQOzB1kmh./sEicQsq13TlX0JJgWpUquF86nzaUK.", "(99) 99999-9993", false, "40daa1af-6657-4438-959e-24b890be7e78", 0, false, new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1250), "alice" },
                    { new Guid("ed99a995-42d5-454f-8e3b-d47c0f9fda76"), 0, "e0a1daae-1868-4467-a3e4-ce637d9ee6f4", new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1249), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$bQS2iM9reYB519nzcDXt6OccnwLvtuM0JV9/hleUVEN388mhAyx8C", "(99) 99999-9992", false, "c523dbfc-ee2d-4b6d-9fab-5cf17c4415ab", 0, false, new DateTime(2025, 8, 2, 11, 47, 9, 943, DateTimeKind.Local).AddTicks(1223), "jane" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 2, 11, 47, 10, 747, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c15fec0-1556-4245-8a63-cfc343c5f9aa"), new Guid("0f9403de-8f4e-4745-8ee9-e3404c878fe3") },
                    { new Guid("136289e3-b6e0-4747-b350-afae18a8552b"), new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d") },
                    { new Guid("bc440105-e520-4427-b9b9-86583723abda"), new Guid("d42b02f3-92d8-470a-8f6a-32c805421de0") },
                    { new Guid("0079602d-40cd-4bea-af8b-356db4901f08"), new Guid("e04c4ea1-9b92-446d-bd69-d220483831a9") },
                    { new Guid("8fb55404-99f4-48ba-aeb3-b2e575383029"), new Guid("ed99a995-42d5-454f-8e3b-d47c0f9fda76") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Name", "Standard", "TableData", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1c6ccabd-1252-42e3-b1db-6994cf026d5a"), new DateTime(2025, 8, 2, 14, 47, 10, 785, DateTimeKind.Utc).AddTicks(6166), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "Tabela FE - Fontes Padrão", true, "{\"NutrientRows\":[{\"MonthRange\":6,\"NutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}]}", 1, new DateTime(2025, 8, 2, 14, 47, 10, 785, DateTimeKind.Utc).AddTicks(6166), new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d") },
                    { new Guid("ea3a2cb7-9ec9-4202-bef5-a3ac74c78cd1"), new DateTime(2025, 8, 2, 14, 47, 10, 785, DateTimeKind.Utc).AddTicks(4287), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "Tabela FE - Alta Eficiência", true, "{\"NutrientRows\":[{\"MonthRange\":6,\"NutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}]}", 1, new DateTime(2025, 8, 2, 14, 47, 10, 785, DateTimeKind.Utc).AddTicks(4593), new Guid("19277387-cc22-4089-abf0-a1aca5f5c01d") }
                });
        }
    }
}
