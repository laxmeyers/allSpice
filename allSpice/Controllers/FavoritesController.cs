namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
        {
            _favoritesService = favoritesService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> MakeFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite favorite = _favoritesService.MakeFavorite(favoriteData);
                return Ok(favorite);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteFavorite(int id)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Favorite favorite = _favoritesService.DeleteFavorite(id, userInfo.Id);
                return Ok("your favorite was deleted you know the one.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}