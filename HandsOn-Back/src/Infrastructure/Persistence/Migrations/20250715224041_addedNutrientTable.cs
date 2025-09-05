using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedNutrientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "NutrientTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CultureType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Standard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TableData = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientTables_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_NutrientTables_UserId",
                table: "NutrientTables",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutrientTables");

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
    }
}
