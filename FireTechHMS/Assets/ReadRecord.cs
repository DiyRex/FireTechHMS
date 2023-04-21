using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireTechHMS.Assets
{
    internal class ReadRecord
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set;}
        public static string Title { get; set; }
        public static string Description { get; set; }
        public static string Author { get; set; }

        public static List<string> getStudentById(string id)
        {
            List<string> student = new List<string>();
            DataTable dt = new DataTable();
            SQLiteConn db = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter($"SELECT * FROM `student` WHERE Id={id}", db.getConnection);
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                DateTime Birthday = Convert.ToDateTime(dt.Rows[0]["Birthday"].ToString());
                DateTime AddedDate = Convert.ToDateTime(dt.Rows[0]["AddedAt"].ToString());

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
                student.Add(dt.Rows[0]["Id"].ToString());
                student.Add(dt.Rows[0]["FirstName"].ToString());
                student.Add(dt.Rows[0]["LastName"].ToString());
                student.Add(dt.Rows[0]["Address"].ToString());
                student.Add(dt.Rows[0]["NIC"].ToString());
                student.Add(Birthday.ToShortDateString());
                student.Add(sex);
                student.Add(dt.Rows[0]["ContactNumber"].ToString());
                student.Add(dt.Rows[0]["Email"].ToString());
                student.Add(dt.Rows[0]["GrdFirstName"].ToString());
                student.Add(dt.Rows[0]["GrdLastName"].ToString());
                student.Add(dt.Rows[0]["GrdContactNumber"].ToString());
                student.Add(dt.Rows[0]["GrdNIC"].ToString());
                student.Add(AddedDate.ToShortDateString());
            }


            return student;
        }

        public static List<string> getRoomById(string id)
        {
            string getRoomStatus(string sts)
            {
                if(sts == "1")
                {
                    return "Occupied";
                }
                else
                {
                    return "Available";
                }
            }

            string roomCondition(string cond)
            {
                if (cond == "1")
                {
                    return "AC";
                }
                else
                {
                    return "Non AC";
                }
            }
            List<string> room = new List<string>();
            DataTable dt = new DataTable();
            SQLiteConn db = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter($"SELECT * FROM `rooms` WHERE room_id={id}", db.getConnection);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DateTime AddedDate = Convert.ToDateTime(dt.Rows[0]["added"].ToString());

           
                room.Add(dt.Rows[0]["room_id"].ToString());
                room.Add(roomCondition(dt.Rows[0]["room_condition"].ToString()));
                room.Add(getRoomStatus(dt.Rows[0]["occupied"].ToString()));
                room.Add(dt.Rows[0]["bed_count"].ToString());
                room.Add(AddedDate.ToShortDateString());
            }


            return room;
        }

    }
}
