using MyApplication.Domain.Algorithm;
using MyApplication.Domain.Algorithm.RecommendationStrategies;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Recipes;

namespace MS_Test
{
    [TestClass]
    public class UnitTest
    {

        [TestClass]
        public class RecommendationStrategyTests
        {
            private List<Recipe> MockRecipes = new List<Recipe>
            {
                new Recipe(
                    1, "Fatha Shawarma", 1,"mock", 7, "mock", recipetype.Maincourse, "rice, chicken, beef, vegetables, potato", 1, 1, "mock", true, null),
                new Recipe(
                    2, "Omelette", 2, "mock", 19, "mock", recipetype.Maincourse, "eggs, chili, spices, salt, pepper", 1, 1, "mock", true, null),
                new Recipe(
                    3, "Herbal milk tea", 1, "mock", 30, "mock", recipetype.Drink, "spices, tea, condensed milk", 1, 1, "mock", true, null),
                new Recipe(
                    4, "Paella", 3, "mock", 3,"mock", recipetype.Maincourse, "yogurt, rice, seafood", 1, 1, "mock", true, null),
                new Recipe(
                    5, "Vanilla pudding", 2, "mock", 12, "mock", recipetype.Dessert, "pudding, vanilla, milk", 1, 1, "mock", true, null),
                new Recipe(
                    6, "Sponge Cake", 1, "mock", 20, "mock", recipetype.Dessert, "butter, flour, eggs, sugar", 1, 1, "mock", true, null),
                new Recipe(
                    7, "Hot Cocoa", 3, "mock", 30, "mock", recipetype.Drink, "cocoa, milk, sugar", 1, 1, "mock", true, null),
            };

            private List<Recipe> EmptyList = new List<Recipe>();

            [TestMethod]
            public void LikeBasedRecommendation_Successful()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(MockRecipes), new LikeBasedRecommendation());
                List<int> Order = new List<int> { 3, 7, 6, 2 };

                // Act
                var result = strategy.RecommendRecipes(null);
                List<int> OrderResult = new List<int>();
                foreach(var r in result)
                {
                    OrderResult.Add(r.recipeid);
                }

                // Assert
                Assert.IsNotNull(result);
                CollectionAssert.AreEqual(Order, OrderResult);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void LikeBasedRecommendation_Failure()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(EmptyList), new LikeBasedRecommendation());

                // Act
                var result = strategy.RecommendRecipes(null);

                // Assert
                // Expected ArgumentNullException
            }

            [TestMethod]
            public void RandomBasedRecommendation_Successful()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(MockRecipes), new RandomBasedRecommendation());

                // Act
                var result = strategy.RecommendRecipes(null);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);
                Assert.IsTrue(result.Count == 4);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void RandomBasedRecommendation_Failure()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(EmptyList), new RandomBasedRecommendation());

                // Act
                var result = strategy.RecommendRecipes(null);

                // Assert
                // Expected ArgumentNullException
            }

            [TestMethod]
            public void IngredientsBasedRecommendation_Successful()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(MockRecipes), new IngredientsBasedRecommendation());
                int CodeOfLikedRecipes = 2;
                //Since there is no relationship table,
                //the Likes will be represented by other User ID

                // Act
                var result = strategy.RecommendRecipes(CodeOfLikedRecipes);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);
            }

            [TestMethod]
            public void IngredientsBasedRecommendation_EmptyFavorites()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(MockRecipes), new IngredientsBasedRecommendation());
                int CodeOfLikedRecipes = 4;
                //Since there is no relationship table,
                //the Likes will be represented by other User ID

                // Act
                var result = strategy.RecommendRecipes(CodeOfLikedRecipes);

                //Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 0);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void IngredientsBasedRecommendation_Failure()
            {
                // Arrange
                var strategy = new RecommendationStrategy(new MockRecipeRepository(null), new IngredientsBasedRecommendation());
                int CodeOfLikedRecipes = 1; 
                //Since there is no relationship table,
                //the Likes will be represented by other User ID

                // Act
                var result = strategy.RecommendRecipes(CodeOfLikedRecipes);

                // Assert
                // Expected ArgumentNullException
            }
        }

    }
}