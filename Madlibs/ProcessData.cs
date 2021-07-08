using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madlibs
{
    //Create database and JSON to hold 
    class ProcessData
    { 
        public static MadlibQA SelectMadLibFromList(List<MadlibQA> madlibs)
        {
            int id = -1;
            bool success = false;
            Console.WriteLine("Hello!\nPlease select one of the following madlibs by entering the ID:\n");
            foreach (var madlib in madlibs) {
                Console.WriteLine($"{madlib.ID}: {madlib.Name}");
            }
            while (!success) {
                if (Int32.TryParse(Console.ReadLine(), out id)) {
                    success = true;
                }
                else {
                    Console.WriteLine("Please enter a numeric integer value.");
                } 
            }
            return madlibs.Find(x => x.ID == id);

        }
        public static void AskQuestions(MadlibQA madlib)
        {
            bool finished;
            int id = 0;
            do
            {
                Console.WriteLine("Please answer the following questions:\n");

                foreach (var q in madlib.qaList)
                {
                    Console.WriteLine(q.Question);
                    q.Answer = Console.ReadLine();
                    q.OrderID = id++;
                }

                Console.WriteLine("For the story, press Enter.\n");
                Console.ReadLine();

                Console.WriteLine(ParseAndCreateMadLibString(madlib.qaList, madlib.MadLib));

                Console.ReadLine();
                finished = true;
            } while (!finished);
        }

        public static string ParseAndCreateMadLibString(List<QA> qAs, string string2Parse = "")
        {
            foreach (var qA in qAs)  {
                string2Parse = string2Parse.Replace(qA.OrderID.ToString(), qA.Answer);
            } 
            return string2Parse;
        }
    }
}
