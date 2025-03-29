<script setup lang="ts">
import { GetCommunitiesPosts, getCommunityDetails } from '@/services/CommunitiesService';
import type { Posts } from '@/types/CommunityDetailsResponse';
import type { ICommunity } from '@/types/ICommunity';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const id = route.params.id;

const posts = ref<Posts[]>();
const community = ref<ICommunity>();

async function getCommunity() {
    return getCommunityDetails(Number(id)).then(response=>{
        community.value = response.data;
    });
};

async function getPostsByCommunity() {
    return GetCommunitiesPosts().then(response=>{
        posts.value = response.data.data
    });
};


onMounted(()=>{
    getPostsByCommunity();
    getCommunity();
});

</script>

<template>
    <div class="flex justify-center mb-50">
        <div class="p-6 mt-0 w-200 bg-black rounded-b-2xl border-white border-1 shadow-2xl text-white">
            <img class="w-full h-40 rounded-2xl object-cover inline-flex" src="https://wallpaperaccess.com/full/6273968.jpg">
            <img  class="size-25 rounded-full inline-flex" src="https://res.cloudinary.com/startup-grind/image/upload/c_fill,dpr_2.0,f_auto,g_center,h_1080,q_100,w_1080/v1/gcs/platform-data-dsc/events/spring-boot-1_5zDxm9B.jpg">
            <h1 class="text-4xl inline-flex">{{ community?.name }}</h1>
            <p class="">{{ community?.description }}</p>
            <span class="mt-6 block">{{ community?.totalMembers }} Members</span>
        </div>
    </div>
</template>