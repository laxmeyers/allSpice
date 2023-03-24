namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite DeleteFavorite(int id, string userId)
        {
            Favorite favorite = _repo.GetOneFavorite(id);
            if (favorite == null) throw new Exception("This favorite doesn't exist");
            if (favorite.AccountId != userId) throw new Exception("this isn't yours");
            int rows = _repo.DeleteFavorite(id);
            if (rows == 0) throw new Exception("We couldn't delete this for some reason");
            if (rows > 1) throw new Exception("We deleted more than one...");
            return favorite;
        }

        internal List<FavoriteRecipe> GetFavorites(string userId)
        {
            List<FavoriteRecipe> favorites = _repo.GetFavorites(userId);
            return favorites;
        }

        internal Favorite MakeFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.MakeFavorite(favoriteData);
            return favorite;
        }
    }
}