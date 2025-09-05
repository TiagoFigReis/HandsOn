using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AnalisesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("70a45c2e-312f-4295-93d1-fe51a815fba5"), new Guid("01359e91-9e34-45cd-a6d4-d96cb64b1d57") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("136bb564-15f5-4246-9e93-91aa97c8973f"), new Guid("0383aa64-b530-4380-baa8-2b13fbc11335") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a9cf5714-d416-4e59-8e64-975c4d1979aa"), new Guid("3c34ef92-6553-484c-9731-6d9a3aaa4d39") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a3fc8402-1d16-45da-9bbe-df471daa1e48"), new Guid("62562241-3213-4d0e-b00a-b25a69f902c0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1bd441f0-3b41-447d-9fde-41fca5584d24"), new Guid("764ec639-0400-4072-a9e5-3fc95265eabb") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("136bb564-15f5-4246-9e93-91aa97c8973f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1bd441f0-3b41-447d-9fde-41fca5584d24"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70a45c2e-312f-4295-93d1-fe51a815fba5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3fc8402-1d16-45da-9bbe-df471daa1e48"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a9cf5714-d416-4e59-8e64-975c4d1979aa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01359e91-9e34-45cd-a6d4-d96cb64b1d57"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0383aa64-b530-4380-baa8-2b13fbc11335"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c34ef92-6553-484c-9731-6d9a3aaa4d39"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62562241-3213-4d0e-b00a-b25a69f902c0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("764ec639-0400-4072-a9e5-3fc95265eabb"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Analise_UserId",
                table: "Analise",
                column: "UserId");

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

            migrationBuilder.DropIndex(
                name: "IX_Analise_UserId",
                table: "Analise");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("136bb564-15f5-4246-9e93-91aa97c8973f"), "b9c943be-62d7-4747-8c79-087f65485f82", "Manager", "MANAGER" },
                    { new Guid("1bd441f0-3b41-447d-9fde-41fca5584d24"), "4c0297c5-2e25-4309-864c-0fc411bcf772", "Admin", "ADMIN" },
                    { new Guid("70a45c2e-312f-4295-93d1-fe51a815fba5"), "11733207-0b04-42f3-8c75-7018233cece3", "Consultant", "CONSULTANT" },
                    { new Guid("a3fc8402-1d16-45da-9bbe-df471daa1e48"), "757886f5-e9ff-4a72-9441-77bcbfda238b", "Collaborator", "COLLABORATOR" },
                    { new Guid("a9cf5714-d416-4e59-8e64-975c4d1979aa"), "ff97fd3b-5d3a-469e-9f4a-03c3a45bb05e", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("01359e91-9e34-45cd-a6d4-d96cb64b1d57"), 0, "ba498843-425b-4b00-8298-80b7f95e996f", new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(863), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$rEO2UaISX1Bd7gKvv8FBuu/aP4lVVigja6UFEPgKxBlEz1DWpvleC", "(99) 99999-9993", false, "65ed3907-cc79-4f44-832e-0bf301bb999a", 0, false, new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(858), "alice" },
                    { new Guid("0383aa64-b530-4380-baa8-2b13fbc11335"), 0, "e146b38d-c4e9-47ff-b1f4-904780eeeef8", new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(876), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$JKMbwb7MAGKVkUVylIyjTOqyOJ1csqiCugXYVwoBMYOOPcztW05Pm", "(99) 99999-9994", false, "2aad6742-f51e-42d4-9098-fc5364b3022e", 0, false, new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(864), "bob" },
                    { new Guid("3c34ef92-6553-484c-9731-6d9a3aaa4d39"), 0, "49fbf0e3-5618-4720-96ec-a99305837fdb", new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(857), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Mg9MrtwC8ZcT5YFkqRi7vuG5MmY0aMgNv22O7RHTDSV1ZzcVJWkkO", "(99) 99999-9992", false, "03c03242-68ba-45e4-82c4-81fe30660307", 0, false, new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(830), "jane" },
                    { new Guid("62562241-3213-4d0e-b00a-b25a69f902c0"), 0, "98d04e64-3235-40fe-8ddf-eea71a5cb9d9", new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(883), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$gkl.UmisOa/yQKAPxU5Sluefl8dSSJyz/jr4qdw5owHfZeAftWjk6", "(99) 99999-9995", false, "7f9a0d8f-083a-4272-b6d9-fa398efd72bb", 0, false, new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(877), "charlie" },
                    { new Guid("764ec639-0400-4072-a9e5-3fc95265eabb"), 0, "85d88c0c-3ac0-4fcb-9e7f-48aef6cf347e", new DateTime(2025, 6, 29, 7, 24, 16, 877, DateTimeKind.Local).AddTicks(454), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$/W6MMY87bk0KnBhapxhwXud8ji7xgQTSpxKz63ZtyKqeBdUI8L30O", "(99) 99999-9991", false, "b61d21f1-c534-434d-a027-e8fd56997202", 0, false, new DateTime(2025, 6, 29, 7, 24, 16, 876, DateTimeKind.Local).AddTicks(7675), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("70a45c2e-312f-4295-93d1-fe51a815fba5"), new Guid("01359e91-9e34-45cd-a6d4-d96cb64b1d57") },
                    { new Guid("136bb564-15f5-4246-9e93-91aa97c8973f"), new Guid("0383aa64-b530-4380-baa8-2b13fbc11335") },
                    { new Guid("a9cf5714-d416-4e59-8e64-975c4d1979aa"), new Guid("3c34ef92-6553-484c-9731-6d9a3aaa4d39") },
                    { new Guid("a3fc8402-1d16-45da-9bbe-df471daa1e48"), new Guid("62562241-3213-4d0e-b00a-b25a69f902c0") },
                    { new Guid("1bd441f0-3b41-447d-9fde-41fca5584d24"), new Guid("764ec639-0400-4072-a9e5-3fc95265eabb") }
                });
        }
    }
}
