using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentType = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentCardName = table.Column<string>(type: "TEXT", nullable: false),
                    CardNum = table.Column<string>(type: "TEXT", nullable: false),
                    CardExp = table.Column<string>(type: "TEXT", nullable: false),
                    CardCvv = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentVoid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
