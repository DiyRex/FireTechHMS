using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTechHMS.Assets
{
    internal class UpdateRecord
    {
        private static int getSex(string Sex)
        {
            int isex = 0;
            if (Sex == "Male")
            {
                isex = 0;
            }
            else if (Sex == "Female")
            {
                isex = 1;
            }
            else if (Sex == "Other")
            {
                isex = 2;
            }
            return isex;
        }
        public static int UpdateStudent(string FirstName, string LastName, string Address, string NIC, string Birthday, string Sex, string ContactNumber, string Email, string GrdFirstName, string GrdLastName, string GrdContactNumber, string GrdNIC, string stid)
        {
            

            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"UPDATE `student` SET 
                                        `FirstName`=@FirstName, 
                                        `LastName`=@LastName, 
                                        `Address`=@Address, 
                                        `NIC`=@NIC, 
                                        `Birthday`=@Birthday, 
                                        `Sex`=@Sex, 
                                        `ContactNumber`=@ContactNumber, 
                                        `Email`=@Email, 
                                        `GrdFirstName`=@GrdFirstName, 
                                        `GrdLastName`=@GrdLastName,
                                        `GrdContactNumber`=@GrdContactNumber, 
                                        `GrdNIC`=@GrdNIC 
                                        WHERE `Id`=@std_id;";

            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@NIC", NIC);
            command.Parameters.AddWithValue("@Birthday", Birthday);
            command.Parameters.AddWithValue("@Sex", getSex(Sex));
            command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@GrdFirstName", GrdFirstName);
            command.Parameters.AddWithValue("@GrdLastName", GrdLastName);
            command.Parameters.AddWithValue("@GrdContactNumber", GrdContactNumber);
            command.Parameters.AddWithValue("@GrdNIC", GrdNIC);
            command.Parameters.AddWithValue("@std_id", stid);
            int st = command.ExecuteNonQuery();
            conn.closeConnection();
            return st;

        }

        public static int UpdateRoom(string condition, string bdcount, string roomID )
        {


            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"UPDATE `rooms` SET 
                                        `room_condition`=@room_condition, 
                                        `bed_count`=@bed_count
                                        WHERE `room_id`=@room_id;";

            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@room_condition", condition);
            command.Parameters.AddWithValue("@bed_count", bdcount);
            command.Parameters.AddWithValue("@room_id", roomID);
            int rt = command.ExecuteNonQuery();
            conn.closeConnection();
            return rt;

        }

        public static int UpdateRoomStatus(string available, string roomID)
        {

            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"UPDATE `rooms` SET 
                                        `occupied`=@status 
                                        WHERE `room_id`=@room_id;";

            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@status", available);
            command.Parameters.AddWithValue("@room_id", roomID);
            int rt = command.ExecuteNonQuery();
            conn.closeConnection();
            return rt;

        }

    }
}
