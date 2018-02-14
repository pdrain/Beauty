using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.Collector
{
    public class HMNCollecotr
    {
        private static HMNCollecotr _instance;
        private static object _lock = new object();
        public static HMNCollecotr Instance
        {

            get
            {
                if (_instance == null) {
                    lock (_lock) {
                        if (_instance == null) {
                            _instance = new HMNCollecotr();

                        }
                    }
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }

        }

        public void Collect()
        {
            CatalogRobots catalogRobots = new CatalogRobots();
            catalogRobots.DoRobot(Config.CatalogPath);
        }

    }
}
