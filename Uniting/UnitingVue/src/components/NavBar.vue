<script setup lang="ts">
import { useAuthStore } from '@/stores/auth';
import { storeToRefs } from 'pinia';
import { ref } from 'vue'
import { RouterLink } from 'vue-router'

const isOpen = ref<boolean>(false);


const store = useAuthStore();

const {isLoggedIn} =  storeToRefs(store);


</script>

<template>
    <!--set navbar back to purple-900-->
    <nav class="bg-black border-b-1 border-gray-300">
        <div class="p-1 flex justify-between items-center">
            <div class="p-1 flex justify-between items-center">
                <div class="mx-4">
                    <RouterLink class="text-white" :to="{name: 'home'}">Logo here</RouterLink>
                </div>
                <div class="m-1">
                    <RouterLink to="/blog" class="text-white mx-4">
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                            stroke="currentColor" class="size-6 inline-flex">
                            <path stroke-linecap="round" stroke-linejoin="round"
                                d="M12 7.5h1.5m-1.5 3h1.5m-7.5 3h7.5m-7.5 3h7.5m3-9h3.375c.621 0 1.125.504 1.125 1.125V18a2.25 2.25 0 0 1-2.25 2.25M16.5 7.5V18a2.25 2.25 0 0 0 2.25 2.25M16.5 7.5V4.875c0-.621-.504-1.125-1.125-1.125H4.125C3.504 3.75 3 4.254 3 4.875V18a2.25 2.25 0 0 0 2.25 2.25h13.5M6 7.5h3v3H6v-3Z" />
                        </svg>

                        Blog
                    </RouterLink>
                </div>
                <div class="m-1">
                    <RouterLink to="/explore" class="text-white mx-4">
                        <svg class="size-6 inline-flex" viewBox="0 0 24 24" fill="none" stroke="currentColor"
                            stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <circle cx="12" cy="12" r="10" />
                            <polygon points="16.24 7.76 14.12 14.12 7.76 16.24 9.88 9.88 16.24 7.76" />
                        </svg>
                        Explore
                    </RouterLink>
                </div>
                <!--search bar-->
                <div class="border-1  rounded-3xl bg-gray-800">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                        stroke="currentColor" class="size-6 inline-flex ml-2 text-white">
                        <path stroke-linecap="round" stroke-linejoin="round"
                            d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
                    </svg>
                    <input class="bg-gray-800  text-white pl-2 ml-1 w-55 h-9  rounded-4xl focus:outline-none"
                        type="text" placeholder=" Search " />
                </div>
            </div>

            <!--authentication-->
            <div class="flex justify-between items-center">
                <div v-if="!isLoggedIn">
                    <RouterLink
                        class="text-black bg-white px-3 py-2 font-medium text-sm rounded-3xl hover:bg-purple-700 hover:text-white"
                        to="/auth/login">Login</RouterLink>
                </div>
                <div v-if="!isLoggedIn">
                    <RouterLink
                        class="px-3 py-2 text-white rounded-3xl text-sm font-medium hover:bg-purple-700 hover:text-white"
                        to="/auth/register">Register</RouterLink>
                </div>
                <div v-else>
                    <button class="block rounded-full mx-2 pt-2 pb-2 cursor-pointer focus:border-white"
                        @click="isOpen = !isOpen">
                        <img class="rounded-full size-10 object-cover"
                            src="https://elcomercio.pe/resizer/AB93Kg1JoITGLMLkCgLBnVzg_7g=/980x528/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/37OWRM2CLBAE7BP5SXKLVMNHZE.jpg" />
                    </button>
                    <!--dropdown-->
                    <div class="relative">
                        <div class="w-48 bg-black border-white border-1 shadow-2xl rounded-lg absolute right-0"
                            v-if="isOpen">
                            <RouterLink class="block px-3 py-2 rounded-lg text-white hover:text-purple-700" href=""
                                to="/auth/profile">Profile</RouterLink>
                            <form action="">
                                <a class="block px-3 py-2 text-white hover:text-purple-700" href="">Logout</a>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</template>
