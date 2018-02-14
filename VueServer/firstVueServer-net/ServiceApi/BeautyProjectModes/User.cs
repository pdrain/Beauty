using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProjectModes
{
   public class User
    {
       public long ID { get; set; }

       public string SalesOpenID { get; set; }

       public string OpenId { get; set; }

       public string UserHeadImg { get; set; }

       public string Account { get; set; }

       public string PassWord { get; set; }

       public DateTime RegDate { get; set; }

       public Nullable<DateTime> LastLoginTime { get; set; }

       public int TitleType { get; set; }

       public long ParentId { get; set; }

       public long UpdateUser { get; set; }

       public Nullable<DateTime> UpdateTime { get; set; }

    }
}
