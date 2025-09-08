using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Formulation_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), new Guid("935db416-f736-47aa-a5c3-b96f98bcd195") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), new Guid("a6f57896-0ef3-4946-9036-9e70934b6005") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99537fb9-272a-4cff-87cb-a56136635590"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("935db416-f736-47aa-a5c3-b96f98bcd195"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a6f57896-0ef3-4946-9036-9e70934b6005"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9"));

            migrationBuilder.CreateTable(
                name: "FormulationTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Standard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompoundFormulationRows = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasicFormulationRows = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CultureId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulationTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulationTables_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormulationTables_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0527c785-2ab6-4377-b3a7-dc1f3e1fe57e"), "4d29bdf9-19da-460c-b072-8264bba6eaa3", "Manager", "MANAGER" },
                    { new Guid("2f0ccda2-1756-4f2e-aba5-5e698d757e89"), "647e318b-0a4a-4e95-abe2-3206cdbc5a31", "Collaborator", "COLLABORATOR" },
                    { new Guid("4c73c00e-d370-4110-b752-8cab173511d2"), "5096e0df-90d4-4cf9-bbf4-c4203669316d", "Admin", "ADMIN" },
                    { new Guid("bb29a436-5e41-4799-849b-0aac4b43a5cb"), "676a38f8-03b5-4c3f-8613-325f10f075bf", "Owner", "OWNER" },
                    { new Guid("c9ee0adb-cea5-46fd-b474-c39be3d8e13c"), "764b1498-e29c-473c-8ebe-b11c8f92134d", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("246a92c7-5253-46e3-b1f5-e68bdb47f938"), 0, "8c0ea6b1-f50d-4134-bd2e-5a5a4a40b0eb", new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8587), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$Rc2PWc43i9gHulya2fpwvugOvaR/HSypJXxO6Xkogwex0W4z4DB0G", "(99) 99999-9993", false, "fe94485d-5439-4cf7-8516-0b50336de685", 0, false, new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8585), "alice" },
                    { new Guid("343d92d4-3a40-4ee4-a3e6-7fc04ec9877f"), 0, "f14dcfe4-9c70-45eb-bfd2-c4064c2a4623", new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8590), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$duh7Fo05X7SgobfGBkM1pORsPyyy/XV0pmhg4G32kJWtlQTCL9psi", "(99) 99999-9994", false, "32d2bf35-689a-437c-ab7f-5ca23e94f431", 0, false, new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8588), "bob" },
                    { new Guid("4d542a3e-7311-471b-a4c5-52b89145376d"), 0, "1929765c-3e2d-44b7-86be-9a124158c543", new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8584), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$/kYhsZj8tdOMBNod4lUPg..2iTFo7LsDRzvlFdcpOWcxCh2L5lhry", "(99) 99999-9992", false, "ab83559b-292f-4e8e-8832-f06eb51710e5", 0, false, new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8571), "jane" },
                    { new Guid("835ee2ee-a450-40cc-b1b6-20f8b0d1e0f8"), 0, "1c613d08-7ea8-4bff-a237-2194bc88816f", new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8398), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$1aVo9gpw0LR/35RHTv3Zquxe0RqEvBmYCbH6Za67DIQ4Jb.NQRLK6", "(99) 99999-9991", false, "2fdeb789-31cd-4654-a220-00ee193bdce7", 0, false, new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(7030), "john" },
                    { new Guid("b46610d4-9f49-4812-91c3-870bfe3a5c9b"), 0, "a0c9b307-12ef-4117-a1c0-f1219af4732f", new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8597), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$yipidSoqpeo7oItx0TCtkO/AWujMHFt99/Rhmk3EsAICSAfHuRXk6", "(99) 99999-9995", false, "d1652962-e794-4557-85c6-c5ac8d7f00f2", 0, false, new DateTime(2025, 9, 7, 19, 17, 26, 345, DateTimeKind.Local).AddTicks(8591), "charlie" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 9, 7, 19, 17, 27, 2, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c9ee0adb-cea5-46fd-b474-c39be3d8e13c"), new Guid("246a92c7-5253-46e3-b1f5-e68bdb47f938") },
                    { new Guid("0527c785-2ab6-4377-b3a7-dc1f3e1fe57e"), new Guid("343d92d4-3a40-4ee4-a3e6-7fc04ec9877f") },
                    { new Guid("bb29a436-5e41-4799-849b-0aac4b43a5cb"), new Guid("4d542a3e-7311-471b-a4c5-52b89145376d") },
                    { new Guid("4c73c00e-d370-4110-b752-8cab173511d2"), new Guid("835ee2ee-a450-40cc-b1b6-20f8b0d1e0f8") },
                    { new Guid("2f0ccda2-1756-4f2e-aba5-5e698d757e89"), new Guid("b46610d4-9f49-4812-91c3-870bfe3a5c9b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormulationTables_CultureId",
                table: "FormulationTables",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulationTables_UserId",
                table: "FormulationTables",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormulationTables");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c9ee0adb-cea5-46fd-b474-c39be3d8e13c"), new Guid("246a92c7-5253-46e3-b1f5-e68bdb47f938") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0527c785-2ab6-4377-b3a7-dc1f3e1fe57e"), new Guid("343d92d4-3a40-4ee4-a3e6-7fc04ec9877f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bb29a436-5e41-4799-849b-0aac4b43a5cb"), new Guid("4d542a3e-7311-471b-a4c5-52b89145376d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4c73c00e-d370-4110-b752-8cab173511d2"), new Guid("835ee2ee-a450-40cc-b1b6-20f8b0d1e0f8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2f0ccda2-1756-4f2e-aba5-5e698d757e89"), new Guid("b46610d4-9f49-4812-91c3-870bfe3a5c9b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0527c785-2ab6-4377-b3a7-dc1f3e1fe57e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0ccda2-1756-4f2e-aba5-5e698d757e89"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c73c00e-d370-4110-b752-8cab173511d2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb29a436-5e41-4799-849b-0aac4b43a5cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9ee0adb-cea5-46fd-b474-c39be3d8e13c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("246a92c7-5253-46e3-b1f5-e68bdb47f938"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("343d92d4-3a40-4ee4-a3e6-7fc04ec9877f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d542a3e-7311-471b-a4c5-52b89145376d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("835ee2ee-a450-40cc-b1b6-20f8b0d1e0f8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b46610d4-9f49-4812-91c3-870bfe3a5c9b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), "a1813bbb-4837-42b2-ab6c-6670819509fa", "Consultant", "CONSULTANT" },
                    { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), "e90c3be0-d9b6-4175-99ef-8b483aa11aef", "Admin", "ADMIN" },
                    { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), "d1e856b7-b513-4e11-838e-39323191d644", "Manager", "MANAGER" },
                    { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), "fa8cf61d-d2a3-4e28-988a-9de6ded3f956", "Collaborator", "COLLABORATOR" },
                    { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), "4a8226d9-0556-4623-9606-c4ceea0db4ee", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6"), 0, "b7511e86-df7f-453f-afff-6ea2ee7b1799", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3866), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Nw9DSOj7QT0yr7VigHBrU.Oa8PQULiPouHO9e6btccjvwIyJjF1Ve", "(99) 99999-9994", false, "eb669343-10ca-4ff9-9884-003b46878687", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3863), "bob" },
                    { new Guid("935db416-f736-47aa-a5c3-b96f98bcd195"), 0, "6669fdaa-e89f-45ea-afb3-51113bbacdbd", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3657), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$MDFHHwQuT8BbRSuOmqR9qOXeGlgcMmaSIenpF7M7wKSDTP/NRM7Lq", "(99) 99999-9991", false, "04d4cc10-817c-4560-932a-66844d2d5d5c", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(2228), "john" },
                    { new Guid("a6f57896-0ef3-4946-9036-9e70934b6005"), 0, "12bc27a6-be26-4948-a9a1-04dd80d30054", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3869), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$P5xunVtKaXq8pj7KuBKey.P0cxwev0L.EMm02vRoEYQ1QfUHUYU8W", "(99) 99999-9995", false, "477cfe70-03e1-4078-8b8a-7ff7a790cb29", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3867), "charlie" },
                    { new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9"), 0, "9a60cd09-ca58-47d3-8f8e-33ccc14535fe", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3853), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$34yzDMKz//uYvfpGRQUhx.NYprGRzfNlq357lAJQpuLMgpjKJV.VC", "(99) 99999-9992", false, "c8017f6a-88fd-48c9-98d1-7849a1405277", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3840), "jane" },
                    { new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9"), 0, "a8b25e01-5731-43ea-b817-424259fe1856", new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3862), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$71ngCni6yCWpOWOUKXl0/ehdZsAKZFK5KYoGemDI8bO509uFKm4Vq", "(99) 99999-9993", false, "2cc960ad-9506-4c71-8325-beeaec00ef7d", 0, false, new DateTime(2025, 8, 26, 15, 18, 9, 460, DateTimeKind.Local).AddTicks(3854), "alice" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 26, 15, 18, 10, 105, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("99537fb9-272a-4cff-87cb-a56136635590"), new Guid("6a96c1b9-0f59-4fe2-bc63-7824eee415c6") },
                    { new Guid("349cda3c-5f7c-43ea-bfec-422383d8a9cb"), new Guid("935db416-f736-47aa-a5c3-b96f98bcd195") },
                    { new Guid("dd8f11f2-0014-4b64-8da7-b3856ce364e9"), new Guid("a6f57896-0ef3-4946-9036-9e70934b6005") },
                    { new Guid("f72705ab-a7d3-4a45-ba9c-ce681b6311f2"), new Guid("b366e2e2-1ae0-4667-9089-8550b767e4f9") },
                    { new Guid("294b53fe-bdf2-4bfb-abab-6f84bceb0518"), new Guid("d7ead7b5-02fd-4156-bf0e-ba1d60e9aef9") }
                });
        }
    }
}
