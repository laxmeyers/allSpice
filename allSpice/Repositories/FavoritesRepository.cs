namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite MakeFavorite(Favorite favoriteData)
        {
            string sql = @"
            Insert into favorites
            (recipeId, accountId)
            values
            (@recipeId, @accountId);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }
    }
}