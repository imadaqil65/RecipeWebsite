using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Users;
using System.Runtime.CompilerServices;

namespace Web_Application.DTO
{
    public class Mapper
    {
        private static byte[]? ConvertImageToByte(IFormFile img)
        {
            byte[] content = null;
            if (img != null)
            {
                using MemoryStream ms = new MemoryStream();
                img.CopyTo(ms);
                content = ms.ToArray();
            }
            return content;
        }

        private static Recipe ReturnUpdatedRecipeFields(Recipe updRecipe, RecipeDTO recipe)
        {
            updRecipe.name = recipe.recipeName;
            updRecipe.desc = recipe.description;
            //updRecipe.recipetype = recipe.Recipetype;
            updRecipe.Ingredients = recipe.ingredients;
            updRecipe.steps = recipe.steps;
            updRecipe.preptime = recipe.preptime;
            updRecipe.cooktime = recipe.cooktime;
            if (updRecipe.image == null)
            {
                updRecipe.image = ConvertImageToByte(recipe.image);
            }
            return updRecipe;
        }

        public static MainCourse setMainCourse(RecipeDTO recipe, MainCourseDTO mainCourse, List<Diet> diets, int Userid)
        {
            return new MainCourse(recipe.recipeName, Userid, recipe.description, recipe.Recipetype, recipe.ingredients, recipe.preptime, recipe.cooktime, recipe.steps, true, ConvertImageToByte(recipe.image), mainCourse.cuisineType, diets, mainCourse.servingSuggestion);
        }

        public static MainCourse UpdateMainCourse(RecipeDTO recipe, MainCourseDTO mainCourse, List<Diet> diets, MainCourse updRecipe)
        {
            ReturnUpdatedRecipeFields(updRecipe, recipe);
            updRecipe.cuisineType = mainCourse.cuisineType;
            updRecipe.servingSuggestion = mainCourse.servingSuggestion;
            updRecipe.dietaryType = diets;
            
            return updRecipe;
        }

        public static Drink setDrink(RecipeDTO recipe, DrinkDTO drink, int Userid)
        {
            return new Drink(recipe.recipeName, Userid, recipe.description, recipe.ingredients, recipe.Recipetype, recipe.preptime, recipe.cooktime, recipe.steps, true, ConvertImageToByte(recipe.image), drink.alcoholic, drink.drinkType, drink.glassType);
        }

        public static Drink UpdateDrink(RecipeDTO recipe, DrinkDTO drink, Drink updRecipe)
        {
            ReturnUpdatedRecipeFields(updRecipe, recipe);
            updRecipe.alcoholic = drink.alcoholic;
            updRecipe.glassType = drink.glassType;
            updRecipe.drinkType = drink.drinkType;

            return updRecipe;
        }

        public static Dessert setDessert(RecipeDTO recipe, DessertDTO dessert, int Userid)
        {
            return new Dessert(recipe.recipeName, Userid, recipe.description, recipe.Recipetype, recipe.ingredients, recipe.preptime, recipe.cooktime, recipe.steps, true, ConvertImageToByte(recipe.image), dessert.dessertType, dessert.servingMethod, dessert.topping);
        }

        public static Dessert UpdateDessert(RecipeDTO recipe, DessertDTO dessert, Dessert updRecipe)
        {
            ReturnUpdatedRecipeFields(updRecipe, recipe);
            updRecipe.dessertType = dessert.dessertType;
            updRecipe.servingMethod = dessert.servingMethod;
            updRecipe.topping = dessert.topping;

            return updRecipe;
        }
    }
}
