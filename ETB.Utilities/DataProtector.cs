using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETB.Utilities
{
    public class DataProtector
    {
        private readonly IDataProtector _protector;

        public DataProtector(IDataProtectionProvider protectionProvider)
        {
            _protector = protectionProvider.CreateProtector(GetType().FullName, "AppApi");
        }

        public string Encrypt(string stringValue)
        {
            return _protector.Protect(stringValue);
        }

        public string Decrypt(string encryptedValue)
        {
            return _protector.Unprotect(encryptedValue);
        }

    }
}
