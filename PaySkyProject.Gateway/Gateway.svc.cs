using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace PaySkyProject.Gateway
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Gateway" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Gateway.svc or Gateway.svc.cs at the Solution Explorer and start debugging.
    public class Gateway : IGateway
    {
        public string ProcessTransaction(Transaction transaction)
        {
            if (transaction != null)
            {
                var value = transaction.Value;
                var data = Decrypt(value);
                var obj  = JsonConvert.DeserializeObject<TransactionObj>(data);
                obj.ResponseCode = "00";
                obj.Message = "00";
                obj.ApprovalCode = 123123;
                obj.DateTime = DateTime.Now;

            var objResult = new JavaScriptSerializer().Serialize(obj);

            var dataResult = Encrypt(objResult);

            return string.Format(dataResult);
            }

            return "Error happened ...!";
        }


        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray;

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            string key = "FA4158A4-D499-4208-87FB-35E7BD153753";

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            string encrypted = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return encrypted;
        }


        public static string Decrypt(string cipherString)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "FA4158A4-D499-4208-87FB-35E7BD153753";

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }

    public class TransactionObj
    {
        public int TransactionId { get; set; }
        public long ProcessingCode { get; set; }
        public int SystemTraceNr { get; set; }
        public int FunctionCode { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public double AmountTrxn { get; set; }
        public int CurrencyCode { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public int ApprovalCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}
