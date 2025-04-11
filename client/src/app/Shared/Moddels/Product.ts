import { IPhoto } from "./Photo"

 export interface IProduct {
    id: number
    name: string
    description: string
    newPrice: number
    oldPrice: number
    stock: number
    categoryName: string
    photos: IPhoto[]
  }