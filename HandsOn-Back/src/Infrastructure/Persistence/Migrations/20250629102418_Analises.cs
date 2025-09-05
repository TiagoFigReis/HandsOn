using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Analises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), new Guid("3d333144-c00a-490f-970c-aa995da67100") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), new Guid("9b133a03-3800-4248-b129-4d74a60d8395") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d333144-c00a-490f-970c-aa995da67100"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b133a03-3800-4248-b129-4d74a60d8395"));

            migrationBuilder.CreateTable(
                name: "Analise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tipo = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Lab = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proprietario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Propriedade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnaliseUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analise", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analise");

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
                    { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), "aa23e890-96a6-4557-82a2-eae8ebade3cb", "Consultant", "CONSULTANT" },
                    { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), "a06d95f3-9c52-4a39-ad2a-4085ec83e764", "Manager", "MANAGER" },
                    { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), "3d58d68b-3852-40d9-9c40-e0f0565ec68e", "Collaborator", "COLLABORATOR" },
                    { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), "dbfcf47c-59be-4b08-a9ca-fbbdb18bd6d9", "Owner", "OWNER" },
                    { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), "431e73e6-5238-4024-8141-5355c5e91d52", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("3d333144-c00a-490f-970c-aa995da67100"), 0, "db52f37f-924e-42af-ab5f-1bca57412bbd", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2569), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$.fY72scmAdUZ2leBi5.O/Op2XbpJnFMh2n.LdeoY246Pa6Rt/uDO2", "(99) 99999-9991", false, "7841ebd5-6212-48f6-a6b2-aa472f01ccc2", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 116, DateTimeKind.Local).AddTicks(9351), "john" },
                    { new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"), 0, "5fe5ed19-8167-4b69-b38c-9d8f6a076012", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3065), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$/e8R1TfwYfT6XsB7Zddmo.KynrAEY.TIrbpjigDGW5FQgvyBM2ptS", "(99) 99999-9993", false, "546d828d-a70e-4012-a6e9-8beac0552599", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3056), "alice" },
                    { new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"), 0, "650cce00-1734-4585-bc30-a25474e282a8", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3087), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$B/ngxiWj0FCSa/osLPYBAez8k6ntJjUhNbyAjGcGFUNmr0ak.W8Vm", "(99) 99999-9995", false, "553b8b44-52e4-4f09-99f8-d225f03d3433", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3079), "charlie" },
                    { new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"), 0, "020c0d83-b132-45e0-bc26-a5b64941d899", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3075), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$27zZAGL4qvzhThokBox8ieggp7l8UGPEu9YpM/4giov2rM33bLA8a", "(99) 99999-9994", false, "b89df511-3e8d-404a-9e1e-e7f7ce66d508", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3067), "bob" },
                    { new Guid("9b133a03-3800-4248-b129-4d74a60d8395"), 0, "3b863f86-88cf-4e75-b081-2ef902a1dadd", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3052), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$ioHWq/EohvquKoiZlGW2SeUthdzBRHxRavz64jPADk2wAj5cTgv9O", "(99) 99999-9992", false, "8847620b-0885-4b56-8a87-68e9f0548727", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2994), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), new Guid("3d333144-c00a-490f-970c-aa995da67100") },
                    { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8") },
                    { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31") },
                    { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850") },
                    { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), new Guid("9b133a03-3800-4248-b129-4d74a60d8395") }
                });
        }
    }
}
