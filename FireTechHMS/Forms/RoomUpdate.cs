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
    public partial class RoomUpdate : Form
    {
        public RoomUpdate()
        {
            InitializeComponent();
        }

        private string r_id;

        private void RoomUpdate_Load(object sender, EventArgs e)
        {
            r_id = MainForm.r_id;
            if (r_id != null)
            {
                List<string> roomData = ReadRecord.getRoomById(r_id);
                condition.Text = roomData[1];
                bdCount.Text = roomData[3];
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (condition.Text != null && bdCount.Text != null)
            {
                string newCondition = condition.Text;
                string newBdCount = bdCount.Text;
                int rt = UpdateRecord.UpdateRoom(condition:newCondition, bdcount:newBdCount, roomID:r_id);

                if (rt == 1)
                {
                    MainForm.roomUp_sts = 1;
                    new MessageContainer("Room Updated Successfully !").Show();
                }
                else
                {
                    new MessageContainer("Something Went Wrong").Show();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
