<script setup lang="ts">
import { ref } from 'vue';

const content = ref<string>();

const emit = defineEmits<{
    send: [value: string | undefined]
}>();

function CreatePost(){
        emit('send', content.value);
        content.value ='';
}

</script>

<template>
    <div>
        <form @submit.prevent="CreatePost">
            <div class="mb-3">
                <input v-model="content" type="text" class="border-1 border-gray-500 text-white w-full p-6 rounded-3xl" placeholder="Create new post in this community">
                <button class="rounded-3xl border-1 border-white bg-white text-black w-15 h-7 hover:bg-gray-400" type="submit">Post</button>
            </div>
        </form>
    </div>
</template>