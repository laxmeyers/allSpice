namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal List<Favorite> GetFavorites()
        {
            throw new NotImplementedException();
        }

        internal Favorite MakeFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.MakeFavorite(favoriteData);
            return favorite;
        }
    }
}