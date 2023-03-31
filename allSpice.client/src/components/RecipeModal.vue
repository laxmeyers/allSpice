<template>
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <!-- <slot></slot> -->
            <div class="modal-header">
                <button class="btn btn-danger" @click="DeleteRecipe(recipe)" data-bs-dismiss="modal">Delete Recipe</button>
                <h5 class="modal-title ps-3">{{ recipe.title }}</h5>
                <button type="reset" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-4">
                            <img class="img-fluid" :src="recipe.img" alt="">
                        </div>
                        <div class="col-4">
                            {{ recipe.instructions }}
                        </div>
                        <div class="col-4">
                            <div class="row">
                                <div class="col-12" v-for="i in ingredients">
                                    <li class="d-flex justify-content-between border-bottom border-dark">{{ i.name }} {{
                                        i.quantity }} <i v-if="account.id == recipe.creatorId" title="delete ingredient"
                                            class="fs-5 mdi mdi-delete text-danger selectable text-end" @click="DeleteIngredient(i)"></i> </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer d-flex justify-content-around" v-if="account.id == recipe.creatorId">
                <button class="btn btn-outline-success"
                    @click="change()">Edit Instructions</button>
                <div v-if="editMode">
                    <form @submit.prevent="EditInstructions()">
                        <div class="form-floating w-100">
                            <textarea v-model="editable2.instructions" type="text" class="form-control"
                                id="floatingPassword" placeholder="Password" required></textarea>
                            <label for="floatingPassword">Instructions</label>
                        </div>
                        <button type="submit" class="btn btn-outline-success">Save</button>
                    </form>
                </div>
                <form @submit.prevent="AddIngredient()">
                    <div class="form-floating">
                        <input v-model="editable.name" required type="text" class="form-control" id="floatingPassword"
                            placeholder="Password">
                        <label for="floatingPassword">Ingredient name</label>
                    </div>
                    <div class="form-floating">
                        <input v-model="editable.quantity" required type="text" class="form-control" id="floatingPassword"
                            placeholder="Password">
                        <label for="floatingPassword">Ingredient quantity</label>
                    </div>
                    <div class="text-end"><button type="submit" class="btn btn-outline-success">add ingredient</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService'
import { recipesService } from '../services/RecipesService';
import { useRouter } from 'vue-router';

export default {
    setup() {
        const editable = ref({})
        const editable2 = ref({})
        editable2.value = AppState.activeRecipe
        return {
            editable,
            editable2,
            recipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients),
            account: computed(() => AppState.account),
            editMode: computed(() => AppState.edit),
            async AddIngredient() {
                try {
                    const ingredient = editable.value
                    ingredient.recipeId = AppState.activeRecipe.id
                    await ingredientsService.AddIngredient(ingredient)
                    editable.value = {}
                } catch (error) {
                    Pop.error(error, '[making ingredient]')
                }
            },

            async DeleteRecipe(recipe) {
                try {
                    if (await Pop.confirm('Are you sure?')) {
                        await recipesService.DeleteRecipe(recipe)
                        Pop.success(`You deleted the recipe ${recipe.title}`)
                    }
                } catch (error) {
                    Pop.error(error)
                }
            },

            change() {
                try {
                    AppState.edit = !AppState.edit
                } catch (error) {
                    Pop.error(error, '[edit mode]')
                }
            },

            async EditInstructions() {
                try {
                    const instructions = editable2.value
                    await recipesService.EditInstructions(instructions)
                } catch (error) {
                    Pop.error(error, '[editing instructions]')
                }
            },

            async DeleteIngredient(ingredient) {
                try {
                    if (await Pop.confirm("You sure?")) {   
                        await recipesService.DeleteIngredient(ingredient)
                    }
                } catch (error) {
                    Pop.error(error, '[Deleting ingredient]')
                }
            }

        }
    }
}
</script>


<style lang="scss" scoped></style>