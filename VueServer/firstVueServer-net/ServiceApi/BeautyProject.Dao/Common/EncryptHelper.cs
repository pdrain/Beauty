using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace BeautyProject.Dao.Common
{
    public class EncryptHelper
    {
        private static string certificate_password = ConfigurationManager.AppSettings["pfx_password"];
        private static string certificate_path = System.Web.HttpContext.Current.Server.MapPath("/") + "/" + ConfigurationManager.AppSettings["pfx_filename"];

        ///   <summary>
        ///   MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strContent)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF7.GetBytes(strContent);
            bytes = crypto.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte num in bytes)
            {
                sb.AppendFormat("{0:x2}", num);
            }
            return sb.ToString().ToUpper();        //32位
        }

        ///   <summary>
        ///   MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5Encrypt(byte[] content)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            byte[] bytes = content;
            bytes = crypto.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte num in bytes)
            {
                sb.AppendFormat("{0:x2}", num);
            }
            return sb.ToString().ToUpper();        //32位
        }



        /// <summary>   
        /// RSA解密   
        /// </summary>   
        /// <param name="xmlPrivateKey"></param>   
        /// <param name="m_strDecryptString"></param>   
        /// <returns></returns>   
        public static string RSADecrypt(string m_strDecryptString)
        {
            X509Certificate2 x509 = DataCertificate.GetCertificateFromPfxFile(certificate_path, certificate_password);            
            string xmlPrivateKey = x509.PrivateKey.ToXmlString(true);

            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPrivateKey);
            byte[] rgb = Convert.FromBase64String(m_strDecryptString);
            byte[] bytes = provider.Decrypt(rgb, false);
            return new UnicodeEncoding().GetString(bytes);
        }
        /// <summary>   
        /// RSA加密   
        /// </summary>   
        /// <param name="xmlPublicKey"></param>   
        /// <param name="m_strEncryptString"></param>   
        /// <returns></returns>   
        public static string RSAEncrypt(string m_strEncryptString)
        {
            X509Certificate2 x509 = DataCertificate.GetCertificateFromPfxFile(certificate_path, certificate_password);
            string xmlPublicKey = x509.PrivateKey.ToXmlString(false);


            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));
        }
    }
}
