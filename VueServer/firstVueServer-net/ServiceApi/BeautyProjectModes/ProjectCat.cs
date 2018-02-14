using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyProjectModes
{
    public class ProjectCat
    {
        public int ID { get; set; }

        public string Guid { get; set; }

        public string ParentGuid { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int DisplayOrder { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public int ComplexRate { get; set; }

        public int SafetyRate { get; set; }

        public int FocusRate { get; set; }
    }
}
