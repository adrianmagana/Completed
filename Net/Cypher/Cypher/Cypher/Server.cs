using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cypher
{
    //uses base64 encoding for data transfer and utf-8 for taking input
    class Server
    {
        private string symmetricKey;

        private RSA rsa;
        private Aes aes;
        public Server()
        {       
                rsa = RSA.Create(); //creates a default rsa with auto generated key pair
                aes = Aes.Create();       
        }

        public string GetPublicKey()
        {
            Byte[] keyBytes = rsa.ExportRSAPublicKey();
            return Convert.ToBase64String(keyBytes);
        }
        //decrypts symmetric key which was encryped using public key
        public void SetSymmetricKey(string encrypted)
        {
     
            symmetricKey = AsymmetricDencryption(encrypted); 
            aes.Key = Convert.FromBase64String(symmetricKey);
        }

        public string AsymmetricEncryption(string plainText)
        {
            Byte[] strBytes = Encoding.UTF8.GetBytes(plainText);
            Byte[] encryptedBytes = rsa.Encrypt(strBytes,RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string AsymmetricDencryption(string encrypted)
        {
            Byte[] strBytes = Convert.FromBase64String(encrypted);
            Byte[] encryptedBytes = rsa.Decrypt(strBytes, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(encryptedBytes);
        }


        public AesEncryptedMessage SymmetricEncryption(string plainText)
        {
            aes.GenerateIV();
            var encryptor = aes.CreateEncryptor();
            byte[] b = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(b, 0, b.Length);
            string encrypted = Convert.ToBase64String(encryptedBytes);
            string iv = Convert.ToBase64String(aes.IV);
            AesEncryptedMessage msg = new AesEncryptedMessage(encrypted, iv);
            return msg;
        }

        public string SymmetricDencryption(AesEncryptedMessage msg)
        {
            byte[] encryptedBytes = Convert.FromBase64String(msg.Message);
            byte[] iv = Convert.FromBase64String(msg.IV);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor();
            byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            string output = Encoding.UTF8.GetString(plainBytes);
            return output;
        }
    }
}
