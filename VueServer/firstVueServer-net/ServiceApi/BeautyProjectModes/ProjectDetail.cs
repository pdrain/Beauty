using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyProjectModes
{
    public class ProjectDetail
    {
        public int ID { get; set; }

        public string CatGuid { get; set; }

        public string ProjectContent { get; set; }

        public string Price { get; set; }

        public string ShouShu { get; set; }

        public string ShouShuWay { get; set; }

        public string ShouShuLiaoCheng { get; set; }

        public string ZhiLiao { get; set; }

        public string ZhiLiaoRenQun { get; set; }

        public string ZhiLiaoXiaoGuo { get; set; }

        public string ZhiLiaoShiChang { get; set; }

        public string KangFu { get; set; }

        public string ChaiXianShijian { get; set; }

        public string IsZhuYuan { get; set; }

        public string ShuHouXiuXi { get; set; }

        public string YouDian { get; set; }

        public string QuanDian { get; set; }

        public DateTime CreateTime { get; set; }

        public Nullable<DateTime> UpdateTime { get; set; }
    }
}
