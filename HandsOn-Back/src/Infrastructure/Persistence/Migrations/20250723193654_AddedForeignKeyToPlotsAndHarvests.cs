using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyToPlotsAndHarvests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("482a423f-a5d3-4642-a5d3-dc9f18ec3698"), "6ea278bd-5bf8-4375-b37b-66625a0ce52d", "Owner", "OWNER" },
                    { new Guid("77d460a9-cbf7-433b-b900-8311559a7128"), "5694e8e1-1165-4b04-a168-f7bd93dd31a6", "Collaborator", "COLLABORATOR" },
                    { new Guid("87c5a2d4-7fab-497a-b090-2f5acc083288"), "0d2053f3-0bb3-4a4a-886d-9f6808c4118d", "Consultant", "CONSULTANT" },
                    { new Guid("bfdc9d93-b679-41ee-b4c1-900598be8fe4"), "351ec286-be0f-4b43-a67a-198e64c833a9", "Admin", "ADMIN" },
                    { new Guid("ea35917c-ab2a-4c95-8d93-91768fb9e074"), "4976ca83-36cf-46e9-8b50-64318e54cff6", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("391cc515-e842-4d41-a4f4-1038c7589b9e"), 0, "022fd651-babb-485d-8948-47ebb25b08c5", new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2125), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$VPrLuZv9QMKMVJB1bqJRzuR.Gi90Xq3rauKWuFpz/oe92Ihqn4eIG", "(99) 99999-9992", false, "60f575a9-0368-44b0-90e3-e5fb16cbd9cc", 0, false, new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2102), "jane" },
                    { new Guid("3bd1c3af-d917-4b9e-9fa2-2313a54e1f28"), 0, "769f48b3-bcbf-43c8-94c1-aed7eb9da544", new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(1859), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$40fI8/qisN//GrSnyjLBueUdeFCqeD0wBZTQmjK/OO8SN9brx4B1e", "(99) 99999-9991", false, "ea4f2163-f20c-42ec-a0f1-219bb91d3dd9", 0, false, new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(48), "john" },
                    { new Guid("66823dcf-541f-4d8e-95f7-f5e5c2233ea0"), 0, "3a596c9a-1498-46a4-bdf5-4cc4d890d881", new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2130), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$aur9gXQvfo/jHnNzFHoigeWi5V342Yee92ikRIz1Q7U.IoyGdhe8a", "(99) 99999-9993", false, "97c20196-87b7-44e9-b8a8-077ed7114c0f", 0, false, new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2126), "alice" },
                    { new Guid("db74a67d-7276-4e55-bd47-c7267230c66a"), 0, "01e13300-7118-4ceb-872d-3b20a8ffbedf", new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2137), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$09pLZ4q2.4KrD.Q7otN0gOBejyZgGAbSpLH7fDjV80mnRe.MBaYSa", "(99) 99999-9995", false, "9298088e-cbaf-4df4-9628-e7f87af8fcb1", 0, false, new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2134), "charlie" },
                    { new Guid("f3c09429-a140-4c73-85db-ebc8d4fe2cda"), 0, "0f9118d7-af6a-4a7c-b231-1fa73ac33992", new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2133), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$8bb5RaC5NY6xy6MyrXgQDecXgGa5Le7.ozBFzTzyO8DNAv7LV0kqK", "(99) 99999-9994", false, "745dad23-c03c-49e9-bd3c-2544e9a6eca6", 0, false, new DateTime(2025, 7, 23, 16, 36, 52, 501, DateTimeKind.Local).AddTicks(2131), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("482a423f-a5d3-4642-a5d3-dc9f18ec3698"), new Guid("391cc515-e842-4d41-a4f4-1038c7589b9e") },
                    { new Guid("bfdc9d93-b679-41ee-b4c1-900598be8fe4"), new Guid("3bd1c3af-d917-4b9e-9fa2-2313a54e1f28") },
                    { new Guid("87c5a2d4-7fab-497a-b090-2f5acc083288"), new Guid("66823dcf-541f-4d8e-95f7-f5e5c2233ea0") },
                    { new Guid("77d460a9-cbf7-433b-b900-8311559a7128"), new Guid("db74a67d-7276-4e55-bd47-c7267230c66a") },
                    { new Guid("ea35917c-ab2a-4c95-8d93-91768fb9e074"), new Guid("f3c09429-a140-4c73-85db-ebc8d4fe2cda") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plot_UserId",
                table: "Plot",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_PlotId",
                table: "Harvest",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harvest_Plot_PlotId",
                table: "Harvest",
                column: "PlotId",
                principalTable: "Plot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plot_AspNetUsers_UserId",
                table: "Plot",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harvest_Plot_PlotId",
                table: "Harvest");

            migrationBuilder.DropForeignKey(
                name: "FK_Plot_AspNetUsers_UserId",
                table: "Plot");

            migrationBuilder.DropIndex(
                name: "IX_Plot_UserId",
                table: "Plot");

            migrationBuilder.DropIndex(
                name: "IX_Harvest_PlotId",
                table: "Harvest");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("482a423f-a5d3-4642-a5d3-dc9f18ec3698"), new Guid("391cc515-e842-4d41-a4f4-1038c7589b9e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bfdc9d93-b679-41ee-b4c1-900598be8fe4"), new Guid("3bd1c3af-d917-4b9e-9fa2-2313a54e1f28") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87c5a2d4-7fab-497a-b090-2f5acc083288"), new Guid("66823dcf-541f-4d8e-95f7-f5e5c2233ea0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77d460a9-cbf7-433b-b900-8311559a7128"), new Guid("db74a67d-7276-4e55-bd47-c7267230c66a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ea35917c-ab2a-4c95-8d93-91768fb9e074"), new Guid("f3c09429-a140-4c73-85db-ebc8d4fe2cda") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("482a423f-a5d3-4642-a5d3-dc9f18ec3698"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77d460a9-cbf7-433b-b900-8311559a7128"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87c5a2d4-7fab-497a-b090-2f5acc083288"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfdc9d93-b679-41ee-b4c1-900598be8fe4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ea35917c-ab2a-4c95-8d93-91768fb9e074"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("391cc515-e842-4d41-a4f4-1038c7589b9e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3bd1c3af-d917-4b9e-9fa2-2313a54e1f28"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66823dcf-541f-4d8e-95f7-f5e5c2233ea0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("db74a67d-7276-4e55-bd47-c7267230c66a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f3c09429-a140-4c73-85db-ebc8d4fe2cda"));

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
    }
}
