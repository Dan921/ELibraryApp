using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Logic
{
    public class PasswordHelper
    {
        public string GeneratePassword()
        {
            Random rand = new Random();
            int simbolsСount = rand.Next(6, 13);
            int specSimbolsCount = rand.Next(3, simbolsСount);
            simbolsСount -= specSimbolsCount;
            string password = "";
            for (int i = 0; i < simbolsСount; i++)
            {
                password += (char)rand.Next(97, 122);
            }
            for (int i = 0; i < specSimbolsCount; i++)
            {
                password = password.Insert(rand.Next(0, password.Length + 1), ((char)rand.Next(33, 64)).ToString());
            }
            return password;
        }

        public string GetHashPassword(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
