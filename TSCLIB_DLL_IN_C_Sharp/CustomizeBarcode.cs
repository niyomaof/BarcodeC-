using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class CustomizeBarcode : Form
    {
        public CustomizeBarcode()
        {
            InitializeComponent();
           
        }


        private void CustomizeBarcode_Load(object sender, EventArgs e)
        {
            
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\setting.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);
                string bar2 = xx[0];
                int int2 = int.Parse(bar2);
                /// สองดวงใหญ่ ///
                if (int2 == 1)
                {
                    MessageBox.Show("สองดวง");
                    string TestCustomize = System.IO.File.ReadAllText(@"C:\Users\Public\TestCustomize.txt");

                    char[] test = { '\n' };
                    string[] xy = TestCustomize.Split(test);
                    //txtNameProduct//
                    string npx = xy[0];
                    int npX = int.Parse(npx);
                    string npy = xy[1];
                    int npY = int.Parse(npy);

                    //pictureBoxBarcode//
                    string pbbx = xy[2];
                    int pbbX = int.Parse(pbbx);
                    string pbby = xy[3];
                    int pbbY = int.Parse(pbby);

                    //txtNamePrice//
                    string nprx = xy[4];
                    int nprX = int.Parse(nprx);
                    string npry = xy[5];
                    int nprY = int.Parse(npry);

                    //txtPrice//
                    string prx = xy[6];
                    int prX = int.Parse(prx);
                    string pry = xy[7];
                    int prY = int.Parse(pry);

                    //txtNameQty//
                    string nqx = xy[8];
                    int nqX = int.Parse(nqx);
                    string nqy = xy[9];
                    int nqY = int.Parse(nqy);

                    //txtQty//
                    string qtyx = xy[10];
                    int qtyX = int.Parse(qtyx);
                    string qtyy = xy[11];
                    int qtyY = int.Parse(qtyy);

                    //txtNameTotal_price//
                    string ntpx = xy[12];
                    int ntpX = int.Parse(ntpx);
                    string ntpy = xy[13];
                    int ntpY = int.Parse(ntpy);

                    //txtTotal_price//
                    string tpx = xy[14];
                    int tpX = int.Parse(tpx);
                    string tpy = xy[15];
                    int tpY = int.Parse(tpy);


                    txtNameProduct.Location = new Point(npX, npY);
                    pictureBoxBarcode.Location = new Point(pbbX, pbbY);
                    txtNamePrice.Location = new Point(nprX, nprY);
                    txtPrice.Location = new Point(prX, prY);
                    txtNameQty.Location = new Point(nqX, nqY);
                    txtQty.Location = new Point(qtyX, qtyY);
                    txtNameTotal_price.Location = new Point(ntpX, ntpY);
                    txtTotal_price.Location = new Point(tpX, tpY);
                }
                /// สามดวงเล็ก ///
                else if (int2 == 0)
                {
                    MessageBox.Show("สามดวง");

                }
            }
            catch
            {

            }
            
            ControlExtension.Draggable(txtNameProduct, true);
            ControlExtension.Draggable(pictureBoxBarcode, true);
            ControlExtension.Draggable(txtNamePrice, true);
            ControlExtension.Draggable(txtPrice, true);
            ControlExtension.Draggable(txtNameQty, true);
            ControlExtension.Draggable(txtQty, true);
            ControlExtension.Draggable(txtNameTotal_price, true);
            ControlExtension.Draggable(txtTotal_price, true);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\setting.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);
                string bar2 = xx[0];
                int int2 = int.Parse(bar2);
                /// สองดวงใหญ่ ///
                if (int2 == 1)
                {
                    string nameProductX = txtNameProduct.Location.X.ToString();
                    string nameProductY = txtNameProduct.Location.Y.ToString();
                    string barcodeX = pictureBoxBarcode.Location.X.ToString();
                    string barcodeY = pictureBoxBarcode.Location.Y.ToString();
                    string namePriceX = txtNamePrice.Location.X.ToString();
                    string namePriceY = txtNamePrice.Location.Y.ToString();
                    string priceX = txtPrice.Location.X.ToString();
                    string priceY = txtPrice.Location.Y.ToString();
                    string nameQtyX = txtNameQty.Location.X.ToString();
                    string nameQtyY = txtNameQty.Location.Y.ToString();
                    string qtyX = txtQty.Location.X.ToString();
                    string qtyY = txtQty.Location.Y.ToString();
                    string nameTotal_priceX = txtNameTotal_price.Location.X.ToString();
                    string nameTotal_priceY = txtNameTotal_price.Location.Y.ToString();
                    string total_priceX = txtTotal_price.Location.X.ToString();
                    string total_priceY = txtTotal_price.Location.Y.ToString();

                    string[] lines = { nameProductX, nameProductY, barcodeX, barcodeY, namePriceX, namePriceY,
                                priceX, priceY, nameQtyX, nameQtyY,qtyX,qtyY,nameTotal_priceX,nameTotal_priceY,
                                total_priceX,total_priceY };
                    System.IO.File.WriteAllLines(@"C:\Users\Public\TestCustomize.txt", lines);

                    MessageBoxYes objForm = new MessageBoxYes();
                    objForm.Show();
                }
                else if(int2 == 0)
                { 
                
                }
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\setting.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);
                string bar2 = xx[0];
                int int2 = int.Parse(bar2);
                /// สองดวงใหญ่ ///
                if (int2 == 1)
                {
                    // ============= Reset สองดวงใหญ่ ============= //
                    txtNameProduct.Location = new Point(80, 20);
                    pictureBoxBarcode.Location = new Point(80, 60);
                    txtNamePrice.Location = new Point(65, 160);
                    txtPrice.Location = new Point(95, 185);
                    txtNameQty.Location = new Point(180, 160);
                    txtQty.Location = new Point(240, 185);
                    txtNameTotal_price.Location = new Point(110, 205);
                    txtTotal_price.Location = new Point(220, 200);

                    string nameProductX = txtNameProduct.Location.X.ToString();
                    string nameProductY = txtNameProduct.Location.Y.ToString();
                    string barcodeX = pictureBoxBarcode.Location.X.ToString();
                    string barcodeY = pictureBoxBarcode.Location.Y.ToString();
                    string namePriceX = txtNamePrice.Location.X.ToString();
                    string namePriceY = txtNamePrice.Location.Y.ToString();
                    string priceX = txtPrice.Location.X.ToString();
                    string priceY = txtPrice.Location.Y.ToString();
                    string nameQtyX = txtNameQty.Location.X.ToString();
                    string nameQtyY = txtNameQty.Location.Y.ToString();
                    string qtyX = txtQty.Location.X.ToString();
                    string qtyY = txtQty.Location.Y.ToString();
                    string nameTotal_priceX = txtNameTotal_price.Location.X.ToString();
                    string nameTotal_priceY = txtNameTotal_price.Location.Y.ToString();
                    string total_priceX = txtTotal_price.Location.X.ToString();
                    string total_priceY = txtTotal_price.Location.Y.ToString();

                    string[] lines = { nameProductX, nameProductY, barcodeX, barcodeY, namePriceX, namePriceY,
                                priceX, priceY, nameQtyX, nameQtyY,qtyX,qtyY,nameTotal_priceX,nameTotal_priceY,
                                total_priceX,total_priceY };
                    System.IO.File.WriteAllLines(@"C:\Users\Public\TestCustomize.txt", lines);
                    // ============= ============= ============= //
                }
                else if (int2 == 0)
                {

                }
            }
            catch
            {
            }
        }
    }
}
