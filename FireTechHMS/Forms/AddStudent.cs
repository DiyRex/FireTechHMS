using FireTechHMS.Assets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Forms
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnaddStd_Click(object sender, EventArgs e)
        {
            int isex=0;

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

            switch (sex)
            {
                case "Male":
                    isex = 0;
                    break;
                case "Female":
                    isex = 1;
                    break;
                case "Other":
                    isex = 2;
                    break;
            }

            int sts = AddRecord.addStudent(first_name,last_name,address,nic,birthday,isex,contact,email,grd_first_name,grd_last_name,grd_contact,grd_nic);

            if (sts == 1)
            {
                MainForm.add_sts = 1;
                new MessageContainer("Student Added Successfully !").Show();
            }
            else
            {
                new MessageContainer("Something Went Wrong !").Show();
                
            }

        }
    }
}
