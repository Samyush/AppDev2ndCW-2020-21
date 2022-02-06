using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDev2ndCW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Member_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Purchased_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contacts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookInventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author_Id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Id = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Stocked_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock_Quantity = table.Column<int>(type: "int", nullable: false),
                    Sales_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInventory_BookAuthors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInventory_BookCategories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer_Id = table.Column<long>(type: "bigint", nullable: false),
                    Sale_Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Id = table.Column<long>(type: "bigint", nullable: false),
                    Book_Id = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_BookInventory_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "BookInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_Sale_Id",
                        column: x => x.Sale_Id,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInventory_Author_Id",
                table: "BookInventory",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookInventory_Category_Id",
                table: "BookInventory",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_Book_Id",
                table: "SaleItems",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_Sale_Id",
                table: "SaleItems",
                column: "Sale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Customer_Id",
                table: "Sales",
                column: "Customer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookInventory");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
