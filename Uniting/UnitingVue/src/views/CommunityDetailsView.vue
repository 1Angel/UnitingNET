<script setup lang="ts">
import ButtonComponent from '@/components/ButtonComponent.vue';
import CreatePostComponent from '@/components/CreatePostComponent.vue';
import PostListSkeletonLoaderComponent from '@/components/PostListSkeletonLoaderComponent.vue';
import { GetCommunitiesPosts, getCommunityDetails } from '@/services/CommunitiesService';
import { ToggleFollow } from '@/services/FollowingService';
import { createPost } from '@/services/PostService';
import { useAuthStore } from '@/stores/auth';
import type { Posts } from '@/types/CommunityDetailsResponse';
import type { ICommunity } from '@/types/ICommunity';
import { computed, defineAsyncComponent, onMounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();
const { isLoggedIn } = useAuthStore();

const id = route.params.id;

const posts = ref<Posts[]>();
const community = ref<ICommunity>();
const isUserFollowing = ref<boolean>(true);

const textButton = ref<string>('Joined');
const titleCase = computed(() => community.value?.name.toUpperCase());

const postList = defineAsyncComponent({
    loader: ()=> import('../components/PostListComponent.vue'),
    loadingComponent: PostListSkeletonLoaderComponent,
    delay:200,
});

async function getCommunity() {
    return getCommunityDetails(Number(id)).then(response => {
        community.value = response.data;
        isUserFollowing.value = response.data.isUserFollowing;
    });
};

async function getPostsByCommunity() {
    return GetCommunitiesPosts(Number(id)).then(response => {
        posts.value = response.data.data;
    });
};

async function ToggleCommunityFollow() {
    return ToggleFollow(Number(id)).then((response) => {
        textButton.value = response.data === 'followed' ? 'Joined' : 'Join'
    })
}

async function RedirectToLogin() {
    if (!isLoggedIn) {
        router.push({ name: 'login' });
    }
}

async function CreatePost(content: string | undefined) {
    return createPost(Number(id), content).then((res)=>{
        getPostsByCommunity();
    })

}

onMounted(() => {
    getCommunity();
    getPostsByCommunity();

    if (isUserFollowing.value == true) {
        textButton.value = 'Joined'
    } else if (isUserFollowing.value == false) {
        textButton.value = 'Join'
    }
});

</script>

<template>
    <div class="flex justify-center mb-5">

        <div class="p-6 mt-0 w-200 bg-black rounded-b-2xl border-white border-1 shadow-2xl text-white">
            <ButtonComponent 
            v-if="isLoggedIn" 
            :title="isUserFollowing ? textButton : 'Join'" 
            :bg-color="'white'"
            :text-color="'black'" 
            class="flex justify-end" 
            @click="ToggleCommunityFollow" />

            <ButtonComponent v-else 
            :title="'Log In'" 
            :bg-color="'black'" 
            :text-color="'white'" 
            class="flex justify-end"
            @click="RedirectToLogin" />

            <!-- <img class="w-full h-40 rounded-2xl object-cover inline-flex" src="https://wallpaperaccess.com/full/6273968.jpg"> -->
            <img class="size-25 rounded-full inline-flex"
                src="https://dominickm.com/wp-content/uploads/2016/06/spring-boot-logo_full.png">
            <h1 class="text-4xl inline-flex ml-2">{{ titleCase }}</h1>
            <p class="">{{ community?.description }}</p>
            <span class="mt-6 block">{{ community?.totalMembers }} Members</span>
        </div>
    </div>
    
    <div class="flex justify-center">
        <div class="border-1 rounded-3xl pt-4 border-white">
            <CreatePostComponent v-show="isLoggedIn" @send="CreatePost($event)" class="mx-3"/>
            <div v-for="i in posts" :key="i.postInfo.id" class="m-3 mt-0 w-200 bg-black rounded-3xl border-white border-1 shadow-2xl text-white">
                <postList 
                :post="i.postInfo"
                :show-community="false"
                />
            </div>
        </div>
        </div>
</template>