import { environment } from 'src/environments/environment'

export const baseUrl = environment.production ? 'http://api.shoppingcart.com' : 'http://localhost:4000/api'
export const productUrl = baseUrl + '/product'
//export const cartUrl = baseUrl + '/cart'
