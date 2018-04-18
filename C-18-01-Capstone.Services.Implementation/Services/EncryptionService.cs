﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using C_18_01_Capstone.Services.Services;

namespace C_18_01_Capstone.Services.Implementation.Services
{
  public class EncryptionService : IEncryptionService
  {
    public string CreateSalt()
    {
      var data = new byte[0x10];
      using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
      {
        cryptoServiceProvider.GetBytes(data);
        return Convert.ToBase64String(data);
      }
    }

    public string EncryptPassword(string password, string salt)
    {
      using (var sha256 = SHA256.Create())
      {
        var saltedPassword = String.Format("{0}{1}", salt, password);
        byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
        var hashedBytes = sha256.ComputeHash(saltedPasswordAsBytes);
        return Convert.ToBase64String(hashedBytes);
      }
    }
  }
}
