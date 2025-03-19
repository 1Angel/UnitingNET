<script setup lang="ts">
import NavBar from './components/NavBar.vue';

</script>

<template>
 <NavBar/>
 <div class="bg-black">
  <div class="mx-10">
    <RouterView/>
  </div>
 </div>

</template>