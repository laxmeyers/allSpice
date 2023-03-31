import { applyStyles } from '@popperjs/core';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';
import { logger } from '../utils/Logger';
import {api} from './AxiosService'

class RecipesService{
    async GetAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(r => new Recipe(r));
    }

    async GetFavorites() {
        const res = await api.get('account/favorites')
        AppState.favorites = res.data.map(r => new Recipe(r))
    }

    async SetFavorites() {
        AppState.recipes.forEach(r => {
            AppState.favorites.forEach(f => {
                if (r.id == f.id) {
                    r.favoriteId = f.favoriteId
                }
            })
        })
    }

    async UnfavoriteRecipe(recipe) {
        const res = await api.delete('api/favorites/' + recipe.favoriteId)
        recipe.favoriteId = 0
    }

    async FavoriteRecipe(recipe) {
        const res = await api.post('api/favorites', { recipeId: recipe.id })
        recipe.favoriteId = res.data.id
    }

    async CreateRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        AppState.recipes.push(new Recipe(res.data))
    }

    SetRecipe(recipe) {
        AppState.activeRecipe = {}
        AppState.activeRecipe = recipe
    }

    async getIngredients(recipeId) {
        AppState.ingredients = []
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.ingredients = res.data
    }

    async DeleteRecipe(recipe) {
        const res = await api.delete('api/recipes/' + recipe.id)
        const index = AppState.recipes.findIndex(r => r.id == recipe.id)
        AppState.recipes.splice(index, 1)
        AppState.activeRecipe = {}
        AppState.ingredients = []
    }

    async EditInstructions(instructions) {
        const res = await api.put('api/recipes/' + AppState.activeRecipe.id, instructions)
        AppState.activeRecipe.instructions = res.data.instructions
    }

    async DeleteIngredient(ingredient) {
        const res = await api.delete('api/ingredients/' + ingredient.id)
        let index = AppState.ingredients.findIndex(i => i.id == ingredient.id)
        AppState.ingredients.splice(index, 1)
    }
}

export const recipesService = new RecipesService();