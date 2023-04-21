using FireTechHMS.Assets;
using FireTechHMS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS
{
    public partial class MainForm : Form
    {
        public static string s_id;
        public static string r_id;
        public static string r_sts;  // testing
        public static int add_sts;
        public static int up_sts;
        public static int roomAdd_sts;
        public static int roomUp_sts;

        public MainForm()
        {
            InitializeComponent();
        }
        private void setStatus(int stVal, int stfVal, string totRm, string ocRm, int avRm)
        {
            room_total.Text = totRm;
            room_occupied.Text = ocRm;
            lblroomav.Text = avRm.ToString();
            lblstaff.Text = stfVal.ToString();
            lblstd.Text = stVal.ToString();
        }

        //// overview
        private void updatePanel()
        {
            OverviewData OD = new OverviewData();
            int stVal = OD.staying();
            int stfVal = OD.staff();
            string totRm = OD.getTotalRooms();
            string ocRm = OD.getOccupiedRooms();
            int avRm = OD.roomAvailable();
            setStatus(stVal, stfVal, totRm, ocRm, avRm);
        }
        //
        //// std panel
        public void addStd()
        {
            string getBirthday(string birthday)
            {
                string parsed_bday = birthday;
                string Bday = DateTime.Parse(birthday).ToString("yyyy-MM-dd");
                return Bday;
            }

            string ssex="";
            this.bunifuDataGridView1.DataSource = null;
            this.bunifuDataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            SQLiteConn db = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `student`", db.getConnection);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["sex"])
                {
                    case 0:
                        ssex = "Male";
                        break;
                    case 1:
                        ssex = "Female";
                        break;
                    case 2:
                        ssex = "Other";
                        break;
                }

                // bunifuDataGridView1.Rows.Add(dr.ItemArray);
                bunifuDataGridView1.Rows.Add(dr["Id"], dr["FirstName"], dr["LastName"], dr["Address"], dr["NIC"], getBirthday(dr[5].ToString()), ssex, dr["ContactNumber"], dr["Email"]);

            }
        }
        //
        // room panel
        public string room = "";
        public string stats = "";
        public void addRoomData()
        {
            this.RoomGrid.DataSource = null;
            this.RoomGrid.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            SQLiteConn db = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `rooms`", db.getConnection);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["room_condition"].ToString() == "1")
                {
                    room = "AC";
                }
                else if (dr["room_condition"].ToString() == "0")
                {
                    room = "Non AC";
                }

                if (dr["occupied"].ToString() == "0")
                {
                    stats = "Occupied";
                }
                else if (dr["occupied"].ToString() == "1")
                {
                    stats = "Available";
                }

                RoomGrid.Rows.Add(dr["room_id"], room, dr["bed_count"], stats);

            }
        }
        //
        // add staff data
        public string role = "";
        public void addstaff()
        {
            this.servicegrid.DataSource = null;
            this.servicegrid.Rows.Clear();
            DataTable dp = new DataTable();
            dp.Rows.Clear();
            SQLiteConn db = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `staff`", db.getConnection);
            da.Fill(dp);
            foreach (DataRow dr in dp.Rows)
            {
                if (dr["role"].ToString() == "0")
                {
                    role = "Warden";
                }
                else if (dr["role"].ToString() == "1")
                {
                    role = "Supervisor";
                }
                else if (dr["role"].ToString() == "2")
                {
                    role = "Assistant";
                }
                else if (dr["role"].ToString() == "3")
                {
                    role = "Cleaner";
                }
                else if (dr["role"].ToString() == "4")
                {
                    role = "Cook";
                }
                else if (dr["role"].ToString() == "5")
                {
                    role = "Security";
                }


                servicegrid.Rows.Add(dr["staff_id"],dr["firstName"], role, dr["contact"]);

            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            updatePanel();
            dashboardbox.Refresh();
            this.dashboardbox.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e) /// overview
        {
            updatePanel();
            OverviewData OverviewData = new OverviewData();
            OverviewData.addtolist();
            this.dashboardbox.Show();
            this.dashboardbox.BringToFront();
            this.stdbox.Hide();
            this.roombox.Hide();
            this.servicebox.Hide();

        }

        private void btnStudents_Click(object sender, EventArgs e)  /// std panel
        {
            addStd();
            this.stdbox.Show();
            this.stdbox.BringToFront();
            this.dashboardbox.Hide();
            this.roombox.Hide();
            this.servicebox.Hide();

        }
        private void btnProfile_Click_1(object sender, EventArgs e)  /// std panel
        {
            s_id = $"{bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()}";
            if (s_id != null)
            {
                
                var report = new StudentReport();
                report.Show();
            }
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)   /// std panel
        {
            s_id = $"{bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()}";
            if (s_id != null)
            {
                StudentUpdate upstd = new StudentUpdate();
                upstd.ShowDialog();
                if (up_sts == 1)
                {
                    addStd();
                    up_sts = 0;
                }
            }
            
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            addRoomData();
            this.roombox.Show();
            this.roombox.BringToFront();
            this.dashboardbox.Hide();
            this.stdbox.Hide();
            this.servicebox.Hide();

            // testing
            r_sts = $"{RoomGrid.CurrentRow.Cells[3].Value.ToString()}";
            if (r_sts == "Available")
            {
                btnavailable.Text = "ADD";
                btnavailable.BackColor1 = Color.Green;
            }
            else
            {
                btnavailable.Text = "REMOVE";
                btnavailable.BackColor1 = Color.Crimson;
            }
            //
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            new SendMail().Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new ConfigPanel().Show();
        }

        private void bunifuGroupBox1_MouseHover(object sender, EventArgs e)
        {
            updatePanel();
            OverviewData OverviewData = new OverviewData();
            OverviewData.addtolist();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            this.servicebox.Show();
            this.roombox.Hide();
            this.servicebox.BringToFront();
            this.dashboardbox.Hide();
            this.stdbox.Hide();
            addstaff();
            
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            this.servicebox.Hide();
            this.roombox.Hide();
            this.servicebox.BringToFront();
            this.dashboardbox.Hide();
            this.stdbox.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddStudent().ShowDialog();
            if (add_sts == 1)
            {
                addStd();
                add_sts = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            s_id = $"{bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()}";
            if (s_id != null)
            {
                int sts = DeleteRecord.DeleteStudent(s_id);
                if (sts == 1)
                {
                    new MessageContainer("Student Record Deleted").Show();
                    addStd();
                }
                else if (sts == 0)
                {
                    new MessageContainer("Failed To Remove").Show();
                }
            }
            
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            addRoom.ShowDialog();
            if (roomAdd_sts == 1)
            {
                addRoomData();
                roomAdd_sts = 0;
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            r_id = $"{RoomGrid.CurrentRow.Cells[0].Value.ToString()}";
            if (r_id != null)
            {
               new RoomUpdate().ShowDialog();
                if (roomUp_sts == 1)
                {
                    addRoomData();
                    roomAdd_sts = 0;
                }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            r_id = $"{RoomGrid.CurrentRow.Cells[0].Value.ToString()}";
            if (r_id != null)
            {
                int dsts = DeleteRecord.Delete(id:r_id, table:"rooms", idField:"room_id");

                if (dsts == 1)
                {
                    new MessageContainer("Room Record Deleted !").Show();
                }
                else
                {
                    new MessageContainer("Something Went Wrong").Show();
                }
            }
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnavailable_Click(object sender, EventArgs e)
        {
            r_sts = $"{RoomGrid.CurrentRow.Cells[3].Value.ToString()}";
           
            r_id = $"{RoomGrid.CurrentRow.Cells[0].Value.ToString()}";
            if (r_sts == "Available")
            {
                btnavailable.Text = "ADD";
                btnavailable.BackColor1 = Color.Green;
                int p = UpdateRecord.UpdateRoomStatus(roomID:r_id, available:"0");
                if (p == 1)
                {
                    //MessageBox.Show("set full");
                    addRoomData();
                }
            }
            else
            {
                btnavailable.Text = "REMOVE";
                btnavailable.BackColor1 = Color.Crimson;
                int p = UpdateRecord.UpdateRoomStatus(roomID: r_id, available: "1");
                if (p == 1)
                {
                    //MessageBox.Show("set empty");
                    addRoomData();
                }
            }
        }

        private void RoomGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void RoomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                r_sts = $"{RoomGrid.CurrentRow.Cells[3].Value.ToString()}";

                r_id = $"{RoomGrid.CurrentRow.Cells[0].Value.ToString()}";
                if (r_sts == "Available")
                {
                    btnavailable.Text = "ADD";
                    btnavailable.BackColor1 = Color.Green;
                }
                else
                {
                    btnavailable.Text = "REMOVE";
                    btnavailable.BackColor1 = Color.Crimson;
                }
            }
        }

        
    }
}
