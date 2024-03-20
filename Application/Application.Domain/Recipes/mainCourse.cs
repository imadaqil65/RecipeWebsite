using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApplication.Domain.Enums;

namespace MyApplication.Domain.Recipes
{
    public class MainCourse:Recipe
    {
        public string cuisineType { get; set; }
        public List<Diet> dietaryType { get; set; }
        public string servingSuggestion { get; set; }

        public MainCourse(int recipeid, string name, int authorid, string author, int TotalLikes, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image, string cuisineType, List<Diet> dietaryType, string servingSuggestion) : base(recipeid, name, authorid, author, TotalLikes, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.dietaryType = dietaryType;
            this.servingSuggestion = servingSuggestion;
            this.cuisineType=cuisineType;
        }

        public MainCourse(string name, int authorid, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image, string cuisineType, List<Diet> dietaryType, string servingSuggestion) : base(name, authorid, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.dietaryType = dietaryType;
            this.servingSuggestion = servingSuggestion;
            this.cuisineType = cuisineType;
        }
    }
}
