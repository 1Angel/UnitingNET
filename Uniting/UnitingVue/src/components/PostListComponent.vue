<script setup lang="ts">
import type { IPost } from '@/types/IUserFeedResponse';
import { computed } from 'vue';

const props = defineProps<{
    post: IPost
}>();

const formattedDate = computed(()=> Intl.DateTimeFormat("en-US", { year: 'numeric', month: 'long',day: 'numeric', hour: 'numeric'}).format(new Date(props.post.createdDate)));

</script>

<template>
    <div class="bg-gray-900 p-4 border-1 rounded-2xl">
        <RouterLink class="text-gray-200 underline block" :to="{name: 'communityDetails', params: {id: props.post.community.id}}">{{ props.post.community.name }}</RouterLink>
        <img class="size-10 rounded-full inline-flex"
            src="https://elcomercio.pe/resizer/AB93Kg1JoITGLMLkCgLBnVzg_7g=/980x528/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/37OWRM2CLBAE7BP5SXKLVMNHZE.jpg" />
        <h6 class="text-white inline-flex pb-5 pl-2">{{ props.post.user.userName }}</h6>
        <p>{{ props.post.description }}</p>
        <span class="text-gray-400">{{ formattedDate }}</span>
    </div>
</template>