using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB db = new ConnectDB();
            SqlConnection conn = db.connect();
            if (conn != null)
            {
                BarcodeTSC objForm = new BarcodeTSC();
                this.Hide();
                objForm.Show();
            }
            else
            {
                MessageBox.Show("Connection Fail");
            }
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\connect.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);
                
                txtIP.Text = xx[0];
                txtDbName.Text = xx[1];
                txtUser.Text = xx[2];
                txtPassword.Text = xx[3];
                txtPort.Text = xx[4];
                
                buttonSave.Enabled = false;
                buttonConnect.Enabled = false;
            }
            catch
            {
                buttonSave.Enabled = false;
                buttonConnect.Enabled = false;
                Console.WriteLine("ไม่มีข้อมูล");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            string db = txtDbName.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;

            ConnectDB conndb = new ConnectDB();
            SqlConnection conn = conndb.testConnection(ip,db,user,password,port);
            try
            {
                string save = "Test Succeed";
                label_testConnectF.Text = "";
                label_Success.Text = save;
                conn.Close();
                buttonSave.Enabled = true;
                buttonConnect.Enabled = true;
            }
            catch
            {
                string fail = "Test Fail";
                label_Success.Text = "";
                label_testConnectF.Text = fail;
                buttonSave.Enabled = false;
                buttonConnect.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            string db = txtDbName.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;

            string[] lines = { ip, db, user, password, port };
            System.IO.File.WriteAllLines(@"C:\Users\Public\connect.txt", lines);
            Console.WriteLine("Save Lines" + lines);
            string save = "Save Succeed";
            la_Save.Text = save;
        }
    }
}
