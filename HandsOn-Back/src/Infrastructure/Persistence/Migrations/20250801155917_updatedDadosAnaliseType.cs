using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedDadosAnaliseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("21254350-68e6-4017-b70e-3b351ab691d5"), new Guid("552844bc-1c96-4564-951b-e6fc7d57bfb4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f2a469b0-a2ca-4073-8e3f-ae205ee3d6e8"), new Guid("7943911e-b0ee-4781-acfb-dcd6322cb675") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5df32bc9-ec07-4792-b1fd-1bc2ce9db85a"), new Guid("90209dd5-9e13-44bf-a0dd-a2e426ff3be3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8033d43-ea69-4eaa-a30c-3fc5da8dd74c"), new Guid("d866b167-2563-4562-97a7-9f40f739b79d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("40db5286-9fa2-4a30-aa85-bd8919bd6820"), new Guid("e41937b6-50e5-4e04-9436-e0b2abf1a71e") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21254350-68e6-4017-b70e-3b351ab691d5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("40db5286-9fa2-4a30-aa85-bd8919bd6820"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5df32bc9-ec07-4792-b1fd-1bc2ce9db85a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8033d43-ea69-4eaa-a30c-3fc5da8dd74c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2a469b0-a2ca-4073-8e3f-ae205ee3d6e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("552844bc-1c96-4564-951b-e6fc7d57bfb4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7943911e-b0ee-4781-acfb-dcd6322cb675"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("90209dd5-9e13-44bf-a0dd-a2e426ff3be3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d866b167-2563-4562-97a7-9f40f739b79d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e41937b6-50e5-4e04-9436-e0b2abf1a71e"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("21254350-68e6-4017-b70e-3b351ab691d5"), "bb5a38c1-e6c4-4370-8b72-217a61f85a18", "Owner", "OWNER" },
                    { new Guid("40db5286-9fa2-4a30-aa85-bd8919bd6820"), "db3dbdc9-82f4-4918-b278-869e8e3f575c", "Manager", "MANAGER" },
                    { new Guid("5df32bc9-ec07-4792-b1fd-1bc2ce9db85a"), "c2d94c81-b880-43f8-b711-be599bbcafce", "Consultant", "CONSULTANT" },
                    { new Guid("c8033d43-ea69-4eaa-a30c-3fc5da8dd74c"), "0c8b1c6f-554d-41da-817e-d8187781501c", "Collaborator", "COLLABORATOR" },
                    { new Guid("f2a469b0-a2ca-4073-8e3f-ae205ee3d6e8"), "78156d64-2e36-4a5f-94eb-9997b4ac65b1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("552844bc-1c96-4564-951b-e6fc7d57bfb4"), 0, "3d42353d-bfc8-4e17-8a98-e433691ed83a", new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2556), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$NHw6/kHeIGWhMZfUYp/za.HAilL9DMU3kK2MN58t9.JjuTRiYXUhG", "(99) 99999-9992", false, "ea6aab59-b5ee-4dc0-87a6-29d1815f4d70", 0, false, new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2539), "jane" },
                    { new Guid("7943911e-b0ee-4781-acfb-dcd6322cb675"), 0, "f55310ca-d9a7-44ae-b0f4-3992fd19c854", new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2300), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$c4kJqFlZ9p9iKeoM50TExOsMZURV64oEHPAbzyr2vJMvffQNi8hga", "(99) 99999-9991", false, "40a4333d-bc47-4ec7-ad34-2fcbe5b17bc0", 0, false, new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(561), "john" },
                    { new Guid("90209dd5-9e13-44bf-a0dd-a2e426ff3be3"), 0, "fa115a5e-0a3c-4bdb-8411-462b356ba83f", new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2561), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$x/WvTC6eu7g7aLBhr4PeTOgwSqf1Vt0EHQ.SMANvmyxeOZxT/X4mu", "(99) 99999-9993", false, "6feb8157-5619-43f8-a6af-76d892068620", 0, false, new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2557), "alice" },
                    { new Guid("d866b167-2563-4562-97a7-9f40f739b79d"), 0, "6710e65f-b527-459f-a8de-847b141c6e61", new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2571), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$llZzxhG4Tjbr7fJY91kia.szvRgAfs44y03WWCKxhznEV7.DXNDmu", "(99) 99999-9995", false, "9990a82c-ca2c-4277-adc9-f025d326c467", 0, false, new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2569), "charlie" },
                    { new Guid("e41937b6-50e5-4e04-9436-e0b2abf1a71e"), 0, "023de1dd-3c00-4231-aca6-7bc2de40bc1e", new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2568), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Qh5MBqGkcHQ4r7QIleh0vuDat8hZ1j0.iQMAQ5cJNa25uid/p9VKm", "(99) 99999-9994", false, "f4f6af30-3f4e-47e1-9ede-6a2423f342b7", 0, false, new DateTime(2025, 7, 31, 14, 57, 9, 81, DateTimeKind.Local).AddTicks(2561), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("21254350-68e6-4017-b70e-3b351ab691d5"), new Guid("552844bc-1c96-4564-951b-e6fc7d57bfb4") },
                    { new Guid("f2a469b0-a2ca-4073-8e3f-ae205ee3d6e8"), new Guid("7943911e-b0ee-4781-acfb-dcd6322cb675") },
                    { new Guid("5df32bc9-ec07-4792-b1fd-1bc2ce9db85a"), new Guid("90209dd5-9e13-44bf-a0dd-a2e426ff3be3") },
                    { new Guid("c8033d43-ea69-4eaa-a30c-3fc5da8dd74c"), new Guid("d866b167-2563-4562-97a7-9f40f739b79d") },
                    { new Guid("40db5286-9fa2-4a30-aa85-bd8919bd6820"), new Guid("e41937b6-50e5-4e04-9436-e0b2abf1a71e") }
                });
        }
    }
}
