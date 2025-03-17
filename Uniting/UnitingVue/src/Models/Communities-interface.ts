export interface Response {
  pageNumber: number
  pageSize: number
  totalCount: number
  data: Communities[]
}

export interface Communities {
  id: number
  name: string
  description: string
  createdDate: Date
}
