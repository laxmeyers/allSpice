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
        <button class="btn btn-outline-success" @click="ChangeRecipes(0)">Home</button>
        <button class="btn btn-outline-success" @click="ChangeRecipes(1)">My Recipes</button>
        <button v-if="account.id" class="btn btn-outline-success" @click="ChangeRecipes(2)">Favorites</button>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="col-md-3 my-3 position-relative d-flex size" v-for="r in recipes">
        <RecipeCard :recipe="r" />
      </div>
    </div>
    <div class="row sticky-bottom p-3">
      <div class="col-12 text-end">
        <button class="btn btn-success mdi mdi-plus" title="Add Recipe" data-bs-toggle="modal" data-bs-target="#recipeForm"></button>
      </div>
    </div>
  </div>

  <Modal id="recipeForm">
    <RecipeForm></RecipeForm>
  </Modal>
</template>

<script>
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService'
import { onMounted, computed, watchEffect, ref } from 'vue';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeForm from '../components/RecipeForm.vue';

export default {
  setup() {
    const filter = ref(0)
    async function GetAllRecipes() {
      try {
        await recipesService.GetAllRecipes();
      }
      catch (error) {
        Pop.error(error, "[getting alll recipes]");
      }
    }
      async function GetFavorites() {
        try {
          await recipesService.GetFavorites();
          await recipesService.SetFavorites();
        }
        catch (error) {
          Pop.error(error, "[getting alll recipes]");
        }
      }
      onMounted(() => {
        GetAllRecipes();
      });

      watchEffect(() => {
        if (AppState.account?.id) {
          GetFavorites()
        }
      })

      return {
        recipes: computed(() => {
          if (!filter.value) {
            return AppState.recipes
          } else if (filter.value == 1) {
            return AppState.recipes.filter(r => r.creatorId == AppState.account.id)
          } else {
            return AppState.recipes.filter(r => r.favoriteId != 0)
          }
        }),
        account: computed(() => AppState.account),

        async ChangeRecipes(recipes) {
          filter.value = recipes
        },
      };
    },
    components: { RecipeCard, RecipeForm }
}
</script>

<style scoped lang="scss">
.header-background {
  background-image: url(/header.png);
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
