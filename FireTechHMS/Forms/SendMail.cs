using FireTechHMS.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Forms
{
    public partial class SendMail : Form
    {
        private string[] smtp = new string[5];
        public SendMail()
        {
            InitializeComponent();
        }

        private void samplemail()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("firetechms", "qnosxuvlcbernefq"),
                EnableSsl = true,

            };

            smtpClient.Send("firetechms@gmail.com", "dsdissanayaka2002@gmail.com", "test mail 2 ", "this is test mail 2");
        }

        private int captureSmtp()
        {
            SQLiteConn conn = new SQLiteConn();
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `config`", conn.getConnection);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                smtp[0] = dt.Rows[0]["smtp_mail"].ToString();
                smtp[1] = dt.Rows[0]["smtp_password"].ToString();
                smtp[2] = dt.Rows[0]["smtp_port"].ToString();
                smtp[3] = dt.Rows[0]["mail_sender"].ToString();
                MailAddress addr = new MailAddress(smtp[3]);
                smtp[4] = addr.User;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void sendMail(string[] usmtp, string receiver, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Host = usmtp[0];
            client.Port = int.Parse(usmtp[2]);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(usmtp[4], usmtp[1]);
            client.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.To.Add(receiver);
            message.From = new MailAddress(usmtp[3]);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            client.Send(message);
        }

        private void SendMail_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            string receiver = tbreceiver.Text;
            string subject = tbsubject.Text;
            string body = tbbody.Text;

            if (captureSmtp() == 1)
            {
                try
                {
                    sendMail(smtp, receiver, subject, body);
                    MessageContainer msg = new MessageContainer("Email Sent Successfully !");
                    msg.Show();
                }
                catch
                {
                    MessageContainer msg = new MessageContainer("Failed To Send Email !");
                    msg.Show();
                }

            }
        }
    }
}
