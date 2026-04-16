<script setup lang="ts">
import {useSubscriptionStore} from "~/stores/useSubscriptionStore";

const { data: products, status } = useLazyFetch<ProductCard[]>('/api/product-cards')
const subscriptionStore = useSubscriptionStore()
const { billing } = storeToRefs(subscriptionStore)

useSeoMeta({
  title: 'Products List',
  description: 'List of products provided.'
})
</script>

<template>
  <div class="flex justify-center">
    <div class="min-w-[800px] w-[90%] max-w-[1100px] mt-4 mb-16">
      <div class="flex justify-between items-center px-2 mb-1">
        <h1 class="text-2xl font-semibold text-black">Start Your 3 Day Free Trial</h1>
        <div class="flex items-center">
          <p class="text-xs text-green-500 font-semibold">Save up to 20%</p>
          <div class="absolute ml-18 mb-[38px] fill-green-500">
            <svg xmlns="http://www.w3.org/2000/svg" height="20px" width="20px" viewBox="0 0 512 196"><!--!Font Awesome Free v7.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2026 Fonticons, Inc.--><path d="M436.7 74.7L448 85.4 448 32c0-17.7 14.3-32 32-32s32 14.3 32 32l0 128c0 17.7-14.3 32-32 32l-128 0c-17.7 0-32-14.3-32-32s14.3-32 32-32l47.9 0-7.6-7.2c-.2-.2-.4-.4-.6-.6-75-75-196.5-75-271.5 0s-75 196.5 0 271.5 196.5 75 271.5 0c8.2-8.2 15.5-16.9 21.9-26.1 10.1-14.5 30.1-18 44.6-7.9s18 30.1 7.9 44.6c-8.5 12.2-18.2 23.8-29.1 34.7-100 100-262.1 100-362 0S-25 175 75 75c99.9-99.9 261.7-100 361.7-.3z"/></svg>
          </div>
          <div class="bg-gray-100 rounded-md ml-2 font-semibold">
            <UButton variant="ghost"
                     class="border-gray-200"
                     :class="billing === 'annual' ?
                        'border-2 bg-white text-black cursor-normal hover:bg-white active:bg-white' :
                        'border-0 bg-transparent text-gray-500 cursor-pointer hover:bg-transparent active:bg-transparent'"
                     label="Annual"
                     @click="billing = 'annual'"
            />
            <UButton variant="ghost"
                     class="border-gray-200 hover:bg-transparent"
                     :class="billing === 'monthly' ?
                        'border-2 bg-white text-black cursor-normal hover:bg-white active:bg-white' :
                        'border-0 bg-transparent text-gray-500 cursor-pointer hover:bg-transparent active:bg-transparent'"
                     label="Monthly"
                     @click="billing = 'monthly'"
            />
          </div>
        </div>
      </div>
      <div class="flex justify-center">
        <ProductCard v-if="status !== 'pending'" v-for="product in products"
                     :key="product.id"
                     :product="product"
                     :billing="billing as string"
                     :isCheckout="false"/>
        <USkeleton v-else v-for="i in 3"
                   class="w-[100%] max-w-[360px] min-w-[260px] h-120 rounded-xl  my-6 mx-2"/>
      </div>

    </div>
  </div>
</template>
