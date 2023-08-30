using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ferme.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<double>(type: "double precision", nullable: false),
                    UnitOfMeasureCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PLU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VATID = table.Column<int>(type: "integer", nullable: false),
                    Percent = table.Column<double>(type: "double precision", nullable: false),
                    Text = table.Column<double>(type: "double precision", nullable: false),
                    VATValue = table.Column<double>(type: "double precision", nullable: false),
                    VATTurnover = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaisseLite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceiptID = table.Column<int>(type: "integer", nullable: false),
                    LocalReceiptID = table.Column<int>(type: "integer", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    PriceToPay = table.Column<double>(type: "double precision", nullable: false),
                    OriginalSalesTotal = table.Column<double>(type: "double precision", nullable: false),
                    PriceToPayWithoutRounding = table.Column<double>(type: "double precision", nullable: false),
                    AmountWithoutRounding = table.Column<double>(type: "double precision", nullable: false),
                    FiscalState = table.Column<string>(type: "text", nullable: true),
                    VATId = table.Column<int>(type: "integer", nullable: true),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaisseLite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaisseLite_VAT_VATId",
                        column: x => x.VATId,
                        principalTable: "VAT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentValue = table.Column<double>(type: "double precision", nullable: false),
                    PaymentConfirmed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CaisseLiteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_CaisseLite_CaisseLiteId",
                        column: x => x.CaisseLiteId,
                        principalTable: "CaisseLite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PLUId = table.Column<int>(type: "integer", nullable: false),
                    BasePriceId = table.Column<int>(type: "integer", nullable: false),
                    PriceToPay = table.Column<double>(type: "double precision", nullable: false),
                    VATId = table.Column<int>(type: "integer", nullable: false),
                    CaisseLiteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_BasePrice_BasePriceId",
                        column: x => x.BasePriceId,
                        principalTable: "BasePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_CaisseLite_CaisseLiteId",
                        column: x => x.CaisseLiteId,
                        principalTable: "CaisseLite",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registration_PLU_PLUId",
                        column: x => x.PLUId,
                        principalTable: "PLU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_VAT_VATId",
                        column: x => x.VATId,
                        principalTable: "VAT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaisseLite_VATId",
                table: "CaisseLite",
                column: "VATId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CaisseLiteId",
                table: "Payment",
                column: "CaisseLiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_BasePriceId",
                table: "Registration",
                column: "BasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CaisseLiteId",
                table: "Registration",
                column: "CaisseLiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_PLUId",
                table: "Registration",
                column: "PLUId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_VATId",
                table: "Registration",
                column: "VATId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "BasePrice");

            migrationBuilder.DropTable(
                name: "CaisseLite");

            migrationBuilder.DropTable(
                name: "PLU");

            migrationBuilder.DropTable(
                name: "VAT");
        }
    }
}
