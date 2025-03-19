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
    <div class="border-b-1 border-white">
        <h3 class="text-white text-2xl font-medium">{{ community.name }}</h3>
        <p class="text-white">{{ community.description }}</p>
        <h6 class="text-white">{{ formatDate }}</h6>
    </div>
</template>