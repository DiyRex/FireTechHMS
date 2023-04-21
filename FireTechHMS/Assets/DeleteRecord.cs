using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FireTechHMS.Assets
{
    internal class DeleteRecord
    {
        public static int DeleteStudent(string id)
        {
            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = @"DELETE FROM `student` WHERE Id=@id;";
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@id", id);
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

        public static int Delete(string id, string table, string idField)
        {
            SQLiteConn conn = new SQLiteConn();
            conn.openConnection();
            string update_str = $@"DELETE FROM `{table}` WHERE {idField}=@id;";
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = conn.getConnection;
            command.CommandText = update_str;
            command.Parameters.AddWithValue("@id", id);
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
