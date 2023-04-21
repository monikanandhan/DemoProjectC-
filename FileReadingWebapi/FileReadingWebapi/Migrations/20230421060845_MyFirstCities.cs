using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FileReadingWebapi.Migrations
{
    public partial class MyFirstCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "longtext", nullable: false),
                    city_ascii = table.Column<string>(type: "longtext", nullable: false),
                    lat = table.Column<string>(type: "longtext", nullable: false),
                    lng = table.Column<string>(type: "longtext", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false),
                    iso2 = table.Column<string>(type: "longtext", nullable: false),
                    iso3 = table.Column<string>(type: "longtext", nullable: false),
                    admin_name = table.Column<string>(type: "longtext", nullable: false),
                    capital = table.Column<string>(type: "longtext", nullable: false),
                    population = table.Column<string>(type: "longtext", nullable: false),
                    citiesno = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
