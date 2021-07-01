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
            List<string> questionList1 = CreateQuestionListBoy();
            List<string> questionList2 = CreateQuestionListGirl();
            List<string> questionList3 = CreateQuestionListLife();

            string madLibstringBoy =  "There was a boy named 0.\n0 liked to 1 his 3 pet 7 named 8 4.\n" +
                                      "One day 8 2 to the 6 and 0 didn't know where 8 was.\n0's mother called all " +
                                      "of his friends together,and they searched for 8.\nThey found 8 and 0 was happy. \n" +
                                      "The End :)";
            string madLibstringGirl = "There was a girl named 0.\n0 liked to 1 her 3 pet 7 named 8 4.\n" +
                                      "One day 8 2 to the 6 and 0 didn't know where 8 was.\n0's mother called all " +
                                      "of her friends together,and they searched for 8.\nThey found 8 and 0 was happy. \n" +
                                      "The End :)";
            string madLibLife       = "One day 0 and 1 were walking from 2 and they discovered a 3.\nThe 3 4 at them so they 5 home. " +
                                       "0 and 1 learned to that day 6.";

            MadlibQA madlib1 = CreateMadLib(1, "Boy with Pet", madLibstringBoy, questionList1);
            MadlibQA madlib2 = CreateMadLib(2, "Girl with Pet", madLibstringGirl, questionList2);
            MadlibQA madlib3 = CreateMadLib(3, "Life", madLibLife, questionList3);

            List<MadlibQA> madLibList = new List<MadlibQA>();
            madLibList.Add(madlib1);
            madLibList.Add(madlib2);
            madLibList.Add(madlib3);

            AskQuestions(SelectMadLibFromList(madLibList));
        }
        public static MadlibQA SelectMadLibFromList(List<MadlibQA> madlibs)
        {
            int id = -1;
            bool success = false;
            Console.WriteLine("Hello!\nPlease select one of the following madlibs by entering the ID:\n");
            foreach(var madlib in madlibs)
            {
                Console.WriteLine($"{madlib.ID}: {madlib.Name}");
            }
            while (!success)
            {
                if (Int32.TryParse(Console.ReadLine(), out id))
                {
                    success = true;
                }
                else
                {
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

                Console.WriteLine(ParseAndCreateMadLibString(madlib.qaList,madlib.MadLib));

                Console.ReadLine();
                finished = true;
            } while (!finished);
        }
        public static List<string> CreateQuestionListBoy()
        {
            List<string> qAs = new List<string>();
            qAs.Add("Enter the name of a boy.");
            qAs.Add("Enter a verb.");
            qAs.Add("Enter the past tense of a verb.");
            qAs.Add("Enter an adjective.");
            qAs.Add("Enter an adverb.");
            qAs.Add("Enter another adverb.");
            qAs.Add("Enter a location.");
            qAs.Add("Enter the type of pet.");
            qAs.Add("Enter the name of the pet.");

            return qAs;
        }
        public static List<string> CreateQuestionListGirl()
        {
            List<string> qAs = new List<string>();
            qAs.Add("Enter the name of a girl.");
            qAs.Add("Enter a verb.");
            qAs.Add("Enter the past tense of a verb.");
            qAs.Add("Enter an adjective.");
            qAs.Add("Enter an adverb.");
            qAs.Add("Enter another adverb.");
            qAs.Add("Enter a location.");
            qAs.Add("Enter the type of pet.");
            qAs.Add("Enter the name of the pet.");

            return qAs;
        }
        public static List<string> CreateQuestionListLife()
        {
            List<string> qAs = new List<string>();
            qAs.Add("Enter the name of a boy.");
            qAs.Add("Enter the name of a girl.");
            qAs.Add("Enter a location.");
            qAs.Add("Enter a noun.");
            qAs.Add("Enter the past tense of a verb.");
            qAs.Add("Enter the past tense of another verb.");
            qAs.Add("Enter a life lesson.");
            return qAs;
        }

        public static MadlibQA CreateMadLib(int id, string name, string madLib, List<string> questions)
        {
            MadlibQA madlib = new MadlibQA();
            madlib.qaList = CreateMadLibQAListFromQuestionList(questions);
            madlib.ID = id;
            madlib.Name = name;
            madlib.MadLib = madLib;
            return madlib;
        }
        public static List<QA> CreateMadLibQAListFromQuestionList(List<string> questions)
        {
            List<QA> qAs = new List<QA>();
            foreach (var q in questions)  {
                QA qA = new QA();
                qA.Question = q;
                qAs.Add(qA);
            }

            return qAs;
        }

        public static string ParseAndCreateMadLibString(List<QA> qAs, string string2Parse = "")
        {  
            foreach(var qA in qAs) {
            string2Parse=string2Parse.Replace(qA.OrderID.ToString(), qA.Answer); }

            return string2Parse;
        }

        public static List<QA> CreateMadLibQAList()
        {
            List<QA> qAs = new List<QA>();

            QA qA1 = new QA();
            qA1.Question = "Enter the name of a boy.";
            qAs.Add(qA1);

            QA qA2 = new QA();
            qA2.Question = "Enter a verb.";
            qAs.Add(qA2);

            QA qA3 = new QA();
            qA3.Question = "Enter the past tense of a verb.";
            qAs.Add(qA3);

            QA qA4 = new QA();
            qA4.Question = "Enter an adjective.";
            qAs.Add(qA4);

            QA qA5 = new QA();
            qA5.Question = "Enter an adverb.";
            qAs.Add(qA5);

            QA qA6 = new QA();
            qA6.Question = "Enter another adverb.";
            qAs.Add(qA6);

            QA qA7 = new QA();
            qA7.Question = "Enter a location.";
            qAs.Add(qA7);

            QA qA8 = new QA();
            qA8.Question = "Enter the type of pet.";
            qAs.Add(qA8);

            QA qA9 = new QA();
            qA9.Question = "Enter the name of the pet.";
            qAs.Add(qA9);

            return qAs;
        }

    }
}


