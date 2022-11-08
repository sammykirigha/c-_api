using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanyShopAPI.Migrations
{
    public partial class CreateEmployeesInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smoker = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "City", "Comment", "CountryId", "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "Latitude", "Longitude", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
                values: new object[] { 1, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "Lorem Ipsum", 1, "bethany@bethanyspieshop.com", null, "Bethany", 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 50.850299999999997, 4.3517000000000001, 1, "324777888773", false, "Grote Markt 1", "1000" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "City", "Comment", "CountryId", "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "Latitude", "Longitude", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
                values: new object[] { 2, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antwerp", "Lorem Ipsum", 2, "sam@bethanyspieshop.com", null, "Samuel", 0, 1, new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kirigha", 50.850299999999997, 4.3517000000000001, 0, "33999909923", false, "New Street", "2000" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
