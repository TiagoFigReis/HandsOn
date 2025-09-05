using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedAnaliseEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analise_AspNetUsers_UserId",
                table: "Analise");

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

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "Analise");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Analise",
                newName: "HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_Analise_UserId",
                table: "Analise",
                newName: "IX_Analise_HarvestId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Analise_Harvest_HarvestId",
                table: "Analise",
                column: "HarvestId",
                principalTable: "Harvest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analise_Harvest_HarvestId",
                table: "Analise");

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

            migrationBuilder.RenameColumn(
                name: "HarvestId",
                table: "Analise",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Analise_HarvestId",
                table: "Analise",
                newName: "IX_Analise_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlotId",
                table: "Analise",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Analise_AspNetUsers_UserId",
                table: "Analise",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
