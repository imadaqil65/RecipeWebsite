using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Services
{
    public class RecipeServices
    {
        private readonly IRecipeRepository datasource;
        public RecipeServices(IRecipeRepository datasource)
        {
            this.datasource = datasource;
        }

        public void CreateRecipe(Recipe recipe)
        {
            try
            {
                datasource.CreateItem(recipe);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRecipe(Recipe recipe)
        {
            datasource.UpdateItem(recipe);
        }

        public Recipe GetRecipeById(int id)
        {
            return datasource.GetItemById(id);
        }

        public IReadOnlyCollection<Recipe> ViewAllRecipes()
        {
            return datasource.ReadAllItems();
        }

        public IReadOnlyCollection<Recipe> ViewActiveRecipes()
        {
            return datasource.ReadActiveItems();
        }

        public IReadOnlyCollection<Recipe> GetActiveRecipesPerType(int id)
        {
            return datasource.GetActiveRecipesPerType(id);
        }

        public IReadOnlyCollection<Recipe> ViewRecipesFromUser(int id)
        {
            return datasource.ReadUserRecipes(id);
        }

        public IReadOnlyCollection<Recipe> ViewUserFavorites(int user)
        {
            return datasource.ReadUserFavorites(user);
        }

        public void DeleteRecipes(int id)
        {
            datasource.DeleteItem(id);
        }
    }
}
