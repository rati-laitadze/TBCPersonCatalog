using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonCatalog.Repository.Migrations
{
    public partial class addImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumberType",
                table: "PhoneNumbers",
                newName: "PhoneNumberType");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageFilename",
                value: "rati");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumberType",
                table: "PhoneNumbers",
                newName: "phoneNumberType");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageFilename",
                value: null);
        }
    }
}
