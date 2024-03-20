using MyApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Recipes
{
    public class Drink : Recipe
    {
        public bool alcoholic { get; set; }
        public string drinkType { get; set; }
        public string glassType { get; set; }

        public Drink(string name, int authorid, string desc, string Ingredients, recipetype recipetype, int preptime, int cooktime, string steps, bool shown, byte[]? image, bool alcoholic, string drinkType, string glassType) : base(name, authorid, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.alcoholic = alcoholic;
            this.drinkType = drinkType;
            this.glassType = glassType;
        }

        public Drink(int recipeid, string name, int authorid, string author, int TotalLikes, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image, bool alcoholic, string drinkType, string glassType) : base(recipeid, name, authorid, author, TotalLikes, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.alcoholic = alcoholic;
            this.drinkType = drinkType;
            this.glassType = glassType;
        }
    }
}
