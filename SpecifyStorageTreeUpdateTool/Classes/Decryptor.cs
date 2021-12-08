using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SpecifyStorageTreeUpdateTool
{
    internal class Decryptor
    {
        private readonly int ITERATION_COUNT = 1000;
        private readonly int SALT_LENGTH = 8;


        private byte[] reverseHexStr(string str)
        {
            int len = str.Length / 2;
            byte[] bytes = new byte[len];
            int inx = 0;
            for (int i = 0; i < len; i++)
            {
                int iVal = Convert.ToInt32(str.Substring(inx, 2), 16);
                bytes[i] = (byte)(iVal > 127 ? iVal - 256 : iVal);
                inx += 2;
            }
            return bytes;
        }
        
        public string decrypt(string encryptedStr, string password)
        {
            byte[] input = reverseHexStr(encryptedStr);
            byte[] salt = new byte[SALT_LENGTH];
            System.Array.Copy(input, 0, salt, 0, SALT_LENGTH);
            byte[] inputBytes = new byte[input.Length - salt.Length];
            System.Array.Copy(input, salt.Length, inputBytes, 0, inputBytes.Length);
            PKCSKeyGenerator crypto = new PKCSKeyGenerator(password, salt, ITERATION_COUNT, 1);
            ICryptoTransform cryptoTransform = crypto.Decryptor;
            var clearBytes = cryptoTransform.TransformFinalBlock(input, SALT_LENGTH, input.Length - SALT_LENGTH);
            return Encoding.UTF8.GetString(clearBytes);           
        }
    }
}
