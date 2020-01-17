using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ZXing;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class BarcodeTSC : MaterialForm
    {
        private static BarcodeTSC _instance;
        public static BarcodeTSC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BarcodeTSC();
                return _instance;
            }
        }

        public BarcodeTSC()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager material = MaterialSkinManager.Instance;
            //var skinManager = MaterialSkinManager.Instance;
            material.AddFormToManage(this);
            material.Theme = MaterialSkinManager.Themes.DARK;
            material.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.sKUMASTERTableAdapter.Fill(this.hYDataSet.SKUMASTER);
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\Public\setting.txt");

                char[] s = { '\n' };
                string[] xx = text.Split(s);
                string index = xx[0];
                int indexComboBox = int.Parse(index);

                comboBoxS.SelectedIndex = indexComboBox;
                txtX.Text = xx[1];
                txtY.Text = xx[2];
                txtS.Text = xx[3];
            }
            catch
            {

            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }
        //////new///////
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtProduct.Text == "")
                {
                    MB.Mb_Product1_1 objForm = new MB.Mb_Product1_1();
                    objForm.Show();
                    //MessageBox.Show("คุณยังไม่กรอก ชื่อสินค้า");
                }
                else if (txtQty.Text == "")
                {
                    MB.Mb_Qty1_1 objForm = new MB.Mb_Qty1_1();
                    objForm.Show();
                    //MessageBox.Show("คุณยังไม่กรอก ปริมาณสุทธิ (ก.ก.)");
                }
                else if (txtPrice.Text == "")
                {
                    MB.Mb_Price1_1 objForm = new MB.Mb_Price1_1();
                    objForm.Show();
                    //MessageBox.Show("คุณยังไม่กรอก ราคา/หน่วย");
                }
                else if (txtBarcode.Text == "")
                {
                    MB.Mb_Barcode1_1 objForm = new MB.Mb_Barcode1_1();
                    objForm.Show();
                    //MessageBox.Show("คุณยังไม่กรอก รหัสสินค้า");
                }
                else
                {
                    string barcode = richTextBox1.Text;
                    string product = txtProduct.Text;
                    string qty = txtQty.Text;
                    string price = txtPrice.Text;
                    string set = txtSet.Text;
                    string t = txtS.Text;
                    string Sx = txtX.Text;
                    string Sy = txtY.Text;

                    int ts = int.Parse(t);
                    double xx = double.Parse(Sx);
                    double yy = double.Parse(Sy);
                    double qtys = double.Parse(qty);
                    double prices = double.Parse(price);
                    double total_price;
                    total_price = qtys * prices;

                    TSCActiveX.TSCLIB TSCLIB_DLL = new TSCActiveX.TSCLIB();
                    if (comboBoxS.Text == "ฉลากเล็กแบบฉีก 3 ดวง")
                    {
                        switch (ts)
                        {
                            case 1:
                                TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                                TSCLIB_DLL.ActiveXsendcommand("SIZE " + xx.ToString() + " mm, " + yy.ToString() + " mm");
                                TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                                TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                                TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                                TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                                TSCLIB_DLL.ActiveXclearbuffer();

                                //|| ใบที่ 1
                                TSCLIB_DLL.ActiveXwindowsfont(80, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "1", "5", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(45, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(80, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(130, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(170, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //||  ใบที่ 1

                                TSCLIB_DLL.ActiveXprintlabel(set, "1");
                                TSCLIB_DLL.ActiveXcloseport();
                                break;

                            case 2:
                                TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                                TSCLIB_DLL.ActiveXsendcommand("SIZE " + xx.ToString() + " mm, " + yy.ToString() + " mm");
                                TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                                TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                                TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                                TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                                TSCLIB_DLL.ActiveXclearbuffer();

                                //|| ใบที่ 1
                                TSCLIB_DLL.ActiveXwindowsfont(80, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "1", "5", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(45, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(80, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(130, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(170, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //||  ใบที่ 1

                                //|| ใบที่ 2
                                ////TSCLIB_DLL.ActiveXwindowsfont(แนวนอน, แนวตั้ง , ขนานตัวอักษร, 0, 0, 0, "AngsanaUPC", product);////
                                ///TSCLIB_DLL.ActiveXbarcode(""+(20+325), "55", "EAN13", "80", "1", "0", "ยาว", "กว้าง", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(90 + 250, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("" + (20 + 325), "60", "128", "80", "1", "0", "1", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 45, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 75, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 140, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 180, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //|| ใบที่ 2
                                TSCLIB_DLL.ActiveXprintlabel(set, "1");
                                TSCLIB_DLL.ActiveXcloseport();
                                break;

                            case 3:
                                TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                                TSCLIB_DLL.ActiveXsendcommand("SIZE " + xx.ToString() + " mm, " + yy.ToString() + " mm");
                                TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                                TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                                TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                                TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                                TSCLIB_DLL.ActiveXclearbuffer();

                                //|| ใบที่ 1
                                TSCLIB_DLL.ActiveXwindowsfont(80, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "1", "5", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(45, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(80, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(130, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(170, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //||  ใบที่ 1

                                //|| ใบที่ 2
                                ////TSCLIB_DLL.ActiveXwindowsfont(แนวนอน, แนวตั้ง , ขนานตัวอักษร, 0, 0, 0, "AngsanaUPC", product);////
                                ///TSCLIB_DLL.ActiveXbarcode(""+(20+325), "55", "EAN13", "80", "1", "0", "ยาว", "กว้าง", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(90 + 250, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("" + (20 + 325), "60", "128", "80", "1", "0", "1", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 45, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 75, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 140, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 180, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //|| ใบที่ 2

                                //|| ใบที่ 3    
                                TSCLIB_DLL.ActiveXwindowsfont(90 + 270 + 260, 30, 35, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("" + (20 + 325 + 280), "60", "128", "80", "1", "0", "1", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 270 + 50, 150, 35, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 270 + 80, 170, 35, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 230 + 185, 150, 35, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 270 + 180, 170, 35, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 270 + 70, 190, 40, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(270 + 270 + 160, 185, 50, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //|| ใบที่ 3

                                TSCLIB_DLL.ActiveXprintlabel(set, "1");
                                TSCLIB_DLL.ActiveXcloseport();
                                break;
                        }
                        txtBarcode.Text = "";
                        txtProduct.Text = "";
                        txtQty.Text = "";
                        txtPrice.Text = "";
                        richTextBox1.Text = "";
                    }
                    else if (comboBoxS.Text == "ฉลากกลางแบบฉีก 2 ดวง")
                    {
                        ////////สองดวงใหญ่////////
                        switch (ts)
                        {
                            case 1:
                                TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                                //TSCLIB_DLL.ActiveXsendcommand("SIZE 104 mm, 31.6 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SIZE " + xx.ToString() + " mm, " + yy.ToString() + " mm");
                                TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                                TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                                TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                                TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                                TSCLIB_DLL.ActiveXclearbuffer();

                                //|| ใบที่ 1
                                TSCLIB_DLL.ActiveXwindowsfont(80, 20, 45, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "2", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(65, 160, 45, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(95, 185, 45, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(180, 160, 45, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(240, 185, 45, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(110, 205, 50, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(220, 200, 60, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //||  ใบที่ 1
                                TSCLIB_DLL.ActiveXprintlabel(set, "1");
                                TSCLIB_DLL.ActiveXcloseport();
                                break;

                            case 2:
                                TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                                TSCLIB_DLL.ActiveXsendcommand("SIZE " + xx.ToString() + " mm, " + yy.ToString() + " mm");
                                TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                                TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                                TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                                TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                                TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                                TSCLIB_DLL.ActiveXclearbuffer();

                                //|| ใบที่ 1
                                TSCLIB_DLL.ActiveXwindowsfont(80, 20, 45, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "2", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(65, 160, 45, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(95, 185, 45, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(180, 160, 45, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(240, 185, 45, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(110, 205, 50, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(220, 200, 60, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //||  ใบที่ 1

                                //|| ใบที่ 2
                                ////TSCLIB_DLL.ActiveXwindowsfont(แนวนอน, แนวตั้ง , ขนานตัวอักษร, 0, 0, 0, "AngsanaUPC", product);////
                                ///TSCLIB_DLL.ActiveXbarcode(""+(20+325), "55", "EAN13", "80", "1", "0", "ยาว", "กว้าง", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(480, 20, 45, 0, 0, 0, "AngsanaUPC", product);
                                TSCLIB_DLL.ActiveXbarcode("" + (485), "60", "128", "80", "1", "0", "2", "4", barcode);
                                TSCLIB_DLL.ActiveXwindowsfont(475, 160, 45, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                                TSCLIB_DLL.ActiveXwindowsfont(505, 185, 45, 0, 0, 0, "AngsanaUPC", price);
                                TSCLIB_DLL.ActiveXwindowsfont(590, 160, 45, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                                TSCLIB_DLL.ActiveXwindowsfont(650, 185, 45, 0, 0, 0, "AngsanaUPC", qty);
                                TSCLIB_DLL.ActiveXwindowsfont(520, 205, 50, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                                TSCLIB_DLL.ActiveXwindowsfont(630, 200, 60, 0, 0, 0, "AngsanaUPC", total_price + " บ.");
                                //|| ใบที่ 2
                                TSCLIB_DLL.ActiveXprintlabel(set, "1");
                                TSCLIB_DLL.ActiveXcloseport();
                                break;
                        }
                        txtBarcode.Text = "";
                        txtProduct.Text = "";
                        txtQty.Text = "";
                        txtPrice.Text = "";
                        richTextBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error " + ex);
            }
        }

        private void txtProduct_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtQty_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBarcode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQty_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode.Text != "")
                {
                    if (txtQty.Text == "" && txtPrice.Text == "")
                    {
                        string txtBar = txtBarcode.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else if (txtPrice.Text != "" && txtQty.Text == "")
                    {
                        string price = txtPrice.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else if (txtPrice.Text == "" && txtQty.Text != "")
                    {
                        string price = txtPrice.Text;
                        string txtBar = txtBarcode.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty.Text;
                        string price = txtPrice.Text;
                        double qtys = double.Parse(qty);
                        double prices = double.Parse(price);
                        double total_price;
                        total_price = qtys * prices;
                        string qtySplit = qty.ToString();
                        string total_priceSplit = total_price.ToString();

                        char[] spearator = { '.' };

                        String[] qtySplitShow = qtySplit.Split(spearator);
                        String[] total_priceSplitShow = total_priceSplit.Split(spearator);

                        if (qtySplitShow.Length == 1)
                        {
                            if (total_priceSplitShow.Length == 1)
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0]);

                                string txtBars = txtBarcode.Text;
                                string txtQty = showQty.ToString();
                                string txtTotal = showTotal_price.ToString();
                                Check12Digits = txtBars.PadRight(17, '0');
                                Check12Digits2 = txtQty.PadRight(17, '0');
                                Check12Digits3 = txtTotal.PadRight(17, '0');

                                int startIndex = 0;
                                int length = 6;
                                int startIndex5 = 0;
                                int length5 = 5;
                                String substring1 = Check12Digits.Substring(startIndex, length);
                                String substring2 = Check12Digits2.Substring(startIndex5, length5);
                                String substring3 = Check12Digits3.Substring(startIndex, length);

                                string txtBar = substring1 + substring3 + substring2;
                                Check12Digits = txtBar.PadRight(17, '0');
                                Barrcode = EAN13Class.EAN13(Check12Digits);
                                if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                                {
                                    richTextBox1.Text.ToString();
                                    richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox1, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode.Text;
                                string txtQty = showQty.ToString();
                                string txtTotal = showTotal_price.ToString();
                                Check12Digits = txtBars.PadRight(17, '0');
                                Check12Digits2 = txtQty.PadRight(17, '0');
                                Check12Digits3 = txtTotal.PadRight(17, '0');

                                int startIndex = 0;
                                int length = 6;
                                int startIndex5 = 0;
                                int length5 = 5;
                                String substring1 = Check12Digits.Substring(startIndex, length);
                                String substring2 = Check12Digits2.Substring(startIndex5, length5);
                                String substring3 = Check12Digits3.Substring(startIndex, length);

                                string txtBar = substring1 + substring3 + substring2;
                                Check12Digits = txtBar.PadRight(17, '0');
                                Barrcode = EAN13Class.EAN13(Check12Digits);
                                if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                                {
                                    richTextBox1.Text.ToString();
                                    richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox1, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            ////\\\\ ราคาสินค้า ที่ตัดจุด ไม่สามารถพิมตัวอักษรได้ \\\\////
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode.Text != "")
                {
                    if (txtQty.Text == "" && txtPrice.Text == "")
                    {
                        string txtBar = txtBarcode.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else if (txtPrice.Text != "" && txtQty.Text == "")
                    {
                        string price = txtPrice.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else if (txtPrice.Text == "" && txtQty.Text != "")
                    {
                        string price = txtPrice.Text;
                        string txtBar = txtBarcode.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty.Text;
                        string price = txtPrice.Text;
                        double qtys = double.Parse(qty);
                        double prices = double.Parse(price);
                        double total_price;
                        total_price = qtys * prices;
                        string qtySplit = qty.ToString();
                        string total_priceSplit = total_price.ToString();

                        char[] spearator = { '.' };

                        String[] qtySplitShow = qtySplit.Split(spearator);
                        String[] total_priceSplitShow = total_priceSplit.Split(spearator);

                        if (qtySplitShow.Length == 1)
                        {
                            if (total_priceSplitShow.Length == 1)
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0]);

                                string txtBars = txtBarcode.Text;
                                string txtQty = showQty.ToString();
                                string txtTotal = showTotal_price.ToString();
                                Check12Digits = txtBars.PadRight(17, '0');
                                Check12Digits2 = txtQty.PadRight(17, '0');
                                Check12Digits3 = txtTotal.PadRight(17, '0');

                                int startIndex = 0;
                                int length = 6;
                                int startIndex5 = 0;
                                int length5 = 5;
                                String substring1 = Check12Digits.Substring(startIndex, length);
                                String substring2 = Check12Digits2.Substring(startIndex5, length5);
                                String substring3 = Check12Digits3.Substring(startIndex, length);

                                string txtBar = substring1 + substring3 + substring2;
                                Check12Digits = txtBar.PadRight(17, '0');
                                Barrcode = EAN13Class.EAN13(Check12Digits);
                                if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                                {
                                    richTextBox1.Text.ToString();
                                    richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox1, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode.Text;
                                string txtQty = showQty.ToString();
                                string txtTotal = showTotal_price.ToString();
                                Check12Digits = txtBars.PadRight(17, '0');
                                Check12Digits2 = txtQty.PadRight(17, '0');
                                Check12Digits3 = txtTotal.PadRight(17, '0');

                                int startIndex = 0;
                                int length = 6;
                                int startIndex5 = 0;
                                int length5 = 5;
                                String substring1 = Check12Digits.Substring(startIndex, length);
                                String substring2 = Check12Digits2.Substring(startIndex5, length5);
                                String substring3 = Check12Digits3.Substring(startIndex, length);

                                string txtBar = substring1 + substring3 + substring2;
                                Check12Digits = txtBar.PadRight(17, '0');
                                Barrcode = EAN13Class.EAN13(Check12Digits);
                                if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                                {
                                    richTextBox1.Text.ToString();
                                    richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox1, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void txtBarcode_TextChanged_1(object sender, EventArgs e)
        {
            string bar = txtBarcode.Text;
            ConnectDB db = new ConnectDB();
            SqlConnection conn = db.connect();
            SqlCommand cmdDataBase = new SqlCommand("SELECT SKU_BARCODE,SKU_NAME,SKU_STD_COST FROM SKUMASTER WHERE SKU_BARCODE = '" + bar + "'", conn);
            try
            {
                SqlDataReader reader = cmdDataBase.ExecuteReader();
                while (reader.Read())
                {
                    txtBarcode.Text = reader["SKU_BARCODE"].ToString();
                    txtProduct.Text = reader["SKU_NAME"].ToString();
                    txtPrice.Text = reader["SKU_STD_COST"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
            if (txtBarcode.Text != "")
            {
                if (txtQty.Text == "" && txtPrice.Text == "")
                {
                    string txtBar = txtBarcode.Text;
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox1.Text.ToString();
                        richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox1, intStart);
                    }
                }
                else if (txtPrice.Text != "" && txtQty.Text == "")
                {
                    string price = txtPrice.Text;
                    double prices = double.Parse(price);
                    string txtBar = txtBarcode.Text + prices.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox1.Text.ToString();
                        richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox1, intStart);
                    }
                }
                else if (txtPrice.Text == "" && txtQty.Text != "")
                {
                    string price = txtPrice.Text;
                    string txtBar = txtBarcode.Text + price.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox1.Text.ToString();
                        richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox1, intStart);
                    }
                }
                else
                {
                    string qty = txtQty.Text;
                    string price = txtPrice.Text;
                    double qtys = double.Parse(qty);
                    double prices = double.Parse(price);
                    double total_price;
                    total_price = qtys * prices;
                    string qtySplit = qty.ToString();
                    string total_priceSplit = total_price.ToString();

                    char[] spearator = { '.' };

                    String[] qtySplitShow = qtySplit.Split(spearator);
                    String[] total_priceSplitShow = total_priceSplit.Split(spearator);

                    if (qtySplitShow.Length == 1)
                    {
                        if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode.Text;
                            string txtQty = showQty.ToString();
                            string txtTotal = showTotal_price.ToString();
                            Check12Digits = txtBars.PadRight(17, '0');
                            Check12Digits2 = txtQty.PadRight(17, '0');
                            Check12Digits3 = txtTotal.PadRight(17, '0');

                            int startIndex = 0;
                            int length = 6;
                            int startIndex5 = 0;
                            int length5 = 5;
                            String substring1 = Check12Digits.Substring(startIndex, length);
                            String substring2 = Check12Digits2.Substring(startIndex5, length5);
                            String substring3 = Check12Digits3.Substring(startIndex, length);

                            string txtBar = substring1 + substring3 + substring2;
                            Check12Digits = txtBar.PadRight(17, '0');
                            Barrcode = EAN13Class.EAN13(Check12Digits);
                            if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                            {
                                richTextBox1.Text.ToString();
                                richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox1, intStart);
                            }
                        }
                    }
                    else if (total_priceSplitShow.Length == 1)
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0]);

                        string txtBars = txtBarcode.Text;
                        string txtQty = showQty.ToString();
                        string txtTotal = showTotal_price.ToString();
                        Check12Digits = txtBars.PadRight(17, '0');
                        Check12Digits2 = txtQty.PadRight(17, '0');
                        Check12Digits3 = txtTotal.PadRight(17, '0');

                        int startIndex = 0;
                        int length = 6;
                        int startIndex5 = 0;
                        int length5 = 5;
                        String substring1 = Check12Digits.Substring(startIndex, length);
                        String substring2 = Check12Digits2.Substring(startIndex5, length5);
                        String substring3 = Check12Digits3.Substring(startIndex, length);

                        string txtBar = substring1 + substring3 + substring2;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                    else
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                        string txtBars = txtBarcode.Text;
                        string txtQty = showQty.ToString();
                        string txtTotal = showTotal_price.ToString();
                        Check12Digits = txtBars.PadRight(17, '0');
                        Check12Digits2 = txtQty.PadRight(17, '0');
                        Check12Digits3 = txtTotal.PadRight(17, '0');

                        int startIndex = 0;
                        int length = 6;
                        int startIndex5 = 0;
                        int length5 = 5;
                        String substring1 = Check12Digits.Substring(startIndex, length);
                        String substring2 = Check12Digits2.Substring(startIndex5, length5);
                        String substring3 = Check12Digits3.Substring(startIndex, length);

                        string txtBar = substring1 + substring3 + substring2;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox1.Text.ToString();
                            richTextBox1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox1, intStart);
                        }
                    }
                }
            }
        }

        private void showBarcode_Click(object sender, EventArgs e)
        {
            string product = txtProduct.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;

            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            if (txtQty.Text == "" && txtPrice.Text == "")
            {
                if (txtBarcode.Text == "")
                {
                    MB.Mb_Barcode1_1 objForm = new MB.Mb_Barcode1_1();
                    objForm.Show();
                    //MessageBox.Show("ยังไม่กรอก Barcode");
                }
                else
                {
                    pic.Image = writer.Write(richTextBox1.Text);
                }
            }
            else if (txtQty.Text == "" && txtPrice.Text != "")
            {
                if (txtQty.Text == "")
                {
                    MB.Mb_Qty1_1 objForm = new MB.Mb_Qty1_1();
                    objForm.Show();
                    //MessageBox.Show("ยังไม่กรอก ปริมาณสุทธิ (ก.ก.)");
                }
                else
                {
                    pic.Image = writer.Write(richTextBox1.Text);
                }
            }
            else if (txtQty.Text != "" && txtPrice.Text == "")
            {
                if (txtPrice.Text == "")
                {
                    MB.Mb_Price1_1 objForm = new MB.Mb_Price1_1();
                    objForm.Show();
                    //MessageBox.Show("ยังไม่กรอก ราคา/หน่วย");
                }
                else
                {
                    pic.Image = writer.Write(richTextBox1.Text);
                }
            }
            else
            {
                double qtys = double.Parse(qty);
                double prices = double.Parse(price);
                double total_price;
                total_price = qtys * prices;

                laPrice.Text = (price);
                laProduct.Text = (product);
                laTotal_price.Text = (total_price.ToString());
                laQty.Text = (qty);

                if (txtBarcode.Text == "")
                {
                    MB.Mb_Barcode1_1 objForm = new MB.Mb_Barcode1_1();
                    objForm.Show();
                    //MessageBox.Show("ยังไม่กรอก Barcode");
                }
                else
                {
                    pic.Image = writer.Write(richTextBox1.Text);
                }
            }
        }

        private void txtSet_TextChanged(object sender, EventArgs e)
        {

        }

        private void ปริ้น_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBoxS.SelectedIndex.ToString();
                string x = txtX.Text;
                string y = txtY.Text;
                string s = txtS.Text;

                string[] lines = { name, x, y, s };
                System.IO.File.WriteAllLines(@"C:\Users\Public\setting.txt", lines);

                MessageBoxYes objForm = new MessageBoxYes();
                objForm.Show();
            }
            catch
            {
            }
        }

        private void ตั้งค่าหน้ากระดาษ_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider5_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider4_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider2_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxS.SelectedItem.ToString() == "ฉลากเล็กแบบฉีก 3 ดวง")
            {
                txtX.Text = "104";
                txtY.Text = "27.6";
                txtS.Text = "3";
            }
            else if (comboBoxS.SelectedItem.ToString() == "ฉลากกลางแบบฉีก 2 ดวง")
            {
                txtX.Text = "104";
                txtY.Text = "31.6";
                txtS.Text = "2";
            }
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtS_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxS.SelectedItem.ToString() == "ฉลากเล็กแบบฉีก 3 ดวง")
            {
                string bin_strng = txtS.Text;
                int str_length = bin_strng.Length;
                if (str_length > 0)
                {
                    if (bin_strng.Substring(str_length - 1).Equals("1") || bin_strng.Substring(str_length - 1).Equals("2") || bin_strng.Substring(str_length - 1).Equals("3"))
                    {
                        Console.WriteLine(bin_strng);
                        txtS.Text = bin_strng;

                    }
                    else
                    {
                        Console.WriteLine(bin_strng);
                        txtS.Text = bin_strng.Substring(0, str_length - 1);
                        txtS.SelectionStart = txtS.Text.Length;
                        txtS.SelectionLength = 0;
                    }
                }
            }
            else if (comboBoxS.SelectedItem.ToString() == "ฉลากกลางแบบฉีก 2 ดวง")
            {
                string bin_strng = txtS.Text;
                int str_length = bin_strng.Length;
                if (str_length > 0)
                {
                    if (bin_strng.Substring(str_length - 1).Equals("1") || bin_strng.Substring(str_length - 1).Equals("2"))
                    {
                        Console.WriteLine(bin_strng);
                        txtS.Text = bin_strng;

                    }
                    else
                    {
                        Console.WriteLine(bin_strng);
                        txtS.Text = bin_strng.Substring(0, str_length - 1);
                        txtS.SelectionStart = txtS.Text.Length;
                        txtS.SelectionLength = 0;
                    }
                }
            }
            
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeAll objForm = new BarcodeAll();
            objForm.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}