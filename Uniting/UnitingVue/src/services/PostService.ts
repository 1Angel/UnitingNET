import httpClient from "@/apiConfig/AxiosConfig"
import type { UserFeedResponse } from "@/types/IUserFeedResponse"

export const userFeed = async()=>{
    return httpClient.get<UserFeedResponse>('/communities/feed?pageNumber=1&pageSize=10');
}


export const createPost = async(communityId: number, description: string | undefined)=>{
    return httpClient.post(`/communities/${communityId}/posts`, {description: description});
}