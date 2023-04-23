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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void btnaddStd_Click(object sender, EventArgs e)
        {
            string first_name = this.addfname.Text;
            string last_name = this.addlname.Text;
            string address = this.addaddress.Text;
            string nic = this.addnic.Text;
            string contact = this.addcontact.Text;
            string role = this.addrole.Text;

            if (first_name != "" && last_name != "" && address != "" && nic != "" && contact != "" && role != "")
            {
                int st = AddRecord.addService(FirstName:first_name, LastName:last_name, Address:address, NIC:nic, ContactNumber:contact, role:role);
                if (st == 1)
                {
                    new MessageContainer("Service Added Successfully !").Show();
                    MainForm.srvAdd_sts = 1;
                }
                else 
                {
                    new MessageContainer("Failed To Add Record !").Show();
                }
            }
            else
            {
                new MessageContainer("Fill all fields").Show();
            }
        }
    }
}
