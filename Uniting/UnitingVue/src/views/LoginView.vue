<script setup lang="ts">
import { ref } from 'vue';
import httpClient from '@/apiConfig/AxiosConfig';
import type { AuthResponse } from '@/types/AuthResponse';

const email = ref('');
const password = ref('');
const errorMessage = ref('');


async function login() {

    return await httpClient.post<AuthResponse>('/auth/login', {
        email: email.value,
        password: password.value
    }).then(response => {
        console.log(response.data.access_Token)
    }).catch(err => {
        console.log(err)
    })

}

</script>


<template>
    <div class="flex justify-center mb-50">
        <div class="p-6 mt-6 w-90 bg-black rounded border-white border-1 shadow-2xl">
            <p class="mb-2 text-purple-700 text-3xl">Login</p>
            <h6 class="text-white mb-4">Welcome</h6>
            <form @submit.prevent="login()">
                <div class="mb-6">
                    <label class="font-medium text-white">Email</label>
                    <input class="block shadow border border-white rounded font-medium w-full py-2 px-3 text-gray-200" placeholder="Email"
                        v-model="email" type="email" />
                </div>
                <div class="mb-6">
                    <label class="font-medium text-white">Password</label>
                    <input class="block shadow rounded border border-white px-3 py-2 font-medium w-full text-gray-200" placeholder="Password"
                        v-model="password" type="password" />
                </div>
                <div class="mb-6">
                    <button
                        class="px-4 py-2 bg-purple-700 text-white rounded-3xl hover:bg-white hover:text-purple-700 hover:border-purple-700 hover:border-1"
                        type="submit">Log
                        in</button>
                </div>
            </form>
        </div>
    </div>
</template>