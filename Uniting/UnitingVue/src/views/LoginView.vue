<script setup lang="ts">
import { reactive, ref } from 'vue';
import { AuthService, LoginUser } from '@/services/AuthService';
import { useRouter } from 'vue-router';
import { useAuthStore } from '@/stores/auth';
import { useCounterStore } from '@/stores/counter';

const store = useAuthStore();
const counter = useCounterStore();
const router = useRouter();

const errorMessage = ref('');

const loginForm = reactive({
    email: '',
    password: ''
});

function login() {

    LoginUser(loginForm.email, loginForm.password)
    .then(response => {
        store.setAuthentication(response.data);
        store.FetchCurrentUser();
        router.push('/')
    }).catch(err=>{
        console.log(err.response.data);
        errorMessage.value = err.response.data;
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
                    <input class="block shadow border border-white rounded font-medium w-full py-2 px-3 text-gray-200"
                        placeholder="Email" v-model="loginForm.email" type="email" />
                </div>
                <div class="mb-6">
                    <label class="font-medium text-white">Password</label>
                    <input class="block shadow rounded border border-white px-3 py-2 font-medium w-full text-gray-200"
                        placeholder="Password" v-model="loginForm.password" type="password" />
                </div>
                <div class="mb-6" v-if="errorMessage.length">
                    <span class="text-red-600">{{ errorMessage }}</span>
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