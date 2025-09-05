using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDadosAnaliseService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "DadosAnalise",
                table: "Analise",
                type: "LONGTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2d6a8625-abbe-4f7e-b000-c3aba0dad473"), "5ce97e44-e3b0-434f-bbde-6461dc3ebd91", "Manager", "MANAGER" },
                    { new Guid("42a7d5bf-a5a7-4208-8862-460b08e02124"), "220ff768-9d27-4f7b-afef-925bef375044", "Consultant", "CONSULTANT" },
                    { new Guid("60ad88e4-d027-4244-9da5-19d746297dca"), "d01a1d94-133b-4947-a13c-801fde38d304", "Collaborator", "COLLABORATOR" },
                    { new Guid("6d54732e-045d-427e-b36d-a16c1a5edef7"), "7cffbc04-e33a-4b69-837b-391bcd06deb9", "Owner", "OWNER" },
                    { new Guid("ddc6e8e8-bfb8-4ae1-9dcd-029574771f74"), "1d5a8b99-6faa-4918-8a5b-66a33b93862e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("8c3a5be7-7a3c-40dc-8abe-2d6e4c8c4abe"), 0, "38d5f236-b801-40f6-abca-34557878ee1c", new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1230), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$OCv4bvGcoDXtB2RtLafdWeMzHUAYfkTAQETP3nFkNZ4NjtQ0UbZOG", "(99) 99999-9994", false, "9cbb84e5-a5a8-4ec7-9549-a9b249d395b8", 0, false, new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1227), "bob" },
                    { new Guid("947ef6d0-ea03-4f81-bdf0-8461ed8edc15"), 0, "a6206efc-9763-4d64-bd88-fafe16fa6748", new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(964), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$W9fgKdWyX8mKggIuTSxC2exL6L5gOibDLRFuGMQ.IV5SY02HA7T8y", "(99) 99999-9991", false, "94f5893d-32e2-49e0-9bb8-ade0359b8875", 0, false, new DateTime(2025, 7, 4, 9, 43, 56, 847, DateTimeKind.Local).AddTicks(9080), "john" },
                    { new Guid("d5728080-d638-459e-930a-8d6471b8106e"), 0, "b586d6f3-576a-4c2b-8451-0eab51a2e8bb", new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1237), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$KfA5w7JuAFciaqJSVMFYfOmHOHt9pQ6moP36b.6CHV7CP2uKNM2Wy", "(99) 99999-9995", false, "b0951b59-3656-46b8-8a34-1a11670a2086", 0, false, new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1230), "charlie" },
                    { new Guid("df6ba684-be33-4640-b7e8-d64a0303d066"), 0, "c6f92a76-1408-4d6c-96bd-fa57d5111c6d", new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1222), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$NcbKbAr6xz3vtcGMpKs2eu00xJzqpJVt9.nsdJQc3q0lx3M48LPXm", "(99) 99999-9992", false, "c460c516-5cf3-4957-9b91-1f2fe8c93f2f", 0, false, new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1204), "jane" },
                    { new Guid("ef848b26-892c-4196-a474-3820d6baedd9"), 0, "1ad2f4c8-3209-4d78-bc80-88da20d296d0", new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1226), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$8uE9fViVsvcblaG1VEzFneytdLrEunLD3csZwD1yJn4pEyxy8aRnq", "(99) 99999-9993", false, "749d2b44-14d6-40ed-8bab-a4463d6951ec", 0, false, new DateTime(2025, 7, 4, 9, 43, 56, 848, DateTimeKind.Local).AddTicks(1223), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d6a8625-abbe-4f7e-b000-c3aba0dad473"), new Guid("8c3a5be7-7a3c-40dc-8abe-2d6e4c8c4abe") },
                    { new Guid("ddc6e8e8-bfb8-4ae1-9dcd-029574771f74"), new Guid("947ef6d0-ea03-4f81-bdf0-8461ed8edc15") },
                    { new Guid("60ad88e4-d027-4244-9da5-19d746297dca"), new Guid("d5728080-d638-459e-930a-8d6471b8106e") },
                    { new Guid("6d54732e-045d-427e-b36d-a16c1a5edef7"), new Guid("df6ba684-be33-4640-b7e8-d64a0303d066") },
                    { new Guid("42a7d5bf-a5a7-4208-8862-460b08e02124"), new Guid("ef848b26-892c-4196-a474-3820d6baedd9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d6a8625-abbe-4f7e-b000-c3aba0dad473"), new Guid("8c3a5be7-7a3c-40dc-8abe-2d6e4c8c4abe") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ddc6e8e8-bfb8-4ae1-9dcd-029574771f74"), new Guid("947ef6d0-ea03-4f81-bdf0-8461ed8edc15") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("60ad88e4-d027-4244-9da5-19d746297dca"), new Guid("d5728080-d638-459e-930a-8d6471b8106e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d54732e-045d-427e-b36d-a16c1a5edef7"), new Guid("df6ba684-be33-4640-b7e8-d64a0303d066") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("42a7d5bf-a5a7-4208-8862-460b08e02124"), new Guid("ef848b26-892c-4196-a474-3820d6baedd9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2d6a8625-abbe-4f7e-b000-c3aba0dad473"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42a7d5bf-a5a7-4208-8862-460b08e02124"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60ad88e4-d027-4244-9da5-19d746297dca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d54732e-045d-427e-b36d-a16c1a5edef7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddc6e8e8-bfb8-4ae1-9dcd-029574771f74"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c3a5be7-7a3c-40dc-8abe-2d6e4c8c4abe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("947ef6d0-ea03-4f81-bdf0-8461ed8edc15"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5728080-d638-459e-930a-8d6471b8106e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df6ba684-be33-4640-b7e8-d64a0303d066"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ef848b26-892c-4196-a474-3820d6baedd9"));

            migrationBuilder.AlterColumn<string>(
                name: "DadosAnalise",
                table: "Analise",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
