<script setup lang="ts">
import NavBar from './components/NavBar.vue';

</script>

<template>
  <NavBar />
  <div class="bg-black pb-10">
    <div class="m-0">
      <RouterView />
    </div>
  </div>

</template>