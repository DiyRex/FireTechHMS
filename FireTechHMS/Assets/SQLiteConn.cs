using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTechHMS.Assets
{
    internal class SQLiteConn
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=../Database/hms_db.db; Version = 3; New = True; Compress = True; ");

        // Data Source=D:\\Projects\\C#\\Visual Studio\\Databases\\hms_db.db; Version = 3; New = True; Compress = True; 

        public SQLiteConnection getConnection
        {
            get
            {
                return conn;
            }
        }

        // create a function to open the connection
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // create a function to close the connection
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
