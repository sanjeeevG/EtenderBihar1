using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Models
{
    public class UserInfoDetailViewModel
    {
        public string UserId { get; set; }
        public int UserDetailId { get; set; }
        public string FullName { get; set; }
        public string PhotoPath { get; set; }
        public string UserRole { get; set; }
    }
}
