using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BeautyProjectModes;
using BeautyProject.Dao;

namespace DataCollector.Collector
{
    public class CatalogRobots : Robots
    {
        private ProjectDao _projectCatDao = new ProjectDao();
        public override void DoRobot(string path)
        {
            List<ProjectCat> projectCats = new List<ProjectCat>();
            List<ProjectDetail> projectDetails = new List<ProjectDetail>();

            //网页原始数据
            string pageData = this.FetchData(path);

            pageData = this.RemoveChangeLineAndEmptySpace(pageData);
            if (string.IsNullOrEmpty(pageData))
            {
                throw new Exception("读取网页数据失败。URL:" + path);
            }


            //提取根目录
            ExtractRootCatalogs(pageData, ref projectCats, ref projectDetails);



            // 先删除历史数据
            _projectCatDao.ClearData();

            // 插入新的数据
            projectCats.ForEach(c =>
            {
                _projectCatDao.Insert(c);
            });

           

            // 插入新的数据
            projectDetails.ForEach(c =>
            {
                c.CreateTime = DateTime.Now;
                _projectCatDao.InsertDetail(c);
            });


        }

        private void ExtractRootCatalogs(string pageData, ref List<ProjectCat> projectCats, ref List<ProjectDetail> projectDetails)
        {
            List<string> roots = new List<string>();
            string reg = "<liclass=\"li-table\"(.*?)<\\/li>";

            MatchCollection matchs = Regex.Matches(pageData, reg, RegexOptions.Multiline);


            foreach (var match in matchs)
            {

                var content = match.ToString();
                if (string.IsNullOrEmpty(content)) continue;

                //提取根目录
                ExtractFirstLeverCat(content, ref projectCats, ref projectDetails);
            }


        }

        private void ExtractFirstLeverCat(string content, ref List<ProjectCat> projectCats, ref List<ProjectDetail> projectDetails)
        {
            string guid = Guid.NewGuid().ToString();

            string reg = "<divclass=\"part-text\">(.*?)<\\/div>";
            Match rootCatalog = Regex.Match(content, reg, RegexOptions.IgnoreCase);

            var value = rootCatalog.Groups[1].Value;
            if (string.IsNullOrEmpty(value)) guid = string.Empty;

            var projectCat = new ProjectCat();
            projectCat.Guid = guid;
            projectCat.Name = value;
            projectCats.Add(projectCat);


            //提取下一级目录
            ExtractSecondLeverCat(guid, content, ref projectCats, ref projectDetails);


        }

        private void ExtractSecondLeverCat(string firstCatGuid, string content, ref List<ProjectCat> projectCats, ref List<ProjectDetail> projectDetails)
        {


            string reg = "<divclass=\"cont-tr\">(.*?)<\\/div><\\/div><\\/div><\\/div><\\/span><\\/a><\\/div><\\/div>";
            MatchCollection secondLeverMatchs = Regex.Matches(content, reg, RegexOptions.Multiline);
            foreach (var match in secondLeverMatchs)
            {
                var secondLeverContent = match.ToString();
                if (string.IsNullOrEmpty(content)) continue;

                Match secondCatalog = Regex.Match(secondLeverContent, "<atarget=\"_blank\"href=\"\\/\\/www.yuemei.com\\/.*?/\">(.*?)<\\/a>", RegexOptions.IgnoreCase);
                var value = secondCatalog.Groups[1].Value;
                if (string.IsNullOrEmpty(value)) continue;

                string guid = Guid.NewGuid().ToString();

                var projectCat = new ProjectCat();
                projectCat.Guid = guid;
                projectCat.ParentGuid = firstCatGuid;
                projectCat.Name = value;
                projectCats.Add(projectCat);

                //提取项目
                ExtractThirdLeverCat(guid, secondLeverContent, ref projectCats, ref projectDetails);
            }

        }

