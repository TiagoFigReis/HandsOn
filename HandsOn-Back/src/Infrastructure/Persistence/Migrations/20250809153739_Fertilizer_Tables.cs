using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class Fertilizer_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deleta os dados inseridos pela migração anterior ('removedHarvestAndPlotEntitities')
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

            // Cria a nova tabela 'FertilizerTables'
            migrationBuilder.CreateTable(
                name: "FertilizerTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LeafParameters = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoilParameters = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CultureId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerTables_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Insere os novos dados desta migração
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), "9b75450e-b7f9-4ec8-9096-c88c32b1e0d4", "Consultant", "CONSULTANT" },
                    { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), "9ccbfd03-9f47-49d6-a054-24c3ce4c8178", "Owner", "OWNER" },
                    { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), "7baeffdd-39b5-4cd3-ad16-7f0b3b1c8e4b", "Admin", "ADMIN" },
                    { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), "a6f2bbeb-f42d-4257-8e9a-e1d2dfaf1054", "Collaborator", "COLLABORATOR" },
                    { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), "fb46d42a-d3fb-43d0-acb5-9d34ee3b089f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587"), 0, "9d32d11e-7081-43ff-a6d9-0a90884d7c0a", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4974), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$xzACKrPGQchBijYt/kWB5OHFDB7FWskE0jl7.5Bem9cQIxtZes.LG", "(99) 99999-9992", false, "a8393fc9-e9fe-4bcf-b5b2-ca948f14d9fa", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4949), "jane" },
                    { new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5"), 0, "e2b8bf1b-8473-482f-a632-47cf05ebd25c", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4982), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$Br9o87ViLwhfR1yVMgyzkeaJQrbJsM9hLO5HIySBtTxgJp.TAZzFm", "(99) 99999-9995", false, "23da6f1c-d868-4117-8773-e57e4db8647c", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4980), "charlie" },
                    { new Guid("63117516-c9d3-43c0-9631-f05d25b19133"), 0, "a9fd64b8-743b-43c9-9df9-e3e6a6c3793d", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4980), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$qyMsC4B3PQ/0pvQSFGK/juwy.Ue1AxpfU51.k8w9/29Ovil1Nd56C", "(99) 99999-9994", false, "8cf87514-6bdf-471f-9f09-0f069253a4a3", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4978), "bob" },
                    { new Guid("938f8cbf-d731-4292-acde-86061c94c23c"), 0, "af4a7976-caf5-427b-8e57-063a048274a2", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4774), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$ZZxctgt8royUcSTOlzmUa.w/VoMg3Ik95.aLgDINTCNziJuYSp3fa", "(99) 99999-9991", false, "130827c8-d5ee-4e95-bed9-b0e76efbb31d", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(3316), "john" },
                    { new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb"), 0, "60e31cfb-05ca-4924-9e58-4bda1b7cbb21", new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4977), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$5Obc3zTg.J/C1RpHeDROc.N6VuLzbme6zwshrcibV5B4KHQ.Zmyvu", "(99) 99999-9993", false, "fbfd9b5f-1312-46f7-a53b-2497923956cf", 0, false, new DateTime(2025, 8, 9, 12, 37, 37, 996, DateTimeKind.Local).AddTicks(4975), "alice" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 9, 12, 37, 39, 7, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587") },
                    { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5") },
                    { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), new Guid("63117516-c9d3-43c0-9631-f05d25b19133") },
                    { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), new Guid("938f8cbf-d731-4292-acde-86061c94c23c") },
                    { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerTables_CultureId",
                table: "FertilizerTables",
                column: "CultureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerTables");

            // Deleta os dados inseridos pelo método Up desta migração
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"), new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"), new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"), new Guid("63117516-c9d3-43c0-9631-f05d25b19133") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"), new Guid("938f8cbf-d731-4292-acde-86061c94c23c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"), new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bac0885-d6dd-4071-862c-9419268e2cc0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c2c8d90-185e-4018-97b5-ef6a264a49d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3e6fd09-ddeb-4dad-b690-94033592b19e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1667636-46ae-4a50-9952-3ad9c0c4dd93"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e76561f5-8798-4364-905c-9b27e39c9b5f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("15764c95-a14f-4a0d-8772-cff4d94d9587"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32ed38bf-27ae-487b-8d37-7339d25d63d5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63117516-c9d3-43c0-9631-f05d25b19133"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("938f8cbf-d731-4292-acde-86061c94c23c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35fad6c-0c9b-4352-bd8d-c7f49718dafb"));

            // Re-insere os dados da migração anterior para restaurar o estado
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
    }
}