using MyApplication.Domain.Enums;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Users;

namespace MS_Test
{
	internal class MockRecipeRepository : IRecipeRepository
	{
		private List<Recipe> recipes;
		public MockRecipeRepository(List<Recipe> recipes)
		{
			this.recipes = recipes;
		}

		public void CreateItem(Recipe item)
		{
			throw new NotImplementedException();
		}

		public void DeleteItem(int itemId)
		{
			throw new NotImplementedException();
		}

		public List<Recipe> GetActiveRecipesPerType(int id)
		{
			throw new NotImplementedException();
		}

		public Recipe GetItemById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Recipe> GetSimilarRecipes(string query)
		{
			return recipes.Where(x => x.Ingredients.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
		}

		public List<Recipe> ReadActiveItems()
		{
			return recipes;
		}

		public List<Recipe> ReadAllItems()
		{
			throw new NotImplementedException();
		}

		public List<Recipe> ReadUserFavorites(int user)
		{
			if (ReadActiveItems() != null)
			{
				return recipes.FindAll(x => x.authorid == user);
			}
			return null;
		}

		public List<Recipe> ReadUserRecipes(int id)
		{
            if (ReadActiveItems() != null)
            {
                return recipes.FindAll(x => x.authorid == id);
            }
            return null;
        }

		public void UpdateItem(Recipe item)
		{
			throw new NotImplementedException();
		}
	}
}
