using MyApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Recipes
{
    public class Recipe
    {
        public int recipeid { get; private set; }
        public string name { get; set; }
        public string? author { get; set; }
        public int authorid { get; set; }
        public int TotalLikes { get; private set; }
        public string desc { get; set; }
        public recipetype recipetype { get; set; }
        public string Ingredients { get; set; }
        public int preptime { get; set; }
        public int cooktime { get; set; }
        public string steps { get; set; }
        public bool shown { get; set; }
        public byte[]? image { get; set; }

        public Recipe(string name, int authorid, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image)
        {
            this.name = name;
            this.authorid = authorid;
            this.desc = desc;
            this.recipetype = recipetype;
            this.Ingredients = Ingredients;
            this.preptime = preptime; //in minutes
            this.cooktime = cooktime; //in minutes
            this.steps = steps;
            this.shown = shown;
            this.image = image;
        }

        public Recipe(int recipeid, string name, int authorid, string author,int TotalLikes, string desc, recipetype recipetype, string Ingredients, int preptime, int cooktime, string steps, bool shown, byte[]? image)
        {
            this.recipeid = recipeid;
            this.name = name;
            this.authorid = authorid;
            this.author = author;
            this.TotalLikes = TotalLikes;
            this.desc = desc;
            this.recipetype = recipetype;
            this.Ingredients = Ingredients;
            this.preptime = preptime; //in minutes
            this.cooktime = cooktime; //in minutes
            this.steps = steps;
            this.shown = shown;
            this.image = image;
        }

    }
}
