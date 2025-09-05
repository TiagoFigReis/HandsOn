using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedHarvestIdAtAnaliseEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analise_Harvest_HarvestId",
                table: "Analise");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), new Guid("deb34abf-d7b7-49d8-8001-6666e5757429") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), new Guid("f759becb-176d-45e9-b23a-7b715d5c401a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16032f08-f636-4725-b33d-ce52d51aed31"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("366012e3-b13a-4836-b312-afc7025b45ab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("deb34abf-d7b7-49d8-8001-6666e5757429"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f759becb-176d-45e9-b23a-7b715d5c401a"));


            migrationBuilder.RenameColumn(
                name: "HarvestId",
                table: "Analise",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Analise_HarvestId",
                table: "Analise",
                newName: "IX_Analise_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Analise_AspNetUsers_UserId",
                table: "Analise",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analise_AspNetUsers_UserId",
                table: "Analise");

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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Analise",
                newName: "HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_Analise_UserId",
                table: "Analise",
                newName: "IX_Analise_HarvestId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), "baea9819-8938-4479-ba07-13551d2ba23a", "Collaborator", "COLLABORATOR" },
                    { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), "6202027f-b556-41e0-9b53-3b5207b105bc", "Manager", "MANAGER" },
                    { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), "dd6bfe22-ccdb-4faa-812e-80f0a05aed30", "Admin", "ADMIN" },
                    { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), "90fd25bc-95d4-47a8-b1f5-e9786b48008f", "Owner", "OWNER" },
                    { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), "62735984-8efc-4ee3-8988-72341d88b3cb", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797"), 0, "df55c81a-8113-4d36-bb1d-c4b5b7fcbdfc", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5105), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$DBTr1QVfZ3jeivt.5o8nze9edf86U4zksJdbyko4bnJhr/UHwhuiK", "(99) 99999-9992", false, "277a6c76-51e7-484f-8278-46fff7264ff4", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5088), "jane" },
                    { new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b"), 0, "6123c1e0-c8ee-43f5-a406-8618271cd6a4", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5120), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JQf8KLisiUI/hziV7q860ejkGVYYaankuf1EZSjZ9Pefm5ihMInuq", "(99) 99999-9995", false, "ace53c87-66e7-49a3-b660-bec4a559f3e6", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5114), "charlie" },
                    { new Guid("deb34abf-d7b7-49d8-8001-6666e5757429"), 0, "084e6193-a1b9-4c43-8854-d46c977d706d", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5109), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$2SLUnrB4bEy2XJRIFV0Q8.Hbc/l.Do8qmq/wts0RGlYsP5EbkjyJi", "(99) 99999-9993", false, "b9d73caa-2e17-455e-80e6-6246a6778608", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5106), "alice" },
                    { new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a"), 0, "824ba82a-68da-4e93-93a1-bd10f1de0644", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(4849), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$qMij7G9o5tjsncPyMqvf4OlkUORgfG2H9t/g9qFMCHCMPR/iPf6xK", "(99) 99999-9991", false, "0dfbbf9e-2099-4ebb-9099-a244a965b898", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(3012), "john" },
                    { new Guid("f759becb-176d-45e9-b23a-7b715d5c401a"), 0, "11523aa3-39ae-4e8b-8630-9ebf935a846d", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5113), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$uoclND/iiCAftV4TxFozuOwOXXHiMw4W8/dYxjRwU0V0hU3HQRur6", "(99) 99999-9994", false, "7e803890-99ca-436c-82f6-8e0deb22c641", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5110), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797") },
                    { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b") },
                    { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), new Guid("deb34abf-d7b7-49d8-8001-6666e5757429") },
                    { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a") },
                    { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), new Guid("f759becb-176d-45e9-b23a-7b715d5c401a") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Analise_Harvest_HarvestId",
                table: "Analise",
                column: "HarvestId",
                principalTable: "Harvest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
