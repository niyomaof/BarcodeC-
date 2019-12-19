using System.Drawing;
using System.Windows.Forms;

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
