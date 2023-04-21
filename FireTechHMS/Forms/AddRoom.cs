using FireTechHMS.Assets;
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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void btnaddRoom_Click(object sender, EventArgs e)
        {
            string roomcond = condition.Text;
            string roombedcnd = bdCount.Text;
            int sts = AddRecord.addRoom(roomcond, roombedcnd);

            if (sts == 1)
            {
                MainForm.roomAdd_sts = 1;
                new MessageContainer("Room Added Successfully !").Show();
            }
            else if (sts == 0)
            {
                new MessageContainer("Something Went Wrong").Show();

            }
        }
    }
}
