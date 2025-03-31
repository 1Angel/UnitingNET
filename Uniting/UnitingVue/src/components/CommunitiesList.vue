<script setup lang="ts">
import type { Communities } from '@/types/Communities';
import { computed, onMounted } from 'vue';

const props = defineProps<{
    community: Communities
}>();

const formatDate = computed(() => 
Intl.DateTimeFormat("en-US", {year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric'})
.format(new Date(props.community.createdDate)));

</script>

<template>
    <div class="bg-black  border-b-1 pb-2 border-white">
        <img src="https://static-cdn.jtvnw.net/jtv_user_pictures/f37f760d-3fa0-482b-9609-453033822e5d-profile_image-70x70.png" class="rounded-full size-10 inline-flex m-1">
        <RouterLink :to="{name: 'communityDetails', params:{id: community.id}}" class="text-white text-2xl font-medium inline-flex">{{ community.name }}</RouterLink>
        <p class="text-white">{{ community.description }}.</p>
        <span class="text-gray-400">{{ formatDate }}</span>
    </div>
</template>