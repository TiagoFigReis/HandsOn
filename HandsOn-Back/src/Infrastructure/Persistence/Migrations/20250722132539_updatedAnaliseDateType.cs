using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedAnaliseDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Apaga os dados semeados pela migração anterior para substituí-los.
            // Os GUIDs aqui DEVEM corresponder aos inseridos na migração 'updatedAnalise'.
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("15de5412-e412-46dd-bbe1-f781aeaa97e0"), new Guid("0a98bfea-ad93-442b-9c5d-c44a8ea5897d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("eb75dc5b-aaf6-4d76-bbd9-f5cb4a1abe96"), new Guid("2fadbb94-b492-433f-abf7-0b4a3a6347ea") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("571e9985-eb99-4db9-960b-ca29189610fe"), new Guid("3a8f33d9-b746-4f45-b2cc-b27859dceb15") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b09f15bb-2d3c-48be-ac9d-5db9d735129e"), new Guid("43238013-5f04-449a-bf42-7ad4cae03993") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ce5ba32c-8705-4c15-bb65-f235d055ffd1"), new Guid("9bb98090-926d-4345-9b2b-efb0ed436fa5") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("15de5412-e412-46dd-bbe1-f781aeaa97e0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("571e9985-eb99-4db9-960b-ca29189610fe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b09f15bb-2d3c-48be-ac9d-5db9d735129e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce5ba32c-8705-4c15-bb65-f235d055ffd1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eb75dc5b-aaf6-4d76-bbd9-f5cb4a1abe96"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a98bfea-ad93-442b-9c5d-c44a8ea5897d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fadbb94-b492-433f-abf7-0b4a3a6347ea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3a8f33d9-b746-4f45-b2cc-b27859dceb15"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("43238013-5f04-449a-bf42-7ad4cae03993"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bb98090-926d-4345-9b2b-efb0ed436fa5"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataAnalise",
                table: "Analise",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1)); 

            migrationBuilder.DropColumn(
                name: "Mes", 
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataAnalise",
                table: "Analise",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1)); 

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15de5412-e412-46dd-bbe1-f781aeaa97e0"), "2f1a2b71-4d09-4a66-97ef-73927ca078ce", "Consultant", "CONSULTANT" },
                    { new Guid("571e9985-eb99-4db9-960b-ca29189610fe"), "7ef94675-6dd1-4759-b41f-344c13049388", "Owner", "OWNER" },
                    { new Guid("b09f15bb-2d3c-48be-ac9d-5db9d735129e"), "aa05418d-bbf0-4ab7-a393-352a3dbc9d1b", "Manager", "MANAGER" },
                    { new Guid("ce5ba32c-8705-4c15-bb65-f235d055ffd1"), "af8e23ff-f1b9-4241-a77d-52119ca77636", "Admin", "ADMIN" },
                    { new Guid("eb75dc5b-aaf6-4d76-bbd9-f5cb4a1abe96"), "9ef6fcc2-9c7c-47ef-b127-504f140d2dcd", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a98bfea-ad93-442b-9c5d-c44a8ea5897d"), 0, "efedd97c-8683-4e4d-b4f9-6d17551a3f7c", new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5571), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$.UNSEcqN0mDPutoUTlJewe5P7jrUR.kIjpAqlPp/d9jELh/P0XgwS", "(99) 99999-9993", false, "8eb719b9-9d12-4ccf-915b-39b1d8f0949b", 0, false, new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5568), "alice" },
                    { new Guid("2fadbb94-b492-433f-abf7-0b4a3a6347ea"), 0, "9490ebfc-92d6-4b4e-ae98-e1c0d4132bd4", new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5578), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$oGUgOLgS/.tgI43xjQKUu.L2hcjJf3Evh9EdPmMsrIMJplfSYm60e", "(99) 99999-9995", false, "a1b26794-b961-47bd-9694-eb53817b0b25", 0, false, new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5575), "charlie" },
                    { new Guid("3a8f33d9-b746-4f45-b2cc-b27859dceb15"), 0, "ca456ade-c3a9-466b-a093-a651c1bec173", new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5567), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$YRcKSYiS3/uKdtxxXfEHceNn4HPaoEhycD7Teszd.BAI1kUvyxFyq", "(99) 99999-9992", false, "68924bd8-6890-44ea-980b-4e96b416e903", 0, false, new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5544), "jane" },
                    { new Guid("43238013-5f04-449a-bf42-7ad4cae03993"), 0, "df3873bf-490c-4ed0-bc81-d49c60dc327a", new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5575), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$CIRmgPTU35eFqiBeSB9IUeXPAZi11ACzQFVOG0Uz7Nxdx/5j2XFbK", "(99) 99999-9994", false, "d7d2ebfc-66a6-4f9d-9b00-3294205c7a6d", 0, false, new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5572), "bob" },
                    { new Guid("9bb98090-926d-4345-9b2b-efb0ed436fa5"), 0, "dfa735f5-5af5-4dee-8118-f058f8bfd850", new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(5289), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$xQAURbMO.DXIGniiEl8sXOjCnlGnQMh82h.RGNb.sn9oji/76nKPi", "(99) 99999-9991", false, "af9ffdab-189b-4d39-a571-3787e6f1498c", 0, false, new DateTime(2025, 7, 15, 21, 59, 9, 260, DateTimeKind.Local).AddTicks(3352), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("15de5412-e412-46dd-bbe1-f781aeaa97e0"), new Guid("0a98bfea-ad93-442b-9c5d-c44a8ea5897d") },
                    { new Guid("eb75dc5b-aaf6-4d76-bbd9-f5cb4a1abe96"), new Guid("2fadbb94-b492-433f-abf7-0b4a3a6347ea") },
                    { new Guid("571e9985-eb99-4db9-960b-ca29189610fe"), new Guid("3a8f33d9-b746-4f45-b2cc-b27859dceb15") },
                    { new Guid("b09f15bb-2d3c-48be-ac9d-5db9d735129e"), new Guid("43238013-5f04-449a-bf42-7ad4cae03993") },
                    { new Guid("ce5ba32c-8705-4c15-bb65-f235d055ffd1"), new Guid("9bb98090-926d-4345-9b2b-efb0ed436fa5") }
                });
        }
    }
}