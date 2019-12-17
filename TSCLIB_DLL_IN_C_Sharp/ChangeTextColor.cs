using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TSCLIB_DLL_IN_C_Sharp
{
    class ChangeTextColor
    {
        public static void ChangeColor(RichTextBox rtx, int Start, byte Length = 1)
        {
            rtx.SelectionAlignment = HorizontalAlignment.Left;
            rtx.SelectionStart = Start;
            rtx.SelectionLength = Length;
            rtx.SelectionColor = Color.Crimson;
        }
    }
}
