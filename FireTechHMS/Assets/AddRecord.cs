using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FireTechHMS.Assets
{
    internal class AddRecord
    {
        public static int addStudent(string FirstName, string LastName, string Address, string NIC, string Birthday, int Sex, string ContactNumber, string Email, string GrdFirstName, string GrdLastName, string GrdContactNumber, string GrdNIC)
        {
            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"INSERT INTO `student` (`Id`, `FirstName`, `LastName`, `Address`, `NIC`, `Birthday`, `Sex`, `ContactNumber`, `Email`, `GrdFirstName`, `GrdLastName`, `GrdContactNumber`, `GrdNIC`,`AddedAt`)
                VALUES 
                (
                 NULL,
                @FstName,
                @LstName,
                @Address,
                @NIC,
                @Birthday,
                @Sex,
                @ContactNumber,
                @Email,
                @GrdFirstName,
                @GrdLastName,
                @GrdContactNumber,
                @GrdNIC,
                @AddedAt
                );";
            DateTime p = DateTime.Now;
            string endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@FstName", FirstName);
            command.Parameters.AddWithValue("@LstName", LastName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@NIC", NIC);
            command.Parameters.AddWithValue("@Birthday", Birthday);
            command.Parameters.AddWithValue("@Sex", Sex);
            command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@GrdFirstName", GrdFirstName);
            command.Parameters.AddWithValue("@GrdLastName", GrdLastName);
            command.Parameters.AddWithValue("@GrdContactNumber", GrdContactNumber);
            command.Parameters.AddWithValue("@GrdNIC", GrdNIC);
            command.Parameters.AddWithValue("@AddedAt", endDate);
            int sts = command.ExecuteNonQuery();
            
            conn.closeConnection();
            if (sts == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static int addRoom(string condition, string bedCount)
        {
            int getCondition(string rcondition)
            {
                if(rcondition == "AC")
                {
                    return 0;

                }else
                {
                    return 1;
                }
            }
            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"INSERT INTO `rooms` (`room_id`, `room_condition`, `bed_count`, `occupied`, `added`)
                VALUES 
                (
                 NULL,
                @condition,
                @bedCount,
                @occupied,
                @added);";

            DateTime p = DateTime.Now;
            string endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@condition", getCondition(condition).ToString());
            command.Parameters.AddWithValue("@bedCount",bedCount);
            command.Parameters.AddWithValue("@occupied", "1");
            command.Parameters.AddWithValue("@added", endDate);
            int sts = command.ExecuteNonQuery();

            conn.closeConnection();
            if (sts == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


        public static int addService(string FirstName, string LastName, string Address, string NIC, string role, string ContactNumber)
        {
            int getRole(string s_role)
            {
                switch (s_role)
                {
                    case "Warden":
                        return 1;
                    case "Cleaner":
                        return 2;
                    case "Supervisor":
                        return 3;
                    case "Cook":
                        return 4;
                    case "Security":
                        return 5;
                    default: return 0;
                }
            }
            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"INSERT INTO `staff` (`staff_id`, `firstname`, `lastname`, `address`, `nic`, `contact`, `role`, `added_at`)
                VALUES 
                (
                 NULL,
                @FstName,
                @LstName,
                @Address,
                @NIC,
                @ContactNumber,
                @role,
                @AddedAt
                );";
            DateTime p = DateTime.Now;
            string endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@FstName", FirstName);
            command.Parameters.AddWithValue("@LstName", LastName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@NIC", NIC);
            command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            command.Parameters.AddWithValue("@role", getRole(role).ToString());
            command.Parameters.AddWithValue("@AddedAt", endDate);
            int sts = command.ExecuteNonQuery();

            conn.closeConnection();
            if (sts == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}
