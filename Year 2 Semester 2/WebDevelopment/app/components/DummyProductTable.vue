<script setup lang="ts">
import type { DummyProduct} from "~/types/DummyProduct";

const props = defineProps<{
  products: DummyProduct[] | null;
}>()
</script>

<template>
  <div class="m-4">
    <!-- pretable div -->
    <div class="flex justify-between mb-3 py-2">
      <div class="flex items-left">
        <p class="text-sm text-gray-600 font-medium">0 selected</p>
      </div>
      <div class="flex items-center gap-4">
        <div class="flex items-center gap-1 text-gray-600 cursor-pointer hover:text-gray-400 transition-colors">
          <i class="fa-solid fa-arrow-down-wide-short"></i>
          <p class="text-sm font-semibold">Sort by</p>
        </div>
        <div class="flex items-center gap-1 text-gray-600 cursor-pointer hover:text-gray-400 transition-colors">
          <i class="fa-solid fa-ellipsis-vertical"></i>
          <p class="text-sm font-semibold">Actions</p>
        </div>
      </div>
    </div>

    <!-- table div -->
    <div class="w-full mb-2 rounded-lg border-1 border-gray-300 overflow-hidden">
      <table class="w-full font-medium">
        <thead class="">
        <tr class="bg-gray-100 text-gray-500 text-sm">
          <th class="px-4 py-2 w-[80px]">
            <div class="flex items-left justify-center">
              <input type="checkbox" class="w-4 h-4 rounded-lg border-2 border-gray-600">
              <i class="fa-solid fa-angle-down scale-75"></i>
            </div>
          </th>
          <th class="px-4 py-2 w-[15%] text-left font-medium">Title</th>
          <th class="px-4 py-2 w-[25%] text-left font-medium">Description</th>
          <th class="px-4 py-2 w-[10%] text-left font-medium">Price</th>
          <th class="px-4 py-2 w-[10%] text-right font-medium">Rating</th>
          <th class="px-4 py-2 w-[10%] text-right font-medium">Brand</th>
          <th class="px-4 py-2 w-[10%] text-left font-medium">Category</th>
          <th class="px-4 py-2 w-[100px] text-right">Photo</th>
        </tr>
        </thead>

        <tbody>
        <tr v-for="product in products" :key="product.id">
          <th class="pl-2 pr-6 py-4 text-center">
            <input type="checkbox" class="w-4 h-4 rounded border-2 border-gray-400">
          </th>
          <th class="font-semibold text-left p-4">{{ product.title }}</th>
          <th class="font-medium p-4">{{ product.description }}</th>
          <th class="font-medium p-4">{{ product.price }}</th>
          <th class="font-medium text-left p-4">{{ product.rating }}</th>
          <th class="font-medium text-left p-4">{{ product.brand }}</th>
          <th class="font-medium text-left p-4">{{ product.category }}</th>
          <th class="p-4"><i class="fa-solid fa-ellipsis-vertical"></i></th>
        </tr>
        <tr class="bg-gray-0 text-gray-600 text-sm p-2 text-right border-b border-gray-100 items-center hover:bg-gray-100 transition-colors">
        </tr>
        <tr class="bg-gray-0 text-gray-600 text-sm p-2 text-right border-b border-gray-100  items-center hover:bg-gray-100 transition-colors">
          <th class="pl-2 pr-6 py-4 text-center">
            <input type="checkbox" class="w-4 h-4 rounded border-2 border-gray-400">
          </th>
          <th class="font-semibold text-left p-4">test save</th>
          <th class="font-medium p-4">10</th>
          <th class="font-medium p-4">Me</th>
          <th class="font-medium text-left p-4">02/10/2026 at 5:52PM</th>
          <th class="p-4"><i class="fa-solid fa-ellipsis-vertical"></i></th>
        </tr>
        </tbody>
      </table>

      <!-- posttable div -->
      <div class="flex justify-between items-center p-4">
        <div class="flex justify-center items-center gap-1 text-xs text-gray-600">
          <p>Show</p>
          <input type="text" value="5" class="border-1 border-gray-300 text-sm text-gray-700 font-bold w-6 h-8 rounded text-center">
          <p> of 5 results</p>
        </div>
        <div class="">
          <div class="h-8 w-8 font-semibold rounded-full bg-green-100 border-1 border-green-500 items-center text-center pt-0.5">1</div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
