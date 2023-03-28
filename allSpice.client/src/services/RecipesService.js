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
}

export const recipesService = new RecipesService();