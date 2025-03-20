<script setup lang="ts">
import type { Communities } from '@/types/Communities';
import { computed } from 'vue';

defineProps<{
    community: Communities
}>();



const formatDate = computed(() => Intl.DateTimeFormat('en',
    { year: "numeric", month: "short", day: "numeric", hour: "numeric", minute: "numeric" }
).format());

</script>

<template>
    <div class="bg-black  border-b-1 pb-2 border-white">
        <img src="https://static-cdn.jtvnw.net/jtv_user_pictures/f37f760d-3fa0-482b-9609-453033822e5d-profile_image-70x70.png" class="rounded-full size-10 inline-flex m-1">
        <h3 class="text-white text-2xl font-medium inline-flex">{{ community.name }}</h3>
        <p class="text-white">{{ community.description }}.</p>
        <h6 class="text-white">{{ formatDate }}</h6>
    </div>
</template>