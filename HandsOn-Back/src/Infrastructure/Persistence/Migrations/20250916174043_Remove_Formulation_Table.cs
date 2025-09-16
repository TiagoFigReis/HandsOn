using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Formulation_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2c547307-3ff0-41a9-afb2-79fb41486676"), "8fdcceb6-260c-40c2-9e9d-3b0100d33862", "Consultant", "CONSULTANT" },
                    { new Guid("6480bf68-9446-479b-91e2-7c81fca7c717"), "232c8ed8-aa50-4de1-90c0-ad3476a3c198", "Owner", "OWNER" },
                    { new Guid("66aae01c-cf36-4826-9c55-1a29cfc14023"), "47cc96df-4a3c-437e-942e-4f65e6b46869", "Collaborator", "COLLABORATOR" },
                    { new Guid("cbe5ed86-88b3-466d-a1c3-bf88cbcdca64"), "f135f641-ce9d-4211-b431-219da96bf12c", "Manager", "MANAGER" },
                    { new Guid("dea767c8-d342-4ccf-b0cf-36e9fb7f9046"), "c559869d-2252-4c80-8507-7a5b1b848295", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("154bbe52-b7ea-4947-80f8-6ef4ed020ba6"), 0, "5bf6993d-c163-4dc6-938e-9996e1dc08e9", new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5211), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$y1YI1tCm3yAMnEUq2k1KgujtgYMtsVQz2Ejhsxo8hB52Brf8.fSk.", "(99) 99999-9993", false, "19c25854-f091-4d37-a79e-4b4bde42291a", 0, false, new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5207), "alice" },
                    { new Guid("16a10ead-a813-4e89-9d4e-d060ae56cff6"), 0, "649e87aa-4f44-4b13-8adf-e6f7e4e50e0b", new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(4997), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$VFfd6uelS9JJOzneFaO0cOSGJLIBBYNZCwfPlMQRzSGNJn0EWiFp.", "(99) 99999-9991", false, "b952288e-79f9-4273-b759-2d10efe65028", 0, false, new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(3520), "john" },
                    { new Guid("6c94fd03-9209-467c-bcea-054bd3d3dcb8"), 0, "13df6570-cf04-4f88-885c-b538b8eb4db8", new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5206), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$.NwaSndKVdkmBwACYZiLx.FNLoqIHHmmveqNlKR1Do3SEDuqOkLmu", "(99) 99999-9992", false, "bcc93397-3d3b-45f7-8fae-4d71ca9ac7e3", 0, false, new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5194), "jane" },
                    { new Guid("b5895243-d687-4e89-9cc2-4a3ffc72c532"), 0, "77bbcf8d-1459-4208-a979-493208a83bae", new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5218), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$BhlFjI91bkPFzNTNASCWVeTv7thgA5Mk1WCXJ5/OCOUTSP/7m4.le", "(99) 99999-9994", false, "9d24bbe1-fa4a-4252-9edc-5fa381c4cfe6", 0, false, new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5211), "bob" },
                    { new Guid("d3d86045-ddbb-4aad-8d51-c35461e86f08"), 0, "3f742b26-3e0e-4dab-9daa-3f08497b7a02", new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5233), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$sZRQJ3dk1lMBKgMxFuDSr.El5y.TewJ.rlPITAe/vfaRJek0F1FXG", "(99) 99999-9995", false, "48a082f9-ba06-454b-b415-867521ea959c", 0, false, new DateTime(2025, 9, 16, 14, 40, 42, 596, DateTimeKind.Local).AddTicks(5219), "charlie" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 9, 16, 14, 40, 43, 374, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c547307-3ff0-41a9-afb2-79fb41486676"), new Guid("154bbe52-b7ea-4947-80f8-6ef4ed020ba6") },
                    { new Guid("dea767c8-d342-4ccf-b0cf-36e9fb7f9046"), new Guid("16a10ead-a813-4e89-9d4e-d060ae56cff6") },
                    { new Guid("6480bf68-9446-479b-91e2-7c81fca7c717"), new Guid("6c94fd03-9209-467c-bcea-054bd3d3dcb8") },
                    { new Guid("cbe5ed86-88b3-466d-a1c3-bf88cbcdca64"), new Guid("b5895243-d687-4e89-9cc2-4a3ffc72c532") },
                    { new Guid("66aae01c-cf36-4826-9c55-1a29cfc14023"), new Guid("d3d86045-ddbb-4aad-8d51-c35461e86f08") }
                });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "SoilData", "Standard", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b28c4809-f53e-49af-a6c4-0657610b603b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "[{\"NutrientColumns\":[{\"Header\":0,\"Inverted\":false,\"Min\":28,\"Med1\":0,\"Med2\":0,\"Max\":31},{\"Header\":1,\"Inverted\":false,\"Min\":1.7,\"Med1\":0,\"Med2\":0,\"Max\":1.9},{\"Header\":2,\"Inverted\":false,\"Min\":22,\"Med1\":0,\"Med2\":0,\"Max\":25},{\"Header\":3,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":13},{\"Header\":4,\"Inverted\":false,\"Min\":2.7,\"Med1\":0,\"Med2\":0,\"Max\":3.5},{\"Header\":5,\"Inverted\":false,\"Min\":1.8,\"Med1\":0,\"Med2\":0,\"Max\":2.3},{\"Header\":6,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":20},{\"Header\":7,\"Inverted\":false,\"Min\":50,\"Med1\":0,\"Med2\":0,\"Max\":60},{\"Header\":8,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":15},{\"Header\":9,\"Inverted\":false,\"Min\":100,\"Med1\":0,\"Med2\":0,\"Max\":150},{\"Header\":10,\"Inverted\":false,\"Min\":120,\"Med1\":0,\"Med2\":0,\"Max\":200},{\"Header\":11,\"Inverted\":false,\"Min\":15,\"Med1\":0,\"Med2\":0,\"Max\":18},{\"Header\":12,\"Inverted\":false,\"Min\":1.1,\"Med1\":0,\"Med2\":0,\"Max\":1.4},{\"Header\":13,\"Inverted\":false,\"Min\":12,\"Med1\":0,\"Med2\":0,\"Max\":17},{\"Header\":14,\"Inverted\":false,\"Min\":467,\"Med1\":0,\"Med2\":0,\"Max\":620},{\"Header\":15,\"Inverted\":false,\"Min\":1867,\"Med1\":0,\"Med2\":0,\"Max\":3100},{\"Header\":16,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":0.7},{\"Header\":17,\"Inverted\":false,\"Min\":85,\"Med1\":0,\"Med2\":0,\"Max\":190},{\"Header\":18,\"Inverted\":false,\"Min\":1.7,\"Med1\":0,\"Med2\":0,\"Max\":2.5},{\"Header\":19,\"Inverted\":false,\"Min\":6,\"Med1\":0,\"Med2\":0,\"Max\":9},{\"Header\":20,\"Inverted\":false,\"Min\":146,\"Med1\":0,\"Med2\":0,\"Max\":250},{\"Header\":21,\"Inverted\":false,\"Min\":2.8,\"Med1\":0,\"Med2\":0,\"Max\":4.8},{\"Header\":22,\"Inverted\":false,\"Min\":67,\"Med1\":0,\"Med2\":0,\"Max\":130},{\"Header\":23,\"Inverted\":false,\"Min\":0.8,\"Med1\":0,\"Med2\":0,\"Max\":2}]}]", "{\"NutrientColumns\":[{\"Header\":1,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":30},{\"Header\":2,\"Inverted\":false,\"Min\":0.15,\"Med1\":0,\"Med2\":0,\"Max\":0.3},{\"Header\":3,\"Inverted\":false,\"Min\":2,\"Med1\":0,\"Med2\":0,\"Max\":5},{\"Header\":4,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":1.5},{\"Header\":5,\"Inverted\":false,\"Min\":5,\"Med1\":0,\"Med2\":0,\"Max\":20},{\"Header\":6,\"Inverted\":false,\"Min\":2,\"Med1\":0,\"Med2\":0,\"Max\":6},{\"Header\":7,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":2},{\"Header\":8,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":10},{\"Header\":9,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":100},{\"Header\":10,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":40},{\"Header\":24,\"Inverted\":false,\"Min\":5,\"Med1\":0,\"Med2\":0,\"Max\":6.5},{\"Header\":25,\"Inverted\":true,\"Min\":0.2,\"Med1\":0.5,\"Med2\":1,\"Max\":2},{\"Header\":26,\"Inverted\":true,\"Min\":1,\"Med1\":2.5,\"Med2\":5,\"Max\":9},{\"Header\":27,\"Inverted\":false,\"Min\":0.7,\"Med1\":2,\"Med2\":4,\"Max\":7},{\"Header\":28,\"Inverted\":false,\"Min\":0.6,\"Med1\":1.8,\"Med2\":3.6,\"Max\":6},{\"Header\":29,\"Inverted\":false,\"Min\":1.6,\"Med1\":4.3,\"Med2\":8.6,\"Max\":15},{\"Header\":30,\"Inverted\":false,\"Min\":20,\"Med1\":40,\"Med2\":60,\"Max\":80}]}", true, new DateTime(2025, 9, 16, 14, 40, 43, 400, DateTimeKind.Local).AddTicks(121), new Guid("16a10ead-a813-4e89-9d4e-d060ae56cff6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c547307-3ff0-41a9-afb2-79fb41486676"), new Guid("154bbe52-b7ea-4947-80f8-6ef4ed020ba6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dea767c8-d342-4ccf-b0cf-36e9fb7f9046"), new Guid("16a10ead-a813-4e89-9d4e-d060ae56cff6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6480bf68-9446-479b-91e2-7c81fca7c717"), new Guid("6c94fd03-9209-467c-bcea-054bd3d3dcb8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cbe5ed86-88b3-466d-a1c3-bf88cbcdca64"), new Guid("b5895243-d687-4e89-9cc2-4a3ffc72c532") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66aae01c-cf36-4826-9c55-1a29cfc14023"), new Guid("d3d86045-ddbb-4aad-8d51-c35461e86f08") });

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("b28c4809-f53e-49af-a6c4-0657610b603b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c547307-3ff0-41a9-afb2-79fb41486676"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6480bf68-9446-479b-91e2-7c81fca7c717"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66aae01c-cf36-4826-9c55-1a29cfc14023"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbe5ed86-88b3-466d-a1c3-bf88cbcdca64"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dea767c8-d342-4ccf-b0cf-36e9fb7f9046"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("154bbe52-b7ea-4947-80f8-6ef4ed020ba6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16a10ead-a813-4e89-9d4e-d060ae56cff6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c94fd03-9209-467c-bcea-054bd3d3dcb8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b5895243-d687-4e89-9cc2-4a3ffc72c532"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3d86045-ddbb-4aad-8d51-c35461e86f08"));

            migrationBuilder.CreateTable(
                name: "FormulationTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CultureId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BasicFormulationRows = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompoundFormulationRows = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Standard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
    }
}
