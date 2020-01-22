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

            // Creating and setting the properties of label 
            Label nameProduct = new Label();
            nameProduct.AutoSize = true;
            nameProduct.Text = "product";
            nameProduct.Location = new Point(80, 20);
            nameProduct.Font = new Font("Angsana New", 14);
            // Adding this label to form 
            this.Controls.Add(nameProduct);

            // Creating and setting the properties of label 
            Label namePrice = new Label();
            namePrice.AutoSize = true;
            namePrice.Text = "ราคา/หน่วย";
            namePrice.Location = new Point(65, 160);
            namePrice.Font = new Font("Angsana New", 14);
            // Adding this label to form 
            this.Controls.Add(namePrice);

            // Creating and setting the properties of label 
            Label price = new Label();
            price.AutoSize = true;
            price.Text = "90";
            price.Location = new Point(95, 185);
            price.Font = new Font("Angsana New", 14);
            // Adding this label to form 
            this.Controls.Add(price);

            // Creating and setting the properties of label 
            Label nameQty = new Label();
            nameQty.AutoSize = true;
            nameQty.Text = "ปริมาณสุทธิ (ก.ก.)";
            nameQty.Location = new Point(180, 160);
            nameQty.Font = new Font("Angsana New", 14);
            // Adding this label to form 
            this.Controls.Add(nameQty);

            // Creating and setting the properties of label 
            Label qty = new Label();
            qty.AutoSize = true;
            qty.Text = "20";
            qty.Location = new Point(240, 185);
            qty.Font = new Font("Angsana New", 14);
            // Adding this label to form 
            this.Controls.Add(qty);

            // Creating and setting the properties of label 
            Label nameTotal_price = new Label();
            nameTotal_price.AutoSize = true;
            nameTotal_price.Text = "มูลค่ารวม";
            nameTotal_price.Location = new Point(110, 205);
            nameTotal_price.Font = new Font("Angsana New", 16);
            // Adding this label to form 
            this.Controls.Add(nameTotal_price);

            // Creating and setting the properties of label 
            Label total_price = new Label();
            total_price.AutoSize = true;
            total_price.Text = "1940 บ.";
            total_price.Location = new Point(220, 200);
            total_price.Font = new Font("Angsana New", 16);
            // Adding this label to form 
            this.Controls.Add(total_price);

            ControlExtension.Draggable(nameProduct,true);
            ControlExtension.Draggable(namePrice, true);
            ControlExtension.Draggable(price, true);
            ControlExtension.Draggable(nameQty, true);
            ControlExtension.Draggable(qty, true);
            ControlExtension.Draggable(nameTotal_price, true);
            ControlExtension.Draggable(total_price, true);
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
                MessageBoxYes objForm = new MessageBoxYes();
                objForm.Show();
            }
            catch
            {
            }
        }
    }
}
