using System;
using System.Security.Cryptography;
using System.Text;

namespace Cypher
{
    //uses base64 encoding for data transfer and utf-8 for taking input
    class Client
    {
        private readonly string symmetricKey = "gNMEkOKWTh9EK1T3DjUlWT9g5QWD9+CboZEr+SSuOpk=";
        private RSA rsa;
        private Aes aes;

        public Client(string publicKey)
        {
            rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
            aes = Aes.Create();
            aes.Key = Convert.FromBase64String(symmetricKey);                  
        }

        public string GetSymmetricKey()
        {
            return AsymmetricEncryption(symmetricKey);
        }

        public string AsymmetricEncryption(string plainText)
        {           
            Byte[] strBytes = Encoding.UTF8.GetBytes(plainText);
            Byte[] encryptedBytes = rsa.Encrypt(strBytes, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedBytes);
        }

        public AesEncryptedMessage SymmetricEncryption(string plainText)
        {
            aes.GenerateIV();
            var encryptor = aes.CreateEncryptor();
            byte[] b = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(b, 0, b.Length);
            string encrypted = Convert.ToBase64String(encryptedBytes);
            string iv = Convert.ToBase64String(aes.IV);
            AesEncryptedMessage msg = new AesEncryptedMessage(encrypted,iv);
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
