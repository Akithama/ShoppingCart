export class Product {
  productId: number
  productName: string
  description: string
  price: number
  url: string
  quantity: number
  categoryId: number
  items: number
  specification: string
  specDetails: any[]

  constructor(id, name, description, price, imageUrl, categoryId, quantity, items, specification,specDetails) {
    this.productId = id
    this.productName = name
    this.description = description
    this.price = price
    this.url = imageUrl
    this.categoryId = categoryId
    this.quantity = quantity
    this.items = items
    this.specification = specification
    this.specDetails = specDetails
  }
}
