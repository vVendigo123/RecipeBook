using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    class Recipe
    {
        public string Name { get; }
        public string Ingredients { get; }
        public string Preparations { get; }
        public int Id { get; }
        private static int numberOfRecipes = 0;   // READ ABOUT INITIALIZING static variables!!!
        //public int Number { get; set; }

        public Recipe(string name, string ingredients, string preparations)
        {
            numberOfRecipes++;
            Name = name;
            Ingredients = ingredients;
            Preparations = preparations;
            Id = 0;
        }
        public Recipe(string name, string ingredients, string preparations, int id)
        {
            numberOfRecipes++;
            Name = name;
            Ingredients = ingredients;
            Preparations = preparations;
            Id = id;
        }
        public void ShowContent()  // simple drawing the content on screen
        {
            Console.WriteLine("Recipe name: {0}", Name);
            Console.WriteLine("\nIngredients:\n{0}", Ingredients);
            Console.WriteLine("\nPreparations:\n{0}", Preparations);
        }
        public static int NumberOfRecipes()
        {
            return numberOfRecipes;
        }
        public static void Delete()
        {
            numberOfRecipes--;
        }
    }
}
