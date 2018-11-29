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

        static Recipe CreateRecipe()
        {
            string name = ReadString("Enter the recipe name: ");
            string ingredients = ReadString("Enter the ingredients(use Spacebar to separate them): ");
            string preparations = ReadString("Enter the preparations: ");
            Recipe recipe = new Recipe(name, ingredients, preparations);
            return recipe;
        }
        static void AddRecipe(Recipe[] recipes) // simple adding recipes to an array
        {
            bool noSpace = true;
            for(int i = 0; i < recipes.Length; i++)
            {
                if(recipes[i] == null)
                {
                    recipes[i] = CreateRecipe();
                    noSpace = false;
                    break;
                }
            }
            if (noSpace)
                Console.WriteLine("There is no more space for new recipes. Please delete a recipe to add one");

        }
        static void OpenRecipe(Recipe[] recipes) // Opening recipes is not ready yet
        {
            int numberOfRecipes = 0;
            for(int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] != null)
                    numberOfRecipes++;
            }
            Console.WriteLine("Currently you have {0}/{1} recipes.", numberOfRecipes, recipes.Length);
            int number = ReadInt("Enter a number of a recipe: ", 1, numberOfRecipes);
            for(int i = 0; i < ; i++)
            {
                // End this
            }
        }

        // Reading STRING
        static string ReadString(string prompt = "Enter text: ", string error = "You must enter at least one character!")
        {
            bool isGood = false;
            string outcome;
            do
            {
                Console.Write(prompt);
                outcome = Console.ReadLine();
                if (outcome.Length >= 1)
                    isGood = true;
                if (!isGood)
                    Console.WriteLine(error);
            } while (!isGood);
            return outcome;
        }
        // Reading INT
        static int ReadInt(string prompt = "Enter a number: ", int min = int.MinValue, int max = int.MaxValue, string error = "You have entered a wrong number!")
        {
            bool isGood = false;
            int outcome;
            do
            {
                bool isDouble = int.TryParse(ReadString(prompt), out outcome);
                if ((outcome >= min) && (outcome <= max) && isDouble)
                    isGood = true;
                if (!isGood)
                    Console.WriteLine(error);
            } while (!isGood);
            return outcome;
        }
    }
}
