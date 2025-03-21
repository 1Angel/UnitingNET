import httpClient from "@/apiConfig/AxiosConfig";
import type { AuthResponse } from "@/types/AuthResponse";
import type { User } from "@/types/IUser";
import type { AxiosResponse } from "axios";


export const LoginUser = async(email: string, password: string):Promise<AxiosResponse<AuthResponse>>=>{
    return httpClient.post<AuthResponse>('/auth/login', {email: email, password: password});
}

export const GetCurrentUser = async()=>{
    return httpClient.get<User>('/auth/current-user');
}