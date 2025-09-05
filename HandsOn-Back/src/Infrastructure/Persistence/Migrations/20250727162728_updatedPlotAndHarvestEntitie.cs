using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedPlotAndHarvestEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), new Guid("5bb15db8-3675-4114-88e3-498597044987") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), new Guid("b27ee196-032b-4f7e-853d-8ce54302a236") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77efed5c-12ba-497c-891a-e1b271782df0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5bb15db8-3675-4114-88e3-498597044987"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b27ee196-032b-4f7e-853d-8ce54302a236"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838"));

            migrationBuilder.DropColumn(
                name: "Cultivar",
                table: "Harvest");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Plot",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProducaoEsperada",
                table: "Harvest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), "baea9819-8938-4479-ba07-13551d2ba23a", "Collaborator", "COLLABORATOR" },
                    { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), "6202027f-b556-41e0-9b53-3b5207b105bc", "Manager", "MANAGER" },
                    { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), "dd6bfe22-ccdb-4faa-812e-80f0a05aed30", "Admin", "ADMIN" },
                    { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), "90fd25bc-95d4-47a8-b1f5-e9786b48008f", "Owner", "OWNER" },
                    { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), "62735984-8efc-4ee3-8988-72341d88b3cb", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797"), 0, "df55c81a-8113-4d36-bb1d-c4b5b7fcbdfc", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5105), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$DBTr1QVfZ3jeivt.5o8nze9edf86U4zksJdbyko4bnJhr/UHwhuiK", "(99) 99999-9992", false, "277a6c76-51e7-484f-8278-46fff7264ff4", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5088), "jane" },
                    { new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b"), 0, "6123c1e0-c8ee-43f5-a406-8618271cd6a4", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5120), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JQf8KLisiUI/hziV7q860ejkGVYYaankuf1EZSjZ9Pefm5ihMInuq", "(99) 99999-9995", false, "ace53c87-66e7-49a3-b660-bec4a559f3e6", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5114), "charlie" },
                    { new Guid("deb34abf-d7b7-49d8-8001-6666e5757429"), 0, "084e6193-a1b9-4c43-8854-d46c977d706d", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5109), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$2SLUnrB4bEy2XJRIFV0Q8.Hbc/l.Do8qmq/wts0RGlYsP5EbkjyJi", "(99) 99999-9993", false, "b9d73caa-2e17-455e-80e6-6246a6778608", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5106), "alice" },
                    { new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a"), 0, "824ba82a-68da-4e93-93a1-bd10f1de0644", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(4849), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$qMij7G9o5tjsncPyMqvf4OlkUORgfG2H9t/g9qFMCHCMPR/iPf6xK", "(99) 99999-9991", false, "0dfbbf9e-2099-4ebb-9099-a244a965b898", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(3012), "john" },
                    { new Guid("f759becb-176d-45e9-b23a-7b715d5c401a"), 0, "11523aa3-39ae-4e8b-8630-9ebf935a846d", new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5113), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$uoclND/iiCAftV4TxFozuOwOXXHiMw4W8/dYxjRwU0V0hU3HQRur6", "(99) 99999-9994", false, "7e803890-99ca-436c-82f6-8e0deb22c641", 0, false, new DateTime(2025, 7, 27, 13, 27, 26, 559, DateTimeKind.Local).AddTicks(5110), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797") },
                    { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b") },
                    { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), new Guid("deb34abf-d7b7-49d8-8001-6666e5757429") },
                    { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a") },
                    { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), new Guid("f759becb-176d-45e9-b23a-7b715d5c401a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"), new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16032f08-f636-4725-b33d-ce52d51aed31"), new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"), new Guid("deb34abf-d7b7-49d8-8001-6666e5757429") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"), new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("366012e3-b13a-4836-b312-afc7025b45ab"), new Guid("f759becb-176d-45e9-b23a-7b715d5c401a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16032f08-f636-4725-b33d-ce52d51aed31"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("366012e3-b13a-4836-b312-afc7025b45ab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("526e3e55-973a-4ebc-b88e-44b1a71dd9b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b742fa2b-3ae7-4d35-854a-b3153eb6331f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be4f4b96-f159-4af6-9605-e7968573ec3f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("46f2e1ff-fb0b-4be0-91f5-a0917c73a797"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4eb556b9-bcbf-47b3-87b2-6edcc238a99b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("deb34abf-d7b7-49d8-8001-6666e5757429"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f56ab3c6-c6a1-4ad0-b8cf-edb0b9c8285a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f759becb-176d-45e9-b23a-7b715d5c401a"));

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Plot",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ProducaoEsperada",
                table: "Harvest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cultivar",
                table: "Harvest",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), "c704b892-62d4-414d-915d-45d2081d72be", "Consultant", "CONSULTANT" },
                    { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), "cb2a3749-7232-477a-acef-07716a160c9e", "Admin", "ADMIN" },
                    { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), "f82d0459-5ec3-4aa1-af30-cfe37a317d6c", "Collaborator", "COLLABORATOR" },
                    { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), "2f938fe1-18cc-4fb9-b71a-a3c7b00b3adc", "Manager", "MANAGER" },
                    { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), "99bff389-9dcc-440e-bb1d-0c425a689eeb", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5bb15db8-3675-4114-88e3-498597044987"), 0, "64b88d6c-b7b3-4f49-b871-636f34efa2c9", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3162), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$7wD/4vpwGaXauUd10ZPSteEp7Ue11GavfphSgmbjyf0F.ftiScqAy", "(99) 99999-9994", false, "829caa3e-3151-40ec-84a3-832d5d7a00bd", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3160), "bob" },
                    { new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e"), 0, "9e11565b-b9a9-40f9-9d64-4d311c1924b6", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3144), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$S7FQnM60rnhdhTOsHQ8Qke9.uvBHzuBVgC97RJXRoN6Fd0IwoXVdq", "(99) 99999-9992", false, "f506e0bc-84e3-4d7b-b595-1d85ec939531", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3135), "jane" },
                    { new Guid("b27ee196-032b-4f7e-853d-8ce54302a236"), 0, "942ec016-9ecc-4e84-a387-f510a4b44bf4", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(2869), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$yJRE96tE3o/jNDL8XHEKsuj9TCz/vSuucLEMJ.hoSacIqnMVEy1IO", "(99) 99999-9991", false, "2adf3690-2c71-49f8-a05a-29e83af7dbd8", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(1534), "john" },
                    { new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c"), 0, "b78f3761-d4b1-4c56-8de9-3e1fff6bc9ff", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3159), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$Qgolh1HGnTYyu5jVytslBeMdJKtilMmr/slY3K2diXAml5Z7tuEsu", "(99) 99999-9993", false, "a74fe19a-3136-4af5-8eb0-83e9fe313371", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3146), "alice" },
                    { new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838"), 0, "1a34f38a-9512-4d8c-842a-58b424d6a7c6", new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3164), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$B80r9RA05hC4k5QPAZcF.OGwZ8Yi6vUH66dUE1IlEP7ftFzaWHnLe", "(99) 99999-9995", false, "ecfa68e3-faf4-49ff-a85a-fa47920911a4", 0, false, new DateTime(2025, 7, 27, 0, 26, 27, 715, DateTimeKind.Local).AddTicks(3162), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("77efed5c-12ba-497c-891a-e1b271782df0"), new Guid("5bb15db8-3675-4114-88e3-498597044987") },
                    { new Guid("f6d0d04d-8c78-4388-beb8-14fa2eeea5a7"), new Guid("70328580-3ffc-4ed9-a484-9da3b9822f5e") },
                    { new Guid("36f5da5c-2eec-46d1-89c5-bc2eaa615c1e"), new Guid("b27ee196-032b-4f7e-853d-8ce54302a236") },
                    { new Guid("235cedb3-2982-41dd-bd32-186bbf83ff1e"), new Guid("f6a9c899-ee96-40fb-a407-d10c959b2c6c") },
                    { new Guid("775724b6-1e13-4732-b17e-ceaf7728530b"), new Guid("fba168d3-66a0-4f9a-9425-36d7a5645838") }
                });
        }
    }
}