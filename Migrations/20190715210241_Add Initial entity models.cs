using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTNtmp.Migrations
{
    public partial class AddInitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonalEmail",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MarketingEmail",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCardId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeVendorsId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorPositionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusType = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPositionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(nullable: false),
                    VendorPhone = table.Column<string>(maxLength: 10, nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    PositionUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorHours_Vendors_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    BillRate = table.Column<float>(nullable: false),
                    PositionUrl = table.Column<string>(nullable: true),
                    NoOfRequirements = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FeedBack = table.Column<string>(nullable: true),
                    ClientID = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorPositions_Vendors_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorPositionId = table.Column<int>(nullable: false),
                    EmployeeCardId = table.Column<int>(nullable: false),
                    CheckedOutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_EmployeeCards_EmployeeCardId",
                        column: x => x.EmployeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_VendorPositions_VendorPositionId",
                        column: x => x.VendorPositionId,
                        principalTable: "VendorPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorPositionId = table.Column<int>(nullable: true),
                    EmployeeCardId = table.Column<int>(nullable: true),
                    HoldPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_EmployeeCards_EmployeeCardId",
                        column: x => x.EmployeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_VendorPositions_VendorPositionId",
                        column: x => x.VendorPositionId,
                        principalTable: "VendorPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorPositionId = table.Column<int>(nullable: false),
                    EmployeeCardId = table.Column<int>(nullable: true),
                    OnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_EmployeeCards_EmployeeCardId",
                        column: x => x.EmployeeCardId,
                        principalTable: "EmployeeCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Submissions_VendorPositions_VendorPositionId",
                        column: x => x.VendorPositionId,
                        principalTable: "VendorPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCardId",
                table: "Employees",
                column: "EmployeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HomeVendorsId",
                table: "Employees",
                column: "HomeVendorsId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_EmployeeCardId",
                table: "CheckoutHistories",
                column: "EmployeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_VendorPositionId",
                table: "CheckoutHistories",
                column: "VendorPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_EmployeeCardId",
                table: "Holds",
                column: "EmployeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_VendorPositionId",
                table: "Holds",
                column: "VendorPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_EmployeeCardId",
                table: "Submissions",
                column: "EmployeeCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_VendorPositionId",
                table: "Submissions",
                column: "VendorPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorHours_BranchId",
                table: "VendorHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorPositions_LocationId",
                table: "VendorPositions",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeCards_EmployeeCardId",
                table: "Employees",
                column: "EmployeeCardId",
                principalTable: "EmployeeCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Vendors_HomeVendorsId",
                table: "Employees",
                column: "HomeVendorsId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeCards_EmployeeCardId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Vendors_HomeVendorsId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "VendorHours");

            migrationBuilder.DropTable(
                name: "VendorPositionStatuses");

            migrationBuilder.DropTable(
                name: "EmployeeCards");

            migrationBuilder.DropTable(
                name: "VendorPositions");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeCardId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_HomeVendorsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeCardId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HomeVendorsId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalEmail",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MarketingEmail",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
