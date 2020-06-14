using System;
using System.Collections.Generic;
using System.Text;

namespace ETB.Core.Entities
{
    public enum SignInType
    {   
        Out,
        In
    }
    public class UserSignInLog
    {
        public int Id { get; set; }
        public UserInfo UserInfo { get; set; }
        public DateTime SignInTime { get; set; }
        public SignInType SignInType { get; set; } = SignInType.In;
    }
}
