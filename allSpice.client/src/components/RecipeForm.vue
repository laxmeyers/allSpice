<template>
    <form @submit.prevent="CreateRecipe()">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Recipe</h5>
                    <button type="reset" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form-floating mb-3">
                        <input v-model="editable.title" type="text" class="form-control" id="floatingInput"
                            placeholder="name@example.com" required>
                        <label for="floatingInput">Title</label>
                    </div>
                    <div class="form-floating mb-3">
                        <input v-model="editable.img" type="url" class="form-control" id="floatingInput"
                            placeholder="name@example.com" required>
                        <label for="floatingInput">Image</label>
                    </div>
                    <div class="form-floating mb-3">
                        <input v-model="editable.category" type="text" class="form-control" id="floatingInput"
                            placeholder="name@example.com" required>
                        <label for="floatingInput">Category</label>
                    </div>
                    <div class="form-floating">
                        <textarea v-model="editable.instructions" type="text" class="form-control" id="floatingPassword"
                            placeholder="Password" required></textarea>
                        <label for="floatingPassword">instructions</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="reset" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Create Recipe</button>
                </div>
            </div>
        </div>
    </form>
</template>


<script>
import { ref } from 'vue';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async CreateRecipe() {
                try {
                    const recipeData = editable.value
                    await recipesService.CreateRecipe(recipeData)
                    editable.value = {}
                } catch (error) {
                    Pop.error(error, '[creating recipe]')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>