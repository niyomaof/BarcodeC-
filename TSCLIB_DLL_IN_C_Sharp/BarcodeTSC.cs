using MaterialSkin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ZXing;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class BarcodeTSC : MaterialSkin.Controls.MaterialForm
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
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProduct.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ชื่อสินค้า");
                }
                else if (txtQty.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ปริมาณสุทธิ (ก.ก.)");
                }
                else if (txtPrice.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ราคา/หน่วย");
                }
                else if (txtBarcode.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก รหัสสินค้า");
                }
                else
                {
                    string barcode = richTextBox1.Text;
                    string product = txtProduct.Text;
                    string qty = txtQty.Text;
                    string price = txtPrice.Text;
                    string set = txtSet.Text;
                    double qtys = double.Parse(qty);
                    double prices = double.Parse(price);
                    double total_price;
                    total_price = qtys * prices;

                    TSCActiveX.TSCLIB TSCLIB_DLL = new TSCActiveX.TSCLIB();
                    //TSCLIB_DLL.ActiveXabout();
                    TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                    TSCLIB_DLL.ActiveXsendcommand("SIZE 104 mm, 27.6 mm");
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error " + ex);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.sKUMASTERTableAdapter.Fill(this.hYDataSet.SKUMASTER);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            ////////////////
            string product = txtProduct.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;

            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            if (txtQty.Text == "" && txtPrice.Text == "")
            {
                if (txtBarcode.Text == "")
                {
                    MessageBox.Show("ยังไม่กรอก Barcode");
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
                    MessageBox.Show("ยังไม่กรอก ปริมาณสุทธิ (ก.ก.)");
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
                    MessageBox.Show("ยังไม่กรอก ราคา/หน่วย");
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
                    MessageBox.Show("ยังไม่กรอก Barcode");
                }
                else
                {
                    pic.Image = writer.Write(richTextBox1.Text);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)

        {
            /*
            string bin_strng = txtQty.Text;
            int str_length = bin_strng.Length;
            if (str_length > 0)
            {
                if (bin_strng.Substring(str_length - 1).Equals("0") || bin_strng.Substring(str_length - 1).Equals("1") || bin_strng.Substring(str_length - 1).Equals("2") || bin_strng.Substring(str_length - 1).Equals("3") || 
                    bin_strng.Substring(str_length - 1).Equals("4") || bin_strng.Substring(str_length - 1).Equals("5") || bin_strng.Substring(str_length - 1).Equals("6") || bin_strng.Substring(str_length - 1).Equals("7") ||
                    bin_strng.Substring(str_length - 1).Equals("8") || bin_strng.Substring(str_length - 1).Equals("9") || bin_strng.Substring(str_length - 1).Equals("."))
                {
                    if (bin_strng == ".")
                    {
                        Console.WriteLine("S01 = "+bin_strng);
                        txtQty.Text = bin_strng;
                    }
                    else
                    {
                        txtQty.Text = bin_strng.Substring(0, str_length - 1);
                        Console.WriteLine("S02 = " + bin_strng);
                        txtQty.Text = bin_strng;
                    }
                }
                else
                {
                    Console.WriteLine("S11 = " + bin_strng);
                    txtQty.Text = bin_strng.Substring(0, str_length - 1);
                    txtQty.SelectionStart = txtQty.Text.Length;
                    txtQty.SelectionLength = 0;
                }
            } 
            */

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

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)

        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sKUMASTERBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }
    }
}