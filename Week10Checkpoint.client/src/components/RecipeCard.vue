<template>
  <!-- <router-link :to="{name: 'Recipe Details', params: {recipeId: recipe.id}}"> -->
<div @click="getRecipeDetails()" data-bs-toggle="modal" data-bs-target="#recipe-modal" class="card elevation-5">
<h2 class="text-center p-2">{{ recipe.title }}</h2>
<img :src="recipe.img" alt="" class="recipeCardImage">
<div class="fs-4 p-2 text-center">{{ recipe.category }}</div>
<!-- <div class="col-6">{{ recipe.creator.name }}</div> -->
<!-- <div class="col-6"> <img :src="recipe.creator.picture" alt=""> </div> -->
</div>
<!-- </router-link> -->
</template>

<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";

export default {
  props: {recipe: {type: Recipe, required: true}},
setup(props) {
  return {
    async getRecipeDetails(){
      try {
        logger.log(props.recipe.id)
        const recipeId = props.recipe.id
        await recipesService.getRecipeById(recipeId)
      } catch (error) {
        Pop.error(error)
      }
    }
  };
},
};
</script>


<style>
.recipeCardImage{
  width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center;
}
</style>