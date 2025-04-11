import { IProduct } from "./Product"

export interface IPagination {
    pageNumber: number
    pageSize: number
    totalCount: number
    data: IProduct[]
  }
  
  
  
  