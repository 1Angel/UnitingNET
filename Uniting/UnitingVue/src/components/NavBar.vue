<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';


const isOpen = ref<boolean>(false);

</script>


<template>
    <nav class="bg-purple-900 border-b-2">
        <div class="p-1 flex justify-between items-center">
            <div>
                <a class="text-white">Logo here</a>
            </div>
            <div>
                <!-- <a class="text-cyan-300 px-3 py-2 text-sm font-medium rounded-3xl hover:bg-cyan-700 hover:text-white">Home</a> -->
                <input class="bg-white w-100 h-9 rounded-4xl border-gray-300" type="text"
                    placeholder=" search communities ">
            </div>


            <div class="flex justify-between items-center">
                <div>
                    <RouterLink
                        class="text-purple-300 px-3 py-2 font-medium text-sm rounded-3xl hover:bg-purple-700 hover:text-white"
                        to="/auth/login">Login</RouterLink>
                </div>
                <div>
                    <RouterLink
                        class="px-3 py-2 text-purple-300 rounded-3xl text-sm font-medium hover:bg-purple-700 hover:text-white"
                        to="/auth/register">Register</RouterLink>
                </div>
                <div>
                    <button class="block rounded-full mx-2 pt-2 pb-2 cursor-pointer focus:border-white"
                        @click="isOpen = !isOpen">
                        <img class="rounded-full size-10 object-cover"
                            src="https://elcomercio.pe/resizer/AB93Kg1JoITGLMLkCgLBnVzg_7g=/980x528/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/37OWRM2CLBAE7BP5SXKLVMNHZE.jpg">

                    </button>
                    <div class="relative">
                        <div class="w-48 bg-white shadow-2xl rounded-lg absolute right-0" v-if="isOpen">
                            <RouterLink class="block px-3 py-2 rounded-lg text-gray-800 hover:text-purple-700" href=""
                                to="/auth/profile">Profile</RouterLink>
                            <form action="">
                                <a class="block px-3 py-2 text-gray-800 hover:text-purple-700" href="">Logout</a>
                            </form>
                        </div>

                    </div>
                </div>


            </div>
        </div>

    </nav>
</template>