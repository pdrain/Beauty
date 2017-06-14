using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Models
{
    public class ProjectCat
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string IconClass { get; set; }

        public int DisplayOrder { get; set; }
    }
}