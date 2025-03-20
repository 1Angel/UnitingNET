import type { AuthResponse } from "@/types/AuthResponse";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const isAuth = ref(false);

    const isLoggedIn = computed(()=> isAuth.value == true);

    function setAuthentication(userData: AuthResponse){
        localStorage.setItem("access_token", userData.access_Token);
        localStorage.setItem("userData", JSON.stringify(userData));
        isAuth.value = true;
        console.log(isAuth.value);
    }

    return {isAuth, isLoggedIn, setAuthentication}

  })
  