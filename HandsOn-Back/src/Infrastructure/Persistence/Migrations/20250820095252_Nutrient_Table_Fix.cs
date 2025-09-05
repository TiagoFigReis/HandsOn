using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Nutrient_Table_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("408a409f-b7fb-4d11-a6dd-9c1e8ee2fb5c"), new Guid("911d449e-c52c-4d08-a660-ad6461745e94") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("361075c7-ac88-4250-a336-93b1e54d623a"), new Guid("97f7ca8a-18dc-4b6d-9584-abf9e7d44f51") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("985515cc-254f-4939-a548-1cae61da757f"), new Guid("9b901697-e48d-481c-a4c9-d375c77470da") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("908b0ed1-79e1-4dfb-a10c-ea54c525f72f"), new Guid("9ef3a46a-3cbb-4742-815a-ff678ddab55d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("68a402bf-70df-41ec-8769-e0c3f90908ee"), new Guid("a966df06-86c0-421f-ae71-3c7eda96db1c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("361075c7-ac88-4250-a336-93b1e54d623a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("408a409f-b7fb-4d11-a6dd-9c1e8ee2fb5c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68a402bf-70df-41ec-8769-e0c3f90908ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("908b0ed1-79e1-4dfb-a10c-ea54c525f72f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("985515cc-254f-4939-a548-1cae61da757f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("911d449e-c52c-4d08-a660-ad6461745e94"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97f7ca8a-18dc-4b6d-9584-abf9e7d44f51"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b901697-e48d-481c-a4c9-d375c77470da"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9ef3a46a-3cbb-4742-815a-ff678ddab55d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a966df06-86c0-421f-ae71-3c7eda96db1c"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NutrientTables");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), "8bbdc0bf-82fb-436b-b531-eaa3d16da31f", "Consultant", "CONSULTANT" },
                    { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), "d36b53fd-f8b1-4006-a9a5-9f1feaefb0bb", "Manager", "MANAGER" },
                    { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), "c4fd2c74-feb3-4186-8198-2af38defbc0d", "Owner", "OWNER" },
                    { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), "99436396-4186-4b35-afbb-c0aa47e6b7e7", "Admin", "ADMIN" },
                    { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), "a37a9900-3e32-4835-b835-e60660dbcec8", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("263ef84e-d882-4819-85ec-1311de268273"), 0, "e661439c-6b1e-4faa-bfe3-cf562ab1b28f", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7430), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$MghBhXwj2MRnO3h5HQt/4.ulpIfHjxPIx.ibBr3IuFBlgXEEThnte", "(99) 99999-9994", false, "4afbbb85-9341-438e-90c4-7c81b82746d2", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7424), "bob" },
                    { new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c"), 0, "baa0b31b-4500-4fd7-9efe-ea3983eaa9ce", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7433), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$e5mNp/Wd29.CRbHlaSAUKO532mNhRGAmntR5Lz3gGTehLByChryWi", "(99) 99999-9995", false, "21751865-a8fd-44b3-8b3e-a08271b9f2df", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7431), "charlie" },
                    { new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96"), 0, "155df36a-09dd-4d27-b80e-a3a137af5f03", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7423), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$cs/JjAenjCDgTb2gR1lcyegD8TZlP4RSZ48VK91rgswxxVLeKl4Dq", "(99) 99999-9993", false, "76d06b10-e5a9-4c41-82ca-e32467510cef", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7419), "alice" },
                    { new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1"), 0, "0cfa5a35-c803-4afc-ab10-dc4ba173c9b9", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7418), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$DkQmU8.Qhl/n7twmais0vOkjstcq37cnuD4ZI3i5bLCsXbAy8.ZAm", "(99) 99999-9992", false, "807039a5-8c15-4a3c-b4aa-87de9dedde96", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7403), "jane" },
                    { new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4"), 0, "98e4902d-2e76-4dde-b3f1-43d8f5e52e12", new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(7200), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$5mC6TIo9nfw.44kEw2e4NORH62eXSHxTRR9S72ArZ8zYbN5YMN6Ma", "(99) 99999-9991", false, "2aed3e51-9e63-4f0f-87fd-a71a9b0cbae4", 0, false, new DateTime(2025, 8, 20, 6, 52, 50, 947, DateTimeKind.Local).AddTicks(5783), "john" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 20, 6, 52, 51, 908, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), new Guid("263ef84e-d882-4819-85ec-1311de268273") },
                    { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c") },
                    { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96") },
                    { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1") },
                    { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"), new Guid("263ef84e-d882-4819-85ec-1311de268273") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"), new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"), new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"), new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"), new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66b179b4-dcf3-4f3a-905e-6fb7cfa6b76e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cf3dea4-b923-48f3-b216-0185f8b0498e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c4815fb-a13e-43bf-9bc5-fe3a0b25baae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc9a0eae-18e8-491b-999e-48d805370ac0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f463d0de-3112-4772-aeca-5cb3b412bdbd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("263ef84e-d882-4819-85ec-1311de268273"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("708b22d5-03e8-46b7-8e5b-e83926f22c6c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("83bdd31c-98f6-4510-983d-61d3592e9b96"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b2b0a029-08a1-44ba-a9f0-7e58be6c71a1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5f61f6b-2bce-472d-b07f-b1b952f8cef4"));

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
                    { new Guid("361075c7-ac88-4250-a336-93b1e54d623a"), "527ac436-5acc-4796-8e58-c688fa7585d1", "Manager", "MANAGER" },
                    { new Guid("408a409f-b7fb-4d11-a6dd-9c1e8ee2fb5c"), "f4cb1de4-577a-45ec-8157-1aa7f26fffa4", "Admin", "ADMIN" },
                    { new Guid("68a402bf-70df-41ec-8769-e0c3f90908ee"), "c2f4e13c-5e94-4de8-bcc6-b334fb2ac0c2", "Collaborator", "COLLABORATOR" },
                    { new Guid("908b0ed1-79e1-4dfb-a10c-ea54c525f72f"), "7c285bdd-aa2c-4ad7-aeb1-521a20edd3be", "Consultant", "CONSULTANT" },
                    { new Guid("985515cc-254f-4939-a548-1cae61da757f"), "bb7516f1-0b40-4b88-9ad7-cd46ee68fdeb", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("911d449e-c52c-4d08-a660-ad6461745e94"), 0, "bc2fceea-4894-4e09-9845-0a44ed888c11", new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(2217), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$YReQVSBjC88irU23ytMB8Ousgp1KmWhpvbhNf/V31A.rDQOaeeo/i", "(99) 99999-9991", false, "36736872-19ad-4f81-a2b0-405c3e956374", 0, false, new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(285), "john" },
                    { new Guid("97f7ca8a-18dc-4b6d-9584-abf9e7d44f51"), 0, "cdbf545b-551c-46da-840f-38c8305fd162", new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3070), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$1eB0lo4zulgywslOH5duLu4prnVqH/q9a6kSErRuDo6rgGvsfMlia", "(99) 99999-9994", false, "96b35f60-efd2-4d54-ac40-182f2e731be9", 0, false, new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3066), "bob" },
                    { new Guid("9b901697-e48d-481c-a4c9-d375c77470da"), 0, "e1ce723c-1bdc-4a11-be00-5a085b6456a2", new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3061), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$szUipxYz3VCtC0GV7wzB4OoSHjpAYmGhzMQwrk2IICtwcNhatTQ2u", "(99) 99999-9992", false, "405fc73b-6c34-4208-94e5-64fc455f9ff6", 0, false, new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3032), "jane" },
                    { new Guid("9ef3a46a-3cbb-4742-815a-ff678ddab55d"), 0, "92bf499d-c7a3-4c11-8507-8ce078e8edb3", new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3065), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$vnVQlwECXWm4KWAOmKgrVOQ6MqI3.xdQtPU9mC8iKVE0xcx30m/cO", "(99) 99999-9993", false, "df228c4c-194e-4129-bdfe-31de809433cd", 0, false, new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3062), "alice" },
                    { new Guid("a966df06-86c0-421f-ae71-3c7eda96db1c"), 0, "9c6c8ca7-01c4-4df2-8aa7-3a4455247401", new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3073), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$RDF/auUEsSHNQ1l9oT71b.VcZoTFDZ7h8AeIDyGZt5bGJ4Hwrd0ci", "(99) 99999-9995", false, "d971d317-fc7d-4bd1-ab5b-63782fc3e481", 0, false, new DateTime(2025, 8, 10, 20, 29, 32, 156, DateTimeKind.Local).AddTicks(3070), "charlie" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 10, 20, 29, 32, 944, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("408a409f-b7fb-4d11-a6dd-9c1e8ee2fb5c"), new Guid("911d449e-c52c-4d08-a660-ad6461745e94") },
                    { new Guid("361075c7-ac88-4250-a336-93b1e54d623a"), new Guid("97f7ca8a-18dc-4b6d-9584-abf9e7d44f51") },
                    { new Guid("985515cc-254f-4939-a548-1cae61da757f"), new Guid("9b901697-e48d-481c-a4c9-d375c77470da") },
                    { new Guid("908b0ed1-79e1-4dfb-a10c-ea54c525f72f"), new Guid("9ef3a46a-3cbb-4742-815a-ff678ddab55d") },
                    { new Guid("68a402bf-70df-41ec-8769-e0c3f90908ee"), new Guid("a966df06-86c0-421f-ae71-3c7eda96db1c") }
                });
        }
    }
}
