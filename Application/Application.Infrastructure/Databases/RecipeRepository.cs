using Microsoft.Data.SqlClient;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;
using MyApplication.Infrastructure.Mapping;
using System.Data;

namespace MyApplication.Infrastructure.Databases
{
    public class RecipeRepository : IRecipeRepository
    {

        private string query = string.Empty;

        public void CreateItem(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    int recipeid;
                    //if(recipe.image != null)
                    query = SqlResource.InsertRecipe;
                    //else
                    //    query = SqlResource.InsertRecipeNoImage;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("authorid", recipe.authorid);
                        command.Parameters.AddWithValue("name", recipe.name);
                        command.Parameters.AddWithValue("desc", recipe.desc);
                        command.Parameters.AddWithValue("recipetype", recipe.recipetype);
                        command.Parameters.AddWithValue("Ingredients", recipe.Ingredients);
                        command.Parameters.AddWithValue("preptime", recipe.preptime);
                        command.Parameters.AddWithValue("cooktime", recipe.cooktime);
                        command.Parameters.AddWithValue("steps", recipe.steps);
                        //Handles null image
                        SqlParameter imageParameter = new SqlParameter("image", SqlDbType.VarBinary);
                        imageParameter.Value = (object)recipe.image ?? DBNull.Value;
                        command.Parameters.Add(imageParameter);

                        recipeid = Convert.ToInt32(command.ExecuteScalar());
                    }
                    switch (recipe)
                    {
                        case MainCourse maincourse:
                            query = SqlResource.InsertMainCourse;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeid", recipeid);
                                command.Parameters.AddWithValue("cuisinetype", maincourse.cuisineType);
                                command.Parameters.AddWithValue("servingsuggestion", maincourse.servingSuggestion);
                                command.ExecuteNonQuery();
                            }
                            query = SqlResource.InsertDietaryRestriction;
                            foreach (Diet diet in maincourse.dietaryType)
                            {
                                using (SqlCommand command = new SqlCommand(query, conn))
                                {
                                    command.Parameters.AddWithValue("mainCourseId", recipeid);
                                    command.Parameters.AddWithValue("DietId", diet);
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;
                        case Drink drink:
                            query = SqlResource.InsertDrink;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeid", recipeid);
                                command.Parameters.AddWithValue("alcoholic", drink.alcoholic);
                                command.Parameters.AddWithValue("drinktype", drink.drinkType);
                                command.Parameters.AddWithValue("glasstype", drink.glassType);
                                command.ExecuteNonQuery();
                            }
                            break;
                        case Dessert dessert:
                            query = SqlResource.InsertDessert;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeId", recipeid);
                                command.Parameters.AddWithValue("dessertType", dessert.dessertType);
                                command.Parameters.AddWithValue("servingMethod", dessert.servingMethod);
                                command.Parameters.AddWithValue("topping", dessert.topping);
                                command.ExecuteNonQuery();
                            }
                            break;
                    }
                }
            }
            catch
            {
                throw new InvalidDataException("Data cannot be added to database");
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.DeleteRecipe;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("recipeId", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    throw ex;
                else
                    throw new InvalidDataException("Data cannot be deleted");
            }
        }

        private int GetRecipeType(SqlConnection conn, int id)
        {
            query = "SELECT recipeid, FK_recipetype FROM recipe WHERE recipeid = @id";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(1);
                    }
                    throw new ArgumentNullException();
                }
            }
        }

        public Recipe GetItemById(int id)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    int type = GetRecipeType(conn, id);
                    switch (type)
                    {
                        case 1:
                            query = SqlResource.GetMainCourseById;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("id", id);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        return reader.MapToMainCourse(GetDietaryTypes(id), TotalLikes(Convert.ToInt32(reader["recipeId"])));
                                    }
                                    throw new Exception();
                                }
                            }
                        case 2:
                            query = SqlResource.GetDrinkById;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("id", id);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        return reader.MapToDrink(TotalLikes(Convert.ToInt32(reader["recipeId"])));
                                    }
                                    throw new Exception();
                                }
                            }
                        case 3:
                            query = SqlResource.GetDessertById;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("id", id);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        return reader.MapToDessert(TotalLikes(Convert.ToInt32(reader["recipeId"])));
                                    }
                                    throw new Exception();
                                }
                            }
                        default:
                            query = SqlResource.GetRecipeById;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("id", id);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        return reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"])));
                                    }
                                    throw new Exception();
                                }
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex != null)
                    throw ex;
                else
                    throw new InvalidDataException("Recipe id is invalid");
            }
        }

        private int TotalLikes(int recipeId)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                query = "SELECT COUNT(*) FROM favorite WHERE recipeId=@recipeid";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("recipeid", recipeId);
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader.GetInt32(0);
                        return 0;
                    }
                }
            }
        }

        public List<Recipe> ReadAllItems()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.ViewAllRecipes;
                    List<Recipe> recipes = new List<Recipe>();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                            }
                            return recipes;
                        }
                    }
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        private List<Diet> GetDietaryTypes(int id)
        {
            try
            {
                List<Diet> dietList = new List<Diet>();
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.GetDietaryTypes;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dietList.Add((Diet)reader.GetInt32(1));
                            }
                            return dietList;
                        }
                    }
                }
            }
            catch { throw new ArgumentNullException(); }
        }

        public List<Recipe> ReadUserRecipes(int id)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.ViewRecipesFromUser;
                    List<Recipe> recipes = new List<Recipe>();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("userId", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                            }
                            return recipes;
                        }
                    }
                }
            }
            catch { throw new ArgumentNullException(); }
        }
        public List<Recipe> ReadActiveItems()
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    query = SqlResource.ViewActiveRecipes;
                    List<Recipe> recipes = new List<Recipe>();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                            }
                            return recipes;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex == null)
                {
                    throw new ArgumentNullException();
                }
                throw ex;
            }
        }

        public List<Recipe> GetActiveRecipesPerType(int id)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                List<Recipe> recipes = new List<Recipe>();
                switch (id)
                {
                    default:
                        query = SqlResource.ViewActiveRecipesPerType;
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("type", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recipes.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                                }
                                return recipes;
                            }
                        }
                    case 1:
                        query = SqlResource.ViewActiveMainCourse;
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("type", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recipes.Add(reader.MapToMainCourse(GetDietaryTypes(Convert.ToInt32(reader[0])), TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                                }
                                return recipes;
                            }
                        }
                    case 2:
                        query = SqlResource.ViewActiveDrinks;
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("type", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recipes.Add(reader.MapToDrink(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                                }
                                return recipes;
                            }
                        }
                    case 3:
                        query = SqlResource.ViewActiveDesserts;
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("type", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recipes.Add(reader.MapToDessert(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                                }
                                return recipes;
                            }
                        }
                }

            }
        }

        public void UpdateItem(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    //int recipeid;
                    query = SqlResource.UpdateRecipe;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("recipeId", recipe.recipeid);
                        command.Parameters.AddWithValue("authorid", recipe.authorid);
                        command.Parameters.AddWithValue("name", recipe.name);
                        command.Parameters.AddWithValue("desc", recipe.desc);
                        command.Parameters.AddWithValue("recipetype", recipe.recipetype);
                        command.Parameters.AddWithValue("Ingredients", recipe.Ingredients);
                        command.Parameters.AddWithValue("preptime", recipe.preptime);
                        command.Parameters.AddWithValue("cooktime", recipe.cooktime);
                        command.Parameters.AddWithValue("steps", recipe.steps);
                        command.Parameters.AddWithValue("shown", recipe.shown);
                        //Handles null image
                        SqlParameter imageParameter = new SqlParameter("image", SqlDbType.VarBinary);
                        imageParameter.Value = (object)recipe.image ?? DBNull.Value;
                        command.Parameters.Add(imageParameter);

                        command.ExecuteNonQuery();
                    }
                    switch (recipe)
                    {
                        case MainCourse maincourse:
                            query = SqlResource.UpdateMainCourse;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeid", recipe.recipeid);
                                command.Parameters.AddWithValue("cuisinetype", maincourse.cuisineType);
                                command.Parameters.AddWithValue("servingsuggestion", maincourse.servingSuggestion);
                                command.ExecuteNonQuery();
                            }
                            query = "DELETE FROM [maincourse-diet] WHERE FK_MainCourseId = @id";
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("id", recipe.recipeid);
                                command.ExecuteNonQuery();
                            }
                            query = SqlResource.InsertDietaryRestriction;
                            foreach (var diet in maincourse.dietaryType)
                            {
                                using (SqlCommand command = new SqlCommand(query, conn))
                                {
                                    command.Parameters.AddWithValue("mainCourseId", recipe.recipeid);
                                    command.Parameters.AddWithValue("DietId", diet);
                                    command.ExecuteNonQuery();
                                }
                            }
                            break;
                        case Drink drink:
                            query = SqlResource.UpdateDrink;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeid", recipe.recipeid);
                                command.Parameters.AddWithValue("alcoholic", drink.alcoholic);
                                command.Parameters.AddWithValue("drinktype", drink.drinkType);
                                command.Parameters.AddWithValue("glasstype", drink.glassType);
                                command.ExecuteNonQuery();
                            }
                            break;
                        case Dessert dessert:
                            query = SqlResource.UpdateDessert;
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("recipeId", recipe.recipeid);
                                command.Parameters.AddWithValue("dessertType", dessert.dessertType);
                                command.Parameters.AddWithValue("servingMethod", dessert.servingMethod);
                                command.Parameters.AddWithValue("topping", dessert.topping);
                                command.ExecuteNonQuery();
                            }
                            break;
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Recipe> GetSimilarRecipes(string queries)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    string query = "SELECT r.*, u.username FROM recipe r LEFT JOIN [user] u ON r.FK_authorId = u.userID WHERE r.shown = 1 AND LOWER(ingredients) LIKE LOWER('%'+@query+'%')";
                    List<Recipe> recipes = new List<Recipe>();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@query", queries);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipes.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                            }
                            return recipes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    throw ex;
                else
                    throw new InvalidDataException();
            }
        }

        public List<Recipe> ReadUserFavorites(int user)
        {
            try
            {
                query = "SELECT f.UserId, r.*, u.username FROM recipe r LEFT JOIN favorite f ON r.recipeId" +
                    " = f.recipeId INNER JOIN [user] u ON r.FK_authorId = u.userid WHERE f.UserId = @userid";
                using (SqlConnection conn = Connection.GetConnection())
                {
                    List<Recipe> Comments = new List<Recipe>();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("userid", user);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Comments.Add(reader.MapTorecipe(TotalLikes(Convert.ToInt32(reader["recipeId"]))));
                            }
                            return Comments;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    throw ex;
                else
                    throw new InvalidDataException("User id is invalid");
            }
        }

    }
}
