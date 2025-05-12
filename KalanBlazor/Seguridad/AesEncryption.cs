using System.Security.Cryptography;
using System.Text;

namespace KalanBlazor.Seguridad
{
    public class AesEncryption
    {
        private readonly byte[] Salt = Encoding.ASCII.GetBytes("204d93fe8cbeb276b25ea51a484c6fda1a1edd59fc88a7c9a0232874a1ff0100");
        private readonly int Iterations = 1000;

        public string UrlEncrypt(string plainText, string password)
        {
            string encrypted = Encrypt(plainText, password);
            return System.Net.WebUtility.UrlEncode(encrypted);
        }

        public string UrlDecrypt(string cipherText, string password)
        {
            string decoded = Decrypt(cipherText, password);
            return System.Net.WebUtility.UrlDecode(decoded);
        }

        public string EncryptPassword(string Password)
        {
            return UrlEncrypt(Password, "KalanPassword");
        }

        public string DecryptPassword(string Password)
        {
            return UrlDecrypt(Password, "KalanPassword");
        }

        public string Encrypt(string plainText, string password)
        {
            var key = new Rfc2898DeriveBytes(password, Salt, Iterations);

            using var aes = Aes.Create();
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cs))
            {
                writer.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText, string password)
        {
            var key = new Rfc2898DeriveBytes(password, Salt, Iterations);

            using var aes = Aes.Create();
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var reader = new StreamReader(cs))
            {
                return reader.ReadToEnd();
            }
        }
    }
}