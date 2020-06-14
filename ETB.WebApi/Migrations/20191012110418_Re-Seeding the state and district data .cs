using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class ReSeedingthestateanddistrictdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictHQ", "DistrictName", "State" },
                values: new object[,]
                {
                    { 101, "Araria", "Araria", "Bihar" },
                    { 134, "Sitamarhi", "Sitamarhi", "Bihar" },
                    { 135, "Siwan", "Siwan", "Bihar" },
                    { 136, "Supaul", "Supaul", "Bihar" },
                    { 137, "Hajipur", "Vaishali", "Bihar" },
                    { 138, "Bettiah", "West Champaran", "Bihar" },
                    { 1001, "Bokaro", "Bokaro", "Jharkhand" },
                    { 1002, "Chatra", "Chatra", "Jharkhand" },
                    { 1003, "Deoghar", "Deoghar", "Jharkhand" },
                    { 1004, "Dhanbad", "Dhanbad", "Jharkhand" },
                    { 1005, "Dumka", "Dumka", "Jharkhand" },
                    { 1006, "Jamshedpur", "East Singhbhum", "Jharkhand" },
                    { 1007, "Garhwa", "Garhwa", "Jharkhand" },
                    { 1008, "Giridih", "Giridih", "Jharkhand" },
                    { 133, "Sheohar", "Sheohar", "Bihar" },
                    { 1009, "Godda", "Godda", "Jharkhand" },
                    { 1012, "Jamtara", "Jamtara", "Jharkhand" },
                    { 1013, "Khunti", "Khunti", "Jharkhand" },
                    { 1014, "Koderma", "Kodarma", "Jharkhand" },
                    { 1015, "Latehar", "Latehar", "Jharkhand" },
                    { 1016, "Lohardaga", "Lohardaga", "Jharkhand" },
                    { 1017, "Pakur", "Pakur", "Jharkhand" },
                    { 1018, "Daltonganj", "Palamu", "Jharkhand" },
                    { 1019, "Ramgarh", "Ramgarh", "Jharkhand" },
                    { 1020, "Ranchi", "Ranchi", "Jharkhand" },
                    { 1021, "Sahebganj", "Sahibganj", "Jharkhand" },
                    { 1022, "Seraikela", "Saraikela Kharsawan", "Jharkhand" },
                    { 1023, "Simdega", "Simdega", "Jharkhand" },
                    { 1024, "Chaibasa", "West Singhbhum", "Jharkhand" },
                    { 1010, "Gumla", "Gumla", "Jharkhand" },
                    { 132, "Sheikhpura", "Sheikhpura", "Bihar" },
                    { 1011, "Hazaribag", "Hazaribagh", "Jharkhand" },
                    { 130, "Samastipur ", "Samastipur", "Bihar" },
                    { 131, "Chapra", "Saran", "Bihar" },
                    { 102, "Arwal", "Arwal", "Bihar" },
                    { 103, "Aurangabad", "Aurangabad", "Bihar" },
                    { 104, "Banka", "Banka", "Bihar" },
                    { 105, "Begusarai", "Begusarai", "Bihar" },
                    { 106, "Bhabhua", "Bhabhua", "Bihar" },
                    { 107, "Bhagalpur", "Bhagalpur", "Bihar" },
                    { 109, "Buxar", "Buxar", "Bihar" },
                    { 110, "Darbhanga", "Darbhanga", "Bihar" },
                    { 111, "Motihari", "East Champaran", "Bihar" },
                    { 112, "Gaya", "Gaya", "Bihar" },
                    { 113, "Gopalganj", "Gopalganj", "Bihar" },
                    { 114, "Jamui", "Jamui", "Bihar" },
                    { 115, "Jehanabad", "Jehanabad", "Bihar" },
                    { 108, "Ara", "Bhojpur", "Bihar" },
                    { 125, "Nawada ", "Nawada", "Bihar" },
                    { 128, "Sasaram", "Rohtas", "Bihar" },
                    { 127, "Purnea ", "Purnea", "Bihar" },
                    { 126, "Patna", "Patna", "Bihar" },
                    { 124, "Nalanda ", "Nalanda", "Bihar" },
                    { 116, "Katihar", "Katihar", "Bihar" },
                    { 123, "Muzaffarpur ", "Muzaffarpur", "Bihar" },
                    { 121, "Madhubani", "Madhubani", "Bihar" },
                    { 120, "Madhepura", "Madhepura", "Bihar" },
                    { 119, "Lakhisarai", "Lakhisarai", "Bihar" },
                    { 118, "Kishanganj", "Kishanganj", "Bihar" },
                    { 117, "Khagaria", "Khagaria", "Bihar" },
                    { 122, "Munger", "Munger", "Bihar" },
                    { 129, "Saharsa ", "Saharsa", "Bihar" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Capital", "Name", "StateOrOthers" },
                values: new object[,]
                {
                    { 25, "Agartala", "Tripura", 0 },
                    { 24, "Hyderabad", "Telangana", 0 },
                    { 23, "Chennai", "Tamil Nadu", 0 },
                    { 35, "Pondicherry", "Puducherry (Pondicherry)", 0 },
                    { 26, "Lucknow", "Uttar Pradesh", 0 },
                    { 21, "Jaipur", "Rajasthan", 0 },
                    { 22, "Gangtok", "Sikkim", 0 },
                    { 27, "Dehradun", "Uttarakhand", 0 },
                    { 33, "Delhi", "Delhi", 0 },
                    { 29, "Port Blair", "Andaman and Nicobar Islands", 0 },
                    { 30, "Chandigarh", "Chandigarh", 0 },
                    { 31, "Silvassa", "Dadar and Nagar Haveli", 0 },
                    { 32, "Daman", "Daman and Diu", 0 },
                    { 34, "Kavaratti", "Lakshadweep", 0 },
                    { 20, "Chandigarh", "Punjab", 0 },
                    { 28, "Kolkata", "West Bengal", 0 },
                    { 19, "Bhubaneswar", "Odisha", 0 },
                    { 4, "Dispur", "Assam", 0 },
                    { 17, "Aizawl", "Mizoram", 0 },
                    { 36, "Srinagar", "Jammu and Kashmir", 0 },
                    { 2, "Hyderabad", "Andhra Pradesh", 0 },
                    { 3, "Itanagar", "Arunachal Pradesh", 0 },
                    { 5, "Raipur", "Chhattisgarh", 0 },
                    { 6, "Panaji", "Goa", 0 },
                    { 7, "Gandhinagar", "Gujarat", 0 },
                    { 8, "Chandigarh", "Haryana", 0 },
                    { 9, "Shimla", "Himachal Pradesh", 0 },
                    { 10, "Ranchi", "Jharkhand", 0 },
                    { 11, "Bengaluru", "Karnataka", 0 },
                    { 12, "Thiruvananthapuram", "Kerala", 0 },
                    { 13, "Bhopal", "Madhya Pradesh", 0 },
                    { 14, "Mumbai", "Maharashtra", 0 },
                    { 15, "Imphal", "Manipur", 0 },
                    { 16, "Shillong", "Meghalaya", 0 },
                    { 18, "Kohima", "Nagaland", 0 },
                    { 37, "Leh", "Ladakh", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37);

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
                    { 29, "Saharsa ", "Saharsa", "Bihar" },
                    { 30, "Samastipur ", "Samastipur", "Bihar" },
                    { 31, "Chapra", "Saran", "Bihar" },
                    { 32, "Sheikhpura", "Sheikhpura", "Bihar" },
                    { 33, "Sheohar", "Sheohar", "Bihar" },
                    { 34, "Sitamarhi", "Sitamarhi", "Bihar" },
                    { 35, "Siwan", "Siwan", "Bihar" },
                    { 36, "Supaul", "Supaul", "Bihar" },
                    { 21, "Madhubani", "Madhubani", "Bihar" },
                    { 20, "Madhepura", "Madhepura", "Bihar" },
                    { 19, "Lakhisarai", "Lakhisarai", "Bihar" },
                    { 18, "Kishanganj", "Kishanganj", "Bihar" },
                    { 2, "Arwal", "Arwal", "Bihar" },
                    { 3, "Aurangabad", "Aurangabad", "Bihar" },
                    { 4, "Banka", "Banka", "Bihar" },
                    { 5, "Begusarai", "Begusarai", "Bihar" },
                    { 6, "Bhabhua", "Bhabhua", "Bihar" },
                    { 7, "Bhagalpur", "Bhagalpur", "Bihar" },
                    { 8, "Ara", "Bhojpur", "Bihar" },
                    { 37, "Hajipur", "Vaishali", "Bihar" },
                    { 9, "Buxar", "Buxar", "Bihar" },
                    { 11, "Motihari", "East Champaran", "Bihar" },
                    { 12, "Gaya", "Gaya", "Bihar" },
                    { 13, "Gopalganj", "Gopalganj", "Bihar" },
                    { 14, "Jamui", "Jamui", "Bihar" },
                    { 15, "Jehanabad", "Jehanabad", "Bihar" },
                    { 16, "Katihar", "Katihar", "Bihar" },
                    { 17, "Khagaria", "Khagaria", "Bihar" },
                    { 10, "Darbhanga", "Darbhanga", "Bihar" },
                    { 38, "Bettiah", "West Champaran", "Bihar" }
                });
        }
    }
}
