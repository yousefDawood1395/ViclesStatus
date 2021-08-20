using Microsoft.EntityFrameworkCore.Migrations;

namespace ViclesStatus.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer_ID", "Address", "CustomerName" },
                values: new object[] { 1, "Nasr City", "customer1" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer_ID", "Address", "CustomerName" },
                values: new object[] { 2, "maady", "customer2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer_ID", "Address", "CustomerName" },
                values: new object[] { 3, "fifth sittlement", "customer3" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Vehicle_ID", "Customer_ID", "RegNr" },
                values: new object[] { 1, 1, "hsdgdt1245" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Vehicle_ID", "Customer_ID", "RegNr" },
                values: new object[] { 2, 2, "hhiuie3565" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Vehicle_ID", "Customer_ID", "RegNr" },
                values: new object[] { 3, 3, "llddldl65487" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Vehicle_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Vehicle_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Vehicle_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 3);
        }
    }
}
