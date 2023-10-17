import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class RecipesService{

  async getRecipes(){
    const res = await api.get('api/recipes')
    logger.log('got recipes', res.data)
    AppState.recipes = res.data.map(recipe => new Recipe(recipe))
  }

  async getRecipeById(recipeId){
const res = await api.get(`api/recipes/${recipeId}`)
logger.log('got recipe by Id', res.data)
AppState.activeRecipe = new Recipe(res.data)
  }
  async createRecipe(recipeData){
    const res = await api.post('api/recipes',recipeData)
    logger.log('Created Recipe', res.data)
    AppState.recipes.push(new Recipe(res.data))
  }


}

export const recipesService = new RecipesService