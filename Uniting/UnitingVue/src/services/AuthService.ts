import httpClient from "@/apiConfig/AxiosConfig";
import type { AuthResponse } from "@/types/AuthResponse";


export const AuthService={

    LoginUser(email: string, password: string) {
        return httpClient.post<AuthResponse>('/auth/login', {email, password});
    }

}