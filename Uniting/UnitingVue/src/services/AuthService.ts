import httpClient from "@/apiConfig/AxiosConfig";
import type { AuthResponse } from "@/types/AuthResponse";


export const AuthService={

    LoginUser(email: string, password: string) {
        return httpClient.post<AuthResponse>('/auth/login', {email, password});
    }

export const RegisterUser= async(username: string, email: string, password: string)=>{
    return httpClient.post<AuthResponse>('/auth/register', {username: username, email: email, password: password});
}

export const GetCurrentUser = async()=>{
    return httpClient.get<User>('/auth/current-user');
}
