namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
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