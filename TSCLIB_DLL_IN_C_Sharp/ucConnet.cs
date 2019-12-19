using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Controls;


namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class ucConnet : Form
    {
        public ucConnet()
        {
            InitializeComponent();
        }

        private void showBarcode_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            string db = txtDB.Text;
            string user = txtUser.Text;
            string password = txtPassword.Text;

            string connetionString;
            SqlConnection cnn;
            
            connetionString = @"Data Source=" + ip + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + password + "";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();

            BarcodeTSC objForm = new BarcodeTSC();
            this.Hide();
            objForm.Show();
            


        }

        private void btuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
