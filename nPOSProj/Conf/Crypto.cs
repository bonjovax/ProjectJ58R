using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace nPOSProj.Conf
{
    class Crypto
    {
        private String getHash;

        //Send
        public String Hashed(String encode)
        {
            try
            {
                SHA512 hash = SHA512.Create();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] combined = encoder.GetBytes(encode);
                hash.ComputeHash(combined);
                getHash = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception)
            {
                Console.WriteLine("NOT PRESENT!");
            }
            return getHash;
        }

        //Return
        public String retreiveHash()
        {
            return getHash;
        }

        public String RefHashed(String encode)
        {
            try
            {
                SHA1 hash = SHA1.Create();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] combined = encoder.GetBytes(encode);
                hash.ComputeHash(combined);
                getHash = Convert.ToBase64String(hash.Hash);
            }
            catch (Exception)
            {
                Console.WriteLine("NOT PRESENT!");
            }
            return getHash;
        }

        //Return
        public String RefretreiveHash()
        {
            return getHash;
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }
        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }
        public string EncryptText(string cardno, string transaction_no)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(cardno);
            byte[] transactionBytes = Encoding.UTF8.GetBytes(transaction_no);

            // Hash the password
            transactionBytes = SHA512.Create().ComputeHash(transactionBytes);
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, transactionBytes);
            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }
        protected string DecryptText(string cardno, string transaction_no)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(cardno);
            byte[] transactionBytes = Encoding.UTF8.GetBytes(transaction_no);
            transactionBytes = SHA512.Create().ComputeHash(transactionBytes);
            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, transactionBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);
            return result;
        }
    }
}