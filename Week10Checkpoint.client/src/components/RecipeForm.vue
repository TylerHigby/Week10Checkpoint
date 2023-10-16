<template>
  <form @submit.prevent="createRecipe" class="row">
    <h1 class="text-center p-3">CREATE A RECIPE</h1>
    <!-- Title -->
  <div class="mb-3 col-6">
    <label for="" class="form-label">Title:</label>
    <input v-model="recipeData.title" type="text" class="form-control" required>
  </div>
  <!-- CATEGORY -->
  <div class="mb-3 col-6">
    <label for="" class="form-label">Category:</label>
    <input v-model="recipeData.category" type="text" class="form-control" required>
  </div>
  <!-- INSTRUCTIONS -->
  <div class="mb-3">
    <label for="" class="form-label">Instructions:</label>
    <textarea v-model="recipeData.instructions" type="text" class="form-control" required></textarea>
  </div>
  <!-- IMAGE -->
  <div class="mb-3">
    <label for="" class="form-label">Cover Image:</label>
    <input v-model="recipeData.img" type="url" class="form-control" required>
  </div>
  <button type="submit" class="btn btn-primary col-12">Submit Recipe</button>
</form>
</template>

<script setup>
import {onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js";

const recipeData = ref({})


async function createRecipe(){
  try {
    await recipesService.createRecipe(recipeData.value)
    Pop.success("Recipe Created")
  } catch (error) {
    Pop.error(error)
  }
}



</script>


<style>
</style>