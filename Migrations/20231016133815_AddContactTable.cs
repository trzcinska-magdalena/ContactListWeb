using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactListWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SubcategoryID = table.Column<int>(type: "int", nullable: true),
                    SubcategoryOther = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Subcategory_SubcategoryID",
                        column: x => x.SubcategoryID,
                        principalTable: "Subcategory",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "BirthDate", "CategoryID", "Email", "Name", "Password", "Phone", "SubcategoryID", "SubcategoryOther", "Surname" },
                values: new object[] { 1, new DateTime(1900, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "anna.kowal@qw.pl", "Anna", "aniako123A", "123456789", 2, null, "Kowal" });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CategoryID",
                table: "Contact",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SubcategoryID",
                table: "Contact",
                column: "SubcategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
