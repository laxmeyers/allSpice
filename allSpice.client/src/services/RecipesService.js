import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import {api} from './AxiosService'

class RecipesService{
    async GetAllRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data;
    }

    async GetFavorites() {
        const res = await api.get('account/favorites')
        AppState.recipes = res.data
    }
}

export const recipesService = new RecipesService();