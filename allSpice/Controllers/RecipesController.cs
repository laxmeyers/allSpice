namespace allSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _auth = auth;
            _ingredientsService = ingredientsService;
        }


        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Recipe>> MakeRecipe([FromBody] Recipe recipeData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.MakeRecipe(recipeData);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Recipe>> Get()
        {
            try
            {
                List<Recipe> recipes = _recipesService.Get();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            try
            {
                Recipe recipe = _recipesService.Get(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipe>> EditRecipe(int id, [FromBody] Recipe recipeData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.EditRecipe(id, recipeData);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteRecipe(int id)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Recipe recipe = _recipesService.DeleteRecipe(id, userInfo.Id);
                return Ok($"{recipe.Title} was deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientsInRecipe(int recipeId)
        {
            try
            {
                List<Ingredient> ingredients = _ingredientsService.GetIngredientsInRecipe(recipeId);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}