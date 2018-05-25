using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SecurityCrypto
{
    class Program
    {
        static void Main()
        {
            const string test = "This is a Sample Text";
            Console.WriteLine("Original Message For Hashing:\n" + test);
            var sha256message = CreateSHA256(Encoding.UTF8.GetBytes(test));
            Console.WriteLine("\nMessage Created Through SHA 256:\n" + Convert.ToBase64String(sha256message));

            var sha512message = CreateSHA512(Encoding.UTF8.GetBytes(test));
            Console.WriteLine("\nMessage Created Through SHA 512 :\n" + Convert.ToBase64String(sha512message));

            var md5message = CreateMD5(Encoding.UTF8.GetBytes(test));
            Console.WriteLine("\nMessage Created Through MD5:\n" + Convert.ToBase64String(md5message));

            var key = GenerateKey();

            var hmacmd5message = CreateHMACMD5(Encoding.UTF8.GetBytes(test),key);
            Console.WriteLine("\nMessage Created Through HMAC MD5:\n" + Convert.ToBase64String(hmacmd5message));

            var hmac256message = CreateHMACSHA256(Encoding.UTF8.GetBytes(test),key);
            Console.WriteLine("\nMessage Created Through HMAC 256:\n" + Convert.ToBase64String(hmac256message));

            var hmac512message = CreateHMACSHA512(Encoding.UTF8.GetBytes(test),key);
            Console.WriteLine("\nMessage Created Through HMAC 512:\n" + Convert.ToBase64String(hmac512message));

            Console.Read();

        }


        public static byte[] CreateSHA256(byte[] hashdata)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(hashdata);
            }
        }

        public static byte[] CreateSHA512(byte[] hashdata)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(hashdata);
            }
        }


        public static byte[] CreateMD5(byte[] hashdata)
        {
            using (var md5data = MD5.Create())
            {
                return md5data.ComputeHash(hashdata);
            }
        }

        public static byte[] CreateHMACMD5(byte[] hashdata,byte[] key)
        {
            using (var hmacdata = new HMACMD5(key))
            {
                return hmacdata.ComputeHash(hashdata);
            }
        }

        public static byte[] CreateHMACSHA256(byte[] hashdata,byte[] key)
        {
            using (var hmacdata = new HMACSHA256(key))
            {
                return hmacdata.ComputeHash(hashdata);
            }
        }


        public static byte[] CreateHMACSHA512(byte[] hashdata,byte[] key)
        {
            using (var hmacdata = new HMACSHA512(key))
            {
                return hmacdata.ComputeHash(hashdata);
            }
        }
        
        private static int KeySize = 32;

        public static byte[] GenerateKey()
        {
            
            using (var rndgen = new RNGCryptoServiceProvider())
            {
                var rnd = new byte[KeySize];
                rndgen.GetBytes(rnd);

                return rnd;
                
            }
        }




    }
}
