using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple RecipeBook");
            bool done = false;

            const int maxNumber = 100;
            Recipe[] recipes = new Recipe[maxNumber];

            // Recipes are made NULL
            for(int i = 0; i < maxNumber; i++)
            {
                recipes[i] = null;
            }

            while(!done)
            {
                Console.WriteLine("Select an action: ");
                Console.WriteLine("1. Add a recipe.");
                Console.WriteLine("2. Open a recipe.");
                Console.WriteLine("0. Exit.");

                int choice = ReadInt("", 0, 3);

                switch(choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 0:
                        done = true;
                        break;
                    default:
                        break;
                }
            }
        }

        // Reading STRING
        static string ReadString(string prompt = "Enter text: ", string error = "You must enter at least one character!")
        {
            bool isGood = false;
            string wynik;
            do
            {
                Console.Write(prompt);
                wynik = Console.ReadLine();
                if (wynik.Length >= 1)
                    isGood = true;
                if (!isGood)
                    Console.WriteLine(error);
            } while (!isGood);
            return wynik;
        }
        // Reading INT
        static int ReadInt(string prompt = "Enter a number: ", int min = int.MinValue, int max = int.MaxValue, string error = "You have entered a wrong number!")
        {
            bool isGood = false;
            int wynik;
            do
            {
                bool isDouble = int.TryParse(ReadString(prompt), out wynik);
                if ((wynik >= min) && (wynik <= max) && isDouble)
                    isGood = true;
                if (!isGood)
                    Console.WriteLine(error);
            } while (!isGood);
            return wynik;
        }
    }
}
