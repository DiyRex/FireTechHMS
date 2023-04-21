using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Forms
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            bunifuProgressBar1.Value = bunifuProgressBar1.Value + 2;
            if (bunifuProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                Authentication auth = new Authentication();
                auth.Show();
            }
        }
        private void splash_Load(object sender, EventArgs e)
        {

        }
    }
}
