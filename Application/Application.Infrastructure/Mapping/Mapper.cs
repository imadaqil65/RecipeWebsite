using Microsoft.Data.SqlClient;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Users;
using System.Data;

namespace MyApplication.Infrastructure.Mapping
{
    internal static class Mapper
    {
        private static T? GetValue<T>(SqlDataReader dataReader, string name)
        {
            if (dataReader.IsDBNull(name))
            {
                return default;
            }
            return dataReader.GetFieldValue<T>(name);
        }

        private static string GetStringValue(SqlDataReader dataReader, string name)
        {
            return GetValue<string>(dataReader, name) ?? string.Empty;
        }

        internal static Recipe MapTorecipe(this SqlDataReader reader, int TotalLikes)
        {
            return new Recipe(
                GetValue<int>(reader, "recipeId"),
                GetStringValue(reader, "name"),
                GetValue<int>(reader, "FK_authorId"),
                GetStringValue(reader, "username"),
                TotalLikes,
                GetStringValue(reader, "description"),
                (recipetype)GetValue<int>(reader, "FK_recipetype"),
                GetStringValue(reader, "Ingredients"),
                GetValue<int>(reader, "preptime"),
                GetValue<int>(reader, "cooktime"),
                GetStringValue(reader, "steps"),
                GetValue<bool>(reader, "shown"),
                GetValue<byte[]>(reader, "image")
            );
        }

        internal static MainCourse MapToMainCourse(this SqlDataReader reader, List<Diet> diets, int TotalLikes)
        {
            Recipe recipe = reader.MapTorecipe(TotalLikes);
            return new MainCourse(
                recipe.recipeid,
                recipe.name,
                recipe.authorid,
                recipe.author ?? string.Empty,
                recipe.TotalLikes,
                recipe.desc,
                recipe.recipetype,
                recipe.Ingredients,
                recipe.preptime,
                recipe.cooktime,
                recipe.steps,
                recipe.shown,
                recipe.image,
                GetStringValue(reader, "cuisineType"),
                diets,
                GetStringValue(reader, "servingSuggestion")
            );
        }

        internal static Drink MapToDrink(this SqlDataReader reader, int TotalLikes)
        {
            Recipe recipe = reader.MapTorecipe(TotalLikes);
            return new Drink(
                recipe.recipeid,
                recipe.name,
                recipe.authorid,
                recipe.author ?? string.Empty,
                recipe.TotalLikes,
                recipe.desc,
                recipe.recipetype,
                recipe.Ingredients,
                recipe.preptime,
                recipe.cooktime,
                recipe.steps,
                recipe.shown,
                recipe.image,
                GetValue<bool>(reader, "alcoholic"),
                GetStringValue(reader, "drinktype"),
                GetStringValue(reader, "glasstype")
                );
        }

        internal static Dessert MapToDessert(this SqlDataReader reader, int TotalLikes)
        {
            Recipe recipe = reader.MapTorecipe(TotalLikes);
            return new Dessert(
                recipe.recipeid,
                recipe.name,
                recipe.authorid,
                recipe.author ?? string.Empty,
                recipe.TotalLikes,
                recipe.desc,
                recipe.recipetype,
                recipe.Ingredients,
                recipe.preptime,
                recipe.cooktime,
                recipe.steps,
                recipe.shown,
                recipe.image,
                GetStringValue(reader, "dessertType"),
                GetStringValue(reader, "servingMethod"),
                GetStringValue(reader, "topping")
                );
        }

        internal static User MapToUserNoPasword(this SqlDataReader reader)
        {
            return new User(
                GetValue<int>(reader, "userID"),
                GetStringValue(reader, "username"),
                GetStringValue(reader, "firstname"),
                GetStringValue(reader, "middlename"),
                GetStringValue(reader, "lastname"),
                GetStringValue(reader, "email"),
                GetValue<bool>(reader, "admin"),
                GetValue<bool>(reader, "shown")
                ) ;
        }
        internal static User MapToUser(this SqlDataReader reader)
        {
            return new User(
                GetValue<int>(reader, "userID"),
                GetStringValue(reader, "username"),
                GetStringValue(reader, "password"),
                GetStringValue(reader, "firstname"),
                GetStringValue(reader, "middlename"),
                GetStringValue(reader, "lastname"),
                GetStringValue(reader, "email"),
                GetValue<bool>(reader, "admin"),
                GetValue<bool>(reader, "shown")
                );
        }

        internal static Comment MapToComment(this SqlDataReader reader)
        {
            return new Comment(
                GetValue<int>(reader, "CommentId"),
                GetValue<int>(reader, "recipeId"),
                GetValue<int>(reader, "userId"),
                GetStringValue(reader, "username"),
                GetStringValue(reader, "comment")
                );
                

        }
    }
}
