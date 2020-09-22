import { OrderDetail } from './orderDetail'

export class Order {
    orderId: number
    customerName: string
    noOfProducts: string
    status: string
    total: number
    dateorder: Date
    orderDetail:OrderDetail[]
    
}