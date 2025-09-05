using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedTypeToNutrientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("feb7381b-1d6a-46a1-bb2b-1c95c53f1bd3"), new Guid("717a2c0f-0408-4660-b623-42770b2f63cd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef33bdad-7710-495e-be32-75af4ee15604"), new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4950693e-1715-45eb-a523-e0f000bd49d4"), new Guid("9f2af753-06a8-4f5b-b1ed-577a9e8df77a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("452c717a-ac2a-425e-897d-8047460d5548"), new Guid("c0284cd8-3a0f-4424-9f7e-227839a024a6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bdfd266c-0a5e-4581-8667-497b37714a6c"), new Guid("e32bbd99-c87f-467f-ad66-418abf22de00") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("26e3bc83-bfc1-4fe0-8b42-2eb76f7a88cc"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("8301c77b-7b70-499f-9a5a-941e8196e02a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("452c717a-ac2a-425e-897d-8047460d5548"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4950693e-1715-45eb-a523-e0f000bd49d4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bdfd266c-0a5e-4581-8667-497b37714a6c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef33bdad-7710-495e-be32-75af4ee15604"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("feb7381b-1d6a-46a1-bb2b-1c95c53f1bd3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("717a2c0f-0408-4660-b623-42770b2f63cd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9f2af753-06a8-4f5b-b1ed-577a9e8df77a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0284cd8-3a0f-4424-9f7e-227839a024a6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e32bbd99-c87f-467f-ad66-418abf22de00"));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "NutrientTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "NutrientTables");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("452c717a-ac2a-425e-897d-8047460d5548"), "f5b19a91-0a3d-447c-81a8-f205531d4c1d", "Collaborator", "COLLABORATOR" },
                    { new Guid("4950693e-1715-45eb-a523-e0f000bd49d4"), "644f0673-a3a8-4c6d-950d-efd893dbdfe7", "Consultant", "CONSULTANT" },
                    { new Guid("bdfd266c-0a5e-4581-8667-497b37714a6c"), "2635ea05-9fd6-4b02-8d8c-a312e6d17100", "Manager", "MANAGER" },
                    { new Guid("ef33bdad-7710-495e-be32-75af4ee15604"), "d1100330-5a99-43ba-ab9f-2806e0cb6fc4", "Admin", "ADMIN" },
                    { new Guid("feb7381b-1d6a-46a1-bb2b-1c95c53f1bd3"), "0382fcc3-adfa-45b0-b588-f21fa458a086", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("717a2c0f-0408-4660-b623-42770b2f63cd"), 0, "9bb3b8d5-2515-4d45-8137-3cc229ce22d9", new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6235), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Q3m8lxrfdpt19K2mBJbRb.irSXJj20PWa2qkgh1RqXFT755voqDFi", "(99) 99999-9992", false, "a87ebaa9-ff3a-42af-ae1f-6652a1fd4372", 0, false, new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6217), "jane" },
                    { new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0"), 0, "848329f7-1db2-4d88-b233-fc08351708e7", new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(5922), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$ggwNoxZ0kqZhCAD4PSaAQO7atoD.ok.QOlpvbXnl77tMfCTovTeIK", "(99) 99999-9991", false, "5a638325-1171-4953-88a7-dc3ab297c451", 0, false, new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(4195), "john" },
                    { new Guid("9f2af753-06a8-4f5b-b1ed-577a9e8df77a"), 0, "0c9dc41e-273e-4469-b856-7f42fda0ea4c", new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6240), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$1aC3/tILscZYsHwmVHlBi.UN.XmBgyNJTa38mGJDLqjU/YHI/wPiO", "(99) 99999-9993", false, "15e5b13e-d686-4533-89d7-d88591a830b9", 0, false, new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6236), "alice" },
                    { new Guid("c0284cd8-3a0f-4424-9f7e-227839a024a6"), 0, "e00d39b3-51cd-4de8-b432-cbad0dbc33a4", new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6251), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$VOKPOw1tZ7Pt9VZqx5LFOeWRUJtCAgCjMOmlF24JWLmRWV10XOUCC", "(99) 99999-9995", false, "5f9720fa-25f5-465d-9bde-e050a926b14f", 0, false, new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6249), "charlie" },
                    { new Guid("e32bbd99-c87f-467f-ad66-418abf22de00"), 0, "170f8e5b-a55c-4d21-8f1c-0ac1c4ee65ef", new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6248), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Q9Uhf5k0ZFG2igWqM9gbQO51puyaoBg/dvkfAlYcSQOxJB9qL1LJ2", "(99) 99999-9994", false, "77a82a36-0132-415e-9804-8a985c86bfff", 0, false, new DateTime(2025, 8, 2, 10, 52, 37, 420, DateTimeKind.Local).AddTicks(6241), "bob" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 2, 10, 52, 38, 185, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("feb7381b-1d6a-46a1-bb2b-1c95c53f1bd3"), new Guid("717a2c0f-0408-4660-b623-42770b2f63cd") },
                    { new Guid("ef33bdad-7710-495e-be32-75af4ee15604"), new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0") },
                    { new Guid("4950693e-1715-45eb-a523-e0f000bd49d4"), new Guid("9f2af753-06a8-4f5b-b1ed-577a9e8df77a") },
                    { new Guid("452c717a-ac2a-425e-897d-8047460d5548"), new Guid("c0284cd8-3a0f-4424-9f7e-227839a024a6") },
                    { new Guid("bdfd266c-0a5e-4581-8667-497b37714a6c"), new Guid("e32bbd99-c87f-467f-ad66-418abf22de00") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Name", "Standard", "TableData", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("26e3bc83-bfc1-4fe0-8b42-2eb76f7a88cc"), new DateTime(2025, 8, 2, 13, 52, 38, 222, DateTimeKind.Utc).AddTicks(5735), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "Tabela FE - Fontes Padrão", true, "{\"NutrientRows\":[{\"MonthRange\":6,\"NutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}]}", new DateTime(2025, 8, 2, 13, 52, 38, 222, DateTimeKind.Utc).AddTicks(5736), new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0") },
                    { new Guid("8301c77b-7b70-499f-9a5a-941e8196e02a"), new DateTime(2025, 8, 2, 13, 52, 38, 222, DateTimeKind.Utc).AddTicks(4131), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), "Tabela FE - Alta Eficiência", true, "{\"NutrientRows\":[{\"MonthRange\":6,\"NutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}]}", new DateTime(2025, 8, 2, 13, 52, 38, 222, DateTimeKind.Utc).AddTicks(4417), new Guid("7c234ef1-5aa3-49e8-99b5-6fd246f278d0") }
                });
        }
    }
}
