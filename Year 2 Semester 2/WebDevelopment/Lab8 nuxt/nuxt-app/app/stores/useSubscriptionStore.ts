import { defineStore } from 'pinia'
import type {ProductCard} from "~/types/productCard";

export const useSubscriptionStore = defineStore('subscription', () => {
  // States
  const billing = ref<'annual' | 'monthly'>('annual')
  const subscription = ref<ProductCard | null>(null)

  // Actions
  const  saveSubscription = (product: ProductCard, billingPlan: 'annual' | 'monthly')=> {
    subscription.value = product
    billing.value = billingPlan
  }

  return {
    subscription,
    billing,
    saveSubscription
  }
})
