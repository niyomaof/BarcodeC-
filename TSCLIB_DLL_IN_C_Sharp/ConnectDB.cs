using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCLIB_DLL_IN_C_Sharp
{
    class ConnectDB
    {
        public SqlConnection testConnection(string host, string db, string user, string password, string port)
        {
            try
            {
                string connetionString = @"Data Source=" + host.Trim() + "," + port.Trim() + ";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + password.Trim() + "";
                SqlConnection conn = new SqlConnection(connetionString);
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }

        }
        public SqlConnection connect()
        {
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\connect.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);

                string connetionString = @"Data Source=" + xx[0].Trim() + "," + xx[4].Trim() + ";Initial Catalog=" + xx[1].Trim() + ";User ID=" + xx[2].Trim() + ";Password=" + xx[3].Trim() + "";
                SqlConnection conn = new SqlConnection(connetionString);
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }

        }
    }
}
