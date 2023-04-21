using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTechHMS.Assets
{
    internal class Config
    {
        public static string HostelName { get; set; }
        public static string AuthKey { get; set; }
        public static int ACRoomRent { get; set; }
        public static int NonACRoomRent { get; set; }
        public static int ACRoomCount { get; set; }
        public static int NonACRoomCount { get; set; }
        public static string Sender_email { get; set; }
        public static string SMTP_Mail { get; set; }
        public static string SMTP_Password { get; set; }
        public static int SMTP_Port { get; set; }
        public static int MAX_Student_Count { get; set; }
        public static int MAX_Room_Count { get; set; }
        public static int KeyMoney { get; set; }

        //public static string[] configData = new string [10];

        public static List<string> getConfigurations()
        {
            List<string> cfg = new List<string>();
            SQLiteConn conn = new SQLiteConn();
            DataTable df = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `config`", conn.getConnection);
            da.Fill(df);
            HostelName = df.Rows[0]["hostel_name"].ToString();
            KeyMoney = int.Parse(df.Rows[0]["keymoney"].ToString());
            AuthKey = df.Rows[0]["auth_key"].ToString();
            ACRoomRent = int.Parse(df.Rows[0]["ac_rent"].ToString());
            NonACRoomRent = int.Parse(df.Rows[0]["non_ac_rent"].ToString());
            ACRoomCount = int.Parse(df.Rows[0]["ac_count"].ToString());
            NonACRoomCount = int.Parse(df.Rows[0]["non_ac_count"].ToString());
            Sender_email = df.Rows[0]["mail_sender"].ToString();
            SMTP_Mail = df.Rows[0]["smtp_mail"].ToString();
            SMTP_Password = df.Rows[0]["smtp_password"].ToString();
            SMTP_Port = int.Parse(df.Rows[0]["smtp_port"].ToString());
            MAX_Student_Count = int.Parse(df.Rows[0]["max_student_count"].ToString());
            MAX_Room_Count = int.Parse(df.Rows[0]["max_bedroom_count"].ToString());

            cfg.Add(KeyMoney.ToString());
            cfg.Add(AuthKey);
            cfg.Add(ACRoomRent.ToString());
            cfg.Add(NonACRoomRent.ToString());
            cfg.Add(NonACRoomCount.ToString());
            cfg.Add(ACRoomCount.ToString());
            cfg.Add(Sender_email);
            cfg.Add(SMTP_Mail);
            cfg.Add(SMTP_Password);
            cfg.Add(SMTP_Port.ToString());
            cfg.Add(HostelName);
            cfg.Add(MAX_Student_Count.ToString());
            cfg.Add(MAX_Room_Count.ToString());

            return cfg;
        }

        public static int updateConfigurations(string hostel_name, string keymoney, string auth_key, string ac_rent, string non_ac_rent, string ac_count, string non_ac_count, string smtp_mail, string smtp_port, string smtp_password, string hostel_mail, string max_std_count, string max_bed_count)
        {
            SQLiteConn conn = new SQLiteConn();
            //    //DataTable df = new DataTable();
            //    //SQLiteDataAdapter da = new SQLiteDataAdapter("UPDATE `config`SET `hostel_name`=@upname, `keymoney`=@uppwd, `auth_key`=@upage, `ac_rent`=@upemail, `non_ac_rent`=@uppwd, `ac_count`=@upage, `non_ac_count`=@upemail, `smtp_mail`=@uppwd, `smtp_port`=@upage, `smtp_password`=@upemail, `hostel_mail`=@upage, `max_std_count`=@upemail, `max_bed_count`=@upage WHERE `test_id`=@frmid", conn.getConnection);
            //    //DataTable dt = new DataTable();




            conn.openConnection();
            string update_str = @"UPDATE `config` SET 
                                        `keymoney`=@keymoney, 
                                        `auth_key`=@auth_key, 
                                        `ac_rent`=@ac_rent, 
                                        `non_ac_rent`=@non_ac_rent, 
                                        `non_ac_count`=@non_ac_count, 
                                        `ac_count`=@ac_count, 
                                        `mail_sender`=@mail_sender, 
                                        `smtp_mail`=@smtp_mail, 
                                        `smtp_password`=@smtp_password, 
                                        `smtp_port`=@smtp_port,
                                        `hostel_name`=@hostel_name, 
                                        `max_student_count`=@max_std_count, 
                                        `max_bedroom_count`=@max_bed_count 
                                        WHERE `config_id`=@config_id;";

            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@keymoney", int.Parse(keymoney));
            command.Parameters.AddWithValue("@auth_key", auth_key);
            command.Parameters.AddWithValue("@ac_rent", int.Parse(ac_rent));
            command.Parameters.AddWithValue("@non_ac_rent", int.Parse(non_ac_rent));
            command.Parameters.AddWithValue("@non_ac_count", int.Parse(non_ac_count));
            command.Parameters.AddWithValue("@ac_count", int.Parse(ac_count));
            command.Parameters.AddWithValue("@mail_sender", hostel_mail);
            command.Parameters.AddWithValue("@smtp_mail", smtp_mail);
            command.Parameters.AddWithValue("@smtp_password", smtp_password);
            command.Parameters.AddWithValue("@smtp_port", int.Parse(smtp_port));
            command.Parameters.AddWithValue("@hostel_name", hostel_name);
            command.Parameters.AddWithValue("@max_std_count", int.Parse(max_std_count));
            command.Parameters.AddWithValue("@max_bed_count", int.Parse(max_bed_count));
            command.Parameters.AddWithValue("@config_id", 1);
            command.ExecuteNonQuery();
            conn.closeConnection();
            return 1;

        }
    }
}
