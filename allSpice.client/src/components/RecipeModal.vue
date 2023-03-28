<template>
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <slot></slot>
            <div class="modal-header">
                <h5 class="modal-title">recipe title</h5>
                <button type="reset" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

            </div>
            <div class="modal-footer">
                <button type="reset" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Create Recipe</button>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    setup() {
        return {
            
        }
    }
}
</script>


<style lang="scss" scoped></style>