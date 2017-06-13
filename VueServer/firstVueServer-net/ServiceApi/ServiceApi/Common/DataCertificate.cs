using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Common
{
    public sealed class DataCertificate
    {
        #region 从证书中获取信息
        /// <summary>   
        /// 根据私钥证书得到证书实体，得到实体后可以根据其公钥和私钥进行加解密   
        /// 加解密函数使用DEncrypt的RSACryption类   
        /// </summary>   
        /// <param name="pfxFileName"></param>   
        /// <param name="password"></param>   
        /// <returns></returns>   
        public static X509Certificate2 GetCertificateFromPfxFile(string pfxFileName,
            string password)
        {
            try
            {
                return new X509Certificate2(pfxFileName, password, X509KeyStorageFlags.Exportable);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>   
        /// 到存储区获取证书   
        /// </summary>   
        /// <param name="subjectName"></param>   
        /// <returns></returns>   
        public static X509Certificate2 GetCertificateFromStore(string subjectName)
        {
            subjectName = "CN=" + subjectName;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == subjectName)
                {
                    return x509;
                }
            }
            store.Close();
            store = null;
            storecollection = null;
            return null;
        }
        /// <summary>   
        /// 根据公钥证书，返回证书实体   
        /// </summary>   
        /// <param name="cerPath"></param>   
        public static X509Certificate2 GetCertFromCerFile(string cerPath)
        {
            try
            {
                return new X509Certificate2(cerPath);
            }
            catch (Exception e)
            {

                return null;
            }
        }
        #endregion
    }
}
