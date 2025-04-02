import httpClient from "@/apiConfig/AxiosConfig"
import type { IUser } from "@/types/IUser";


export const GetUserProfile = async()=>{
    return httpClient.get<IUser>('/auth/current-user');
}