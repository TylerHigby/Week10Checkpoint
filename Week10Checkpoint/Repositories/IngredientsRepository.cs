

namespace Week10Checkpoint.Repositories;
public class IngredientsRepository
{
  private readonly IDbConnection _db;
  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
        INSERT INTO ingredients
        (name, quantity, recipeId, img)
        VALUES
        (@name, @quantity, @recipeId, @img);
        SELECT
        ing.*
        FROM ingredients ing
        WHERE ing.id = LAST_INSERT_ID()
        ;";
    Ingredient newIngredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
    return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
        SELECT
        ing.*,
        rec.*
        FROM ingredients ing
        JOIN recipes rec ON rec.id = ing.recipeId
        WHERE recipeId = @recipeId
        ;";
    List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipeId) =>
    {
      ingredient.RecipeId = recipeId;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }
}
