using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedAnaliseUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c8d8aea-d53f-497b-af30-a9db9f4ae26f"), new Guid("42c39c82-a361-4a77-98aa-4ecdde564224") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("42c3f509-79cb-4743-aa4b-e4066fa420bf"), new Guid("b149a9e8-b213-426f-83eb-36f668a4fad1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f5bf847a-79bc-4e05-9ff9-4eb99df6d35a"), new Guid("d682cbe3-0b9e-489a-84de-584ff686ecbb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("da88977b-8fdf-4cea-b52c-951774bd9e4a"), new Guid("de61189e-eb48-42c7-8128-6fbafbc9ecf1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d970f06c-8e8b-4d2e-a339-ca48be30a5f6"), new Guid("e5af3f50-bb6f-4efe-84f5-8c12b63d2820") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42c3f509-79cb-4743-aa4b-e4066fa420bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c8d8aea-d53f-497b-af30-a9db9f4ae26f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d970f06c-8e8b-4d2e-a339-ca48be30a5f6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da88977b-8fdf-4cea-b52c-951774bd9e4a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5bf847a-79bc-4e05-9ff9-4eb99df6d35a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42c39c82-a361-4a77-98aa-4ecdde564224"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b149a9e8-b213-426f-83eb-36f668a4fad1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d682cbe3-0b9e-489a-84de-584ff686ecbb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("de61189e-eb48-42c7-8128-6fbafbc9ecf1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5af3f50-bb6f-4efe-84f5-8c12b63d2820"));

            migrationBuilder.DropColumn(
                name: "AnaliseUrl",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AnaliseUrl",
                table: "Analise",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("42c3f509-79cb-4743-aa4b-e4066fa420bf"), "69a31006-3507-476a-830b-ba442d9f99f1", "Consultant", "CONSULTANT" },
                    { new Guid("7c8d8aea-d53f-497b-af30-a9db9f4ae26f"), "5f65f732-33ae-4dee-9856-2333cca3460b", "Manager", "MANAGER" },
                    { new Guid("d970f06c-8e8b-4d2e-a339-ca48be30a5f6"), "18623565-5536-4835-a8d4-aa4cf7cf4282", "Collaborator", "COLLABORATOR" },
                    { new Guid("da88977b-8fdf-4cea-b52c-951774bd9e4a"), "56f65f4e-277e-4a2b-93c5-def40b07efad", "Owner", "OWNER" },
                    { new Guid("f5bf847a-79bc-4e05-9ff9-4eb99df6d35a"), "cd98627b-4987-40e0-825b-e5c649fab2b2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("42c39c82-a361-4a77-98aa-4ecdde564224"), 0, "a0a90b0f-b928-4fb4-abc6-a79170213743", new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(899), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$k033t/2QQ31cQ1rqK5ZQ3Oax3iNY7pJGsvH66BhgrtS17AgpoPKnO", "(99) 99999-9994", false, "e6d1bd8d-d3ea-4950-9163-e6cf0dbcb1d4", 0, false, new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(887), "bob" },
                    { new Guid("b149a9e8-b213-426f-83eb-36f668a4fad1"), 0, "f5bbaeb9-e8a8-4ff6-a4c4-e398ff3b9304", new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(886), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$r1nK4PU.dhBW/MUu/5JkuOJDBtt5z7H4xZi6XHTU0nNYqiHnm4dyC", "(99) 99999-9993", false, "33696b45-b6b8-49a9-8ba5-9daeaab81543", 0, false, new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(880), "alice" },
                    { new Guid("d682cbe3-0b9e-489a-84de-584ff686ecbb"), 0, "b1757169-e603-4682-a4b0-7b9b38c914b4", new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(454), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$uCuxCeckQ58Y/oWi172hwuO5rRqLd3uQ6zdTk5Fc5hZJaUtIpnhNu", "(99) 99999-9991", false, "37afeb65-d59a-424e-9e81-9c431b28a754", 0, false, new DateTime(2025, 6, 29, 7, 49, 23, 803, DateTimeKind.Local).AddTicks(7711), "john" },
                    { new Guid("de61189e-eb48-42c7-8128-6fbafbc9ecf1"), 0, "1e548749-bb54-476b-9e56-b82d996fb7a6", new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(879), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$UehouCR4e0QH6UdBJ/tDbOfKIikokXe/tPJDc6qJcydwNfdIwohH6", "(99) 99999-9992", false, "442d6f0a-5783-4dec-93a9-168ede78cbfd", 0, false, new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(852), "jane" },
                    { new Guid("e5af3f50-bb6f-4efe-84f5-8c12b63d2820"), 0, "89f8624a-fa87-40d3-8172-2d1184944de9", new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(904), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$IkF9NndTrSrjLz9Y4y3l7OZIMaXjSqsgQhTtgTEIH.9Lt4UziHasu", "(99) 99999-9995", false, "205275b4-f7cd-4120-b5b3-50055ff55d42", 0, false, new DateTime(2025, 6, 29, 7, 49, 23, 804, DateTimeKind.Local).AddTicks(900), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7c8d8aea-d53f-497b-af30-a9db9f4ae26f"), new Guid("42c39c82-a361-4a77-98aa-4ecdde564224") },
                    { new Guid("42c3f509-79cb-4743-aa4b-e4066fa420bf"), new Guid("b149a9e8-b213-426f-83eb-36f668a4fad1") },
                    { new Guid("f5bf847a-79bc-4e05-9ff9-4eb99df6d35a"), new Guid("d682cbe3-0b9e-489a-84de-584ff686ecbb") },
                    { new Guid("da88977b-8fdf-4cea-b52c-951774bd9e4a"), new Guid("de61189e-eb48-42c7-8128-6fbafbc9ecf1") },
                    { new Guid("d970f06c-8e8b-4d2e-a339-ca48be30a5f6"), new Guid("e5af3f50-bb6f-4efe-84f5-8c12b63d2820") }
                });
        }
    }
}
