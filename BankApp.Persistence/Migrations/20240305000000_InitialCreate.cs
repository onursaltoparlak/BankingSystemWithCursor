using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Persistence.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CorporateCustomers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                TaxNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "IndividualCustomers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                NationalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "UK_CorporateCustomers_Email",
            table: "CorporateCustomers",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "UK_CorporateCustomers_TaxNumber",
            table: "CorporateCustomers",
            column: "TaxNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "UK_IndividualCustomers_Email",
            table: "IndividualCustomers",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "UK_IndividualCustomers_NationalId",
            table: "IndividualCustomers",
            column: "NationalId",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CorporateCustomers");

        migrationBuilder.DropTable(
            name: "IndividualCustomers");
    }
} 