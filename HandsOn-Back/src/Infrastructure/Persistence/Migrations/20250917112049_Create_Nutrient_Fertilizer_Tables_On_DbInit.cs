using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_Nutrient_Fertilizer_Tables_On_DbInit : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("163c418f-6f3a-4269-9f14-bb29a929e5cb"), "14aeade6-b8c9-47b3-91ad-72073462d128", "Manager", "MANAGER" },
                    { new Guid("4f38c233-3155-43d4-afd0-1bee7c30f199"), "29e6004e-33e9-4a48-b680-6542c38bfcb3", "Collaborator", "COLLABORATOR" },
                    { new Guid("911f5414-6bce-4ac3-9460-bbb4242f0d52"), "3778cea8-0628-4f93-a8ea-0687d25b4aec", "Consultant", "CONSULTANT" },
                    { new Guid("e2231ea4-61e8-42cc-b345-dff04884b84b"), "09c6437f-a9e7-4c98-a8da-88a31f6bba7f", "Owner", "OWNER" },
                    { new Guid("e5d56861-e071-4f7a-be34-2a6d416aa2d6"), "553b0f14-1920-4125-88bd-a1c8705e21e5", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("27a5fc22-4cb4-4af7-b949-e7296472fd72"), 0, "2982c3c9-07cf-4efe-84fb-a198f1764f4a", new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(963), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$K.GX3QS6e.Fn/vRPEaJEyuTqtdh6GGInWB1bxfqpPWSvAqRtweNZS", "(99) 99999-9995", false, "efc46f81-c7f5-428b-9c86-1a52d3e0be7d", 0, false, new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(960), "charlie" },
                    { new Guid("7b9dc903-4eba-41c7-89d6-b120b57124bf"), 0, "d1086ac3-971e-40a6-8093-e57ebd5e6692", new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(959), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$shCkks.VNeM1W5mgu60x8OfydrOzD6/lKnjG.XaxsXlaagJysRN8S", "(99) 99999-9994", false, "ae8c77eb-029c-4e71-9f73-3502e2612e81", 0, false, new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(952), "bob" },
                    { new Guid("7e16a336-80ce-4da5-8123-d97ec7992be1"), 0, "4bb02210-ea71-4a6a-8919-5964c19fec85", new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(939), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$rzQt2H4GBJ7XgBLdHKp53eNCOlRXJd4JI0YaTOd/F6U6AyZKtmwtG", "(99) 99999-9993", false, "09218002-ae71-4f9e-ad44-457bad89949c", 0, false, new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(930), "alice" },
                    { new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc"), 0, "41615b30-d7fd-4288-8648-5e676d3843c2", new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(722), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$UOOuNoCypwkOXJ/g4/V2fuoKOlTjal5Sa4rKF3weTyRDLtW0eEGH.", "(99) 99999-9991", false, "9eeb6f42-f372-41b1-b189-a2f62863ccb7", 0, false, new DateTime(2025, 9, 17, 8, 20, 48, 390, DateTimeKind.Local).AddTicks(9172), "john" },
                    { new Guid("e58aa8e9-4f03-4957-843b-a51c78cf70b5"), 0, "a11227b6-4555-4976-adcc-41c7b0d5389d", new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(929), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$5YDyXd5PWwEFXb3I/QO26.W5dNrlwnc2hqzdT153vURDMi90Cmcaa", "(99) 99999-9992", false, "3159e17a-d5cd-418e-af98-b9b38ae9ca5d", 0, false, new DateTime(2025, 9, 17, 8, 20, 48, 391, DateTimeKind.Local).AddTicks(911), "jane" }
                });

            migrationBuilder.UpdateData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"),
                column: "UpdatedAt",
                value: new DateTime(2025, 9, 17, 8, 20, 49, 147, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f38c233-3155-43d4-afd0-1bee7c30f199"), new Guid("27a5fc22-4cb4-4af7-b949-e7296472fd72") },
                    { new Guid("163c418f-6f3a-4269-9f14-bb29a929e5cb"), new Guid("7b9dc903-4eba-41c7-89d6-b120b57124bf") },
                    { new Guid("911f5414-6bce-4ac3-9460-bbb4242f0d52"), new Guid("7e16a336-80ce-4da5-8123-d97ec7992be1") },
                    { new Guid("e5d56861-e071-4f7a-be34-2a6d416aa2d6"), new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc") },
                    { new Guid("e2231ea4-61e8-42cc-b345-dff04884b84b"), new Guid("e58aa8e9-4f03-4957-843b-a51c78cf70b5") }
                });

            migrationBuilder.InsertData(
                table: "FertilizerTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "ExpectedBasesSaturation", "LeafParameters", "SoilParameters", "Standard", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b28c4810-f53e-49af-a6c4-0657610b603b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 70f, "{\"LeafFertilizerColumns\":[{\"Header\":0,\"Products\":[]},{\"Header\":1,\"Products\":[]},{\"Header\":2,\"Products\":[]},{\"Header\":3,\"Products\":[]},{\"Header\":4,\"Products\":[]},{\"Header\":5,\"Products\":[{\"Name\":\"enxofre l\\u00EDquido\",\"Solid\":false,\"MinConcentration\":0.5,\"MaxConcentration\":1}]},{\"Header\":6,\"Products\":[{\"Name\":\"sulfato de zinco\",\"Solid\":true,\"MinConcentration\":1,\"MaxConcentration\":2},{\"Name\":\"zinco l\\u00EDquido\",\"Solid\":false,\"MinConcentration\":0.5,\"MaxConcentration\":1}]},{\"Header\":7,\"Products\":[{\"Name\":\"\\u00E1cido b\\u00F3rico\",\"Solid\":true,\"MinConcentration\":1,\"MaxConcentration\":2},{\"Name\":\"boro l\\u00EDquido\",\"Solid\":false,\"MinConcentration\":0.5,\"MaxConcentration\":1}]},{\"Header\":8,\"Products\":[{\"Name\":\"fungicida c\\u00FAprico\",\"Solid\":false,\"MinConcentration\":1,\"MaxConcentration\":2}]},{\"Header\":9,\"Products\":[{\"Name\":\"sulfato de mangan\\u00EAs\",\"Solid\":true,\"MinConcentration\":1,\"MaxConcentration\":2}]},{\"Header\":10,\"Products\":[{\"Name\":\"ferro quelatizado\",\"Solid\":false,\"MinConcentration\":1,\"MaxConcentration\":2}]},{\"Header\":11,\"Products\":[]}]}", "[{\"ExpectedProductivity\":2,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":56,\"Value2\":45,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":10,\"Value2\":6,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":46,\"Value2\":37,\"Value3\":27,\"Value4\":0},{\"Header\":7,\"NumberOfValues\":4,\"Value1\":6,\"Value2\":4,\"Value3\":0,\"Value4\":0}]},{\"ExpectedProductivity\":4,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":72,\"Value2\":58,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":13,\"Value2\":9,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":65,\"Value2\":51,\"Value3\":38,\"Value4\":0}]},{\"ExpectedProductivity\":6,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":88,\"Value2\":70,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":16,\"Value2\":11,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":83,\"Value2\":66,\"Value3\":50,\"Value4\":0}]},{\"ExpectedProductivity\":8,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":104,\"Value2\":83,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":19,\"Value2\":13,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":102,\"Value2\":81,\"Value3\":61,\"Value4\":0}]},{\"ExpectedProductivity\":10,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":120,\"Value2\":96,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":22,\"Value2\":15,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":119,\"Value2\":96,\"Value3\":72,\"Value4\":0}]},{\"ExpectedProductivity\":12,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":136,\"Value2\":109,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":26,\"Value2\":18,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":138,\"Value2\":110,\"Value3\":82,\"Value4\":0}]},{\"ExpectedProductivity\":14,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":152,\"Value2\":122,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":29,\"Value2\":20,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":156,\"Value2\":125,\"Value3\":94,\"Value4\":0}]},{\"ExpectedProductivity\":16,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":168,\"Value2\":134,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":32,\"Value2\":22,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":174,\"Value2\":140,\"Value3\":105,\"Value4\":0}]},{\"ExpectedProductivity\":18,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":184,\"Value2\":147,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":35,\"Value2\":24,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":193,\"Value2\":154,\"Value3\":116,\"Value4\":0}]},{\"ExpectedProductivity\":20,\"SoilFertilizerColumns\":[{\"Header\":0,\"NumberOfValues\":2,\"Value1\":200,\"Value2\":160,\"Value3\":0,\"Value4\":0},{\"Header\":1,\"NumberOfValues\":3,\"Value1\":38,\"Value2\":26,\"Value3\":0,\"Value4\":0},{\"Header\":2,\"NumberOfValues\":4,\"Value1\":211,\"Value2\":170,\"Value3\":127,\"Value4\":0}]}]", true, new DateTime(2025, 9, 17, 8, 20, 49, 178, DateTimeKind.Local).AddTicks(33), new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc") });

            migrationBuilder.InsertData(
                table: "NutrientTables",
                columns: new[] { "Id", "CreatedAt", "CultureId", "Division", "LeafData", "SoilData", "Standard", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b28c4809-f53e-49af-a6c4-0657610b603b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a3a7b72-2b6a-4b7e-b8d2-3b8d6f6e8a3a"), 0, "[{\"NutrientColumns\":[{\"Header\":0,\"Inverted\":false,\"Min\":28,\"Med1\":0,\"Med2\":0,\"Max\":31},{\"Header\":1,\"Inverted\":false,\"Min\":1.7,\"Med1\":0,\"Med2\":0,\"Max\":1.9},{\"Header\":2,\"Inverted\":false,\"Min\":22,\"Med1\":0,\"Med2\":0,\"Max\":25},{\"Header\":3,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":13},{\"Header\":4,\"Inverted\":false,\"Min\":2.7,\"Med1\":0,\"Med2\":0,\"Max\":3.5},{\"Header\":5,\"Inverted\":false,\"Min\":1.8,\"Med1\":0,\"Med2\":0,\"Max\":2.3},{\"Header\":6,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":20},{\"Header\":7,\"Inverted\":false,\"Min\":50,\"Med1\":0,\"Med2\":0,\"Max\":60},{\"Header\":8,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":15},{\"Header\":9,\"Inverted\":false,\"Min\":100,\"Med1\":0,\"Med2\":0,\"Max\":150},{\"Header\":10,\"Inverted\":false,\"Min\":120,\"Med1\":0,\"Med2\":0,\"Max\":200},{\"Header\":11,\"Inverted\":false,\"Min\":15,\"Med1\":0,\"Med2\":0,\"Max\":18},{\"Header\":12,\"Inverted\":false,\"Min\":1.1,\"Med1\":0,\"Med2\":0,\"Max\":1.4},{\"Header\":13,\"Inverted\":false,\"Min\":12,\"Med1\":0,\"Med2\":0,\"Max\":17},{\"Header\":14,\"Inverted\":false,\"Min\":467,\"Med1\":0,\"Med2\":0,\"Max\":620},{\"Header\":15,\"Inverted\":false,\"Min\":1867,\"Med1\":0,\"Med2\":0,\"Max\":3100},{\"Header\":16,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":0.7},{\"Header\":17,\"Inverted\":false,\"Min\":85,\"Med1\":0,\"Med2\":0,\"Max\":190},{\"Header\":18,\"Inverted\":false,\"Min\":1.7,\"Med1\":0,\"Med2\":0,\"Max\":2.5},{\"Header\":19,\"Inverted\":false,\"Min\":6,\"Med1\":0,\"Med2\":0,\"Max\":9},{\"Header\":20,\"Inverted\":false,\"Min\":146,\"Med1\":0,\"Med2\":0,\"Max\":250},{\"Header\":21,\"Inverted\":false,\"Min\":2.8,\"Med1\":0,\"Med2\":0,\"Max\":4.8},{\"Header\":22,\"Inverted\":false,\"Min\":67,\"Med1\":0,\"Med2\":0,\"Max\":130},{\"Header\":23,\"Inverted\":false,\"Min\":0.8,\"Med1\":0,\"Med2\":0,\"Max\":2}]}]", "{\"NutrientColumns\":[{\"Header\":1,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":30},{\"Header\":2,\"Inverted\":false,\"Min\":0.15,\"Med1\":0,\"Med2\":0,\"Max\":0.3},{\"Header\":3,\"Inverted\":false,\"Min\":2,\"Med1\":0,\"Med2\":0,\"Max\":5},{\"Header\":4,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":1.5},{\"Header\":5,\"Inverted\":false,\"Min\":5,\"Med1\":0,\"Med2\":0,\"Max\":20},{\"Header\":6,\"Inverted\":false,\"Min\":2,\"Med1\":0,\"Med2\":0,\"Max\":6},{\"Header\":7,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":2},{\"Header\":8,\"Inverted\":false,\"Min\":0.5,\"Med1\":0,\"Med2\":0,\"Max\":10},{\"Header\":9,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":100},{\"Header\":10,\"Inverted\":false,\"Min\":10,\"Med1\":0,\"Med2\":0,\"Max\":40},{\"Header\":24,\"Inverted\":false,\"Min\":5,\"Med1\":0,\"Med2\":0,\"Max\":6.5},{\"Header\":25,\"Inverted\":true,\"Min\":0.2,\"Med1\":0.5,\"Med2\":1,\"Max\":2},{\"Header\":26,\"Inverted\":true,\"Min\":1,\"Med1\":2.5,\"Med2\":5,\"Max\":9},{\"Header\":27,\"Inverted\":false,\"Min\":0.7,\"Med1\":2,\"Med2\":4,\"Max\":7},{\"Header\":28,\"Inverted\":false,\"Min\":0.6,\"Med1\":1.8,\"Med2\":3.6,\"Max\":6},{\"Header\":29,\"Inverted\":false,\"Min\":1.6,\"Med1\":4.3,\"Med2\":8.6,\"Max\":15},{\"Header\":30,\"Inverted\":false,\"Min\":20,\"Med1\":40,\"Med2\":60,\"Max\":80}]}", true, new DateTime(2025, 9, 17, 8, 20, 49, 173, DateTimeKind.Local).AddTicks(838), new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f38c233-3155-43d4-afd0-1bee7c30f199"), new Guid("27a5fc22-4cb4-4af7-b949-e7296472fd72") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("163c418f-6f3a-4269-9f14-bb29a929e5cb"), new Guid("7b9dc903-4eba-41c7-89d6-b120b57124bf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("911f5414-6bce-4ac3-9460-bbb4242f0d52"), new Guid("7e16a336-80ce-4da5-8123-d97ec7992be1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e5d56861-e071-4f7a-be34-2a6d416aa2d6"), new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e2231ea4-61e8-42cc-b345-dff04884b84b"), new Guid("e58aa8e9-4f03-4957-843b-a51c78cf70b5") });

            migrationBuilder.DeleteData(
                table: "FertilizerTables",
                keyColumn: "Id",
                keyValue: new Guid("b28c4810-f53e-49af-a6c4-0657610b603b"));

            migrationBuilder.DeleteData(
                table: "NutrientTables",
                keyColumn: "Id",
                keyValue: new Guid("b28c4809-f53e-49af-a6c4-0657610b603b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("163c418f-6f3a-4269-9f14-bb29a929e5cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f38c233-3155-43d4-afd0-1bee7c30f199"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("911f5414-6bce-4ac3-9460-bbb4242f0d52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2231ea4-61e8-42cc-b345-dff04884b84b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5d56861-e071-4f7a-be34-2a6d416aa2d6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("27a5fc22-4cb4-4af7-b949-e7296472fd72"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b9dc903-4eba-41c7-89d6-b120b57124bf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7e16a336-80ce-4da5-8123-d97ec7992be1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc2e8a59-709d-4e59-8b51-4ee3023c9dfc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58aa8e9-4f03-4957-843b-a51c78cf70b5"));

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
