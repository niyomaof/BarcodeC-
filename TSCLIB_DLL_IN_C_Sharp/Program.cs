using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class TSCLIB
{
    [DllImport("TSCActiveX.dll", EntryPoint = "ActiveXabout")]
    public static extern int ActiveXabout();

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXopenport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXbarcode")]
    public static extern int barcode(string x, string y, string type,
                string height, string readable, string rotation,
                string narrow, string wide, string code);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXclearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXcloseport")]
    public static extern int closeport();

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXdownloadpcx")]
    public static extern int downloadpcx(string filename, string image_name);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXformfeed")]
    public static extern int formfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXnobackfeed")]
    public static extern int nobackfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXprinterfont")]
    public static extern int printerfont(string x, string y, string fonttype,
                    string rotation, string xmul, string ymul,
                    string text);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXprintlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXsendcommand")]
    public static extern int sendcommand(string printercommand);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXsetup")]
    public static extern int setup(string width, string height,
              string speed, string density,
              string sensor, string vertical,
              string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "ActiveXwindowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
                    int rotation, int fontstyle, int fontunderline,
                    string szFaceName, string content);

}



namespace TSCLIB_DLL_IN_C_Sharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrom());
        }
    }
}