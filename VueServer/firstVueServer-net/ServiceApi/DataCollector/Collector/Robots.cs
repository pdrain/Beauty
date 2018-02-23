using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataCollector.Collector
{
    public abstract class Robots
    {
        public abstract void DoRobot(string path);

        /// <summary>
        /// 抓取网页内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string FetchData(string path)
        {
            try
            {


                WebClient webClient = new WebClient();
                byte[] data = webClient.DownloadData(path);

                string content = Encoding.UTF8.GetString(data);

                return content;
            }
            catch (Exception ex)
            {
                throw new Exception("采集分类网络请求失败，请检查网络地址");
            }
        }

        /// <summary>
        /// 去除网页中的特殊字符
        /// </summary>
        /// <param name="content"></param>
        /// <param name="specialChar"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public string RemoveSpecialContent(string content, string pattern, string replaceContent)
        {
            try
            {
                content = Regex.Replace(content, pattern, replaceContent);
                return content;
            }
            catch
            {
                return content;

            }
        }
    }
}
