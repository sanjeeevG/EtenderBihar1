using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class AddingseeddatatoDistrictANDState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictHQ", "DistrictName", "State" },
                values: new object[,]
                {
                    { 1, "Araria", "Araria", "Bihar" },
                    { 22, "Munger", "Munger", "Bihar" },
                    { 23, "Muzaffarpur ", "Muzaffarpur", "Bihar" },
                    { 24, "Nalanda ", "Nalanda", "Bihar" },
                    { 25, "Nawada ", "Nawada", "Bihar" },
                    { 26, "Patna", "Patna", "Bihar" },
                    { 27, "Purnea ", "Purnea", "Bihar" },
                    { 28, "Sasaram", "Rohtas", "Bihar" },
                    { 21, "Madhubani", "Madhubani", "Bihar" },
                    { 29, "Saharsa ", "Saharsa", "Bihar" },
                    { 31, "Chapra", "Saran", "Bihar" },
                    { 32, "Sheikhpura", "Sheikhpura", "Bihar" },
                    { 33, "Sheohar", "Sheohar", "Bihar" },
                    { 34, "Sitamarhi", "Sitamarhi", "Bihar" },
                    { 35, "Siwan", "Siwan", "Bihar" },
                    { 36, "Supaul", "Supaul", "Bihar" },
                    { 37, "Hajipur", "Vaishali", "Bihar" },
                    { 30, "Samastipur ", "Samastipur", "Bihar" },
                    { 38, "Bettiah", "West Champaran", "Bihar" },
                    { 20, "Madhepura", "Madhepura", "Bihar" },
                    { 18, "Kishanganj", "Kishanganj", "Bihar" },
                    { 2, "Arwal", "Arwal", "Bihar" },
                    { 3, "Aurangabad", "Aurangabad", "Bihar" },
                    { 4, "Banka", "Banka", "Bihar" },
                    { 5, "Begusarai", "Begusarai", "Bihar" },
                    { 6, "Bhabhua", "Bhabhua", "Bihar" },
                    { 7, "Bhagalpur", "Bhagalpur", "Bihar" },
                    { 8, "Ara", "Bhojpur", "Bihar" },
                    { 19, "Lakhisarai", "Lakhisarai", "Bihar" },
                    { 9, "Buxar", "Buxar", "Bihar" },
                    { 11, "Motihari", "East Champaran", "Bihar" },
                    { 12, "Gaya", "Gaya", "Bihar" },
                    { 13, "Gopalganj", "Gopalganj", "Bihar" },
                    { 14, "Jamui", "Jamui", "Bihar" },
                    { 15, "Jehanabad", "Jehanabad", "Bihar" },
                    { 16, "Katihar", "Katihar", "Bihar" },
                    { 17, "Khagaria", "Khagaria", "Bihar" },
                    { 10, "Darbhanga", "Darbhanga", "Bihar" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Capital", "Name" },
                values: new object[] { 1, "Patna", "Bihar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
