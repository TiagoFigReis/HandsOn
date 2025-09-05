using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedAnalise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87a6d558-e9a6-4e03-8f07-95af29602e59"), new Guid("017a7061-52bc-4da2-80c7-fc49558cda76") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a81fe5f5-acbe-4300-8d9e-c2136372d80c"), new Guid("b4ec9f43-1e9b-4633-a811-d8e174a1530d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1a8e87a7-601d-48d3-a2e6-3b430535c58c"), new Guid("c87d664b-ee15-4303-a7b9-3e63a5e26545") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3e6fedc4-a7d6-40d2-a090-adb7650688d1"), new Guid("e42cfa9b-1dd1-411d-acd3-e3d3e5aed55c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e41215d5-7c5c-44e8-81a0-c1a76b49d929"), new Guid("fa6805b0-7122-49aa-8191-03441c86b147") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a8e87a7-601d-48d3-a2e6-3b430535c58c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6fedc4-a7d6-40d2-a090-adb7650688d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87a6d558-e9a6-4e03-8f07-95af29602e59"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a81fe5f5-acbe-4300-8d9e-c2136372d80c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e41215d5-7c5c-44e8-81a0-c1a76b49d929"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("017a7061-52bc-4da2-80c7-fc49558cda76"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4ec9f43-1e9b-4633-a811-d8e174a1530d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c87d664b-ee15-4303-a7b9-3e63a5e26545"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e42cfa9b-1dd1-411d-acd3-e3d3e5aed55c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa6805b0-7122-49aa-8191-03441c86b147"));

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "Analise",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Analise");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1a8e87a7-601d-48d3-a2e6-3b430535c58c"), "e18245cb-ec66-4b89-890b-aa813faa15e2", "Consultant", "CONSULTANT" },
                    { new Guid("3e6fedc4-a7d6-40d2-a090-adb7650688d1"), "db0f4c8c-8398-4f65-b19a-514878617803", "Collaborator", "COLLABORATOR" },
                    { new Guid("87a6d558-e9a6-4e03-8f07-95af29602e59"), "07c72148-5aad-444c-94dd-8558fd9c1142", "Owner", "OWNER" },
                    { new Guid("a81fe5f5-acbe-4300-8d9e-c2136372d80c"), "b90004c0-784a-4938-8c11-f752b9d77176", "Manager", "MANAGER" },
                    { new Guid("e41215d5-7c5c-44e8-81a0-c1a76b49d929"), "bc6d79e0-115d-47e9-b804-6186dffcf9c1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("017a7061-52bc-4da2-80c7-fc49558cda76"), 0, "41eaae22-b53b-4775-a491-917c84aee35c", new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6065), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Aul/nwiQTTQS2ntukxFkeOCAkdQUUNFHPusDjWVLvvEyQdGEcIjvi", "(99) 99999-9992", false, "7b60730b-a42f-45db-bb03-9b67a07666ec", 0, false, new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6047), "jane" },
                    { new Guid("b4ec9f43-1e9b-4633-a811-d8e174a1530d"), 0, "f32b5287-fd3d-4f8a-8a10-88aa725b24e4", new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6073), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$kzTL/WvYLntT8Shq7jV02O94erEFmH3UKARvniebBMO9heAbcWqza", "(99) 99999-9994", false, "c631a7a4-c93c-485c-b7d2-46bdd9734f57", 0, false, new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6070), "bob" },
                    { new Guid("c87d664b-ee15-4303-a7b9-3e63a5e26545"), 0, "84121127-197f-4fe4-b949-f38632b2d1b3", new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6069), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$ZvkiTOT85rT5JPByQVazsOSPBR/AYofyxW32F0a9pfbcHLyUdQXLi", "(99) 99999-9993", false, "2371436b-0089-4c30-b364-31a6c6ceefd8", 0, false, new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6066), "alice" },
                    { new Guid("e42cfa9b-1dd1-411d-acd3-e3d3e5aed55c"), 0, "dd9d2390-7833-4bba-bec3-44b6460f23fc", new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6080), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$.eng74VF7bGSc08CdePnFOrpUsLRhdeO0wLGSmuRHJltWmzouyicu", "(99) 99999-9995", false, "ce42577c-1de9-4f23-875d-0b9262d74477", 0, false, new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(6073), "charlie" },
                    { new Guid("fa6805b0-7122-49aa-8191-03441c86b147"), 0, "07f06523-a95b-4624-af7f-96d21966633c", new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(5797), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$3oyRu/7juyG.zVrHejhih.jTusltqBYjKKJhPdVYk6G8RwyNtc636", "(99) 99999-9991", false, "bbff82d1-4d18-4435-b114-09f24198054f", 0, false, new DateTime(2025, 7, 15, 19, 40, 39, 674, DateTimeKind.Local).AddTicks(3933), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("87a6d558-e9a6-4e03-8f07-95af29602e59"), new Guid("017a7061-52bc-4da2-80c7-fc49558cda76") },
                    { new Guid("a81fe5f5-acbe-4300-8d9e-c2136372d80c"), new Guid("b4ec9f43-1e9b-4633-a811-d8e174a1530d") },
                    { new Guid("1a8e87a7-601d-48d3-a2e6-3b430535c58c"), new Guid("c87d664b-ee15-4303-a7b9-3e63a5e26545") },
                    { new Guid("3e6fedc4-a7d6-40d2-a090-adb7650688d1"), new Guid("e42cfa9b-1dd1-411d-acd3-e3d3e5aed55c") },
                    { new Guid("e41215d5-7c5c-44e8-81a0-c1a76b49d929"), new Guid("fa6805b0-7122-49aa-8191-03441c86b147") }
                });
        }
    }
}
