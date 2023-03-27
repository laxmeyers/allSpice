<template>
  <div class="container mt-2">
    <div class="row rounded header-background py-5">
      <div class="col-12 text-center text-light">
        <h1>All-Spice</h1>
        <h2>Cherish Your Family</h2>
        <h2>And Their Cooking</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-md-5 rounded sort-buttons m-auto p-3 d-flex justify-content-between bg-light">
        <button class="btn btn-outline-success" @click="GetAllRecipes()">Home</button>
        <button class="btn btn-outline-success">My Recipes</button>
        <button v-if="account.id" class="btn btn-outline-success" @click="GetFavorites()">Favorites</button>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="col-md-3 my-3 position-relative d-flex size" v-for="r in recipes">
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService'
import { onMounted, computed } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';

export default {
  setup() {
    async function GetAllRecipes() {
      try {
        await recipesService.GetAllRecipes();
      }
      catch (error) {
        Pop.error(error, "[getting alll recipes]");
      }
    }
    onMounted(() => {
      GetAllRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),

      async GetFavorites() {
        try {
          await recipesService.GetFavorites();
        } catch (error) {
          Pop.error(error, '[Getting my favorites]')
        }
      },
      async GetAllRecipes() {
        try {
          await recipesService.GetAllRecipes();
        }
        catch (error) {
          Pop.error(error, "[getting alll recipes]");
        }
      }
    };
  },
  components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.header-background {
  background-image: url("header.png");
  background-size: cover;
  background-position: center;
  box-shadow: 5px 5px 5px black;

}

.sort-buttons {
  transform: translateY(-20px);
  box-shadow: 5px 5px 10px black;
}

.size{
  height: 30vh;
}
</style>
