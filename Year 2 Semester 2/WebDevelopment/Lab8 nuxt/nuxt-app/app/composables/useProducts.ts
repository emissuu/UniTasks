import type { Product } from "~/types/product";
import type { DummyProduct } from "~/types/DummyProduct";

export async function GetProducts() {
  return await $fetch<Product[]>("/api/products");
}

export async function GetDummyProducts(){
  return await $fetch<DummyProduct[]>("/api/dummy-products");
}
