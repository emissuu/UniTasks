<script setup lang="ts">
import type {ProductCard} from "~/types/productCard";
import { vMaska } from 'maska/vue'

const route = useRoute()
const planId = (route.query['plan'])?.toString()
const billing = (route.query['billing'])?.toString()
const { data: plans, status } = await useLazyFetch<ProductCard[]>('/api/product-cards')
const plan: ProductCard = computed(() => {
  if (status.value === 'success' && plans)
    return plans.value[parseInt(planId)]
})

const date = new Date()
const day = date.getDate()
const month = date.getMonth()
const year = date.getFullYear()

const state = reactive({
  planId: planId,
  billing: billing,
  cardNumber: undefined,
  expirationDate: undefined,
  verificationCode: undefined,
  fullName: undefined,
  address: undefined,
  isConsent: undefined
})

type Submission = typeof state

async function handleSubmit(event: FormSubmitEvent<Submission>) {
  console.log(event.data)
  await useFetch('/api/subscription/create', {
    method: 'POST',
    body: event.data,
    watch: false
  })
  state.cardNumber = undefined
  state.expirationDate = undefined
  state.verificationCode = undefined
  state.fullName = undefined
  state.address = undefined
  state.isConsent = undefined
}

useSeoMeta({
  title: 'Checkout',
  description: `Purchasing ${plan.name}`
})
</script>

<template>
  <div v-if="planId && plans" class="flex justify-center w-full">
    <div class="min-w-[540px] w-full max-w-[900px]">
      <div class="mt-8 mb-4">
        <NuxtLink to="/products" class="text-sm text-gray-500"> << back</NuxtLink>
        <h1 class="text-2xl text-gray-800 font-bold mt-3">You're Almost In - Start Your 3-Day Free Trial Now!</h1>
        <p class="text-base text-gray-600 mt-2">Set up your account to gain instant access! You won't be charged of you decide to cancel within 3 days</p>
      </div>
      <div class="flex">
        <div class="h-fit">
          <ProductCard
            :product="plan"
            :status="status"
            :billing="billing"
            :isCheckout="true"/>
        </div>


        <!-- Order Summary thingy -->
        <div class="min-w-[400px] w-[55%] h-[100%] ml-12 my-6 p-8 rounded-xl border-gray-200 border text-gray-800 text-sm">
          <h3 class="text-md font-bold mb-6">Order Summary</h3>

          <div class="flex justify-between mb-2">
            <p>{{ billing === 'annual' ? "Annual" : "Monthly" }} Plan</p>
            <p>${{ billing === 'annual' ? plan.priceYearlyDiscounted?.toFixed(2) : plan.priceMonthly }}</p>
          </div>

          <hr class="border-gray-200 mb-2"/>

          <div class="flex justify-between mb-2">
            <p>Total Due <span class="text-[10px] font-baseline text-gray-600">(*not including sales tax where applicable)</span></p>
            <p>${{ billing === 'annual' ? plan.priceYearlyDiscounted?.toFixed(2) : plan.priceMonthly }}</p>
          </div>
          <div class="flex justify-between mb-6 font-semibold">
            <p>Due Today</p>
            <p>$0.00</p>
          </div>
          <div class="bg-gray-100 rounded text-gray-600 font-semibold text-center py-3 mb-8">
            Includes 3-Day Free Trial
          </div>
          <UForm :state="state" @submit="handleSubmit">
            <div class="flex items-center gap-1 mb-4">
              <h3 class="text-md font-bold">Billing Information</h3>
              <UIcon name="lucide:info" class="text-gray-400"/>
            </div>
            <p class="text-sm text-gray-500">Card Details</p>
            <div class="flex justify-between w-full bg-gray-50 border-gray-300 border rounded p-1 mt-1 mb-2">
              <UInput name="cardNumber" type="text" variant="none" icon="lucide:credit-card"
                      placeholder="Number" v-maska="'#### #### #### ####'" v-model="state.cardNumber"
                      class="w-[50%]"/>
              <UInput name="expirationDate" type="text" variant="none"
                      placeholder="MM / YY" v-maska="'##/##'" v-model="state.expirationDate"
                      class="w-[25%]"/>
              <UInput name="verificationCode" type="text" variant="none"
                      placeholder="CVC" v-maska="'###'" v-model="state.verificationCode"
                      class="w-[15%]"/>
            </div>

            <p class="text-sm text-gray-500">Address</p>
            <div class="w-full bg-gray-50 border-gray-300 border rounded p-3 mt-1 mb-2">
              <div class="mb-2">
                <label for="fullName" class="text-sm text-gray-500">Full Name</label><br>
                <div class="border-gray-300 border rounded bg-white">
                  <UInput id="fullName" name="fullName" type="text" variant="none" v-model="state.fullName" class="w-full"/>
                </div>
              </div>
              <div>
                <label for="address" class="text-sm text-gray-500">Address</label><br>
                <div class="border-gray-300 border rounded bg-white">
                  <UInput id="address" name="address" type="text" variant="none" v-model="state.address" class="w-full"/>
                </div>
              </div>
            </div>
            <div class="flex gap-2 mb-4">
              <UCheckbox required name="isConsent" v-model="state.isConsent"/>
              <p class="text-xs text-gray-600">I consent to <a class="font-bold underline cursor-pointer">Terms of Use</a> and understand my 3-day free trial will automatically  convert to ${{ plan.priceYearlyDiscounted?.toFixed(2).toLocaleString() }} per year starting on {{ day + "/" + month + "/" + year }}. The yearly fee will be automatically charged each year going forward unless I cancel my account at least one (1) business day before the end of current billing period, which can be done by calling (888) 463-3163.</p>
            </div>
            <UButton
              type="submit"
              :disabled="!state.isConsent"
              class="disabled:bg-gray-200 disabled:text-gray-500
                enabled:bg-linear-to-r enabled:from-lime-400 enabled:to-emerald-400 enabled:text-black
                enabled:hover:from-green-400 enabled:hover:to-cyan-400 duration-400
                font-semibold py-2 px-5 rounded">
              Try It Free</UButton>

          </UForm>

        </div>
      </div>

    </div>

  </div>
  <div v-else >
    <h1>Couldn't find the product</h1>
  </div>
</template>
