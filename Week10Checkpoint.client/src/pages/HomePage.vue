<template>
  <div class="container">
    <!-- //ANCHOR - RECIPE CREATE FORM -->
    <section class="row" v-if="user.isAuthenticated">
      <RecipeForm/>
    </section>
    <!-- //ANCHOR - RECIPE CARDS -->
    <section class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4 my-3">
        <!-- {{ recipe.title }} -->
        <RecipeCard :recipe="recipe"/>
      </div>
    </section>
  </div>
</template>

<script>
import {computed, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { recipesService } from '../services/RecipesService.js';
import { AppState } from "../AppState.js";
import RecipeForm from '../components/RecipeForm.vue';

export default {
  setup() {
onMounted(() => {
  getRecipes();
});

async function getRecipes(){
  try {
    await recipesService.getRecipes();
  } catch (error) {
    Pop.error(error);
  }
}


    return {
      user: computed(()=> AppState.user),
      recipes: computed(()=> AppState.recipes),
      activeRecipe: computed(()=> AppState.activeRecipe)
    };
  },
  components: {RecipeForm}
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
