import { GetCurrentUser } from "@/services/AuthService";
import type { AuthResponse } from "@/types/AuthResponse";
import type { User } from "@/types/IUser";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const isAuth = ref<boolean>(false);
    const currentUser = ref<User>();

    const isLoggedIn = computed(()=> isAuth.value == true);

    function setAuthentication(userData: AuthResponse){
        localStorage.setItem("access_token", userData.access_Token);
        localStorage.setItem("userData", JSON.stringify(userData));
        isAuth.value = true;
    }

    function FetchCurrentUser(){
        return GetCurrentUser().then(response=>{
            currentUser.value = response.data;
        });
        
    }

    function LogOut(){
        localStorage.clear();
        isAuth.value = false;
    }

    return {isAuth, isLoggedIn, setAuthentication, LogOut, currentUser, FetchCurrentUser}

  })
  