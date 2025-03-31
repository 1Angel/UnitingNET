<script setup lang="ts">
const props = defineProps<{
    title: string;
    bgColor: string;
    textColor: string;
}>();

</script>


<template>
    <div>
        <button 
        class="rounded-3xl border w-20 h-10 cursor-pointer" 
        :style="{backgroundColor: bgColor, color: textColor}" 
        type="button">
            {{ props.title }}
        </button>
    </div>


</template>