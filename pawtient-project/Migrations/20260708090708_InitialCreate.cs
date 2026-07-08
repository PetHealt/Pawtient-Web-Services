using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace pawtient_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    APT_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CLI_id = table.Column<int>(type: "int", nullable: true),
                    PET_id = table.Column<int>(type: "int", nullable: true),
                    VET_id = table.Column<int>(type: "int", nullable: true),
                    APT_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    APT_time = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    APT_patient = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, defaultValue: ""),
                    APT_owner = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, defaultValue: ""),
                    APT_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "REQUESTED"),
                    APT_reason = table.Column<string>(type: "longtext", nullable: true),
                    APT_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "FIRST_VISIT"),
                    APT_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.00m),
                    APT_created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.APT_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    CLI_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    USU_id = table.Column<int>(type: "int", nullable: false),
                    CLI_name = table.Column<string>(type: "longtext", nullable: false),
                    CLI_address = table.Column<string>(type: "longtext", nullable: true),
                    CLI_phone = table.Column<string>(type: "longtext", nullable: true),
                    CLI_ruc = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.CLI_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    INV_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CLI_id = table.Column<int>(type: "int", nullable: false),
                    APT_id = table.Column<int>(type: "int", nullable: true),
                    INV_pet_name = table.Column<string>(type: "longtext", nullable: false),
                    INV_owner_name = table.Column<string>(type: "longtext", nullable: true),
                    INV_patient = table.Column<string>(type: "longtext", nullable: false),
                    INV_client = table.Column<string>(type: "longtext", nullable: true),
                    INV_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.00m),
                    INV_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    INV_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "PENDING"),
                    INV_notes = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.INV_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PET_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CLI_id = table.Column<int>(type: "int", nullable: false),
                    PET_name = table.Column<string>(type: "longtext", nullable: false),
                    PET_species_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    PET_breed_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    PET_age = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PET_birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    PET_sex = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: "UNKNOWN"),
                    PET_microchip = table.Column<string>(type: "varchar(255)", nullable: true),
                    PET_coat_color = table.Column<string>(type: "longtext", nullable: true),
                    PET_weight_kg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PET_is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PET_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SUP_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CLI_id = table.Column<int>(type: "int", nullable: false),
                    SUP_name = table.Column<string>(type: "longtext", nullable: false),
                    SUP_contact_email = table.Column<string>(type: "longtext", nullable: true),
                    SUP_phone = table.Column<string>(type: "longtext", nullable: true),
                    SUP_ruc = table.Column<string>(type: "longtext", nullable: true),
                    SUP_contact = table.Column<string>(type: "longtext", nullable: true),
                    SUP_category = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SUP_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    USU_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    USU_full_name = table.Column<string>(type: "longtext", nullable: false),
                    USU_email = table.Column<string>(type: "varchar(255)", nullable: false),
                    USU_password_hash = table.Column<string>(type: "longtext", nullable: false),
                    USU_role = table.Column<string>(type: "longtext", nullable: false),
                    USU_plan_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Paw Care"),
                    USU_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "ACTIVE"),
                    USU_created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.USU_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PRD_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CLI_id = table.Column<int>(type: "int", nullable: false),
                    SUP_id = table.Column<int>(type: "int", nullable: true),
                    PRD_name = table.Column<string>(type: "longtext", nullable: false),
                    PRD_description = table.Column<string>(type: "longtext", nullable: true),
                    PRD_unit_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PRD_stock = table.Column<int>(type: "int", nullable: false),
                    PRD_minimum_stock = table.Column<int>(type: "int", nullable: false),
                    PRD_is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PRD_id);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SUP_id",
                        column: x => x.SUP_id,
                        principalTable: "Suppliers",
                        principalColumn: "SUP_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_USU_id",
                table: "Clinics",
                column: "USU_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PET_microchip",
                table: "Pets",
                column: "PET_microchip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SUP_id",
                table: "Products",
                column: "SUP_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_USU_email",
                table: "Users",
                column: "USU_email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
