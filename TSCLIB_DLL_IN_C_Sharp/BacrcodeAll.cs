using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSCLIB_DLL_IN_C_Sharp
{
    public partial class BarcodeAll : MaterialForm
    {
        public BarcodeAll()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager material = MaterialSkinManager.Instance;
            //var skinManager = MaterialSkinManager.Instance;
            material.AddFormToManage(this);
            material.Theme = MaterialSkinManager.Themes.DARK;
            material.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void BacrcodeAll_Load(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }



        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ===================  ฉลาก 2 ดวง _1 ===================
        private void txtBarcode2_1_TextChanged(object sender, EventArgs e)
        {
            string bar = txtBarcode2_1.Text;
            ConnectDB db = new ConnectDB();
            SqlConnection conn = db.connect();
            SqlCommand cmdDataBase = new SqlCommand("SELECT SKU_BARCODE,SKU_NAME,SKU_STD_COST FROM SKUMASTER WHERE SKU_BARCODE = '" + bar + "'", conn);
            try
            {
                SqlDataReader reader = cmdDataBase.ExecuteReader();
                while (reader.Read())
                {
                    txtBarcode2_1.Text = reader["SKU_BARCODE"].ToString();
                    txtProduct2_1.Text = reader["SKU_NAME"].ToString();
                    txtPrice2_1.Text = reader["SKU_STD_COST"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
            if (txtBarcode2_1.Text != "")
            {
                if (txtQty2_1.Text == "" && txtPrice2_1.Text == "")
                {
                    string txtBar = txtBarcode2_1.Text;
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_1.Text.ToString();
                        richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                    }
                }
                else if (txtPrice2_1.Text != "" && txtQty2_1.Text == "")
                {
                    string price = txtPrice2_1.Text;
                    double prices = double.Parse(price);
                    string txtBar = txtBarcode2_1.Text + prices.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_1.Text.ToString();
                        richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                    }
                }
                else if (txtPrice2_1.Text == "" && txtQty2_1.Text != "")
                {
                    string price = txtPrice2_1.Text;
                    string txtBar = txtBarcode2_1.Text + price.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_1.Text.ToString();
                        richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                    }
                }
                else
                {
                    string qty = txtQty2_1.Text;
                    string price = txtPrice2_1.Text;
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

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                    }
                    else if (total_priceSplitShow.Length == 1)
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0]);

                        string txtBars = txtBarcode2_1.Text;
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
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                        string txtBars = txtBarcode2_1.Text;
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
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                }
            }
        }

        private void txtQty2_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode2_1.Text != "")
                {
                    if (txtQty2_1.Text == "" && txtPrice2_1.Text == "")
                    {
                        string txtBar = txtBarcode2_1.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else if (txtPrice2_1.Text != "" && txtQty2_1.Text == "")
                    {
                        string price = txtPrice2_1.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode2_1.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else if (txtPrice2_1.Text == "" && txtQty2_1.Text != "")
                    {
                        string price = txtPrice2_1.Text;
                        string txtBar = txtBarcode2_1.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty2_1.Text;
                        string price = txtPrice2_1.Text;
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

                                string txtBars = txtBarcode2_1.Text;
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
                                    richTextBox2_1.Text.ToString();
                                    richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode2_1.Text;
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
                                    richTextBox2_1.Text.ToString();
                                    richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void txtPrice2_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode2_1.Text != "")
                {
                    if (txtQty2_1.Text == "" && txtPrice2_1.Text == "")
                    {
                        string txtBar = txtBarcode2_1.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else if (txtPrice2_1.Text != "" && txtQty2_1.Text == "")
                    {
                        string price = txtPrice2_1.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode2_1.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else if (txtPrice2_1.Text == "" && txtQty2_1.Text != "")
                    {
                        string price = txtPrice2_1.Text;
                        string txtBar = txtBarcode2_1.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_1.Text.ToString();
                            richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty2_1.Text;
                        string price = txtPrice2_1.Text;
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

                                string txtBars = txtBarcode2_1.Text;
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
                                    richTextBox2_1.Text.ToString();
                                    richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode2_1.Text;
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
                                    richTextBox2_1.Text.ToString();
                                    richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_1.Text;
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
                                richTextBox2_1.Text.ToString();
                                richTextBox2_1.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_1.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_1, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void txtQty2_1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrice2_1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBarcode2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        // ===================  ฉลาก 2 ดวง _2 ===================
        private void txtBarcode2_2_TextChanged(object sender, EventArgs e)
        {
            string bar = txtBarcode2_2.Text;
            ConnectDB db = new ConnectDB();
            SqlConnection conn = db.connect();
            SqlCommand cmdDataBase = new SqlCommand("SELECT SKU_BARCODE,SKU_NAME,SKU_STD_COST FROM SKUMASTER WHERE SKU_BARCODE = '" + bar + "'", conn);
            try
            {
                SqlDataReader reader = cmdDataBase.ExecuteReader();
                while (reader.Read())
                {
                    txtBarcode2_2.Text = reader["SKU_BARCODE"].ToString();
                    txtProduct2_2.Text = reader["SKU_NAME"].ToString();
                    txtPrice2_2.Text = reader["SKU_STD_COST"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
            if (txtBarcode2_2.Text != "")
            {
                if (txtQty2_2.Text == "" && txtPrice2_2.Text == "")
                {
                    string txtBar = txtBarcode2_2.Text;
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_2.Text.ToString();
                        richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                    }
                }
                else if (txtPrice2_2.Text != "" && txtQty2_2.Text == "")
                {
                    string price = txtPrice2_2.Text;
                    double prices = double.Parse(price);
                    string txtBar = txtBarcode2_2.Text + prices.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_2.Text.ToString();
                        richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                    }
                }
                else if (txtPrice2_2.Text == "" && txtQty2_2.Text != "")
                {
                    string price = txtPrice2_2.Text;
                    string txtBar = txtBarcode2_2.Text + price.ToString();
                    Check12Digits = txtBar.PadRight(17, '0');
                    Barrcode = EAN13Class.EAN13(Check12Digits);
                    if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                    {
                        richTextBox2_2.Text.ToString();
                        richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                        Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                        ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                    }
                }
                else
                {
                    string qty = txtQty2_2.Text;
                    string price = txtPrice2_2.Text;
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

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                    }
                    else if (total_priceSplitShow.Length == 1)
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0]);

                        string txtBars = txtBarcode2_2.Text;
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
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else
                    {
                        string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                        string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                        string txtBars = txtBarcode2_2.Text;
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
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                }
            }
        }

        private void txtQty2_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode2_2.Text != "")
                {
                    if (txtQty2_2.Text == "" && txtPrice2_2.Text == "")
                    {
                        string txtBar = txtBarcode2_2.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else if (txtPrice2_2.Text != "" && txtQty2_2.Text == "")
                    {
                        string price = txtPrice2_2.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode2_2.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else if (txtPrice2_2.Text == "" && txtQty2_2.Text != "")
                    {
                        string price = txtPrice2_2.Text;
                        string txtBar = txtBarcode2_2.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty2_2.Text;
                        string price = txtPrice2_2.Text;
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

                                string txtBars = txtBarcode2_2.Text;
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
                                    richTextBox2_2.Text.ToString();
                                    richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode2_2.Text;
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
                                    richTextBox2_2.Text.ToString();
                                    richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void txtPrice2_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Barrcode, Check12Digits, Check12Digits2, Check12Digits3;
                if (txtBarcode2_2.Text != "")
                {
                    if (txtQty2_2.Text == "" && txtPrice2_2.Text == "")
                    {
                        string txtBar = txtBarcode2_2.Text;
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else if (txtPrice2_2.Text != "" && txtQty2_2.Text == "")
                    {
                        string price = txtPrice2_2.Text;
                        double prices = double.Parse(price);
                        string txtBar = txtBarcode2_2.Text + prices.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else if (txtPrice2_2.Text == "" && txtQty2_2.Text != "")
                    {
                        string price = txtPrice2_2.Text;
                        string txtBar = txtBarcode2_2.Text + price.ToString();
                        Check12Digits = txtBar.PadRight(17, '0');
                        Barrcode = EAN13Class.EAN13(Check12Digits);
                        if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                        {
                            richTextBox2_2.Text.ToString();
                            richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                            Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                            ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                        }
                    }
                    else
                    {
                        string qty = txtQty2_2.Text;
                        string price = txtPrice2_2.Text;
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

                                string txtBars = txtBarcode2_2.Text;
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
                                    richTextBox2_2.Text.ToString();
                                    richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                                }
                            }
                            else
                            {
                                string showQty = (qtySplitShow[0]);
                                string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                                string txtBars = txtBarcode2_2.Text;
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
                                    richTextBox2_2.Text.ToString();
                                    richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                    Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                    ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                                }
                            }
                        }
                        else if (total_priceSplitShow.Length == 1)
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0]);

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                        else
                        {
                            string showQty = (qtySplitShow[0] + qtySplitShow[1]);
                            string showTotal_price = (total_priceSplitShow[0] + total_priceSplitShow[1]);

                            string txtBars = txtBarcode2_2.Text;
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
                                richTextBox2_2.Text.ToString();
                                richTextBox2_2.Text = EAN13Class.Barcode13Digits.ToString();

                                Int32 intStart = Convert.ToInt32(richTextBox2_2.TextLength - 1);
                                ChangeTextColor.ChangeColor(richTextBox2_2, intStart);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void txtQty2_2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrice2_2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBarcode2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        // ===================  ButtonPrint & Exit ===================
        private void buttonPrintBarcode2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProduct2_1.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ชื่อสินค้า");
                }
                else if (txtQty2_1.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ปริมาณสุทธิ (ก.ก.)");
                }
                else if (txtPrice2_1.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก ราคา/หน่วย");
                }
                else if (txtBarcode2_1.Text == "")
                {
                    MessageBox.Show("คุณยังไม่กรอก รหัสสินค้า");
                }
                else
                {
                   
                    string text = System.IO.File.ReadAllText(@"C:\Users\Public\setting.txt");

                    char[] s = { '\n' };
                    string[] xx = text.Split(s);

                    string X = xx[1];
                    string Y = xx[2];

                    string barcode1 = richTextBox2_1.Text;
                    string product1 = txtProduct2_1.Text;
                    string qty1 = txtQty2_1.Text;
                    string price1 = txtPrice2_1.Text;
                    double qtys1 = double.Parse(qty1);
                    double prices1 = double.Parse(price1);
                    double total_price1;
                    total_price1 = qtys1 * prices1;


                    string barcode2 = richTextBox2_2.Text;
                    string product2 = txtProduct2_2.Text;
                    string qty2 = txtQty2_2.Text;
                    string price2 = txtPrice2_2.Text;
                    double qtys2 = double.Parse(qty2);
                    double prices2 = double.Parse(price2);
                    double total_price2;
                    total_price2 = qtys2 * prices2;
                    //string set = txtSet.Text;



                    TSCActiveX.TSCLIB TSCLIB_DLL = new TSCActiveX.TSCLIB();


                    TSCLIB_DLL.ActiveXopenport("TSC TTP-244 Pro");
                    TSCLIB_DLL.ActiveXsendcommand("SIZE " + X + " mm, " + Y + " mm");
                    TSCLIB_DLL.ActiveXsendcommand("GAP 0 mm, 0 mm");
                    TSCLIB_DLL.ActiveXsendcommand("SPEED 4");
                    TSCLIB_DLL.ActiveXsendcommand("DIRECTION 1");
                    TSCLIB_DLL.ActiveXsendcommand("DENSITY 12");
                    TSCLIB_DLL.ActiveXsendcommand("SET TEAR ON");
                    TSCLIB_DLL.ActiveXclearbuffer();

                    //|| ใบที่ 1
                    TSCLIB_DLL.ActiveXwindowsfont(80, 20, 45, 0, 0, 0, "AngsanaUPC", product1);
                    TSCLIB_DLL.ActiveXbarcode("80", "60", "128", "80", "1", "0", "2", "4", barcode1);
                    TSCLIB_DLL.ActiveXwindowsfont(65, 160, 45, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                    TSCLIB_DLL.ActiveXwindowsfont(95, 185, 45, 0, 0, 0, "AngsanaUPC", price1);
                    TSCLIB_DLL.ActiveXwindowsfont(180, 160, 45, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                    TSCLIB_DLL.ActiveXwindowsfont(240, 185, 45, 0, 0, 0, "AngsanaUPC", qty1);
                    TSCLIB_DLL.ActiveXwindowsfont(110, 205, 50, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                    TSCLIB_DLL.ActiveXwindowsfont(220, 200, 60, 0, 0, 0, "AngsanaUPC", total_price1 + " บ.");
                    //||  ใบที่ 1

                    //|| ใบที่ 2
                    ////TSCLIB_DLL.ActiveXwindowsfont(แนวนอน, แนวตั้ง , ขนานตัวอักษร, 0, 0, 0, "AngsanaUPC", product);////
                    ///TSCLIB_DLL.ActiveXbarcode(""+(20+325), "55", "EAN13", "80", "1", "0", "ยาว", "กว้าง", barcode);
                    TSCLIB_DLL.ActiveXwindowsfont(480, 20, 45, 0, 0, 0, "AngsanaUPC", product2);
                    TSCLIB_DLL.ActiveXbarcode("" + (485), "60", "128", "80", "1", "0", "2", "4", barcode2);
                    TSCLIB_DLL.ActiveXwindowsfont(475, 160, 45, 0, 0, 0, "AngsanaUPC", "ราคา/หน่วย");
                    TSCLIB_DLL.ActiveXwindowsfont(505, 185, 45, 0, 0, 0, "AngsanaUPC", price2);
                    TSCLIB_DLL.ActiveXwindowsfont(590, 160, 45, 0, 0, 0, "AngsanaUPC", "ปริมาณสุทธิ (ก.ก.)");
                    TSCLIB_DLL.ActiveXwindowsfont(650, 185, 45, 0, 0, 0, "AngsanaUPC", qty2);
                    TSCLIB_DLL.ActiveXwindowsfont(520, 205, 50, 0, 0, 0, "AngsanaUPC", "มูลค่ารวม");
                    TSCLIB_DLL.ActiveXwindowsfont(630, 200, 60, 0, 0, 0, "AngsanaUPC", total_price2 + " บ.");
                    //|| ใบที่ 2
                    TSCLIB_DLL.ActiveXprintlabel("1", "1");
                    TSCLIB_DLL.ActiveXcloseport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error " + ex);
            }
        }


        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
