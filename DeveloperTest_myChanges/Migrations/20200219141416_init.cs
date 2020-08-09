using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperTest.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Engineer = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Engineer", "When" },
                values: new object[] { 1, "Test", new DateTime(2020, 2, 19, 14, 14, 16, 317, DateTimeKind.Local).AddTicks(2552) });
            
            //Customer
            migrationBuilder.CreateTable(
               name: "Customers",
               columns: table => new
               {
                   CustomerId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(nullable: true),
                   Type = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Jobs", x => x.CustomerId);
               });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name", "Type" },
                values: new object[] { 1, "Test", "Large" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
