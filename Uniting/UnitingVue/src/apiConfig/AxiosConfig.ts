import axios from 'axios'

const httpClient = axios.create({
  baseURL: 'https://localhost:7035/api',
})

httpClient.interceptors.request.use(req=>{

  const token = localStorage.getItem("access_token");

  req.headers.Authorization = `Bearer ${token}`;

  return req;

})

export default httpClient
