using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedTypeOfNutrientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), new Guid("63117516-c9d3-43c0-9631-f05d25b19133") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), new Guid("938f8cbf-d731-4292-acde-86061c94c23c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63117516-c9d3-43c0-9631-f05d25b19133"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("938f8cbf-d731-4292-acde-86061c94c23c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "NutrientTables");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), "9b75450e-b7f9-4ec8-9096-c88c32b1e0d4", "Consultant", "CONSULTANT" },
                    { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), "9ccbfd03-9f47-49d6-a054-24c3ce4c8178", "Owner", "OWNER" },
                    { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), "7baeffdd-39b5-4cd3-ad16-7f0b3b1c8e4b", "Admin", "ADMIN" },
                    { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), "a6f2bbeb-f42d-4257-8e9a-e1d2dfaf1054", "Collaborator", "COLLABORATOR" },
                    { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), "fb46d42a-d3fb-43d0-acb5-9d34ee3b089f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587"), 0, "9d32d11e-7081-43ff-a6d9-0a90884d7c0a", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4974), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$xzACKrPGQchBijYt/kWB5OHFDB7FWskE0jl7.5Bem9cQIxtZes.LG", "(99) 99999-9992", false, "a8393fc9-e9fe-4bcf-b5b2-ca948f14d9fa", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4949), "jane" },
                    { new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5"), 0, "e2b8bf1b-8473-482f-a632-47cf05ebd25c", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4982), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$Br9o87ViLwhfR1yVMgyzkeaJQrbJsM9hLO5HIySBtTxgJp.TAZzFm", "(99) 99999-9995", false, "23da6f1c-d868-4117-8773-e57e4db8647c", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4980), "charlie" },
                    { new Guid("63117516-c9d3-43c0-9631-f05d25b19133"), 0, "a9fd64b8-743b-43c9-9df9-e3e6a6c3793d", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4980), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$qyMsC4B3PQ/0pvQSFGK/juwy.Ue1AxpfU51.k8w9/29Ovil1Nd56C", "(99) 99999-9994", false, "8cf87514-6bdf-471f-9f09-0f069253a4a3", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4978), "bob" },
                    { new Guid("938f8cbf-d731-4292-acde-86061c94c23c"), 0, "af4a7976-caf5-427b-8e57-063a048274a2", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4774), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$ZZxctgt8royUcSTOlzmUa.w/VoMg3Ik95.aLgDINTCNziJuYSp3fa", "(99) 99999-9991", false, "130827c8-d5ee-4e95-bed9-b0e76efbb31d", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(3316), "john" },
                    { new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb"), 0, "60e31cfb-05ca-4924-9e58-4bda1b7cbb21", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4977), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$5Obc3zTg.J/C1RpHeDROc.N6VuLzbme6zwshrcibV5B4KHQ.Zmyvu", "(99) 99999-9993", false, "fbfd9b5f-1312-46f7-a53b-2497923956cf", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4975), "alice" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 9, 12, 37, 39, 7, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587") },
                    { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5") },
                    { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), new Guid("63117516-c9d3-43c0-9631-f05d25b19133") },
                    { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), new Guid("938f8cbf-d731-4292-acde-86061c94c23c") },
                    { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb") }
                });
        }
    }
}
