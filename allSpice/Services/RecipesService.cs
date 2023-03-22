namespace allSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe MakeRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.MakeRecipe(recipeData);
            return recipe;
        }
    }
}