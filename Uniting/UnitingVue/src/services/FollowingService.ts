import httpClient from "@/apiConfig/AxiosConfig"

export const ToggleFollow = async(communityId: number)=>{
    return httpClient.post<string>(`/communities/${communityId}/follow`);
}