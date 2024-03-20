using MyApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Recipes
{
    public class Dessert : Recipe
    {
        public string dessertType { get; set; }
        public string servingMethod { get; set; }
        public string topping { get; set; }

        public Dessert(int recipeid, string name, int authorid, string author, int TotalLikes, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image, string dessertType, string servingMethod, string topping) : base(recipeid, name, authorid, author, TotalLikes, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.dessertType = dessertType;
            this.servingMethod = servingMethod;
            this.topping = topping;
        }

        public Dessert(string name, int authorid, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image, string dessertType, string servingMethod, string topping) : base(name, authorid, desc, recipetype, Ingredients, preptime, cooktime, steps, shown, image)
        {
            this.dessertType = dessertType;
            this.servingMethod = servingMethod;
            this.topping = topping;
        }
    }
}
