using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntitiePlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("403c0452-d03c-4d80-8205-fc5cc1f66234"), new Guid("0a3534d2-cc5c-466e-9b03-7368c3cd0768") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b0e539ab-50f1-472a-8566-eaccf3112fdf"), new Guid("10b29e0f-54da-43f8-807c-432bb019e90f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab012664-5a33-4e84-b682-76bf508be02a"), new Guid("47ba658b-3d17-49e0-821b-559569c77950") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a30ba6d-93ca-46f1-9435-3aa4d53cb34b"), new Guid("66df6028-6bb1-4898-b7fb-5c2267cfa19d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("19df67a9-d2b2-4222-99ca-f187f9a7a817"), new Guid("add20174-b9bb-486b-9204-112c4cdb141c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a30ba6d-93ca-46f1-9435-3aa4d53cb34b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("19df67a9-d2b2-4222-99ca-f187f9a7a817"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("403c0452-d03c-4d80-8205-fc5cc1f66234"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab012664-5a33-4e84-b682-76bf508be02a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0e539ab-50f1-472a-8566-eaccf3112fdf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a3534d2-cc5c-466e-9b03-7368c3cd0768"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b29e0f-54da-43f8-807c-432bb019e90f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47ba658b-3d17-49e0-821b-559569c77950"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66df6028-6bb1-4898-b7fb-5c2267cfa19d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("add20174-b9bb-486b-9204-112c4cdb141c"));

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Plot");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Plot");

            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Plot",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Area",
                table: "Plot");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Plot",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Plot",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a30ba6d-93ca-46f1-9435-3aa4d53cb34b"), "5dfd494a-f5d0-4a9a-9980-a303ccb50e8a", "Owner", "OWNER" },
                    { new Guid("19df67a9-d2b2-4222-99ca-f187f9a7a817"), "528dd04d-f33d-46ae-b508-ad43f5903789", "Collaborator", "COLLABORATOR" },
                    { new Guid("403c0452-d03c-4d80-8205-fc5cc1f66234"), "06211799-b426-4d5b-95c6-8e0de5e057e7", "Admin", "ADMIN" },
                    { new Guid("ab012664-5a33-4e84-b682-76bf508be02a"), "22ffdce8-3ab0-4a19-8091-aef225df879d", "Consultant", "CONSULTANT" },
                    { new Guid("b0e539ab-50f1-472a-8566-eaccf3112fdf"), "d301920b-241c-44f1-99d1-131b0eefe15c", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a3534d2-cc5c-466e-9b03-7368c3cd0768"), 0, "22d57f76-6c8a-48c5-8f34-cd1b462198b0", new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4701), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$cp7Z45GbQ/WtfHml01oVa..nF7flMKBb.I2gKq2Xr7QoDjpWNY8XK", "(99) 99999-9991", false, "471bb3e0-d632-462d-876d-fb3da69aab7e", 0, false, new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(2850), "john" },
                    { new Guid("10b29e0f-54da-43f8-807c-432bb019e90f"), 0, "8817b0b5-3db1-42e6-9719-c8c46e022d5a", new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4982), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$SjOFrE8NvxhmgQsGnq36yuWuGDhH/dlO9rlSLeO.QrR8fbPXo2s0S", "(99) 99999-9994", false, "062ae0eb-19fd-4964-b01a-65dfa64c5b89", 0, false, new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4980), "bob" },
                    { new Guid("47ba658b-3d17-49e0-821b-559569c77950"), 0, "d98c4293-7348-406c-9bbf-e94350942b6b", new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4979), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$Qc8GwXSwmdm0b935k0DZi.O3YJ6QviM0.ernFdcGOZiPEQZyHGMEC", "(99) 99999-9993", false, "66ef8915-bf71-4edc-8c37-3a8eae4d21ef", 0, false, new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4976), "alice" },
                    { new Guid("66df6028-6bb1-4898-b7fb-5c2267cfa19d"), 0, "7e6e2bd3-5391-4efd-8f39-cb44a692f90f", new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4975), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$DupNETsvYzViXaV5kY.fd.W4NSmW6GcDGCJDR/kmb8N3nu.jrT3Ce", "(99) 99999-9992", false, "501975ef-94ae-4d81-9a08-d90ceca749ad", 0, false, new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4952), "jane" },
                    { new Guid("add20174-b9bb-486b-9204-112c4cdb141c"), 0, "03f1f9f1-5f06-4291-bbe9-7f1ebf637eab", new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4985), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$wi7X0F3Ygr4ADx2wJ3qHU.Z8GZ70Mb0gCQ78dNxWwJWcfxk1Sv3j2", "(99) 99999-9995", false, "16303b0c-dd2f-4c22-89b5-d8423f312b44", 0, false, new DateTime(2025, 7, 23, 21, 23, 55, 765, DateTimeKind.Local).AddTicks(4983), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("403c0452-d03c-4d80-8205-fc5cc1f66234"), new Guid("0a3534d2-cc5c-466e-9b03-7368c3cd0768") },
                    { new Guid("b0e539ab-50f1-472a-8566-eaccf3112fdf"), new Guid("10b29e0f-54da-43f8-807c-432bb019e90f") },
                    { new Guid("ab012664-5a33-4e84-b682-76bf508be02a"), new Guid("47ba658b-3d17-49e0-821b-559569c77950") },
                    { new Guid("0a30ba6d-93ca-46f1-9435-3aa4d53cb34b"), new Guid("66df6028-6bb1-4898-b7fb-5c2267cfa19d") },
                    { new Guid("19df67a9-d2b2-4222-99ca-f187f9a7a817"), new Guid("add20174-b9bb-486b-9204-112c4cdb141c") }
                });
        }
    }
}
