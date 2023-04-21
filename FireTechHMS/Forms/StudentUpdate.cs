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
    public partial class StudentUpdate : Form
    {
        public StudentUpdate()
        {
            InitializeComponent();
        }

        private void StudentUpdate_Load(object sender, EventArgs e)
        {
            if(MainForm.s_id != null)
            {
                List<string> student = ReadRecord.getStudentById(MainForm.s_id);
                addfname.Text = student[1];
                addlname.Text = student[2];
                addaddress.Text = student[3];
                addnic.Text = student[4];
                addbirthday.Value = DateTime.Parse(student[5]);
                addsex.Text = student[6];
                addcontact.Text = student[7];
                addemail.Text = student[8];
                addgrdfname.Text = student[9];
                addgrdlaname.Text = student[10];
                addgrdcontact.Text = student[11];
                addgrdnic.Text = student[12];
            }
        }

        private void btnUpdateStd_Click(object sender, EventArgs e)
        {
            string first_name = addfname.Text;
            string last_name = addlname.Text;
            string address = addaddress.Text;
            string nic = addnic.Text;
            string birthday = addbirthday.Value.ToString("yyyy-MM-dd");
            string sex = addsex.Text;
            string contact = addcontact.Text;
            string email = addemail.Text;
            string grd_first_name = addgrdfname.Text;
            string grd_last_name = addgrdlaname.Text;
            string grd_contact = addgrdcontact.Text;
            string grd_nic = addgrdnic.Text;

            int sts = UpdateRecord.UpdateStudent(first_name, last_name, address, nic, birthday, sex, contact, email, grd_first_name, grd_last_name, grd_contact, grd_nic, MainForm.s_id);

            if (sts == 1)
            {
                MainForm.up_sts = 1;
                new MessageContainer("Student Updated Successfully !").Show();
            }
            else
            {
                new MessageContainer("Something Went Wrong !").Show();

            }

        }
    }
}
