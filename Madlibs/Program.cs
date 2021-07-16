using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Madlibs
{
   public class Program
    { 
        public static void Main(string[] args)  {
            Data madlibData = new Data();

            DatabaseData databaseData = new DatabaseData();

            //ProcessData.AskQuestions(ProcessData.SelectMadLibFromList(madlibData.GenerateMadLibInfo()));
            ProcessData.AskQuestions(ProcessData.SelectMadLibFromList(databaseData.CreateMadLibListFromSQL()));//CreateMadLibListFromSQL
        }
        
    }
}


