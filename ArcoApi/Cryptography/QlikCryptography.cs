using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArcoApi.Cryptography
{
    public static class QlikCryptography
    {
        private static readonly byte[] Key = new byte[] { 125, 85, 45, 26, 122, 14, 32, 145, 201, 125, 44, 174, 54, 77, 33, 1 };
        private static readonly byte[] IV = new byte[] { 55, 95, 216, 8, 14, 22, 69, 7, 5, 2, 59, 28, 97, 81, 241, 36 };

        public static string EncryptString(string S)
        {
            RijndaelManaged rjm = new RijndaelManaged();
            rjm.KeySize = 128;
            rjm.BlockSize = 128;
            rjm.Key = Key;
            rjm.IV = IV;
            var input = Encoding.UTF8.GetBytes(S);
            var output = rjm.CreateEncryptor().TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }


        public static string DecryptString(string S)
        {
            RijndaelManaged rjm = new RijndaelManaged();
            rjm.KeySize = 128;
            rjm.BlockSize = 128;
            rjm.Key = Key;
            rjm.IV = IV;
            try
            {
                var input = Convert.FromBase64String(S);
                var output = rjm.CreateDecryptor().TransformFinalBlock(input, 0, input.Length);
                return Encoding.UTF8.GetString(output);
            }
            catch
            {
                return S;
            }
        }
    }
}
