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
        private static int numberOfRecipes = 0;
        //public int Number { get; set; }

        public Recipe(string name, string ingredients, string preparations)
        {
            numberOfRecipes++;
            Name = name;
            Ingredients = ingredients;
            Preparations = preparations;
        }
        public void ShowContent()  // simple drawing the content on screen
        {
            Console.WriteLine("Recipe name: {0}", Name);
            Console.WriteLine("Ingredients: {0}", Ingredients);
            Console.WriteLine("Preparations: {0}", Preparations);
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
