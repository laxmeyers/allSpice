namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<FavoriteRecipe> GetFavorites(string id)
        {
            string sql = @"
            Select 
            rec.*,
            fav.id as favoriteId,
            acct.* 
            from favorites fav
            join recipes rec on rec.id = fav.recipeId
            join accounts acct on acct.id = fav.accountId
            where accountId = @id;
            ";
            List<FavoriteRecipe> favorites = _db.Query<FavoriteRecipe, Account, FavoriteRecipe>(sql, (favorite, account) =>
            {
                favorite.Creator = account;
                return favorite;
            }, new { id }).ToList();
            return favorites;

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

        internal Favorite GetOneFavorite(int id)
        {
            string sql = @"
            Select 
            * 
            from favorites 
            where id = @id;
            ";
            Favorite favorite = _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
            return favorite;
        }

        internal int DeleteFavorite(int id)
        {
            string sql = @"
            Delete
            from favorites 
            where id = @id;
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }
    }
}