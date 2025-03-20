<script setup lang="ts">
import TrendingTags from './TrendingTags.vue';

</script>

<template>
    <div class="flex justify-center ">
        <div class="flex w-full max-w-6xl">
            <!--content here: posts or communities or anything else-->
            <div class="w-2/3 space-y-6">
                <slot/>
            </div>
        </div>

        <!--side bars trending tags, communities, etc-->
        <div class="w-1/3 ml-6 space-y-6">
            <div class="bg-gray-900 p-4 rounded-lg">Últimas discusiones</div>
      <div class="bg-gray-900 p-4 rounded-lg">Tags</div>
      <div class="bg-gray-900 p-4 rounded-lg">Categorías</div>
        </div>
    </div>
</template>