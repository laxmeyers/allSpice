namespace allSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        private readonly RecipesService _recipeService;

        public IngredientsService(IngredientsRepository repo, RecipesService recipeService)
        {
            _repo = repo;
            _recipeService = recipeService;
        }

        internal Ingredient AddIngredient(Ingredient ingredientData)
        {
            _recipeService.Get(ingredientData.RecipeId);
            Ingredient ingredient = _repo.AddIngredient(ingredientData);
            return ingredient;
        }

        internal List<Ingredient> GetIngredientsInRecipe(int recipeId)
        {
            _recipeService.Get(recipeId);
            List<Ingredient> ingredients = _repo.GetIngredientsInRecipe(recipeId);
            return ingredients;
        }

        internal Ingredient RemoveIngredient(int id, string userId)
        {
            Ingredient ingredient = _repo.FindIngredient(id);
            if (ingredient == null) throw new Exception("This ingredient isn't here.");
            Recipe recipe = _recipeService.Get(ingredient.RecipeId);
            if (recipe.CreatorId != userId) throw new Exception("This isnt your recipe");
            int rows = _repo.RemoveIngredient(id);
            if (rows == 0) throw new Exception("Unable to find ingredient to delete");
            if (rows > 1) throw new Exception("more than one ingredient removed");
            return ingredient;

        }
    }
}