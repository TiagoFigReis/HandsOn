using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDadosAnaliseService2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e6e552b-4ae4-4741-935b-efd32e3071a3"), "e5fd1327-fcb5-41ba-a2b0-fcc81af075b1", "Consultant", "CONSULTANT" },
                    { new Guid("5c712189-c89b-45b3-938b-1c2efbffc042"), "230de175-e853-4aaa-9dac-379347420619", "Owner", "OWNER" },
                    { new Guid("ec49f030-06f5-4000-87e6-80128ea3d833"), "10dee1a7-da0b-4457-ba16-c1474b192224", "Manager", "MANAGER" },
                    { new Guid("f35ccd89-c8dd-4b12-bcc9-066be097e482"), "6de94582-a355-48a1-98b6-bd32e80923a1", "Collaborator", "COLLABORATOR" },
                    { new Guid("f9022458-9d8f-4127-82b7-7d14da0cb85c"), "d5e23bf9-a2de-41ce-af08-655d6ce8f0fd", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("38e94019-156f-4b99-b2c8-e095b7eb1134"), 0, "4430bdc6-7cbf-4ca0-a25d-bd7b22718fea", new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9303), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$/iPflXv9kc/iCoYqkltckuGpBVlEyUOS3ipyzWWVkkg2QAVR/.E1q", "(99) 99999-9995", false, "423dee23-bd38-4b93-b54b-6c41872155c3", 0, false, new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9299), "charlie" },
                    { new Guid("aa9397cb-f4e6-4126-b05c-1ef221b661a9"), 0, "39db1cf0-7eec-456c-9265-7b23edfef0bf", new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(8778), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$uimk/.X3G3fcje/fQWR.UOMcL2Ome4pEokDR.vnKFd4K.fBBSC9mC", "(99) 99999-9991", false, "be800f64-b4a4-4660-a657-2879ffda9fe0", 0, false, new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(4039), "john" },
                    { new Guid("be0166a1-bc00-420c-89f8-45db81bf671d"), 0, "9c6cdf67-1472-4542-bc95-abb1ea11451a", new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9292), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$VQWj5kfaCLLAHSmr8k4sFeWYxzLEl5RR9InOcIfA5vrRjQsKX3.ve", "(99) 99999-9993", false, "f661ac46-cd3a-44d5-a3f7-0c77fa246b00", 0, false, new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9280), "alice" },
                    { new Guid("da08d301-8498-42a6-9dec-aa2822c45cec"), 0, "51cd3295-05dd-4b71-b3af-85317eab33b4", new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9278), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$PE3lAw.w7YTio5DU8yt3.eRBWmGKqMD/IJ/9fcINc0H9v.juoSOga", "(99) 99999-9992", false, "c33d0a7e-ddd7-49c2-aede-b36373c4545a", 0, false, new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9248), "jane" },
                    { new Guid("e835fb32-7a22-4bbe-a677-a6b6873a3f84"), 0, "43d76493-c84a-4f55-b172-b76cf761e548", new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9298), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Sj2q6pmzDQGg90KdkcQA2el4W1p5nXGNGm2T/4QLaDqZ.mvVPEIsK", "(99) 99999-9994", false, "bbd866ba-9a18-4ac2-a282-c7e412c99c3b", 0, false, new DateTime(2025, 7, 4, 9, 58, 25, 860, DateTimeKind.Local).AddTicks(9294), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f35ccd89-c8dd-4b12-bcc9-066be097e482"), new Guid("38e94019-156f-4b99-b2c8-e095b7eb1134") },
                    { new Guid("f9022458-9d8f-4127-82b7-7d14da0cb85c"), new Guid("aa9397cb-f4e6-4126-b05c-1ef221b661a9") },
                    { new Guid("2e6e552b-4ae4-4741-935b-efd32e3071a3"), new Guid("be0166a1-bc00-420c-89f8-45db81bf671d") },
                    { new Guid("5c712189-c89b-45b3-938b-1c2efbffc042"), new Guid("da08d301-8498-42a6-9dec-aa2822c45cec") },
                    { new Guid("ec49f030-06f5-4000-87e6-80128ea3d833"), new Guid("e835fb32-7a22-4bbe-a677-a6b6873a3f84") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f35ccd89-c8dd-4b12-bcc9-066be097e482"), new Guid("38e94019-156f-4b99-b2c8-e095b7eb1134") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f9022458-9d8f-4127-82b7-7d14da0cb85c"), new Guid("aa9397cb-f4e6-4126-b05c-1ef221b661a9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2e6e552b-4ae4-4741-935b-efd32e3071a3"), new Guid("be0166a1-bc00-420c-89f8-45db81bf671d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5c712189-c89b-45b3-938b-1c2efbffc042"), new Guid("da08d301-8498-42a6-9dec-aa2822c45cec") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ec49f030-06f5-4000-87e6-80128ea3d833"), new Guid("e835fb32-7a22-4bbe-a677-a6b6873a3f84") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e6e552b-4ae4-4741-935b-efd32e3071a3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c712189-c89b-45b3-938b-1c2efbffc042"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec49f030-06f5-4000-87e6-80128ea3d833"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f35ccd89-c8dd-4b12-bcc9-066be097e482"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f9022458-9d8f-4127-82b7-7d14da0cb85c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("38e94019-156f-4b99-b2c8-e095b7eb1134"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aa9397cb-f4e6-4126-b05c-1ef221b661a9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be0166a1-bc00-420c-89f8-45db81bf671d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da08d301-8498-42a6-9dec-aa2822c45cec"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e835fb32-7a22-4bbe-a677-a6b6873a3f84"));

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
    }
}
