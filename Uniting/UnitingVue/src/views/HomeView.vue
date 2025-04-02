<script setup lang="ts">
import PostListComponent from '@/components/PostListComponent.vue';
import { userFeed } from '@/services/PostService';
import { useAuthStore } from '@/stores/auth';
import type { IPost } from '@/types/IUserFeedResponse';
import { storeToRefs } from 'pinia';
import { onMounted, ref } from 'vue';


const store = useAuthStore();
const {isLoggedIn} = storeToRefs(store);

const posts = ref<IPost[]>([]);

onMounted(()=>{
  getUserFeed();
});

async function getUserFeed() {
  userFeed().then(response=>{
    posts.value = response.data.data;
  });
}

</script>

<template>
  <div class="flex justify-center mt-6 bg-black min-h-screen text-white">
    <div class="flex w-full max-w-6xl">

      <div class="w-2/3 space-y-6" v-if="!isLoggedIn">
        <div class="bg-gray-800 border-1 rounded-2xl py-10">
          <p class="ml-10 pt-20 text-white font-medium text-3xl">Log In to discover all the communities 🎇🎇🎇</p>
        </div>
      </div>
      <!-- Contenido principal: Lista de elementos -->
      <div class="w-2/3 space-y-6" v-else>
        <!-- Elemento de la lista -->
         <div v-for="i in posts" :key="i.id">
            <PostListComponent :show-community="true" :post="i"/>
         </div>
          <!--lista de posts del usuario-->

      </div>

      <!-- Sidebar -->
      <div class="w-1/3 ml-6 space-y-6">
        <div class="bg-gray-900 p-4 rounded-lg">Últimas discusiones</div>
        <div class="bg-gray-900 p-4 rounded-lg">Tags</div>
        <div class="bg-gray-900 p-4 rounded-lg">Categorías</div>
      </div>
    </div>
  </div>
</template>