using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.Modules
{
    public static class AES
    {

        public static byte[] encryptStream(byte[] plain, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (MemoryStream mstream = new MemoryStream())
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mstream,
                        aesProvider.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plain, 0, plain.Length);
                    }
                    encrypted = mstream.ToArray();
                }
            }
            return encrypted;
        }
        public static byte[] mydec(byte[] encrypted, byte[] Key, byte[] IV)
        {
            byte[] plain;
            using (MemoryStream mStream = new MemoryStream(encrypted)) //add encrypted
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mStream,
                        aesProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        //cryptoStream.Read(encrypted, 0, encrypted.Length);
                        using (StreamReader stream = new StreamReader(cryptoStream))
                        {
                            string sf = stream.ReadToEnd();
                            plain = System.Text.Encoding.Default.GetBytes(sf);
                        }
                    }
                }
            }
            return plain;
        }
    }
}
