using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedStandardFeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9cba12a9-f552-4f68-bc2f-c29e8b6fdc7f"), new Guid("0ee10597-889f-48b4-841f-6be1c586ef84") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0d24c2d2-53cc-450b-97cc-8b641dfae392"), new Guid("2fb4f4d1-352e-4a2d-a8a6-8df66dda3fa4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef78a696-7510-411f-a00e-8bc42fa2cd8f"), new Guid("ace383a1-b1d6-4813-8424-3598a47b54e4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a69a6d06-360f-4f86-a785-68760ab72bc0"), new Guid("ad041ad5-0735-40a3-8b04-cd2e5b7e1da8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5a1daa07-c798-40ad-aba6-3750b45c15dc"), new Guid("c8864ed8-55bb-4c13-b9e2-7cd13b275495") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d24c2d2-53cc-450b-97cc-8b641dfae392"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a1daa07-c798-40ad-aba6-3750b45c15dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9cba12a9-f552-4f68-bc2f-c29e8b6fdc7f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a69a6d06-360f-4f86-a785-68760ab72bc0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef78a696-7510-411f-a00e-8bc42fa2cd8f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ee10597-889f-48b4-841f-6be1c586ef84"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fb4f4d1-352e-4a2d-a8a6-8df66dda3fa4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ace383a1-b1d6-4813-8424-3598a47b54e4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad041ad5-0735-40a3-8b04-cd2e5b7e1da8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c8864ed8-55bb-4c13-b9e2-7cd13b275495"));

            migrationBuilder.AlterColumn<string>(
                name: "TableData",
                table: "NutrientTables",
                type: "LONGTEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NutrientTables",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café", new DateTime(2025, 8, 2, 10, 52, 38, 185, DateTimeKind.Local).AddTicks(4008) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NutrientTables");

            migrationBuilder.AlterColumn<string>(
                name: "TableData",
                table: "NutrientTables",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "LONGTEXT")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0d24c2d2-53cc-450b-97cc-8b641dfae392"), "9697b13b-5fd1-4260-b412-b71184236419", "Manager", "MANAGER" },
                    { new Guid("5a1daa07-c798-40ad-aba6-3750b45c15dc"), "0ac07dda-6531-4cfe-adc6-8b8e8fcf4929", "Admin", "ADMIN" },
                    { new Guid("9cba12a9-f552-4f68-bc2f-c29e8b6fdc7f"), "6147023b-5088-4ac7-b704-78a8e3945872", "Collaborator", "COLLABORATOR" },
                    { new Guid("a69a6d06-360f-4f86-a785-68760ab72bc0"), "b027adaa-8607-420e-b3c7-627e0a1a2257", "Owner", "OWNER" },
                    { new Guid("ef78a696-7510-411f-a00e-8bc42fa2cd8f"), "be5fbd8b-613b-471c-80fc-fd83024f4e49", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0ee10597-889f-48b4-841f-6be1c586ef84"), 0, "70d333cb-5bfa-4015-9375-071bc615142e", new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5397), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$16/CEqGcD/e7g1KyziqF9OVBeD5kJWEGnsanJRVjvoFcNbfhuhkNS", "(99) 99999-9995", false, "e8d89a97-b0f4-48f3-9763-b76c0ccfca66", 0, false, new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5394), "charlie" },
                    { new Guid("2fb4f4d1-352e-4a2d-a8a6-8df66dda3fa4"), 0, "f2ff321c-8a0e-4a4c-bbb5-574fcb69a25d", new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5394), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$KKsoAWhkPKMDo0GXrFAYMejwHJDFxQdBjepcXxw6/KNzg5zByJVo6", "(99) 99999-9994", false, "309c5225-2a34-43f9-a399-3c4697df2ed5", 0, false, new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5391), "bob" },
                    { new Guid("ace383a1-b1d6-4813-8424-3598a47b54e4"), 0, "9156d4a1-4c6e-4023-aa30-43bc4efc2884", new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5390), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$ndUmJ3aCOy7KKGshSbsku.DQx8evVbqOGYSshAVQRWm7gz7COX0VS", "(99) 99999-9993", false, "75947240-492f-45b2-b0e7-2e26e7a7731f", 0, false, new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5383), "alice" },
                    { new Guid("ad041ad5-0735-40a3-8b04-cd2e5b7e1da8"), 0, "e4ea1532-d16d-4584-a006-985d6511bd87", new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5382), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$5HH21Pigd3SWMVv0B6N.du0MzbW8hJefjiB9lKhTWsEhP2l.BGZEa", "(99) 99999-9992", false, "3911da69-101e-4654-92ed-2f9d25995a53", 0, false, new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5363), "jane" },
                    { new Guid("c8864ed8-55bb-4c13-b9e2-7cd13b275495"), 0, "8b13c841-b1f7-4dbe-8b9e-8d0f029fed2c", new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(5119), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$B2iDonag00uMqyJ.qXaVUO2rB4pkgXvMbJVZ570l2fbNEAFBCUcRG", "(99) 99999-9991", false, "3b2a15ae-c15c-4c51-a6f7-c47b4fe9e10f", 0, false, new DateTime(2025, 8, 1, 12, 59, 15, 612, DateTimeKind.Local).AddTicks(3348), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9cba12a9-f552-4f68-bc2f-c29e8b6fdc7f"), new Guid("0ee10597-889f-48b4-841f-6be1c586ef84") },
                    { new Guid("0d24c2d2-53cc-450b-97cc-8b641dfae392"), new Guid("2fb4f4d1-352e-4a2d-a8a6-8df66dda3fa4") },
                    { new Guid("ef78a696-7510-411f-a00e-8bc42fa2cd8f"), new Guid("ace383a1-b1d6-4813-8424-3598a47b54e4") },
                    { new Guid("a69a6d06-360f-4f86-a785-68760ab72bc0"), new Guid("ad041ad5-0735-40a3-8b04-cd2e5b7e1da8") },
                    { new Guid("5a1daa07-c798-40ad-aba6-3750b45c15dc"), new Guid("c8864ed8-55bb-4c13-b9e2-7cd13b275495") }
                });
        }
    }
}
