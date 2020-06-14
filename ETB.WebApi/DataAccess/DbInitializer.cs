using ETB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApi.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(ETBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Districts.Any())
            {
                return;   // DB has been seeded
            }

            context.Districts.AddRange(GetDistrictsSeed());
            context.SaveChanges();

            if (context.States.Any())
            {
                return;   // DB has been seeded
            }

            context.States.AddRange(GetStateSeed());
            context.SaveChanges();

        }
        public static State[] GetStateSeed()
        {
            var states = new State[]
            {
                new State (){Id = 1,Name= "Bihar", Capital= "Patna", StateOrOthers=0},
                new State (){Id =2, Name = "Andhra Pradesh", Capital= "Hyderabad", StateOrOthers=0 },
                new State (){Id =3, Name = "Arunachal Pradesh", Capital= "Itanagar", StateOrOthers=0 },
                new State (){Id =4, Name = "Assam", Capital= "Dispur", StateOrOthers=0 },
                new State (){Id =5, Name = "Chhattisgarh", Capital= "Raipur", StateOrOthers=0 },
                new State (){Id =6, Name = "Goa", Capital= "Panaji", StateOrOthers=0 },
                new State (){Id =7, Name = "Gujarat", Capital= "Gandhinagar", StateOrOthers=0 },
                new State (){Id =8, Name = "Haryana", Capital= "Chandigarh", StateOrOthers=0 },
                new State (){Id =9, Name = "Himachal Pradesh", Capital= "Shimla", StateOrOthers=0 },
                new State (){Id =10, Name = "Jharkhand", Capital= "Ranchi", StateOrOthers=0 },
                new State (){Id =11, Name = "Karnataka", Capital= "Bengaluru", StateOrOthers=0 },
                new State (){Id =12, Name = "Kerala", Capital= "Thiruvananthapuram", StateOrOthers=0 },
                new State (){Id =13, Name = "Madhya Pradesh", Capital= "Bhopal", StateOrOthers=0 },
                new State (){Id =14, Name = "Maharashtra", Capital= "Mumbai", StateOrOthers=0 },
                new State (){Id =15, Name = "Manipur", Capital= "Imphal", StateOrOthers=0 },
                new State (){Id =16, Name = "Meghalaya", Capital= "Shillong", StateOrOthers=0 },
                new State (){Id =17, Name = "Mizoram", Capital= "Aizawl", StateOrOthers=0 },
                new State (){Id =18, Name = "Nagaland", Capital= "Kohima", StateOrOthers=0 },
                new State (){Id =19, Name = "Odisha", Capital= "Bhubaneswar", StateOrOthers=0 },
                new State (){Id =20, Name = "Punjab", Capital= "Chandigarh", StateOrOthers=0 },
                new State (){Id =21, Name = "Rajasthan", Capital= "Jaipur", StateOrOthers=0 },
                new State (){Id =22, Name = "Sikkim", Capital= "Gangtok", StateOrOthers=0 },
                new State (){Id =23, Name = "Tamil Nadu", Capital= "Chennai", StateOrOthers=0 },
                new State (){Id =24, Name = "Telangana", Capital= "Hyderabad", StateOrOthers=0 },
                new State (){Id =25, Name = "Tripura", Capital= "Agartala", StateOrOthers=0 },
                new State (){Id =26, Name = "Uttar Pradesh", Capital= "Lucknow", StateOrOthers=0 },
                new State (){Id =27, Name = "Uttarakhand", Capital= "Dehradun", StateOrOthers=0 },
                new State (){Id =28, Name = "West Bengal", Capital= "Kolkata", StateOrOthers=0 },
                new State (){Id =29, Name = "Andaman and Nicobar Islands", Capital= "Port Blair", StateOrOthers=0 },
                new State (){Id =30, Name = "Chandigarh", Capital= "Chandigarh", StateOrOthers=0 },
                new State (){Id =31, Name = "Dadar and Nagar Haveli", Capital= "Silvassa", StateOrOthers=0 },
                new State (){Id =32, Name = "Daman and Diu", Capital= "Daman", StateOrOthers=0 },
                new State (){Id =33, Name = "Delhi", Capital= "Delhi", StateOrOthers=0 },
                new State (){Id =34, Name = "Lakshadweep", Capital= "Kavaratti", StateOrOthers=0 },
                new State (){Id =35, Name = "Puducherry (Pondicherry)", Capital= "Pondicherry", StateOrOthers=0 },
                new State (){Id =36, Name = "Jammu and Kashmir", Capital= "Srinagar", StateOrOthers=0 },
                new State (){Id =37, Name = "Ladakh", Capital= "Leh", StateOrOthers=0 },

            };
            return states;
        }

        public static District[] GetDistrictsSeed()
        {
            var districts = new District[]
            {
                new District (){ Id = 101, DistrictName = "Araria", DistrictHQ = "Araria", State = "Bihar" },
                new District (){ Id = 102, DistrictName = "Arwal", DistrictHQ = "Arwal", State = "Bihar" },
                new District (){ Id = 103, DistrictName = "Aurangabad", DistrictHQ = "Aurangabad", State = "Bihar" },
                new District (){ Id = 104, DistrictName = "Banka", DistrictHQ = "Banka", State = "Bihar" },
                new District (){ Id = 105, DistrictName = "Begusarai", DistrictHQ = "Begusarai", State = "Bihar" },
                new District (){ Id = 106, DistrictName = "Bhabhua", DistrictHQ = "Bhabhua", State = "Bihar" },
                new District (){ Id = 107, DistrictName = "Bhagalpur", DistrictHQ = "Bhagalpur", State = "Bihar" },
                new District (){ Id = 108, DistrictName = "Bhojpur", DistrictHQ = "Ara", State = "Bihar" },
                new District (){ Id = 109, DistrictName = "Buxar", DistrictHQ = "Buxar", State = "Bihar" },
                new District (){ Id = 110, DistrictName = "Darbhanga", DistrictHQ = "Darbhanga", State = "Bihar" },
                new District (){ Id = 111, DistrictName = "East Champaran", DistrictHQ = "Motihari", State = "Bihar" },
                new District (){ Id = 112, DistrictName = "Gaya", DistrictHQ = "Gaya", State = "Bihar" },
                new District (){ Id = 113, DistrictName = "Gopalganj", DistrictHQ = "Gopalganj", State = "Bihar" },
                new District (){ Id = 114, DistrictName = "Jamui", DistrictHQ = "Jamui", State = "Bihar" },
                new District (){ Id = 115, DistrictName = "Jehanabad", DistrictHQ = "Jehanabad", State = "Bihar" },
                new District (){ Id = 116, DistrictName = "Katihar", DistrictHQ = "Katihar", State = "Bihar" },
                new District (){ Id = 117, DistrictName = "Khagaria", DistrictHQ = "Khagaria", State = "Bihar" },
                new District (){ Id = 118, DistrictName = "Kishanganj", DistrictHQ = "Kishanganj", State = "Bihar" },
                new District (){ Id = 119, DistrictName = "Lakhisarai", DistrictHQ = "Lakhisarai", State = "Bihar" },
                new District (){ Id = 120, DistrictName = "Madhepura", DistrictHQ = "Madhepura", State = "Bihar" },
                new District (){ Id = 121, DistrictName = "Madhubani", DistrictHQ = "Madhubani", State = "Bihar" },
                new District (){ Id = 122, DistrictName = "Munger", DistrictHQ = "Munger", State = "Bihar" },
                new District (){ Id = 123, DistrictName = "Muzaffarpur", DistrictHQ = "Muzaffarpur ", State = "Bihar" },
                new District (){ Id = 124, DistrictName = "Nalanda", DistrictHQ = "Nalanda ", State = "Bihar" },
                new District (){ Id = 125, DistrictName = "Nawada", DistrictHQ = "Nawada ", State = "Bihar" },
                new District (){ Id = 126, DistrictName = "Patna", DistrictHQ = "Patna", State = "Bihar" },
                new District (){ Id = 127, DistrictName = "Purnea", DistrictHQ = "Purnea ", State = "Bihar" },
                new District (){ Id = 128, DistrictName = "Rohtas", DistrictHQ = "Sasaram", State = "Bihar" },
                new District (){ Id = 129, DistrictName = "Saharsa", DistrictHQ = "Saharsa ", State = "Bihar" },
                new District (){ Id = 130, DistrictName = "Samastipur", DistrictHQ = "Samastipur ", State = "Bihar" },
                new District (){ Id = 131, DistrictName = "Saran", DistrictHQ = "Chapra", State = "Bihar" },
                new District (){ Id = 132, DistrictName = "Sheikhpura", DistrictHQ = "Sheikhpura", State = "Bihar" },
                new District (){ Id = 133, DistrictName = "Sheohar", DistrictHQ = "Sheohar", State = "Bihar" },
                new District (){ Id = 134, DistrictName = "Sitamarhi", DistrictHQ = "Sitamarhi", State = "Bihar" },
                new District (){ Id = 135, DistrictName = "Siwan", DistrictHQ = "Siwan", State = "Bihar" },
                new District (){ Id = 136, DistrictName = "Supaul", DistrictHQ = "Supaul", State = "Bihar" },
                new District (){ Id = 137, DistrictName = "Vaishali", DistrictHQ = "Hajipur", State = "Bihar" },
                new District (){ Id = 138, DistrictName = "West Champaran", DistrictHQ = "Bettiah", State = "Bihar" },
                new District (){Id =1001, DistrictName = "Bokaro", DistrictHQ= "Bokaro", State="Jharkhand" },
                new District (){Id =1002, DistrictName = "Chatra", DistrictHQ= "Chatra", State="Jharkhand" },
                new District (){Id =1003, DistrictName = "Deoghar", DistrictHQ= "Deoghar", State="Jharkhand" },
                new District (){Id =1004, DistrictName = "Dhanbad", DistrictHQ= "Dhanbad", State="Jharkhand" },
                new District (){Id =1005, DistrictName = "Dumka", DistrictHQ= "Dumka", State="Jharkhand" },
                new District (){Id =1006, DistrictName = "East Singhbhum", DistrictHQ= "Jamshedpur", State="Jharkhand" },
                new District (){Id =1007, DistrictName = "Garhwa", DistrictHQ= "Garhwa", State="Jharkhand" },
                new District (){Id =1008, DistrictName = "Giridih", DistrictHQ= "Giridih", State="Jharkhand" },
                new District (){Id =1009, DistrictName = "Godda", DistrictHQ= "Godda", State="Jharkhand" },
                new District (){Id =1010, DistrictName = "Gumla", DistrictHQ= "Gumla", State="Jharkhand" },
                new District (){Id =1011, DistrictName = "Hazaribagh", DistrictHQ= "Hazaribag", State="Jharkhand" },
                new District (){Id =1012, DistrictName = "Jamtara", DistrictHQ= "Jamtara", State="Jharkhand" },
                new District (){Id =1013, DistrictName = "Khunti", DistrictHQ= "Khunti", State="Jharkhand" },
                new District (){Id =1014, DistrictName = "Kodarma", DistrictHQ= "Koderma", State="Jharkhand" },
                new District (){Id =1015, DistrictName = "Latehar", DistrictHQ= "Latehar", State="Jharkhand" },
                new District (){Id =1016, DistrictName = "Lohardaga", DistrictHQ= "Lohardaga", State="Jharkhand" },
                new District (){Id =1017, DistrictName = "Pakur", DistrictHQ= "Pakur", State="Jharkhand" },
                new District (){Id =1018, DistrictName = "Palamu", DistrictHQ= "Daltonganj", State="Jharkhand" },
                new District (){Id =1019, DistrictName = "Ramgarh", DistrictHQ= "Ramgarh", State="Jharkhand" },
                new District (){Id =1020, DistrictName = "Ranchi", DistrictHQ= "Ranchi", State="Jharkhand" },
                new District (){Id =1021, DistrictName = "Sahibganj", DistrictHQ= "Sahebganj", State="Jharkhand" },
                new District (){Id =1022, DistrictName = "Saraikela Kharsawan", DistrictHQ= "Seraikela", State="Jharkhand" },
                new District (){Id =1023, DistrictName = "Simdega", DistrictHQ= "Simdega", State="Jharkhand" },
                new District (){Id =1024, DistrictName = "West Singhbhum", DistrictHQ= "Chaibasa", State="Jharkhand" }

            };

            return districts;
        }
    }
}
