using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedPlotsAndHarvests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bd088014-6656-4ca7-b072-65285e9f29c0"), new Guid("a105d136-5ecf-4106-94af-bb6573d47540") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1d42e673-4875-4773-b2c6-1e30b2d727b6"), new Guid("eb5e463b-2ac9-4519-990c-9d009901ff39") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("767c534b-2b1d-499f-9e78-b158932a8d05"), new Guid("fa32d592-0eb3-4aed-b714-7c01894db520") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d6f16d8d-e337-49b7-8773-e8b056801cae"), new Guid("fea9e587-3c3c-4497-9fe7-6f2ad8da6b1d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ffdb767f-0f78-40eb-b9c4-ed1101ac4851"), new Guid("ff3bb54b-0397-420e-9e43-43d69bbf70dc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d42e673-4875-4773-b2c6-1e30b2d727b6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("767c534b-2b1d-499f-9e78-b158932a8d05"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd088014-6656-4ca7-b072-65285e9f29c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6f16d8d-e337-49b7-8773-e8b056801cae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffdb767f-0f78-40eb-b9c4-ed1101ac4851"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a105d136-5ecf-4106-94af-bb6573d47540"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eb5e463b-2ac9-4519-990c-9d009901ff39"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa32d592-0eb3-4aed-b714-7c01894db520"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fea9e587-3c3c-4497-9fe7-6f2ad8da6b1d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ff3bb54b-0397-420e-9e43-43d69bbf70dc"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlotId",
                table: "Analise",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inicio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fim = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProducaoEsperada = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlotId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvest", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cultura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPlantio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cultivar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), "8cb42112-bd0e-4684-8782-75225d94c739", "Owner", "OWNER" },
                    { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), "e543e64b-f032-45b8-9410-15cb39b6093b", "Collaborator", "COLLABORATOR" },
                    { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), "0fa41820-99d0-4a88-8868-8252881d675a", "Admin", "ADMIN" },
                    { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), "d01cef5d-ec43-4996-b9a3-4c41f83ed67e", "Manager", "MANAGER" },
                    { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), "d84874a1-7337-4c71-ba9f-363baa0a02a2", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f"), 0, "0a131ca4-eb2f-47ec-80a5-883b8267bab7", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9619), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$kLw.ihwlyVXfXC6F6Xr4jeSn95pkhzgvufBNqlY5ezViZriCA8mfe", "(99) 99999-9991", false, "bb82e1dd-33cd-421c-82c8-bbf010032166", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(7800), "john" },
                    { new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f"), 0, "2b7aa2f7-4598-49b5-8a63-bd94fed0ffd6", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9892), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$UvNXH74RZQVVrYDU/Kp9zuQTABOwd1vQY1VXFdqYyXXBX6o1FUENO", "(99) 99999-9994", false, "e5476a89-2e0c-4bc4-b5e7-529c06737c06", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9885), "bob" },
                    { new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463"), 0, "b2d2c5aa-4a8d-4b0a-aa0c-8e5ee2a8aadf", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9885), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$u.xIO6WlDJAFOn8jFGWuWuBT46Qn7R55BZqhe7/D5EVImXxCGxz2u", "(99) 99999-9993", false, "8f317eac-cb14-4281-b5e0-709cc4d407b8", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9881), "alice" },
                    { new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2"), 0, "f287012f-4300-48f2-b8bc-db7f1b414be8", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9880), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$mn.zHmXVd3p/UHbKNxIzH..kF052qOhwBlR7c8taQc4PGB1qt4GZe", "(99) 99999-9992", false, "f91f07ef-50bb-49d9-a1eb-8d3ed0c4bd02", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9862), "jane" },
                    { new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51"), 0, "265f8558-8e00-44b3-a334-a656bbc23c94", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9896), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$ET0SuSQS3GpFsTe4knPYQ.WRG/cnNsY6kJNDHEsR8Mh3SyEMAdDum", "(99) 99999-9995", false, "3599e024-79d8-4d50-aaa8-cf0fd7d6d2f1", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9893), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f") },
                    { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f") },
                    { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463") },
                    { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2") },
                    { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harvest");

            migrationBuilder.DropTable(
                name: "Plot");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51"));

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "Analise");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1d42e673-4875-4773-b2c6-1e30b2d727b6"), "0a00f58e-bf3b-49cf-8aa0-a8f5a5f9451d", "Admin", "ADMIN" },
                    { new Guid("767c534b-2b1d-499f-9e78-b158932a8d05"), "5f4ee767-5d55-4c4b-acaa-244a6f13e635", "Owner", "OWNER" },
                    { new Guid("bd088014-6656-4ca7-b072-65285e9f29c0"), "d56bbaf1-9a33-4e59-9f53-b93fdbde3ae7", "Collaborator", "COLLABORATOR" },
                    { new Guid("d6f16d8d-e337-49b7-8773-e8b056801cae"), "46099a8c-c15e-44c6-817e-c1df55ad8568", "Consultant", "CONSULTANT" },
                    { new Guid("ffdb767f-0f78-40eb-b9c4-ed1101ac4851"), "0ff60732-9cb0-48dc-9f0b-8487b7298c21", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("a105d136-5ecf-4106-94af-bb6573d47540"), 0, "29f51732-e786-4173-99f7-47223308c208", new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4318), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$N9KyU2uPE9rdH52qxOTNye4iTCCIgN0/wXBFGS0.NYd6Pw62BoHeO", "(99) 99999-9995", false, "17b33195-0668-408e-82cd-f664021a3c5d", 0, false, new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4315), "charlie" },
                    { new Guid("eb5e463b-2ac9-4519-990c-9d009901ff39"), 0, "35ce8195-6aa2-481b-977c-0c9bd3aa9fcf", new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4031), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$b5INA0D5o1ikFE5d3FmmVuyylDWblZNb4DRyd9y..HLF/WK6WmLjy", "(99) 99999-9991", false, "6bd1c341-9536-4d65-b69d-313defd67f8f", 0, false, new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(2180), "john" },
                    { new Guid("fa32d592-0eb3-4aed-b714-7c01894db520"), 0, "bf5213e8-3839-43b8-9169-a335cd0e9c88", new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4303), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$aTe9M/r2n7hpgb4dCUYREO81PZGJRMVgHsWBeld02hTPXknbugOpK", "(99) 99999-9992", false, "81646206-068b-474a-a826-55611107c4b3", 0, false, new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4285), "jane" },
                    { new Guid("fea9e587-3c3c-4497-9fe7-6f2ad8da6b1d"), 0, "7c0c1439-42ba-49bd-af8f-3f9aa2b7c3ad", new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4307), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$in1lJjAD3aBndM6YKa9lIOsZy5abCa7D0WGHwwX.QcdrwLdPqk.e6", "(99) 99999-9993", false, "3a8dfda3-c9e3-420a-a6ef-49bc3df0a20d", 0, false, new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4304), "alice" },
                    { new Guid("ff3bb54b-0397-420e-9e43-43d69bbf70dc"), 0, "a1386ccd-0f4c-490c-af7c-57e253c0c31d", new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4315), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$NbsUURGZap3S0ZXFB37TA.n77xCazfohv8/GqCkxlGWKol06hOdli", "(99) 99999-9994", false, "0da531fd-5299-4409-938f-533fc56780c0", 0, false, new DateTime(2025, 7, 22, 10, 25, 37, 566, DateTimeKind.Local).AddTicks(4308), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bd088014-6656-4ca7-b072-65285e9f29c0"), new Guid("a105d136-5ecf-4106-94af-bb6573d47540") },
                    { new Guid("1d42e673-4875-4773-b2c6-1e30b2d727b6"), new Guid("eb5e463b-2ac9-4519-990c-9d009901ff39") },
                    { new Guid("767c534b-2b1d-499f-9e78-b158932a8d05"), new Guid("fa32d592-0eb3-4aed-b714-7c01894db520") },
                    { new Guid("d6f16d8d-e337-49b7-8773-e8b056801cae"), new Guid("fea9e587-3c3c-4497-9fe7-6f2ad8da6b1d") },
                    { new Guid("ffdb767f-0f78-40eb-b9c4-ed1101ac4851"), new Guid("ff3bb54b-0397-420e-9e43-43d69bbf70dc") }
                });
        }
    }
}
