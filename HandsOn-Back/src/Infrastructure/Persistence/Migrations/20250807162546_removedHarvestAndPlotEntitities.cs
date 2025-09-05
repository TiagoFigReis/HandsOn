using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedHarvestAndPlotEntitities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harvest");

            migrationBuilder.DropTable(
                name: "Plot");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), new Guid("20db1d65-fb40-4e95-935c-e64d52871136") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("4e6d9c6a-0cc9-47ed-97e1-3ceedd72faae"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("deaec80a-34c1-4193-890d-24f2dcbd2b09"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed210b5f-776e-4bdb-900d-007562377db7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("20db1d65-fb40-4e95-935c-e64d52871136"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17786e53-8575-40c5-abbd-64a2988673f0"), "4355c265-b4f6-4ca8-a34b-c92921ea295c", "Manager", "MANAGER" },
                    { new Guid("4117e99f-16de-4dbd-9f6d-fa8d466ccacf"), "1040f0ab-b214-419f-a55a-1a68f28154e4", "Collaborator", "COLLABORATOR" },
                    { new Guid("52a004db-3a8b-47dc-9156-84cae062f1c1"), "7de7f808-f846-43ae-91d7-034705e5ebbd", "Admin", "ADMIN" },
                    { new Guid("bfb4c35b-de75-47e8-8b39-07aaef7ee6c5"), "fc647dd1-7037-48d6-850d-145d1dfef0e6", "Consultant", "CONSULTANT" },
                    { new Guid("f0443426-d420-4d61-9829-98812c9e411c"), "25d985b8-f38a-41a0-8f24-0f9cf95615ab", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("054adc0a-eaae-4c96-9dca-253ac9d78011"), 0, "04594243-7204-42d7-ac41-2c016a38fd51", new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2281), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$3gx9popSfAcxVU81TjJ3gOXiBWbmRiLydYmRla79G73tdIjgMW1IG", "(99) 99999-9993", false, "6af1060e-ce8f-4df7-a323-c0fccb84f3aa", 0, false, new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2278), "alice" },
                    { new Guid("88857bfa-53fe-4941-9e70-fbe2e6658bd6"), 0, "e181bc0e-b3d7-4030-b805-1208a38c8b66", new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2277), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$WdjvY3ZwqeJsrdgiAbDq7uQEfWZlJ6P/rP71LU4yGAq5WDEXVMYH.", "(99) 99999-9992", false, "e80e22be-6605-4065-b1dd-f65ec1cd5ec8", 0, false, new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2251), "jane" },
                    { new Guid("b1a11376-041d-4e22-90bd-9b6533f0f613"), 0, "7892e580-0786-4b86-a5c3-3f63b99a560f", new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2287), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$GFlNLmtdNILRYYbuFbum0ufvfBQu6V7WrYeSkNimFJRWIpi/PVcf2", "(99) 99999-9995", false, "8ab02a84-6e6a-4a04-a975-991f4b89461a", 0, false, new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2285), "charlie" },
                    { new Guid("c21103fa-c956-4db1-9a0f-c395ffc8e749"), 0, "fb1f401d-6b5a-44a5-90ef-019aefde1315", new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2284), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$vYR8tgA.inHZGoXIpg.qour7XSZsoCk131zuMtFof7IvXIuoZkbQ6", "(99) 99999-9994", false, "22003168-1582-4893-b2d4-8f09a391d279", 0, false, new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(2281), "bob" },
                    { new Guid("f10c1be8-7a9b-4f87-87a3-151a5442757f"), 0, "a6affd3f-99e9-4492-9601-6c13b5dc881a", new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(1984), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$bPJC7P0lp6A1TEuEmypTH.Wzd/4DrrC4fvBzYdcr7bUY2EX7kR1.e", "(99) 99999-9991", false, "a4b8e069-078a-4c36-8491-9978934cf77f", 0, false, new DateTime(2025, 8, 7, 13, 25, 45, 209, DateTimeKind.Local).AddTicks(59), "john" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 7, 13, 25, 45, 968, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bfb4c35b-de75-47e8-8b39-07aaef7ee6c5"), new Guid("054adc0a-eaae-4c96-9dca-253ac9d78011") },
                    { new Guid("f0443426-d420-4d61-9829-98812c9e411c"), new Guid("88857bfa-53fe-4941-9e70-fbe2e6658bd6") },
                    { new Guid("4117e99f-16de-4dbd-9f6d-fa8d466ccacf"), new Guid("b1a11376-041d-4e22-90bd-9b6533f0f613") },
                    { new Guid("17786e53-8575-40c5-abbd-64a2988673f0"), new Guid("c21103fa-c956-4db1-9a0f-c395ffc8e749") },
                    { new Guid("52a004db-3a8b-47dc-9156-84cae062f1c1"), new Guid("f10c1be8-7a9b-4f87-87a3-151a5442757f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bfb4c35b-de75-47e8-8b39-07aaef7ee6c5"), new Guid("054adc0a-eaae-4c96-9dca-253ac9d78011") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f0443426-d420-4d61-9829-98812c9e411c"), new Guid("88857bfa-53fe-4941-9e70-fbe2e6658bd6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4117e99f-16de-4dbd-9f6d-fa8d466ccacf"), new Guid("b1a11376-041d-4e22-90bd-9b6533f0f613") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("17786e53-8575-40c5-abbd-64a2988673f0"), new Guid("c21103fa-c956-4db1-9a0f-c395ffc8e749") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("52a004db-3a8b-47dc-9156-84cae062f1c1"), new Guid("f10c1be8-7a9b-4f87-87a3-151a5442757f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17786e53-8575-40c5-abbd-64a2988673f0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4117e99f-16de-4dbd-9f6d-fa8d466ccacf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52a004db-3a8b-47dc-9156-84cae062f1c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfb4c35b-de75-47e8-8b39-07aaef7ee6c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0443426-d420-4d61-9829-98812c9e411c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("054adc0a-eaae-4c96-9dca-253ac9d78011"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88857bfa-53fe-4941-9e70-fbe2e6658bd6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1a11376-041d-4e22-90bd-9b6533f0f613"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c21103fa-c956-4db1-9a0f-c395ffc8e749"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f10c1be8-7a9b-4f87-87a3-151a5442757f"));

            migrationBuilder.CreateTable(
                name: "Plot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Area = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coordenadas = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plot_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AnoAgricola = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cultura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPlantio = table.Column<DateOnly>(type: "date", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlotId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProducaoEsperada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvest_Plot_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), "6159faaa-d131-49b5-84c6-d319b2b45e52", "Owner", "OWNER" },
                    { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), "131333c6-a6d1-43ca-8a99-1b2ca49e0871", "Manager", "MANAGER" },
                    { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), "3c0f2afe-c48b-47a9-9dbd-2fee749b3aa9", "Consultant", "CONSULTANT" },
                    { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), "89d4c643-5285-4faf-b3a1-39dfedee40bb", "Admin", "ADMIN" },
                    { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), "dce73cc2-88a7-4255-8309-1e6da93a7c1f", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("20db1d65-fb40-4e95-935c-e64d52871136"), 0, "1765411f-426e-42ac-a1ae-37e250bab11b", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1897), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$dO2mniqe4mkNc4Xwo7df.OmXVDkP/qnQhqpqYCEwnnwKszHJ40/pC", "(99) 99999-9993", false, "2c7cdbb9-ca1f-4b83-b21a-6cda4baa723d", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1889), "alice" },
                    { new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce"), 0, "7015c8d4-48a0-4b46-94b7-8951a43a0711", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1904), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$GW79apfYUpVkF1O2Wl0jeuzijNrusKyD.LKkI7YGCJD2jvZWJzWjW", "(99) 99999-9995", false, "c500bca3-da5e-411a-b950-01a13d31e188", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1901), "charlie" },
                    { new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b"), 0, "53f64e7a-ad8a-4186-a4fc-fa9d1e138bcd", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1888), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$o8VgU7q13jWhDo51Z0SB6OHJsRCp21la.ONCxM7FplIshUFe/lW4G", "(99) 99999-9992", false, "986ff782-d24d-4904-8c70-8e78dcd970dd", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1870), "jane" },
                    { new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab"), 0, "bcc06076-a60b-4b68-a143-88939193e05c", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1513), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$9HEN4IdZ6EFuZJ.N2qTsze6bEmHBoZbJ06DkEuVmIsJoSBQkCq4ma", "(99) 99999-9991", false, "523b1d4c-f604-41ed-a49f-d21df2c00752", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 447, DateTimeKind.Local).AddTicks(9724), "john" },
                    { new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c"), 0, "1c8c4eac-d2ad-4a9e-9db4-0b9767936cbb", new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1900), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$4UmOxd9B9npjTpoTVaues.OIBrnZ99YG3sgVPeN2DZw8TO2TthCW.", "(99) 99999-9994", false, "9a9afd16-123a-4a6c-8c12-30e91a9f2282", 0, false, new DateTime(2025, 8, 7, 10, 11, 53, 448, DateTimeKind.Local).AddTicks(1897), "bob" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 7, 10, 11, 54, 215, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7d5bb694-5294-48e6-9587-4755e53c1e70"), new Guid("20db1d65-fb40-4e95-935c-e64d52871136") },
                    { new Guid("f36ec37a-be79-497b-bfab-eaf25eb8ff95"), new Guid("3452d5d7-2892-4fff-b66e-876e7a5e95ce") },
                    { new Guid("1800adb5-ab22-4a45-8e93-4a6ca802b1d9"), new Guid("71b7a6ab-f5dc-4f30-a510-82345693675b") },
                    { new Guid("ed210b5f-776e-4bdb-900d-007562377db7"), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") },
                    { new Guid("2c9a112f-a709-4b8d-88d9-9a49eef07272"), new Guid("fc9f8aa1-e92f-44bd-8c29-26cba269f79c") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "Name", "SoilData", "Standard", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4e6d9c6a-0cc9-47ed-97e1-3ceedd72faae"), new DateTime(2025, 8, 7, 13, 11, 54, 254, DateTimeKind.Utc).AddTicks(8318), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":15,\"Max\":25},{\"Header\":9,\"Min\":20,\"Max\":30},{\"Header\":8,\"Min\":15,\"Max\":25},{\"Header\":10,\"Min\":20,\"Max\":30},{\"Header\":7,\"Min\":25,\"Max\":40}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Alta Eficiência", "", true, 1, new DateTime(2025, 8, 7, 13, 11, 54, 254, DateTimeKind.Utc).AddTicks(8647), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") },
                    { new Guid("deaec80a-34c1-4193-890d-24f2dcbd2b09"), new DateTime(2025, 8, 7, 13, 11, 54, 255, DateTimeKind.Utc).AddTicks(180), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "{\"LeafNutrientRows\":[{\"LeafNutrientColumns\":[{\"Header\":6,\"Min\":8,\"Max\":12},{\"Header\":9,\"Min\":10,\"Max\":15},{\"Header\":8,\"Min\":8,\"Max\":12},{\"Header\":10,\"Min\":0,\"Max\":5},{\"Header\":7,\"Min\":15,\"Max\":25}]}],\"SoilNutrientRow\":{\"SoilNutrientColumns\":[]}}", "Tabela FE - Fontes Padrão", "", true, 1, new DateTime(2025, 8, 7, 13, 11, 54, 255, DateTimeKind.Utc).AddTicks(181), new Guid("c54bc64b-5729-46b7-85fb-3a1bd6befeab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_PlotId",
                table: "Harvest",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Plot_UserId",
                table: "Plot",
                column: "UserId");
        }
    }
}
