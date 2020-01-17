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
    public partial class MessageBoxYes : Form
    {
        public MessageBoxYes()
        {
            InitializeComponent();
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
