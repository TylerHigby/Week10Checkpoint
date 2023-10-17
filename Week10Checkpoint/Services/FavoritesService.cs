


namespace Week10Checkpoint.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _repo;
  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    Favorite newFavorite = _repo.CreateFavorite(favoriteData);
    return newFavorite;
  }

  internal void DeleteFavorite(int favoriteId)
  {
    _repo.DeleteFavorite(favoriteId);
  }

  internal List<RecipeFavoriteViewModel> GetFavoritesByAccount(string accountId)
  {
    List<RecipeFavoriteViewModel> favoriteRecipes = _repo.GetFavoritesByAccount(accountId);
    return favoriteRecipes;
  }
}