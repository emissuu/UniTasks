<script setup lang="ts">
import type {ProductTableItem} from "~/types/productTableItem";

const { data: products, status } = await useLazyFetch<ProductTableItem[]>('/api/product-table')

useSeoMeta({
  title: 'Products Table',
  description: 'Table of products is here..'
})
</script>

<template>
  <div class="flex justify-center mb-16">
    <ProductTable
                 :products="products"
                 :status="status"
                  class="shadow-md"/>
  </div>
</template>
