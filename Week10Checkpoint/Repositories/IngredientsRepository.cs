


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
        (name, quantity, recipeId)
        VALUES
        (@name, @quantity, @recipeId);
        SELECT
        ing.*
        FROM ingredients ing
        WHERE ing.id = LAST_INSERT_ID()
        ;";
    Ingredient newIngredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
    return newIngredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    string sql = @"
        DELETE FROM ingredients
        WHERE id = @ingredientId
        ;";
    _db.Execute(sql, new { ingredientId });
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
  SELECT
  *
  FROM ingredients
  WHERE recipeId = @recipeId
  ;";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    return ingredients;
  }

}
