<script setup lang="ts">
import CommunitiesList from '@/components/CommunitiesList.vue';
import type { Communities, Response } from '@/types/Communities';
import axios from 'axios';
import { ref, onMounted } from 'vue';

const communities = ref<Communities[] | undefined>();


onMounted(() => {
    GetCommunities();
});

async function GetCommunities() {
    return await axios.get<Response>('https://localhost:7035/api/communities?pageNumber=1&pageSize=3')
        .then(x => {
            communities.value = x.data.data
        });
}

</script>

<template>
<div>
    <p class="text-white">Explore Communities</p>
    <div v-for="i in communities" :key="i.id">
        <CommunitiesList :community="i"/>
    </div>
</div>
</template>
