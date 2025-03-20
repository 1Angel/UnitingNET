<script setup lang="ts">
import CommunitiesList from '@/components/CommunitiesList.vue';
import ContentContainer from '@/components/Content-Container.vue';
import TrendingTags from '@/components/TrendingTags.vue';
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
    <div class="flex justify-center bg-black min-h-screen text-white">
      <div class="flex w-full max-w-6xl">
        <!-- Contenido principal: Lista de elementos -->
        <div class="w-2/3 space-y-6">
          <!-- Elemento de la lista -->
          <div v-for="i in communities">
            <!--lista de posts del usuario-->
            <CommunitiesList :community="i"/>
          </div>
        </div>
  
        <!-- Sidebar -->
        <div class="w-1/3 ml-6 space-y-6 mt-10">
          <div class="bg-gray-900 p-4 rounded-lg">Últimas discusiones</div>
          <div class="bg-gray-900 p-4 rounded-lg">Tags</div>
          <div class="bg-gray-900 p-4 rounded-lg">Categorías</div>
        </div>
      </div>
    </div>
  </template>
