using FireTechHMS.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Forms
{
    public partial class StudentReport : Form
    {
        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        PrintDocument prntdoc = new PrintDocument();
        public StudentReport()
        {
            InitializeComponent();
        }

        private void StudentReport_Load(object sender, EventArgs e)
        {
            string std_id = ""; //StudentsPanal.s_id;
            if (std_id != null)
            {
                SQLiteConn db = new SQLiteConn();
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter($"SELECT * FROM `student` WHERE Id={MainForm.s_id}", db.getConnection);
                da.Fill(dt);

                rplbl1.Text = dt.Rows[0]["Id"].ToString();
                rplbl2.Text = dt.Rows[0]["FirstName"].ToString();
                rplbl3.Text = dt.Rows[0]["LastName"].ToString();
                rplbl4.Text = dt.Rows[0]["Address"].ToString().Replace("\r\n", " ");
                rplbl5.Text = dt.Rows[0]["NIC"].ToString();

                DateTime Birthday = Convert.ToDateTime(dt.Rows[0]["Birthday"].ToString());
                rplbl6.Text = Birthday.ToShortDateString();

                string sex;
                if (dt.Rows[0]["Sex"].ToString() == "0")
                {
                    sex = "Male";
                }
                else if (dt.Rows[0]["Sex"].ToString() == "1")
                {
                    sex = "Female";
                }
                else
                {
                    sex = "Other";
                }
                rplbl7.Text = sex;

                rplbl8.Text = dt.Rows[0]["ContactNumber"].ToString();
                rplbl9.Text = dt.Rows[0]["Email"].ToString();
                rplbl10.Text = dt.Rows[0]["GrdFirstName"].ToString();
                rplbl11.Text = dt.Rows[0]["GrdLastName"].ToString();
                rplbl12.Text = dt.Rows[0]["GrdContactNumber"].ToString();
                rplbl13.Text = dt.Rows[0]["GrdNIC"].ToString();

                DateTime AddedDate = Convert.ToDateTime(dt.Rows[0]["AddedAt"].ToString());
                rplbl14.Text = AddedDate.ToShortDateString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.reportpanel);
        }
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            reportpanel = pnl;
            getprintarea(pnl);
            prntprvw.Document = prntdoc;
            prntdoc.PrintPage += new PrintPageEventHandler(prntdoc_printpage);
            prntprvw.ShowDialog();

        }

        public void prntdoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.reportpanel.Width / 2), this.reportpanel.Location.Y);
        }
        Bitmap memoryimg;
        public void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width * 4, pnl.Height));
        }
    }
}
