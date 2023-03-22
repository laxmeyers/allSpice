namespace allSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int DeleteRecipe(int id)
        {
            string sql = @"
            Delete From recipes where id = @id;
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal List<Recipe> GetAllRecipes()
        {
            string sql = @"
            Select
            recipes.*,
            accounts.*
            from recipes
            JOIN accounts ON accounts.id = creatorId;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (rec, profile) =>
            {
                rec.Creator = profile;
                return rec;
            }
            ).ToList();
            return recipes;
        }

        internal Recipe GetOneRecipe(int id)
        {
            string sql = @"
            Select
            recipes.*,
            accounts.*
            from recipes
            JOIN accounts ON accounts.id = creatorId
            where recipes.id = @id;
            ";
            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (rec, pro) =>
            {
                rec.Creator = pro;
                return rec;
            }, new { id }).FirstOrDefault();
            return recipe;
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

        internal int Updated(Recipe original)
        {
            string sql = @"
            Update recipes
            Set
            id = @id,
            title = @title,
            instructions = @instructions,
            img = @img,
            category = @category,
            creatorId = @creatorId
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, original);
            return rows;
        }
    }
}