using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCLIB_DLL_IN_C_Sharp
{
    class ZTest
    {
        public void test()
        {
            string kb = "1";
            string t = "";
            bool dot = false;
            if (kb == ".")
            {
                Console.WriteLine("KB มี .");
                if (t != "")
                {
                    int i = 0;
                    for (i = 0; i < t.Length; i++)
                    {
                        if (t.Substring(i, 1) == kb)
                        {
                            Console.WriteLine("มี");
                            dot = true;
                            break;
                        }
                    }
                    if (dot == false)
                    {
                        t = t + kb;
                    }
                }
            }
            else
            {
                t = t + kb;
            }



            Console.WriteLine("xxxxxx " + t);
        }

    }
}
