<script setup lang="ts">
import type { Product } from "~/types/product";

const props = defineProps<{
  product: Product;
}>()
</script>

<template>
  <!-- Gradient for the icons -->
  <svg width="0" height="0" class="absolute">
    <defs>
      <linearGradient id="icon-gradient" gradientTransform="rotate(25)">
        <stop offset="0%" stop-color="#ECFCCA"/>
        <stop offset="100%" stop-color="#7CCF35"/>
      </linearGradient>
    </defs>
  </svg>

  <!-- Actual card itself -->
  <div class="flex py-6 px-2">
    <div class="relative w-[100%] max-w-[360px] min-w-[260px] rounded-xl shadow-xl overflow-hidden border-gray-200 border-1
                hover:border-gray-600 hover:shadow-xl/15 transition duration-300 bg-white">
      <div class="w-full overflow-hidden bg-linear-to-r from-lime-500 to-cyan-500 h-1"></div>

      <div class="px-8 pt-6 pb-8">
        <h2 class="text-xl font-bold text-gray-800 mb-4">{{ product.name }}</h2>

        <span class="inline-block bg-gray-100 text-gray-500 text-xs px-2 py-0.5 font-bold rounded mb-1">
                        3-days free then:</span>

        <div class="flex items-baseline mb-1.5">
          <span class="text-4xl text-gray-800 font-bold">${{ product.priceMonthly.toFixed(2) }}</span>
          <span class="text-base text-gray-500">/month</span>
        </div>
        <p class="text-sm text-gray-500 mb-2">
          Billed yearly at <span class="line-through decoration-gray-800 decoration-2">${{ product.priceYearly.toLocaleString() }}</span> <span class="text-gray-700 font-semibold">${{ product.priceYearlyDiscounted.toLocaleString() }}</span></p>

        <span class="inline-block bg-gray-200 text-green-700 text-sm px-3 py-0.5 font-medium rounded mb-4">
                        ${{ (product.priceYearly - product.priceYearlyDiscounted).toLocaleString() }} in savings</span>

        <button v-if="product.isFreeTrialAvailable" class="py-2 w-[100%] cursor-pointer
          bg-linear-to-r from-amber-300 to-orange-400
          hover:from-yellow-300 hover:to-amber-400 transition duration-200
          rounded-sm items-center text-black">
          Try It Free</button>
        <button v-else class="py-2 w-[100%] text-black disabled cursor-not-allowed
          bg-gray-300
          rounded-sm items-center text-black">
          Try It Free</button>

        <hr class="border-gray-200 mb-4"/>

        <ul v-for="item in product.descriptionItems" class="space-y-2">
          <li class="flex gap-2 mb-2">
            <svg class="w-[18px] h-[18px] bg-blue-500 bg-clip-text mt-[2px]" viewBox="0 0 24 24">
              <!-- Icon from Material Design Icons by Pictogrammers - https://github.com/Templarian/MaterialDesign/blob/master/LICENSE -->
              <path fill="url(#icon-gradient)" d="M12 1L9 9l-8 3l8 3l3 8l3-8l8-3l-8-3z"/>
            </svg>
            <div>
              <p class="text-sm text-gray-700 font-semibold" v-html="item.mainText"></p>
              <p v-if="item.subText" class="text-xs text-gray-400 font-semibold" v-html="item.subText"></p>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
