using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeautyProject.Dao.Common
{
    public class PageData
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public int PageCount
        {
            get
            {
                if (Total % PageSize == 0)
                {
                    return Total / PageSize;
                }
                else
                {
                    return ((int)(Total / PageSize)) + 1;
                }
            }
        }

        public object Result { get; set; }
    }
}
