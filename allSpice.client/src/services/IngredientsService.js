import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService{
    async AddIngredient(ingredient) {
        const res = await api.post('api/ingredients', ingredient)
        AppState.ingredients.push(res.data)
    }
}

export const ingredientsService = new IngredientsService()