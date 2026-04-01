<script setup lang="ts">
import { ref, onMounted } from 'vue';
import ProductCard from '~/components/ProductCard.vue';
import {GetDummyProducts, GetProducts} from "~/composables/useProducts";
import type { Product } from "~/types/product";
import DummyProductTable from "~/components/DummyProductTable.vue";
import type {DummyProduct} from "~/types/DummyProduct";
const products = ref<Product[] | null>(null);
const dummyProducts = ref<DummyProduct[] | null>(null);

async function LoadProducts() {
  products.value = await GetProducts()
}
async function LoadDummyProducts() {
  dummyProducts.value = await GetDummyProducts()
}

const title = "Products List";
const description = "List of products provided.";
useSeoMeta({
  title,
  description,
  ogTitle: title,
  ogDescription: description,
  ogImage: 'https://ui.nuxt.com/assets/templates/nuxt/starter-light.png',
  twitterImage: 'https://ui.nuxt.com/assets/templates/nuxt/starter-light.png',
  twitterCard: 'summary_large_image'
})
onMounted([LoadProducts, LoadDummyProducts]);
</script>

<template>
  <div class="flex justify-center mb-4">
    <ProductCard v-for="product in products"
                 :key="product.id"
                 :product="product" />
  </div>
  <div>
    <DummyProductTable :products="dummyProducts" />
  </div>


</template>

<style scoped>

</style>
