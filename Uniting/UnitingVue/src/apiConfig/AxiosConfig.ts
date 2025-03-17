import axios from 'axios'

const httpClient = axios.create({
  baseURL: 'https://localhost:7035/api',
})

export default httpClient
