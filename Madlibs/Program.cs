using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madlibs
{
    class Program
    {

        public static void Main(string[] args)
        {
            Data madlibData = new Data();

            ProcessData.AskQuestions(ProcessData.SelectMadLibFromList(madlibData.GenerateMadLibInfo()));
        }
        
    }
}


