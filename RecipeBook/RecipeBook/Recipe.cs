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

        public Recipe(string name, string ingredients, string preparations)
        {
            Name = name;
            Ingredients = ingredients;
            Preparations = preparations;
        }
    }
}
