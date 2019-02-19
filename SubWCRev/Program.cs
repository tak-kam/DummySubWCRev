using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SubWCRev
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length < 3)
            {
                return -1;
            }

            string template = args[1];
            string outpath = args[2];
            if (File.Exists(outpath))
            {
                return 0;
            }

            using (StreamReader sr = new StreamReader(template, true))
            using (StreamWriter sw = new StreamWriter(outpath))
            {
                while(sr.Peek() != -1)
                {
                    var line = sr.ReadLine();
                    var newline = line.Replace("$WCREV$", "0");
                    sw.WriteLine(newline);
                }
            }

            return 0;
        }
    }
}
