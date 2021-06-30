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
            AskQuestions();
        }

        public static void AskQuestions()
        {
            MadlibQA madlib = new();
            madlib.qaList = CreateMadLibQAList();
            
            bool finished;
            int id = 0;
            do
            {
                Console.WriteLine("Hello!\nPlease answer the following questions:\n");

                foreach (var q in madlib.qaList)
                {
                    Console.WriteLine(q.Question);
                    q.Answer = Console.ReadLine();
                    q.OrderID = id++;
                }

                Console.WriteLine("For the story, press Enter.\n");
                Console.ReadLine();

                Console.WriteLine(CreateMadLibString(madlib.qaList));
                Console.ReadLine();
                finished = true;
            } while (!finished);
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

        public static List<QA> CreateMadLibQAListFromQuestionList(List<string> questions)
        {
            List<QA> qAs = new List<QA>();
            foreach(var q in questions)
            {
                QA qA = new QA();
                qA.Question = q;
                qAs.Add(qA);
            }

            return qAs;
        }
        public static string CreateMadLibString(List<QA> qAs)
        {
            //int x = 0;
            string madLib = "";
            //madLib= "There was a boy named "+qAs[x].Answer+".\n"+ qAs[x].Answer+" liked to "+ qAs[x+1].Answer +" his "+ qAs[x + 3].Answer + " pet " + qAs[x + 7].Answer+" named "+ qAs[x + 8].Answer +" "+ qAs[x + 4].Answer+".\n" +
            //                      "One day " + qAs[x + 8].Answer +" "+ qAs[x + 2].Answer+" to the "+qAs[x + 6].Answer+" and "+ qAs[x].Answer+" didn't know where "+ qAs[x + 8].Answer+" was.\n"+ qAs[x].Answer+"'s mother called all " +
            //                      "of his friends together,and they searched for " + qAs[x + 8].Answer + ".\nThey found " + qAs[x + 8].Answer + " and "+ qAs[x].Answer + " was happy. \n" +
            //                      "The End :)";

            madLib = "There was a boy named " + qAs[0].Answer + ".\n" + qAs[0].Answer + " liked to " + qAs[1].Answer + " his " + qAs[3].Answer + " pet " + qAs[7].Answer + " named " + qAs[8].Answer + " " + qAs[4].Answer + ".\n" +
                      "One day " + qAs[8].Answer + " " + qAs[2].Answer + " to the " + qAs[6].Answer + " and " + qAs[0].Answer + " didn't know where " + qAs[8].Answer + " was.\n" + qAs[0].Answer + "'s mother called all " +
                      "of his friends together,and they searched for " + qAs[8].Answer + ".\nThey found " + qAs[8].Answer + " and " + qAs[x].Answer + " was happy. \n" +
                      "The End :)";
            var madLibSample = "There was a boy named {qAs[x].Answer}.\n{0} liked to {1} his pet {2} named {3} {4}.\n" +
                                  "One day {3} {5} to the {6} and {0} didn't know where {3} was.\n{0}'s mother called all " +
                                  "of his friends together,and they searched for {3}.\nThey found {3} and {0} was happy. \n" +
                                  "The End :)";
            return madLib;
        }
    
    public static string ParseAndCreateMadLibString(List<QA> qAs, string string2Parse)
    {
        int x = 0;
        string madLib = "";
        StringReader reader;
        char c;

        madLib = "There was a boy named *.* liked to * his pet * named * *.\n" +
                               "One day * * to the * and * didn't know where * was.\n*'s mother called all " +
                               "of his friends together,and they searched for *.\nThey found * and * was happy. \n" +
                               "The End :)";
            //for debugging puroses
          string2Parse = madLib;
          reader  = new StringReader(string2Parse);

            //while (!string2Parse.Contains("*"))
            //{

            //}

            //check string for the *; if * exists, replace with
            while (reader.Peek() != -1)
            {
               // ((reader.Read()) != -1)
            {  c = (char)reader.Read();

                    if (c.Equals("*")) {
                   // if (Char.GetNumericValue(c)!=-1)//if c is a number
                    { 
                        string2Parse = string2Parse.Replace("*", qAs[x].Answer);
                        x++; }
                } }
            return madLib;
    }
}
