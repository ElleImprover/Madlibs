using System;

namespace Madlibs
{
    class Program
    {
        static void Main(string[] args)
        {
            AskQuestions();
        }

        public static void AskQuestions()
        {
            MadlibPartsOfSpeech parts = new();

            bool finished;
            do
            {
                Console.WriteLine("Hello!\nPlease answer the following questions:\n");
                Console.WriteLine("Enter the name of a boy.\n");
                parts.Noun = Console.ReadLine();
                Console.WriteLine("Enter a verb.\n");
                parts.Verb = Console.ReadLine();
                Console.WriteLine("Enter the past tense of a verb.\n");
                parts.Verb2 = Console.ReadLine();
                Console.WriteLine("Enter an adjective.\n");
                parts.Adjective = Console.ReadLine();
                Console.WriteLine("Enter an adverb.\n");
                parts.Adverb = Console.ReadLine();
                Console.WriteLine("Enter another adverb.\n");
                parts.Adverb2 = Console.ReadLine();
                Console.WriteLine("Enter a location.\n");
                parts.Location = Console.ReadLine();
                Console.WriteLine("Enter the type of a pet.\n");
                parts.TypeOfPet = Console.ReadLine();
                Console.WriteLine("Enter a name of pet.\n");
                parts.NameofPet = Console.ReadLine();

                Console.WriteLine("For the story, press Enter.\n");
                Console.ReadLine();
                Console.WriteLine("There was a boy named {0}.\n{0} liked to {1} his pet {2} named {3} {4}.\n" +
                                  "One day {3} {5} to the {6} and {0} didn't know where {3} was.\n{0}'s mother called all " +
                                  "of his friends together,and they searched for {3}.\nThey found {3} and {0} was happy. \n" +
                                  "The End :)", parts.Noun, parts.Verb, parts.TypeOfPet, parts.NameofPet, parts.Adverb, parts.Verb2, parts.Location);
                Console.ReadLine();
                Console.WriteLine("Press Enter to exit.\n");
                Console.ReadLine();
                finished = true;

            } while (!finished);
        }
    }
}
