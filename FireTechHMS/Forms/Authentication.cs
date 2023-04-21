using FireTechHMS.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Forms
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
            this.ActiveControl = username;
            username.Focus();
        }
        public object BunifuTextBox1 { get; private set; }
        public static string session_username { get; set; }

        private void loguser(string username, string password)
        {
            //DBConnection
            SQLiteConn db = new SQLiteConn();
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter($"SELECT * FROM `admin` WHERE username='{username}' AND password='{password}'", db.getConnection);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                session_username = username;
                this.DialogResult = DialogResult.OK;
                MainForm dashboard = new MainForm();
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }
        private void Authentication_Load(object sender, EventArgs e)
        {

        }

        private void bunifuToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            if (bunifuToggleSwitch21.Checked)
            {
                grpbox1.Visible = false;
            }
            else
            {
                grpbox1.Visible = true;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = bunifuTextBox2.Text;
            loguser(username, password);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            string email = tbemail.Text;
            string authkey = tbauthkey.Text;

            string verifiedKey = "FTHMS";

            if (authkey == verifiedKey)
            {
                //InsertData(username: username, password: password, email: email);
            }
            else { MessageBox.Show("Invalid AuthKey !!"); }
        }
    }
}
