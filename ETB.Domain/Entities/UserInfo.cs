using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.DataEncryption;
using System.Text;

namespace ETB.Core.Entities
{
    public enum UserRole
    {
        Admin,
        Operator,
        Subscriber,
    }

    public class UserInfo
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserId { get; set; }
        [Encrypted]
        [MaxLength(255)]
        public string Pass { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Subscriber;
        public IsActive Allow { get; set; } = IsActive.Y;
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }

}
