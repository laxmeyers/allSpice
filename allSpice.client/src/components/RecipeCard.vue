<template>
    <img @click="SetRecipe(recipe)" data-bs-toggle="modal" data-bs-target="#recipeModal" :src="recipe.img"
        class="img-fluid same-size rounded selectable" alt="">
    <div class="rounded position-absolute justify-content-center w-75 recipe-title text-center text-light">
        <p class="m-0">{{ recipe.title }}</p>
    </div>
    <div class="rounded-pill position-absolute recipe-category text-light">
        <p class="m-0 px-2">{{ recipe.category }}</p>
    </div>
    <div class="rounded position-absolute recipe-heart text-light px-1 selectable">
        <i v-if="!recipe.favoriteId" class="mdi mdi-heart-outline text-danger fs-5" title="favorite"
            @click="FavoriteRecipe(recipe)"></i>
        <i v-else="!recipe.favoriteId" class="mdi mdi-heart text-danger fs-5" title="un-favorite"
            @click="UnfavoriteRecipe(recipe)"></i>
    </div>

    <Modal id="recipeModal">
        <RecipeModal></RecipeModal>
    </Modal>
</template>
<script>
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import Modal from './Modal.vue';

export default {
    props: {
        recipe: { type: Object, required: true }
    },
    setup() {
        return {
            async UnfavoriteRecipe(recipe) {
                try {
                    await recipesService.UnfavoriteRecipe(recipe);
                }
                catch (error) {
                    Pop.error(error, "[removing favorite]");
                }
            },
            async FavoriteRecipe(recipe) {
                try {
                    await recipesService.FavoriteRecipe(recipe);
                }
                catch (error) {
                    Pop.error(error, "[creating favorite]");
                }
            },
            async SetRecipe(recipe) {
                try {
                    await recipesService.SetRecipe(recipe)
                    await recipesService.getIngredients(recipe.id);
                } catch (error) {
                    Pop.error(error, '[setting active recipe]')
                }
            }
        };
    },
    components: { Modal }
}
</script>


<style lang="scss" scoped>
.same-size {
    height: 100%;
    width: 100%;
    object-fit: cover;
}

.recipe-title {
    bottom: 10px;
    left: 50%;
    transform: translate(-50%, 0);
    background-color: #7e7e7e88;
}

.recipe-category {
    top: 10px;
    left: 20px;
    background-color: #7e7e7e88;
}

.recipe-heart {
    top: 0px;
    right: 20px;
    background-color: #7e7e7e88;
}
</style>