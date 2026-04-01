<script setup lang="ts">
import { ref, onMounted } from 'vue';
import ProductCard from '~/components/ProductCard.vue';
import {GetDummyProducts, GetProducts} from "~/composables/useProducts";
import type { Product } from "~/types/product";
import DummyProductTable from "~/components/DummyProductTable.vue";
import type {DummyProduct} from "~/types/DummyProduct";

const products = ref<Product[]>([]);
const dummyProducts = ref<DummyProduct[]>([]);

async function LoadProducts() {
  products.value = await GetProducts()
}
async function LoadDummyProducts() {
  dummyProducts.value = await GetDummyProducts()
}

function LoadAll() {
  LoadProducts();
  LoadDummyProducts();
}
onMounted(LoadAll)

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
</script>

<template>
  <div class="flex justify-center mb-16">
    <ProductCard v-for="product in products"
                 :key="product.id"
                 :product="product" />
  </div>
  <div>
    <DummyProductTable :products="dummyProducts" class="shadow-md"/>
  </div>
</template>
