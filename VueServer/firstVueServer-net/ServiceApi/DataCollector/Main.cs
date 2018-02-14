using DataCollector.Collector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnStartCollect_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(StartCollect);
            thread.Start();
        }

        private void StartCollect()
        {
            HMNCollecotr.Instance.Collect();
        }




    }
}
