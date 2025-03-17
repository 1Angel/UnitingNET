<template>
    <div class="flex justify-center mb-50">
        <div class="p-6 mt-6 w-90 bg-white rounded shadow-2xl">
            <p class="text-3xl text-purple-700 mb-6">Register</p>
            <form>
                <div class="mb-6">
                    <label class="font-medium">Username</label>
                    <input class="block shadow rounded border px-3 py-2 w-full" placeholder="Username" type="text" />
                </div>
                <div class="mb-6">
                    <label class="font-medium">Email</label>
                    <input class="block shadow rounded border px-3 py-2 w-full" placeholder="Email" type="email" />
                </div>
                <div class="mb-6">
                    <label class="font-medium">Password</label>
                    <input class="block shadow rounded border px-3 py-2 w-full" placeholder="********"
                        type="password" />
                </div>
                <div class="mb-6">
                    <button
                        class="bg-purple-700 text-white px-4 py-2 rounded-3xl hover:text-white hover:bg-purple-500 hover:rounded-3xl hover:border-1"
                        type="submit">
                        Register
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>
