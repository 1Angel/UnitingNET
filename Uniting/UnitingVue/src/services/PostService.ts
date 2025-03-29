import httpClient from "@/apiConfig/AxiosConfig"
import type { UserFeedResponse } from "@/types/IUserFeedResponse"

export const userFeed = async()=>{
    return httpClient.get<UserFeedResponse>('/communities/feed?pageNumber=1&pageSize=10');
}