        private void ExtractThirdLeverCat(string secondGuid, string content, ref List<ProjectCat> projectCats, ref List<ProjectDetail> projectDetails)
        {


            string reg = "<divclass=\"lefttr-text\">(.*?)<\\/div>";
            MatchCollection secondLeverMatchs = Regex.Matches(content, reg, RegexOptions.Multiline);
            foreach (var match in secondLeverMatchs)
            {
                var secondLeverContent = match.ToString();
                if (string.IsNullOrEmpty(content)) continue;

                Match secondCatalog = Regex.Match(secondLeverContent, "<atarget=\"_blank\"href=\"(.*?)\"><span><i>(.*?)<\\/i>", RegexOptions.IgnoreCase);
                var value = secondCatalog.Groups[2].Value;
                if (string.IsNullOrEmpty(value)) continue;

                string guid = Guid.NewGuid().ToString();

                var projectCat = new ProjectCat();
                projectCat.Guid = guid;
                projectCat.ParentGuid = secondGuid;
                projectCat.Name = value;
                projectCats.Add(projectCat);

                // 提取项目详情
                string path = secondCatalog.Groups[1].Value;
                var detail = ExtractProjectDetail(guid, path);
                if (detail != null)
                {
                    detail.CatGuid = guid;
                    projectDetails.Add(detail);
                }
            }

        }

        private ProjectDetail ExtractProjectDetail(string thirdGuid, string path)
        {
            string guid = Guid.NewGuid().ToString();

            //网页原始数据
            string detailInfo = this.FetchData("http:" + path);
            detailInfo = this.RemoveChangeLineAndEmptySpace(detailInfo);

            if (string.IsNullOrEmpty(detailInfo))
            {
                throw new Exception("读取网页数据失败。URL:" + path);
            }


            // 
            string reg = "<divclass=\"detailFile\">(.*?)<\\/div><pclass=\"media-tittit-logclearfix\">";

            Match match = Regex.Match(detailInfo, reg);
            var value = match.Groups[1].Value;
            if (string.IsNullOrEmpty(value)) return null;

            ProjectDetail projectDetail = new ProjectDetail();

            string descReg = "<pclass=\"info_1\">(.*?)<\\/p>";
            Match descMatch = Regex.Match(value, descReg);
            var desc = descMatch.Groups[1].Value;

            projectDetail.ProjectContent = desc;

            string dlReg = "<dl>(.*?)<\\/dl>";
            MatchCollection dlMaths = Regex.Matches(value, dlReg);
            foreach (var m in dlMaths)
            {
                var _dl = m.ToString();
                var title = Regex.Match(_dl, "<dt>(.*?)<\\/dt>").Groups[1].Value;
                if (title == "手术")
                {
                    projectDetail.ShouShu = title;
                }
                if (title == "康复")
                {
                    projectDetail.KangFu = title;
                }

                var shouShuInfo = Regex.Matches(_dl, "<p>(.*?)<\\/p>");
                foreach (var item in dlMaths)
                {
                    var p = item.ToString();
                    var name = Regex.Match(p, "<span>(.*?)<\\/span>").Groups[1].Value;
                    var val = Regex.Match(p, "<i>(.*?)<\\/i>").Groups[1].Value;
                    if (name == "技术手段")
                    {
                        projectDetail.ShouShuWay = val;
                    }
                    if (name == "疗程")
                    {
                        projectDetail.ShouShuLiaoCheng = val;
                    }
                    if (name == "拆线时间")
                    {
                        projectDetail.ChaiXianShijian = val;
                    }

                }
            }

            dlReg = "<dlclass=\"nofloat\">(.*?)<\\/dl>";
            dlMaths = Regex.Matches(value, dlReg);
            foreach (var m in dlMaths)
            {
                var _dl = m.ToString();
                projectDetail.ZhiLiao = Regex.Match(_dl, "<dt>(.*?)<\\/dt>").Groups[1].Value;
                var shouShuInfo = Regex.Matches(_dl, "<p>(.*?)<\\/p>");
                foreach (var item in shouShuInfo)
                {
                    var p = item.ToString();
                    var name = Regex.Match(p, "<span>(.*?)<\\/span>").Groups[1].Value;
                    var val = Regex.Match(p, "<i>(.*?)<\\/i>").Groups[1].Value;

                    if (name == "适宜人群")
                    {
                        projectDetail.ZhiLiaoRenQun = val;
                    }
                    if (name == "治疗时长")
                    {
                        projectDetail.ZhiLiaoShiChang = val;
                    }
                    if (name == "治疗效果")
                    {
                        projectDetail.ZhiLiaoXiaoGuo = val;
                    }
                }
            }


            return projectDetail;

        }

        //正则去换行符和空格
        private string RemoveChangeLineAndEmptySpace(string pageData)
        {
            //正则去换行符
            pageData = this.RemoveSpecialContent(pageData, "\n", "");
            //正则去退格符
            pageData = this.RemoveSpecialContent(pageData, "\t", "");
            //正则去空格
            pageData = this.RemoveSpecialContent(pageData, " ", "");

            return pageData;
        }
    }
}
