using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPassword
{
    public class HashSHA256
    {
        public static string HashPswd(string password) 
        {
            using (SHA256 shA256Hash = SHA256.Create())
            {
                byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                byte[] hashSourceBytrePassword = shA256Hash.ComputeHash(sourceBytePassword);
                string hasspwd = BitConverter.ToString(hashSourceBytrePassword).Replace("-", String.Empty);
                return hasspwd;
            }
        }
    }
}
