<template>
    <!-- <div class="offcanvas offcanvas-start" tabindex="1" 
        aria-labelledby="staticBackdropLabel">
        <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="staticBackdropLabel">Instructions</h5>
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <form @submit.prevent="EditInstructions()">
                <div class="form-floating">
                    <textarea v-model="editable.instructions" type="text" class="form-control" id="floatingPassword"
                        placeholder="Password" required></textarea>
                    <label for="floatingPassword">Instructions</label>
                </div>
                <button type="submit" class="btn btn-outline-success">Save</button>
            </form>
        </div>
    </div> -->
    <div class="offcanvas offcanvas-start" data-bs-backdrop="static" tabindex="-2" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
        <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="offcanvasExampleLabel">Offcanvas</h5>
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <form @submit.prevent="EditInstructions()">
                <div class="form-floating">
                    <textarea v-model="editable.instructions" type="text" class="form-control" id="floatingPassword"
                        placeholder="Password" required></textarea>
                    <label for="floatingPassword">Instructions</label>
                </div>
                <button type="submit" class="btn btn-outline-success">Save</button>
            </form>
        </div>
    </div>
</template>


<script>
import { ref } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import RecipeModal from './RecipeModal.vue';

export default {
    setup() {
        const editable = ref(AppState.activeRecipe);
        return {
            editable,
            async EditInstructions() {
                try {
                    logger.log("hello");
                }
                catch (error) {
                    Pop.error(error, "[editing instructions]");
                }
            }
        };
    },
    components: { RecipeModal }
}
</script>


<style lang="scss" scoped></style>