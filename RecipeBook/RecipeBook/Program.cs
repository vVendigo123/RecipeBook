using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace RecipeBook
{
    class Program
    {       
        static void Main(string[] args)
        {
            bool done = false;

            const int maxNumber = 100;
            Recipe[] recipes = new Recipe[maxNumber];

            // Recipes are made NULL
            for(int i = 0; i < maxNumber; i++)
            {
                recipes[i] = null;
            }

            int[] deletedIds = new int[maxNumber];

            //Loading recipes from Database!

            LoadRecipes(maxNumber, recipes);
            Console.Clear();
            Console.WriteLine("\t\t\t\tSimple RecipeBook");
            Console.ReadKey();

            while(!done)
            {
                Console.Clear();
                Console.WriteLine("Select an action: ");  // THIS SECTION NEEDS TO BE REWRITTEN
                Console.WriteLine("1. Add a recipe.");
                Console.WriteLine("2. Open a recipe.");
                Console.WriteLine("3. Delete a recipe.");
                Console.WriteLine("0. Exit.");

                int choice = ReadInt("", 0, 3);

                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        AddRecipe(recipes);
                        break;
                    case 2:
                        Console.Clear();
                        OpenRecipe(recipes);
                        break;
                    case 3:
                        Console.Clear();
                        DeleteRecipe(maxNumber, recipes, deletedIds);
                        break;
                    case 0:
                        UpdateRecipes(Recipe.NumberOfRecipes(), recipes, deletedIds);//UpdateRecipes(Recipe.NumberOfRecipes(), recipes);
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
        static void AddRecipe(Recipe[] recipes) // using private static variable by creating new objects of the class Recipe
        {
            if(Recipe.NumberOfRecipes() < (recipes.Length-1))
            {
                recipes[Recipe.NumberOfRecipes()] = CreateRecipe();
            }
            else
                Console.WriteLine("There is no more space for new recipes. Please delete a recipe to add one");

        }
        static void OpenRecipe(Recipe[] recipes) // Opening recipes is not ready yet // LIST OF RECIPES TO BE ADDED
        {
            Console.WriteLine("Currently you have {0}/{1} recipes.", Recipe.NumberOfRecipes(), recipes.Length);
            if (Recipe.NumberOfRecipes() > 0)
            {
                int number = ReadInt("Enter a number of a recipe: ", 0, Recipe.NumberOfRecipes());
                if (number == 0)
                    return;
                Console.Clear();
                recipes[number - 1].ShowContent();
            }
            Console.ReadKey();
        }

        static void DeleteRecipe(int maxNumber, Recipe[] recipes, int[] deletedIds)
        {
            Console.WriteLine("Currently you have {0}/{1} recipes.", Recipe.NumberOfRecipes(), recipes.Length);
            if (Recipe.NumberOfRecipes() > 0)
            {
                int number = ReadInt("Enter a number of a recipe to delete: ", 0, Recipe.NumberOfRecipes());
                if (number == 0)
                    return;
                for(int i = 0; i < maxNumber; i++)
                {
                    if(deletedIds[i] == 0)
                    {
                        deletedIds[i] = recipes[number-1].Id;
                        break;
                    }
                }
                recipes[number - 1] = recipes[Recipe.NumberOfRecipes() - 1];
                recipes[Recipe.NumberOfRecipes() - 1] = null;
                Recipe.Delete();
                Console.WriteLine("Recipe number {0} was deleted succesfully.", number);
            }
            Console.ReadKey();
        }

        static void LoadRecipes(int maxNumber, Recipe[] recipes)
        {
            //Establishing connection with local MySql Database
            string connectionString = "server=localhost;user=vvendigo;database=recipe_book_db;port=3306;password=password";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();

                string sql = $"SELECT * FROM recipes LIMIT {maxNumber};";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while(reader.Read())
                {
                    recipes[index] = new Recipe(reader["name"].ToString(), reader["ingredients"].ToString(), 
                        reader["preparations"].ToString(), int.Parse(reader["id"].ToString()));
                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }
        static void UpdateRecipes(int numberOfRecipes, Recipe[] recipes, int[] deletedIds)
        {
            //Establishing connection with local MySql Database
            string connectionString = "server=localhost;user=vvendigo;database=recipe_book_db;port=3306;password=password";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();

                string sql = "";
                MySqlCommand command = new MySqlCommand(sql, connection);
                for(int i = 0; i < deletedIds.Length; i++)
                {
                    if(deletedIds[i] != 0)
                    {
                        command.CommandText = $"DELETE FROM recipes WHERE id='{deletedIds[i]}';";
                        command.ExecuteNonQuery();
                    }
                }
                for(int i = 0; i < numberOfRecipes; i++)
                {
                    Console.WriteLine(numberOfRecipes);

                    if (recipes[i].Id == 0)
                    {
                        command.CommandText = "INSERT INTO recipes(name, ingredients, preparations)" +
                                $"VALUES('{recipes[i].Name}', '{recipes[i].Ingredients}', '{recipes[i].Preparations}');";
                        command.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
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
