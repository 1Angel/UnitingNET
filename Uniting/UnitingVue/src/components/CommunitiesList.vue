<script setup lang="ts">
import type { Communities } from '@/Models/Communities-interface';
import { computed } from 'vue';

defineProps<{
    community: Communities
}>();



const formatDate = computed(() => Intl.DateTimeFormat('en',
    { year: "numeric", month: "short", day: "numeric", hour: "numeric", minute: "numeric" }
).format());

</script>

<template>
    <div class="bg-white mx-10 rounded-2xl shadow-2xl px-2 py-2 mb-2 cursor-pointer">
        <h1 class="text-blue-600 font-bold">
            <RouterLink :to="{ name: 'communityDetails', params: { id: community.id } }">
                {{ community.name.toUpperCase() }}
            </RouterLink>
        </h1>
        <p>{{ community.description }}</p>
        <h6>Created date: {{ formatDate }}</h6>
    </div>

</template>