namespace allSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe EditRecipe(int id, Recipe recipeData)
        {
            Recipe original = this.Get(id);
            if (original.CreatorId != recipeData.CreatorId) throw new Exception("You dont own this recipe.");
            original.Title = recipeData.Title != null ? recipeData.Title : original.Title;
            original.Instructions = recipeData.Instructions != null ? recipeData.Instructions : original.Instructions;
            int rows = _repo.Updated(original);
            if (rows == 0) throw new Exception("unable to edit recipe.");
            if (rows > 1) throw new Exception("Edited more than one recipe.");
            return original;
        }

        internal List<Recipe> Get()
        {
            List<Recipe> recipes = _repo.GetAllRecipes();
            return recipes;
        }

        internal Recipe Get(int id)
        {
            Recipe recipe = _repo.GetOneRecipe(id);
            if (recipe == null) throw new Exception("This recipe doesn't exist");
            return recipe;
        }

        internal Recipe MakeRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.MakeRecipe(recipeData);
            return recipe;
        }
    }
}