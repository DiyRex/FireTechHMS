using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.PeerResolvers;

namespace FireTechHMS.Assets
{
    internal class OverviewData
    {
        public int total_rooms;
        public string occupied_room;

        public static List<string> overViewDataListstring;
        public static List<int> overViewDataListint;
        public int staying()
        {
            DataTable dt = new DataTable();
            SQLiteConn conn = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `student`", conn.getConnection);
            da.Fill(dt);


            int styVal = dt.Rows.Count;
            return styVal;
        }

        public int staff()
        {

            DataTable de = new DataTable();
            SQLiteConn conn = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `staff`", conn.getConnection);
            da.Fill(de);

            int stfVal = de.Rows.Count;
            return stfVal;
        }

        public string getTotalRooms()
        {
            DataTable dr = new DataTable();
            SQLiteConn conn = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `config`", conn.getConnection);
            da.Fill(dr);

            total_rooms = int.Parse(dr.Rows[0]["ac_count"].ToString()) + int.Parse(dr.Rows[0]["non_ac_count"].ToString());
            string totalRoom = total_rooms.ToString();
            return totalRoom;
        }

        public string getOccupiedRooms()
        {
            DataTable df = new DataTable();
            SQLiteConn conn = new SQLiteConn();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM `rooms` WHERE occupied=1", conn.getConnection);
            da.Fill(df);
            occupied_room = df.Rows[0]["occupied"].ToString();
            string room_occupied = occupied_room;
            return room_occupied;
        }

        public int roomAvailable()
        {
            int occ = total_rooms - int.Parse(occupied_room);
            int roomavb = occ;
            return roomavb;
        }

       public void addtolist()
        {
            int stVal = staying();
            int stfVal = staff();
            string totRm = getTotalRooms();
            string ocRm = getOccupiedRooms();
            int avRm = roomAvailable();
            //overViewDataListstring.Add(totRm);
            //overViewDataListstring.Add(ocRm);
            //overViewDataListint.Add(stVal);
            //overViewDataListint.Add(stfVal);
            //overViewDataListint.Add(avRm);
        }
    }
}
