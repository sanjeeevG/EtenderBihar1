using System;
using System.Collections.Generic;
using System.Text;

namespace ETB.Core.Entities
{
    public class UserInfoAuthenticationResult
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsAuthenticated { get; set; }
        public UserRole UserRole { get; set; }
        public string HashedData { get; set; }
        public string Token { get; set; }
    }
}
