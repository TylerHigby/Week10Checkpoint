namespace Week10Checkpoint.Controllers;
[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0;
  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
  {
    _ingredientsService = ingredientsService;
    _auth0 = auth0;
  }

  // [Authorize]
  [HttpPost]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      // ingredientData.CreatorId = userInfo.Id;
      Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData);
      return newIngredient;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{ingredientId}")]
  public ActionResult<string> DeleteIngredient(int ingredientId)
  {
    try
    {
      _ingredientsService.DeleteIngredient(ingredientId);
      return "Ingredient Deleted";
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}