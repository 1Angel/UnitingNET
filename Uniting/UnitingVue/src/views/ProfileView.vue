<script setup lang="ts">
import { GetUserProfile } from '@/services/UserService';
import type { IUser } from '@/types/IUser';
import { onMounted, ref } from 'vue';

const user = ref<IUser>();

async function getUserProfile() {
    return GetUserProfile().then((res)=>{
        user.value = res.data;
    })
}

onMounted(()=>{
    getUserProfile(); 
})

</script>

<template>
    <div class="flex justify-center mb-5">

        <div class="p-6 mt-0 w-200 bg-black rounded-b-2xl border-white border-1 shadow-2xl text-white">
            <img class="size-25 rounded-full inline-flex"
                src="https://images.alphacoders.com/131/thumb-1920-1312794.png">
            <h1 class="text-4xl inline-flex ml-2">{{ user?.userName }}</h1>
            <p class="">{{  }}</p>
            <span class="mt-6 block">Created At: xd</span>
        </div>
    </div>
    
    <!-- <div class="flex justify-center">
        <div class="border-1 rounded-3xl pt-4 border-white">
            <CreatePostComponent v-show="isLoggedIn" @send="CreatePost($event)" class="mx-3"/>
            <div v-for="i in posts" :key="i.postInfo.id" class="m-3 mt-0 w-200 bg-black rounded-3xl border-white border-1 shadow-2xl text-white">
                <postList 
                :post="i.postInfo"
                :show-community="false"
                />
            </div>
        </div>
        </div> -->

        <div class="flex justify-center">
            <div>

            </div>
        </div>
</template>