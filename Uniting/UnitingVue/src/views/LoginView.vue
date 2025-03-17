<script setup lang="ts">
import { ref } from 'vue';
import httpClient from '@/apiConfig/AxiosConfig';
import type { AuthResponse } from '@/Models/AuthResponse-interface';

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
        <div class="p-6 mt-6 w-90 bg-white rounded shadow-2xl">
            <p class="mb-6 text-purple-700 text-3xl">Login</p>
            <form @submit.prevent="login()">
                <div class="mb-6">
                    <label class="font-medium">Email</label>
                    <input class="block shadow border rounded font-medium w-full py-2 px-3" placeholder="Email"
                        v-model="email" type="email" />
                </div>
                <div class="mb-6">
                    <label class="font-medium">Password</label>
                    <input class="block shadow rounded border px-3 py-2 font-medium w-full" placeholder="Password"
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