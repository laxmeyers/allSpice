namespace allSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe MakeRecipe(Recipe recipeData)
        {
            string sql = @"
            Insert Into recipes
            (title, instructions, img, category, creatorId)
            Values
            (@title, @instructions, @img, @category, @creatorId);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }
    }
}