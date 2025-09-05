using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DadosAnaliseService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c996e93e-e232-432d-9baf-f42125eaee01"), new Guid("041a057c-534c-46a7-8cc8-1e463f868a9f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("da428214-2a72-423a-98a8-a8e0862e3e7e"), new Guid("593ca978-6e0a-4d94-b3f4-561cd5479455") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c306cf5d-b78b-4a31-a47d-e0de81398bea"), new Guid("7bcad309-fee2-4796-a60f-efbc9c6699c7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3ab1360-0c26-450d-9e27-4a26b9e28e2e"), new Guid("ae6bbb1d-4642-4e12-8b97-f3f5255ff0d9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("38c1de94-04d6-485c-aa07-f6c856631569"), new Guid("fd3d278b-a409-4c8c-b77a-582025da5847") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38c1de94-04d6-485c-aa07-f6c856631569"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c306cf5d-b78b-4a31-a47d-e0de81398bea"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3ab1360-0c26-450d-9e27-4a26b9e28e2e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c996e93e-e232-432d-9baf-f42125eaee01"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da428214-2a72-423a-98a8-a8e0862e3e7e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("041a057c-534c-46a7-8cc8-1e463f868a9f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("593ca978-6e0a-4d94-b3f4-561cd5479455"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7bcad309-fee2-4796-a60f-efbc9c6699c7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae6bbb1d-4642-4e12-8b97-f3f5255ff0d9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd3d278b-a409-4c8c-b77a-582025da5847"));

            migrationBuilder.AddColumn<string>(
                name: "DadosAnalise",
                table: "Analise",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5477909d-9400-4420-9ece-44c54a10c94f"), "d95e3d5e-eb8e-439d-bc2e-a28543dccf0c", "Consultant", "CONSULTANT" },
                    { new Guid("620ca4a6-0ab8-4d79-b9b0-b5f499b949a4"), "959e377f-77a1-4e7b-8e2e-1cfbed5ededc", "Manager", "MANAGER" },
                    { new Guid("813d6c5b-5e02-41eb-b648-45f2b755e7aa"), "e70a8a46-8b55-43f7-b6e5-bfe619c4a722", "Owner", "OWNER" },
                    { new Guid("c5a3927c-afee-46af-9edf-f2e676661e76"), "193c7490-9037-4c3f-a1d0-9878c0f1059c", "Collaborator", "COLLABORATOR" },
                    { new Guid("e8722aaf-cf06-4f22-88be-a2d0a8fdb2ae"), "7373ac3a-a1e9-431d-b222-514a32549de9", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("248cd23e-addb-4ccd-9ef8-64f460442eba"), 0, "5f791b80-c3b7-4575-a23d-6aa743a35da0", new DateTime(2025, 7, 4, 9, 27, 9, 346, DateTimeKind.Local).AddTicks(9891), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$zojpEdvo10JsqFA7pzAtkOJOTPaunkdxXgwuXguuasXdO6RlLzzwu", "(99) 99999-9991", false, "eacca0d9-7997-4b74-b8e4-5ec547b3e2f2", 0, false, new DateTime(2025, 7, 4, 9, 27, 9, 346, DateTimeKind.Local).AddTicks(7662), "john" },
                    { new Guid("4045ab1c-e754-41bb-b1c6-238d793fe6df"), 0, "5ff3475e-6b0d-4233-8938-eab35c8d0cae", new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(179), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$HjIEwUl0F/ponVxwkK.gr.E4qUDcG6oiJlcGgTZ37RBixjF6sulF6", "(99) 99999-9994", false, "25204ba5-1df2-402e-a29b-5b58e99ca8b0", 0, false, new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(176), "bob" },
                    { new Guid("591b63eb-bb86-4a7d-8e8b-1ec6dcb3ebaf"), 0, "6f9676e0-a8cb-48e6-b934-45efc05b3b89", new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(175), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$nXbrxYb1Nxhg8Rm0niBq.uFiCUGJhCLte5eNwWgFM5v9xmLb8bk8W", "(99) 99999-9993", false, "ace40360-99df-4db9-8434-1f2a5e6a3783", 0, false, new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(166), "alice" },
                    { new Guid("9a7c67d7-af67-48ac-8638-2974ec7c399b"), 0, "c8c74278-0822-4e1c-8b32-ccbbecdc1a4f", new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(182), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JUW76wXSSQ1CIccBOJs.Nu/Yc.iF4Oje36fJ8cEXmhmFJ6esmUYEi", "(99) 99999-9995", false, "221bca88-3d21-4135-b7e1-31886ba3bcb7", 0, false, new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(179), "charlie" },
                    { new Guid("bb104749-a0a6-4560-b3cf-72dc365e0e49"), 0, "f50ed7ca-1185-42c1-ab7a-2604fd451cd0", new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(166), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$BNi2BziWvoXjEQqPL2QGMONgiPKFhr8KuqfaO7UJ3E4QVnHHFT/TK", "(99) 99999-9992", false, "81fec69e-20d2-4b65-91b8-4e5649e81119", 0, false, new DateTime(2025, 7, 4, 9, 27, 9, 347, DateTimeKind.Local).AddTicks(147), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e8722aaf-cf06-4f22-88be-a2d0a8fdb2ae"), new Guid("248cd23e-addb-4ccd-9ef8-64f460442eba") },
                    { new Guid("620ca4a6-0ab8-4d79-b9b0-b5f499b949a4"), new Guid("4045ab1c-e754-41bb-b1c6-238d793fe6df") },
                    { new Guid("5477909d-9400-4420-9ece-44c54a10c94f"), new Guid("591b63eb-bb86-4a7d-8e8b-1ec6dcb3ebaf") },
                    { new Guid("c5a3927c-afee-46af-9edf-f2e676661e76"), new Guid("9a7c67d7-af67-48ac-8638-2974ec7c399b") },
                    { new Guid("813d6c5b-5e02-41eb-b648-45f2b755e7aa"), new Guid("bb104749-a0a6-4560-b3cf-72dc365e0e49") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e8722aaf-cf06-4f22-88be-a2d0a8fdb2ae"), new Guid("248cd23e-addb-4ccd-9ef8-64f460442eba") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("620ca4a6-0ab8-4d79-b9b0-b5f499b949a4"), new Guid("4045ab1c-e754-41bb-b1c6-238d793fe6df") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5477909d-9400-4420-9ece-44c54a10c94f"), new Guid("591b63eb-bb86-4a7d-8e8b-1ec6dcb3ebaf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c5a3927c-afee-46af-9edf-f2e676661e76"), new Guid("9a7c67d7-af67-48ac-8638-2974ec7c399b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("813d6c5b-5e02-41eb-b648-45f2b755e7aa"), new Guid("bb104749-a0a6-4560-b3cf-72dc365e0e49") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5477909d-9400-4420-9ece-44c54a10c94f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("620ca4a6-0ab8-4d79-b9b0-b5f499b949a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("813d6c5b-5e02-41eb-b648-45f2b755e7aa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5a3927c-afee-46af-9edf-f2e676661e76"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8722aaf-cf06-4f22-88be-a2d0a8fdb2ae"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("248cd23e-addb-4ccd-9ef8-64f460442eba"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4045ab1c-e754-41bb-b1c6-238d793fe6df"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("591b63eb-bb86-4a7d-8e8b-1ec6dcb3ebaf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a7c67d7-af67-48ac-8638-2974ec7c399b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bb104749-a0a6-4560-b3cf-72dc365e0e49"));

            migrationBuilder.DropColumn(
                name: "DadosAnalise",
                table: "Analise");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("38c1de94-04d6-485c-aa07-f6c856631569"), "92b4ef75-41e4-4bf8-83e2-098d4a69f2fd", "Manager", "MANAGER" },
                    { new Guid("c306cf5d-b78b-4a31-a47d-e0de81398bea"), "a15a9bc6-5b98-457a-8f73-a9a82293b041", "Collaborator", "COLLABORATOR" },
                    { new Guid("c3ab1360-0c26-450d-9e27-4a26b9e28e2e"), "4ea56705-d537-4d4f-bfb5-a20199d83ef9", "Admin", "ADMIN" },
                    { new Guid("c996e93e-e232-432d-9baf-f42125eaee01"), "15c60302-cb75-4e18-91bd-b02a90257009", "Consultant", "CONSULTANT" },
                    { new Guid("da428214-2a72-423a-98a8-a8e0862e3e7e"), "d6e53523-a068-4d3b-8dd9-5637e3a52e61", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("041a057c-534c-46a7-8cc8-1e463f868a9f"), 0, "ea30e40c-fea0-40be-9b42-9d8024f0a340", new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7864), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$x1mQ2Y3YFBaox0lJiDilquOlqe8oAQtpfn406xc5vfTXkZEkoOohi", "(99) 99999-9993", false, "19b89509-6df6-4ecc-a781-d1180e41f4d9", 0, false, new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7861), "alice" },
                    { new Guid("593ca978-6e0a-4d94-b3f4-561cd5479455"), 0, "e2456407-0d7b-4ac7-b061-5217b482c238", new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7860), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$OYc4m26ynvV5JzrvHdUfYOcu9RpvlYhZl.R1vmDufUuYHp7JJ4Nyq", "(99) 99999-9992", false, "ec070b6c-8e05-4407-82d0-dd75ffaa0ba0", 0, false, new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7842), "jane" },
                    { new Guid("7bcad309-fee2-4796-a60f-efbc9c6699c7"), 0, "79dd7b39-46e6-494b-83bb-67f24a56a7a8", new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7875), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$MgGDIVZkYKT6C17.sYHeuuU5YOumt7.LvSAfAIoBNWrzUUIrkF/2K", "(99) 99999-9995", false, "6c009945-9b01-47e4-a08f-22b9837b0d1a", 0, false, new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7869), "charlie" },
                    { new Guid("ae6bbb1d-4642-4e12-8b97-f3f5255ff0d9"), 0, "598ed2ed-03b5-4878-9b03-06adef674a0d", new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7589), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$sDwkGFTE3EAzDBmDZnXf6eWxPikWHoJ7XLlAqNGivowkmiLmUGE/.", "(99) 99999-9991", false, "33d68992-8464-4f44-bf08-15b9fd827d35", 0, false, new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(5759), "john" },
                    { new Guid("fd3d278b-a409-4c8c-b77a-582025da5847"), 0, "33b1988a-6655-4454-b961-c3c27db5310f", new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7868), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$G4TMLn3RZ1/e1n/VJEH0fOvBfZWccd41OCGfsoDhFpLdxOj1bkQGW", "(99) 99999-9994", false, "a54992b4-dd8a-4985-9e8e-d34e7b855b83", 0, false, new DateTime(2025, 7, 2, 10, 52, 8, 410, DateTimeKind.Local).AddTicks(7865), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c996e93e-e232-432d-9baf-f42125eaee01"), new Guid("041a057c-534c-46a7-8cc8-1e463f868a9f") },
                    { new Guid("da428214-2a72-423a-98a8-a8e0862e3e7e"), new Guid("593ca978-6e0a-4d94-b3f4-561cd5479455") },
                    { new Guid("c306cf5d-b78b-4a31-a47d-e0de81398bea"), new Guid("7bcad309-fee2-4796-a60f-efbc9c6699c7") },
                    { new Guid("c3ab1360-0c26-450d-9e27-4a26b9e28e2e"), new Guid("ae6bbb1d-4642-4e12-8b97-f3f5255ff0d9") },
                    { new Guid("38c1de94-04d6-485c-aa07-f6c856631569"), new Guid("fd3d278b-a409-4c8c-b77a-582025da5847") }
                });
        }
    }
}
