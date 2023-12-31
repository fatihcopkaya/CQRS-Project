﻿using StajProjesiAPI.Application.Abstract.Services;
using System.Security.Cryptography;
using System.Text;


namespace StajProjesiAPI.Infrastructure.Security.Hashing
{
    public class HashingHelper : IHashingHelperService
    {
        public  void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public  bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            using HMACSHA512 hmacshA512 = new(passwordSalt);
            byte[] hash = hmacshA512.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int index = 0; index < hash.Length; ++index)
            {
                if (hash[index] != passwordHash[index])
                    return false;
            }
            return true;
        }
    }
}
