using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Utils.Security.RSA_Cryptography
{
    public class Crypting
    {
        public byte[] ConvertedData { get; private set; }
        public byte[] EncryptedData { get; private set; }
        public string OkEncryptedData { get; private set; }


        public string Encrypt(string plainText, string publicKey)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            ConvertedData = Encoding.UTF8.GetBytes(plainText);
            provider.FromXmlString(publicKey);


            if (plainText == null || plainText.Length == 0)
                throw new ArgumentException("Data are empty", "plainText");
            
            int maxLength = ((provider.KeySize - 384) / 8) + 37;

            if (ConvertedData.Length > maxLength)
                throw new ArgumentException(String.Format("Longueur maximal de la chaine atteinte {0}", maxLength), "plainText");

            if (String.IsNullOrEmpty(publicKey))
                throw new ArgumentException("La clé public n'est pas valide", "publicKey");

            
            EncryptedData = provider.Encrypt(ConvertedData, false);

            OkEncryptedData = Convert.ToBase64String(EncryptedData);

            return OkEncryptedData;
        }
    }
}
