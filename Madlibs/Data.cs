using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madlibs
{

    //Microsoft documentation for ADO.NET

    public class Data
    {
        public List<MadlibQA> GenerateMadLibInfo()
        {
            List<string> questionList1 = CreateQuestionListBoy();
            List<string> questionList2 = CreateQuestionListGirl();
            List<string> questionList3 = CreateQuestionListLife();

            string madLibstringBoy = "There was a boy named 0.\n0 liked to 1 his 3 pet 7 named 8 4.\n" +
                                      "One day 8 2 to the 6 and 0 didn't know where 8 was.\n0's mother called all " +
                                      "of his friends together,and they searched for 8.\nThey found 8 and 0 was happy. \n" +
                                      "The End :)";
            string madLibstringGirl = "There was a girl named 0.\n0 liked to 1 her 3 pet 7 named 8 4.\n" +
                                      "One day 8 2 to the 6 and 0 didn't know where 8 was.\n0's mother called all " +
                                      "of her friends together,and they searched for 8.\nThey found 8 and 0 was happy. \n" +
                                      "The End :)";
            string madLibLife = "One day 0 and 1 were walking from 2 and they discovered a 3.\nThe 3 4 at them so they 5 home. " +
                                       "0 and 1 learned to that day 6.";

            MadlibQA madlib1 = CreateMadLib(1, "Boy with Pet", madLibstringBoy, questionList1);
            MadlibQA madlib2 = CreateMadLib(2, "Girl with Pet", madLibstringGirl, questionList2);
            MadlibQA madlib3 = CreateMadLib(3, "Life", madLibLife, questionList3);

            List<MadlibQA> madLibList = new List<MadlibQA>();
            madLibList.Add(madlib1);
            madLibList.Add(madlib2);
            madLibList.Add(madlib3);

            return madLibList;
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
            madlib.MadLib = madLib;//Call to database
            return madlib;
        }
        public static List<QA> CreateMadLibQAListFromQuestionList(List<string> questions)//Generate list with call to database
        {
            List<QA> qAs = new List<QA>();
            foreach (var q in questions)
            {
                QA qA = new QA();
                qA.Question = q;
                qAs.Add(qA);
            }

            return qAs;
        }

        


    }
}
