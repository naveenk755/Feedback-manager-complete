using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyShopsAPI.Migrations
{
    public partial class initialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RequiresCall = table.Column<bool>(type: "bit", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FridayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FridayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MondayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SaturdayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SaturdayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SundayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SundayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ThursdayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ThursdayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TuesdayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TuesdayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WednesdayClose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WednesdayOpen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
