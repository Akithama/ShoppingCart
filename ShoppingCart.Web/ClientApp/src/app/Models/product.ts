export class Product {
    id: number;
    name: string;
    description: string;
    price: number;
    url: string;
    categoryId: number

    constructor(id, name, description, price, imageUrl, categoryId) {
        this.id = id
        this.name = name
        this.description = description
        this.price = price
        this.url = imageUrl
        this.categoryId = categoryId
    }
}
