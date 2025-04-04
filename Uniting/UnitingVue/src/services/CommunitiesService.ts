import httpClient from "@/apiConfig/AxiosConfig"
import type { CommunityDetailsResponse } from "@/types/CommunityDetailsResponse"
import type { ICommunity } from "@/types/ICommunity";

export const GetCommunitiesPosts = async(communityId: number)=>{
    return httpClient.get<CommunityDetailsResponse>(`/communities/${communityId}/posts?pageSize=10&pageNumber=1`);
}

export const getCommunityDetails = async(id: number)=>{
    return httpClient.get<ICommunity>(`/communities/${id}`);
}