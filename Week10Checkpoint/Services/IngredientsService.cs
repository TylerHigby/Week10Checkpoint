

namespace Week10Checkpoint.Services;
public class IngredientsService
{
  private readonly IngredientsRepository _repo;
  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
    return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }
}