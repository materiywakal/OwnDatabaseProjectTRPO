﻿using System;
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
        public static byte[] decryptStream(byte[] encrypted, byte[] Key, byte[] IV)
        {
            byte[] plain;
            int count;
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.Mode = CipherMode.CBC;
                    using (CryptoStream cryptoStream = new CryptoStream(mStream,
                     aesProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        plain = new byte[encrypted.Length];
                        count = cryptoStream.Read(plain, 0, plain.Length);
                    }
                }
            }

            // My method was written quite some time ago, and I don't remember why we had to copy the Array
            // but I'm pretty sure that it's necessary
            byte[] returnval = new byte[count];
            Array.Copy(plain, returnval, count);
            return returnval;
        }
    }
}
