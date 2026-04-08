<script setup lang="ts">
const { data: products, status } = await useLazyFetch<ProductCard[]>('/api/product-cards')

useSeoMeta({
  title: 'Products List',
  description: 'List of products provided.'
})
</script>

<template>
  <div class="flex justify-center mb-16">
    <ProductCard v-for="product in products"
                 :key="product.id"
                 :product="product"
                 :status="status"
                 :isCheckout="false"/>
  </div>
</template>
