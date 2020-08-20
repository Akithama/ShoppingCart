export class Product {
  productId: number;
  productName: string;
  description: string;
  price: number;
  url: string;
  quantity: number;
  categoryId: number

  constructor(id, name, description, price, imageUrl, categoryId) {
    this.productId = id
    this.productName = name
    this.description = description
    this.price = price
    this.url = imageUrl
    this.categoryId = categoryId
  }
}
