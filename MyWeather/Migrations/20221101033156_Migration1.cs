using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWeather.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weather_records",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Forecast = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    SqlStartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SqlEndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__weather___FBDF78C919D80F5B", x => x.RecordID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weather_records");
        }
    }
}
