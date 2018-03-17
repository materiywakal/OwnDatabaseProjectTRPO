using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer.Modules;

namespace SecurityLayer.Modules
{
    internal class EncryptionModule
    {
        static public MemoryStream EncryptDataBase(DataLayer.DataBaseInstance _dataToCrypt, byte[] _key)
        {
            byte[] _outputData = SharedCryptingMethods.DatabaseObjectToByteArray(_dataToCrypt);

            // Создаем новый экземпляр класса Aes 
            // Создаем ключ и вектор инициализации (IV)
            Console.WriteLine(_outputData.Length);
            Console.WriteLine(_outputData);
            using (var myAes = Aes.Create())
            {
                myAes.GenerateIV();
                string password = "1234abcd";
                for (int i = 0; i < _outputData.Length; i++)
                {
                    Console.Write(_outputData[i].ToString());
                }
                // byte array representation of that string
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

                // need MD5 to calculate the hash
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                myAes.Key = hash;
                // Зашифрованную строку переводим в массив байтов
                byte[] encrypted = AES.encryptStream(_outputData, myAes.Key, myAes.IV);
                _outputData = AES.mydec(encrypted, myAes.Key, myAes.IV);
                Console.WriteLine(_outputData);
                Console.WriteLine(_outputData.Length);
                for (int i = 0; i < _outputData.Length; i++)
                {
                    Console.Write(_outputData[i].ToString());
                }
                // Расшифровываем байты и записываем в строку.
                // string roundtrip = DecryptStringFromBytesAes(encrypted, myAes.Key, myAes.IV);


                //Выводим на экран результат

                //  Console.WriteLine("Round Trip: {0}", roundtrip);
            }

            return new MemoryStream(_outputData);
        }
    }
}
