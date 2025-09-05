using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedPlotAndHarvestsEnities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5bfa68e4-8c79-4e48-ba84-02385174e16c"), new Guid("296aad3f-823c-4206-a5e1-402769cd7d0a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3e3ecb1-a9f7-4994-9223-21ff31f9ebcc"), new Guid("504b2875-e164-4b54-b8bb-07296a958a37") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4a43898f-99e3-4d56-9529-c7492f30fd2e"), new Guid("653f15ae-214d-4e6f-b376-682411b6451d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c6a0c83e-7c25-4c92-bb4d-d1d13ed81bf7"), new Guid("80f76848-f5c0-4a50-8529-10a9400cc276") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2aeefda9-ebbe-4bf8-93da-09fde11e43eb"), new Guid("f449f94a-34fd-45f0-9f45-ebd47d32402a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2aeefda9-ebbe-4bf8-93da-09fde11e43eb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a43898f-99e3-4d56-9529-c7492f30fd2e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5bfa68e4-8c79-4e48-ba84-02385174e16c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3e3ecb1-a9f7-4994-9223-21ff31f9ebcc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6a0c83e-7c25-4c92-bb4d-d1d13ed81bf7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("296aad3f-823c-4206-a5e1-402769cd7d0a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("504b2875-e164-4b54-b8bb-07296a958a37"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("653f15ae-214d-4e6f-b376-682411b6451d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80f76848-f5c0-4a50-8529-10a9400cc276"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f449f94a-34fd-45f0-9f45-ebd47d32402a"));

            migrationBuilder.DropColumn(
                name: "Cultivar",
                table: "Plot");

            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Plot");

            migrationBuilder.DropColumn(
                name: "DataPlantio",
                table: "Plot");

            migrationBuilder.DropColumn(
                name: "Fim",
                table: "Harvest");

            migrationBuilder.RenameColumn(
                name: "Inicio",
                table: "Harvest",
                newName: "DataPlantio");

            migrationBuilder.AddColumn<string>(
                name: "Coordenadas",
                table: "Plot",
                type: "LONGTEXT",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AnoAgricola",
                table: "Harvest",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cultivar",
                table: "Harvest",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cultura",
                table: "Harvest",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), "6f9ce3de-36cb-4da2-96c2-12891e07d5f6", "Admin", "ADMIN" },
                    { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), "020f22ee-eb5a-4156-93ec-da5c797573ed", "Manager", "MANAGER" },
                    { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), "083ef659-fd9e-4cee-9b6a-90f407b4ae93", "Consultant", "CONSULTANT" },
                    { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), "31583cc4-c4f4-473d-ba4c-aa5eebd75b67", "Owner", "OWNER" },
                    { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), "a2f77774-f310-4385-abe1-f92dff27b3ff", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf"), 0, "a03c4728-cb33-41b8-88fc-3b3def255a66", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4627), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$dk4B1kUz2HjojlPltefFS.aJKgWPtrs71uegEsNScmLqIfL9tgj82", "(99) 99999-9994", false, "de7d515a-f5ec-4aad-ab53-28bf961437bd", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4620), "bob" },
                    { new Guid("96a73925-019d-42c8-8e88-28c42e730ade"), 0, "30d59c7b-ac35-4efc-a0e7-73329c16e0cb", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4615), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$lxOspefcfMXwHRvkR40hB.Q81i5rRA.E6.AlYLpqHNdCj9UTWKfTy", "(99) 99999-9992", false, "c7c94a71-386e-41b6-84c0-34f3d0289db9", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4599), "jane" },
                    { new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f"), 0, "81227539-2505-4952-8f6e-088aae0cff14", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4631), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$1ljlE6O//xT4tD.MvI57KeXHXOQn.nkZ52/tiegiXsAbR3357fiJi", "(99) 99999-9995", false, "bd2055b5-29a0-444f-83c7-9b1faf2e2705", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4628), "charlie" },
                    { new Guid("f291fb87-5f54-402d-9942-0516538d3fbf"), 0, "4bf2b5b1-898b-4a23-8546-96acd8c008a3", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4358), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$CNNSKsNCqnVBGsaJ56blReS14G9qtrc8zDZB1kmyVeOHR27zeKmO2", "(99) 99999-9991", false, "e3562644-b938-476c-86d6-13b8bd374281", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(2581), "john" },
                    { new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9"), 0, "7d298ae9-c51a-440a-94c9-a386dabe835f", new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4620), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$KXVO7Qv0bdS6n.LAcx27Xeqkxn7S3JTLpDSyStosIl6mUUa/qIcJS", "(99) 99999-9993", false, "c9617269-1b36-4c12-8da4-c7cb9be23666", 0, false, new DateTime(2025, 7, 26, 9, 58, 26, 445, DateTimeKind.Local).AddTicks(4616), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf") },
                    { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), new Guid("96a73925-019d-42c8-8e88-28c42e730ade") },
                    { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f") },
                    { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), new Guid("f291fb87-5f54-402d-9942-0516538d3fbf") },
                    { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"), new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"), new Guid("96a73925-019d-42c8-8e88-28c42e730ade") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"), new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"), new Guid("f291fb87-5f54-402d-9942-0516538d3fbf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"), new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18b73cb1-0f14-4137-af3d-14251ba5a510"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("73ae84e3-14ef-4a16-ac51-e5cc67f83c37"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d69bf81-7adc-43f3-9d16-1dd8aab87ed2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8de30e32-2dd0-48f6-b4ea-09562739e61d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be4baa36-c088-4d38-882c-ecd0a2ad5e4e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c6bb12b-dce4-4b7a-9e50-906347180faf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96a73925-019d-42c8-8e88-28c42e730ade"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e99a353e-f792-481e-9eb1-b29e3d416f0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f291fb87-5f54-402d-9942-0516538d3fbf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb369dec-f7fc-4ccc-b9b3-e4349aa904a9"));

            migrationBuilder.DropColumn(
                name: "Coordenadas",
                table: "Plot");

            migrationBuilder.DropColumn(
                name: "AnoAgricola",
                table: "Harvest");

            migrationBuilder.DropColumn(
                name: "Cultivar",
                table: "Harvest");

            migrationBuilder.DropColumn(
                name: "Cultura",
                table: "Harvest");

            migrationBuilder.RenameColumn(
                name: "DataPlantio",
                table: "Harvest",
                newName: "Inicio");

            migrationBuilder.AddColumn<string>(
                name: "Cultivar",
                table: "Plot",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cultura",
                table: "Plot",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataPlantio",
                table: "Plot",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fim",
                table: "Harvest",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2aeefda9-ebbe-4bf8-93da-09fde11e43eb"), "b0dec473-74e9-4ba0-a5dd-1f8403ffc662", "Consultant", "CONSULTANT" },
                    { new Guid("4a43898f-99e3-4d56-9529-c7492f30fd2e"), "fdb8ccec-8cb8-47b3-915c-3fff7e445f82", "Owner", "OWNER" },
                    { new Guid("5bfa68e4-8c79-4e48-ba84-02385174e16c"), "36ae1152-99f2-4c19-9018-52a3b9210444", "Admin", "ADMIN" },
                    { new Guid("c3e3ecb1-a9f7-4994-9223-21ff31f9ebcc"), "b7b43e66-046f-46e6-9c12-89f1c5810668", "Manager", "MANAGER" },
                    { new Guid("c6a0c83e-7c25-4c92-bb4d-d1d13ed81bf7"), "9ab13e67-cdc5-46ad-9d6c-83c18dddce77", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("296aad3f-823c-4206-a5e1-402769cd7d0a"), 0, "a7ea33a6-b6c8-4dfa-920c-0adf6ac987dc", new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(3765), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$n7L4sHJJASU0tA1jZZe8iOYvQdDCFE0m4cHJUh76/cjx3nG8Vd3su", "(99) 99999-9991", false, "96fda5fa-87f6-493f-8d85-c18bd7b5722a", 0, false, new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(1801), "john" },
                    { new Guid("504b2875-e164-4b54-b8bb-07296a958a37"), 0, "ff944ce4-e3b1-4ba5-b4c7-95ebaebc4e74", new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4050), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$Rv50z3vc4TFUtYD4FBeHZOjkAM2fWR9glqF7f9TfrGP0p73fz6TzK", "(99) 99999-9994", false, "90ad53c8-5c78-4e30-9aef-76e1cb2229a7", 0, false, new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4047), "bob" },
                    { new Guid("653f15ae-214d-4e6f-b376-682411b6451d"), 0, "031f326a-76f4-449c-9265-9b6da85d0ba9", new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4038), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$MEzJgPbbC19kRV/SKMI3Ku63kN9AYy.9dMTCU/HOM/OSZGV5QDl4q", "(99) 99999-9992", false, "9eba1e30-914d-403c-b316-33f94447ede9", 0, false, new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4017), "jane" },
                    { new Guid("80f76848-f5c0-4a50-8529-10a9400cc276"), 0, "7edae8d0-e06e-4b72-983d-eca0554c4319", new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4053), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$Ylj/PQpKURUMcy0DuNOLGem6943SkwnHSkmfRod2I6jR4j9Ki.hTi", "(99) 99999-9995", false, "ef6ff875-1acc-424b-9d73-54f3c5f67a93", 0, false, new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4051), "charlie" },
                    { new Guid("f449f94a-34fd-45f0-9f45-ebd47d32402a"), 0, "0c9d7971-7b24-494b-b93c-b7cc12a05337", new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4047), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$15KwTMPORNAfjQN1lSr7guxb1nqodL9M6Wyu0JZD5AZtDhHhAj4E.", "(99) 99999-9993", false, "378814be-fd9b-4bec-b388-85abd28240d9", 0, false, new DateTime(2025, 7, 25, 11, 19, 29, 921, DateTimeKind.Local).AddTicks(4039), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5bfa68e4-8c79-4e48-ba84-02385174e16c"), new Guid("296aad3f-823c-4206-a5e1-402769cd7d0a") },
                    { new Guid("c3e3ecb1-a9f7-4994-9223-21ff31f9ebcc"), new Guid("504b2875-e164-4b54-b8bb-07296a958a37") },
                    { new Guid("4a43898f-99e3-4d56-9529-c7492f30fd2e"), new Guid("653f15ae-214d-4e6f-b376-682411b6451d") },
                    { new Guid("c6a0c83e-7c25-4c92-bb4d-d1d13ed81bf7"), new Guid("80f76848-f5c0-4a50-8529-10a9400cc276") },
                    { new Guid("2aeefda9-ebbe-4bf8-93da-09fde11e43eb"), new Guid("f449f94a-34fd-45f0-9f45-ebd47d32402a") }
                });
        }
    }
}
