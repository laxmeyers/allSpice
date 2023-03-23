namespace allSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient AddIngredient(Ingredient ingredientData)
        {
            string sql = @"
            Insert Into ingredients
            (name, quantity, recipeId)
            values
            (@name, @quantity, @recipeId);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;

        }

        internal List<Ingredient> GetIngredientsInRecipe(int recipeId)
        {
            string sql = @"
            Select 
            * 
            from ingredients 
            where recipeId = @recipeId;
            ";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
            return ingredients;
        }

        internal Ingredient FindIngredient(int id)
        {
            string sql = @"
            Select 
            * 
            from ingredients 
            where id = @id;
            ";
            Ingredient ingredient = _db.Query<Ingredient>(sql, new { id }).FirstOrDefault();
            return ingredient;
        }

        internal int RemoveIngredient(int id)
        {
            string sql = @"
            Delete from ingredients 
            where id = @id;
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }
    }
}