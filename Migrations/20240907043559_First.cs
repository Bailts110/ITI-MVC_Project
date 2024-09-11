using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Phones" },
                    { 2, null, "Laptop" },
                    { 3, null, "Fruits" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FName", "LName", "Password" },
                values: new object[,]
                {
                    { 1, "email@mail.com", "Ramy", "Mai", "123456" },
                    { 2, "email@mail.com", "Mai", "Ali", "123456" },
                    { 3, "email@mail.com", "Ali", "Ramy", "123456" },
                    { 4, "email@mail.com", "Omar", "Ramy", "123456" },
                    { 5, "email@mail.com", "Mostafa", "Omar", "123456" },
                    { 6, "email@mail.com", "Ahmed", "Mostafa", "123456" },
                    { 7, "email@mail.com", "Sara", "Ahmed", "123456" },
                    { 8, "email@mail.com", "Osama", "Mohamed", "123456" },
                    { 9, "email@mail.com", "Mohamed", "Osama", "123456" },
                    { 10, "email@mail.com", "Nour", "Nour", "123456" },
                    { 11, "email@mail.com", "Mohamed", "Nour", "123456" },
                    { 12, "email@mail.com", "Nour", "Ramy", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, null, 2234m, 2, "IPhone 12" },
                    { 2, 2, null, null, 2234m, 2, "Lenovo Legion2" },
                    { 3, 1, null, null, 3234m, 2, "Samsung galaxy 123" },
                    { 4, 1, null, null, 4234m, 2, "Huawei y4" },
                    { 5, 2, null, null, 5234m, 2, "HP victus21" },
                    { 6, 1, null, null, 6234m, 2, "Oppo v13" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
