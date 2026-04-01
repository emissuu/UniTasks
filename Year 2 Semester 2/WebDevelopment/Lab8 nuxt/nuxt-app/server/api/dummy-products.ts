export default defineEventHandler(async () => {
  const data = await $fetch<{products: object}>("https://dummyjson.com/products");
  return data.products;
})
