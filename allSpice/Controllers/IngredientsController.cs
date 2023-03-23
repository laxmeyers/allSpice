namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

        public IngredientsController(IngredientsService ingrediantsService, Auth0Provider auth)
        {
            _ingredientsService = ingrediantsService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Ingredient> AddIngrediant([FromBody] Ingredient ingredientData)
        {
            try
            {
                Ingredient ingredient = _ingredientsService.AddIngredient(ingredientData);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> RemoveIngredient(int id)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Ingredient ingredient = _ingredientsService.RemoveIngredient(id);
                return Ok($"removed {ingredient.Name}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}