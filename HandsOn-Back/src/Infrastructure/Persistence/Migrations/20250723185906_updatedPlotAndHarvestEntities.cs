using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedPlotAndHarvestEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataPlantio",
                table: "Plot",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Inicio",
                table: "Harvest",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fim",
                table: "Harvest",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5515df77-a887-422f-8efc-0348b84d98e4"), "8bc86300-82a8-43ff-81a9-327665bbd687", "Consultant", "CONSULTANT" },
                    { new Guid("6089b70e-35ea-4d44-8274-7dce6657fc08"), "b9a0c857-9054-4ccb-a82a-05ba3c346d5d", "Manager", "MANAGER" },
                    { new Guid("8b616c35-0310-4a4f-ad78-ca9602f18465"), "69aeb885-f266-4bef-af46-6ed8f14d4c1d", "Admin", "ADMIN" },
                    { new Guid("c63f2595-6b79-4a27-8793-ba190c5f7beb"), "f0592f82-7f9d-4b96-8126-9ae085f11809", "Owner", "OWNER" },
                    { new Guid("cf739b7c-7552-4bda-abd3-f9e6d45aa3e2"), "7123b14a-312d-4fce-bc1d-224a10001dfc", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("27b4df07-080f-4062-9cfe-f95a4fa491dc"), 0, "cdfcde4e-0820-4473-a1eb-e5cf2af5dd46", new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3937), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$XqCho2ptjHzVU7i7pMLB9.xId1sHE8AWaef1FusdYgrWHBFkbjrgC", "(99) 99999-9992", false, "5276bcb5-12a6-4c86-92b2-d299336fa805", 0, false, new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3919), "jane" },
                    { new Guid("3ea27cfe-3287-4f53-9fb1-d7c12111d977"), 0, "a5d7846f-6489-4d66-9d1a-65677f1ee606", new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3946), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$5N.oxVpPEPW2zW.Qq93EReYVQea3ISrBin1UDFvJr7Avj0/7IUGPu", "(99) 99999-9993", false, "7f991ace-2576-4370-91a1-08954cec57d1", 0, false, new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3938), "alice" },
                    { new Guid("6e854c46-5e44-411f-bd35-f216a286a2bf"), 0, "b5c936db-f07a-4474-970d-42a6c7ffbfbf", new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3953), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$hlY4SLoRUejDPLKUEyrt3OaMhjSNNL0wE4TDeSQSox4fjB49nU/va", "(99) 99999-9995", false, "52f6f2d1-0ece-4f9e-91b8-46804474d0da", 0, false, new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3950), "charlie" },
                    { new Guid("a2b3a104-d124-4bfd-80fe-95d8d2b983b8"), 0, "a593a491-8fb9-4d52-8eb6-cb3d7f5cd838", new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3661), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$gS6a08F13C78.jAUqCMEDOENxS.sdhiZbBk95o9duza.6ea3xVraC", "(99) 99999-9991", false, "a698e8aa-90ba-4a01-a2ba-0465639443df", 0, false, new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(1791), "john" },
                    { new Guid("bca11161-98f3-461f-ba2e-e961680a6ba6"), 0, "f86857fd-e030-4725-99c8-d98ad4195e68", new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3949), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$0EDK2Dz61uH6v8w5/3NvGOhsCBzK.3Zz155brhG8ss5UUM.ocvZLC", "(99) 99999-9994", false, "286f1c1e-52f6-42b4-9764-e73f7d90d740", 0, false, new DateTime(2025, 7, 23, 15, 59, 5, 272, DateTimeKind.Local).AddTicks(3947), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c63f2595-6b79-4a27-8793-ba190c5f7beb"), new Guid("27b4df07-080f-4062-9cfe-f95a4fa491dc") },
                    { new Guid("5515df77-a887-422f-8efc-0348b84d98e4"), new Guid("3ea27cfe-3287-4f53-9fb1-d7c12111d977") },
                    { new Guid("cf739b7c-7552-4bda-abd3-f9e6d45aa3e2"), new Guid("6e854c46-5e44-411f-bd35-f216a286a2bf") },
                    { new Guid("8b616c35-0310-4a4f-ad78-ca9602f18465"), new Guid("a2b3a104-d124-4bfd-80fe-95d8d2b983b8") },
                    { new Guid("6089b70e-35ea-4d44-8274-7dce6657fc08"), new Guid("bca11161-98f3-461f-ba2e-e961680a6ba6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c63f2595-6b79-4a27-8793-ba190c5f7beb"), new Guid("27b4df07-080f-4062-9cfe-f95a4fa491dc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5515df77-a887-422f-8efc-0348b84d98e4"), new Guid("3ea27cfe-3287-4f53-9fb1-d7c12111d977") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cf739b7c-7552-4bda-abd3-f9e6d45aa3e2"), new Guid("6e854c46-5e44-411f-bd35-f216a286a2bf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8b616c35-0310-4a4f-ad78-ca9602f18465"), new Guid("a2b3a104-d124-4bfd-80fe-95d8d2b983b8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6089b70e-35ea-4d44-8274-7dce6657fc08"), new Guid("bca11161-98f3-461f-ba2e-e961680a6ba6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5515df77-a887-422f-8efc-0348b84d98e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6089b70e-35ea-4d44-8274-7dce6657fc08"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b616c35-0310-4a4f-ad78-ca9602f18465"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63f2595-6b79-4a27-8793-ba190c5f7beb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf739b7c-7552-4bda-abd3-f9e6d45aa3e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("27b4df07-080f-4062-9cfe-f95a4fa491dc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ea27cfe-3287-4f53-9fb1-d7c12111d977"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e854c46-5e44-411f-bd35-f216a286a2bf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2b3a104-d124-4bfd-80fe-95d8d2b983b8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bca11161-98f3-461f-ba2e-e961680a6ba6"));

            migrationBuilder.AlterColumn<string>(
                name: "DataPlantio",
                table: "Plot",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Inicio",
                table: "Harvest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Fim",
                table: "Harvest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), "8cb42112-bd0e-4684-8782-75225d94c739", "Owner", "OWNER" },
                    { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), "e543e64b-f032-45b8-9410-15cb39b6093b", "Collaborator", "COLLABORATOR" },
                    { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), "0fa41820-99d0-4a88-8868-8252881d675a", "Admin", "ADMIN" },
                    { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), "d01cef5d-ec43-4996-b9a3-4c41f83ed67e", "Manager", "MANAGER" },
                    { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), "d84874a1-7337-4c71-ba9f-363baa0a02a2", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f"), 0, "0a131ca4-eb2f-47ec-80a5-883b8267bab7", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9619), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$kLw.ihwlyVXfXC6F6Xr4jeSn95pkhzgvufBNqlY5ezViZriCA8mfe", "(99) 99999-9991", false, "bb82e1dd-33cd-421c-82c8-bbf010032166", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(7800), "john" },
                    { new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f"), 0, "2b7aa2f7-4598-49b5-8a63-bd94fed0ffd6", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9892), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$UvNXH74RZQVVrYDU/Kp9zuQTABOwd1vQY1VXFdqYyXXBX6o1FUENO", "(99) 99999-9994", false, "e5476a89-2e0c-4bc4-b5e7-529c06737c06", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9885), "bob" },
                    { new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463"), 0, "b2d2c5aa-4a8d-4b0a-aa0c-8e5ee2a8aadf", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9885), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$u.xIO6WlDJAFOn8jFGWuWuBT46Qn7R55BZqhe7/D5EVImXxCGxz2u", "(99) 99999-9993", false, "8f317eac-cb14-4281-b5e0-709cc4d407b8", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9881), "alice" },
                    { new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2"), 0, "f287012f-4300-48f2-b8bc-db7f1b414be8", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9880), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$mn.zHmXVd3p/UHbKNxIzH..kF052qOhwBlR7c8taQc4PGB1qt4GZe", "(99) 99999-9992", false, "f91f07ef-50bb-49d9-a1eb-8d3ed0c4bd02", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9862), "jane" },
                    { new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51"), 0, "265f8558-8e00-44b3-a334-a656bbc23c94", new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9896), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$ET0SuSQS3GpFsTe4knPYQ.WRG/cnNsY6kJNDHEsR8Mh3SyEMAdDum", "(99) 99999-9995", false, "3599e024-79d8-4d50-aaa8-cf0fd7d6d2f1", 0, false, new DateTime(2025, 7, 23, 15, 15, 8, 338, DateTimeKind.Local).AddTicks(9893), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("938d9e73-e847-4b62-bbf2-3cfcc4e74c42"), new Guid("6433b318-3557-4176-94bb-6cf6ab1a087f") },
                    { new Guid("b6b41c3b-c3e7-49ed-9abc-d459d52bc818"), new Guid("6b071e46-d8dd-4586-bc8b-d6579caeb29f") },
                    { new Guid("d6426ab4-aeae-4d49-a9e7-8e2d5a398548"), new Guid("917a3bb9-ace0-4b7d-b4f1-0ec8e7e99463") },
                    { new Guid("02cfcde4-37bb-4d22-b23c-f96642fd95aa"), new Guid("ca7f1525-da18-4b59-a9a0-339d0199f0a2") },
                    { new Guid("2efc23b2-4ef8-4048-bda0-e6d6770477be"), new Guid("deb5fd91-64f3-44c0-996f-e1ae7a20ee51") }
                });
        }
    }
}
