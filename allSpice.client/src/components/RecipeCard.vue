<template>
        <img :src="recipe.img" class="img-fluid same-size rounded" alt="">
    <div class="rounded position-absolute justify-content-center w-75 recipe-title text-center text-light">
        <p class="m-0">{{ recipe.title }}</p>
    </div>
    <div class="rounded-pill position-absolute recipe-category text-light">
        <p class="m-0 px-2">{{ recipe.category }}</p>
    </div>
    <div class="rounded position-absolute recipe-heart text-light px-1 selectable">
        <i class="mdi mdi-heart-outline text-danger fs-5" title="favorite"></i>
    </div>
</template>


<script>
export default {
    props: {
        recipe: { type: Object, required: true }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>

.same-size{
    height:100%;
    width: 100%;
    object-fit:cover;
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