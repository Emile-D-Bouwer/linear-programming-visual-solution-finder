using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPR281ASS1
{
    internal class MyFileReader
    {
        private List<string> lines;

        public List<string> Lines
        {
            get { return lines; }
        }

        public MyFileReader(string filePath)
        {
            string[] linesArr = File.ReadAllLines(filePath);
            lines = linesArr.ToList();
        }        
    }
}
