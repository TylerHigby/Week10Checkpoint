

namespace Week10Checkpoint.Services;
public class RecipesService
{
  private readonly RecipesRepository _repo;
  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe Create(Recipe recipeData)
  {
    Recipe newRecipe = _repo.Create(recipeData);
    return newRecipe;
  }

  internal Recipe DeleteRecipe(int recipeId, string userId)
  {
    Recipe recipe = this.GetRecipeById(recipeId);
    if (recipe.CreatorId != userId) throw new Exception("That isn't yours to delete!");
    _repo.DeleteRecipe(recipeId);
    return recipe;

  }

  internal List<Recipe> Get()
  {
    List<Recipe> recipes = _repo.Get();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe foundRecipe = _repo.GetRecipeById(recipeId);
    if (foundRecipe == null) throw new Exception($"There's no recipe with the id of {recipeId}");
    return foundRecipe;
  }

  internal Recipe UpdateRecipe(Recipe updateData)
  {
    Recipe original = this.GetRecipeById(updateData.Id);
    //FIXME - Need to verify ownership here
    original.Title = updateData.Title != null ? updateData.Title : original.Title;
    original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;
    original.Category = updateData.Category != null ? updateData.Category : original.Category;
    Recipe recipe = _repo.UpdateRecipe(original);
    return recipe;
  }
}


