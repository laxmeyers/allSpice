<template>
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <slot></slot>
            <div class="modal-header">
                <h5 class="modal-title">recipe title</h5>
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
                                    <li class="d-flex justify-content-between border-bottom border-dark">{{ i.name }} {{ i.quantity }} <i title="delete ingredient" class="fs-5 mdi mdi-delete text-danger selectable text-end"></i> </li>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer d-flex justify-content-around">
                <button class="btn btn-outline-success me-5" data-bs-toggle="offcanvase">edit instructions</button>
                <form @submit.prevent="AddIngredient()">
                    <div class="form-floating">
                        <input v-model="editable.name" required type="text" class="form-control" id="floatingPassword" placeholder="Password">
                        <label for="floatingPassword">Ingredient name</label>
                    </div>
                    <div class="form-floating">
                        <input v-model="editable.quantity" required type="text" class="form-control" id="floatingPassword" placeholder="Password">
                        <label for="floatingPassword">Ingredient quantity</label>
                    </div>
                    <div class="text-end"><button type="submit" class="btn btn-outline-success">add ingredient</button></div>
                </form>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import {ingredientsService} from '../services/IngredientsService'

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            recipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients),
            async AddIngredient() {
                try {
                    const ingredient = editable.value
                    ingredient.recipeId = AppState.activeRecipe.id
                    await ingredientsService.AddIngredient(ingredient)
                    editable.value = {}
                } catch (error) {
                    Pop.error(err, '[making ingredient]')
                }
            }

        }
    }
}
</script>


<style lang="scss" scoped></style>