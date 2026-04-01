<script setup lang="ts">
import type { DummyProduct} from "~/types/DummyProduct";
import type { TableColumn } from "@nuxt/ui/components/Table.vue";
import {UBadge, UButton, UDropdownMenu} from "#components";
import { getPaginationRowModel } from '@tanstack/vue-table';

const table = useTemplateRef('table');
const props = defineProps<{
  products: DummyProduct[];
}>();

// ===== Column initialization thing =====
const columns: TableColumn<DummyProduct>[] = [
  {
    accessorKey: "title",
    header: ({ column }) => getHeader(column, "Title"),
  },
  {
    accessorKey: "description",
    header: "Description",
    meta: {
      class: {
        td: "Text-wrap"
      }
    }
  },
  {
    accessorKey: "price",
    header: ({ column }) => getHeader(column, "Price"),
    cell: ({ row }) => `$${row.getValue("price")}`,
    meta: {
      class: {
        th: "text-center",
        td: "text-center"
      }
    }
  },
  {
    accessorKey: "rating",
    header: ({ column }) => getHeader(column, "Rating"),
    cell:({ row}) => {
      let rating: string = row.getValue("rating");
      if (parseFloat(rating) < 4.5) {
        return h(UBadge,
          { class: 'capitalize', variant: 'subtle', color:  'error' },
          rating);
      } else {
        return h(UBadge,
          { class: 'capitalize', variant: 'subtle', color:  'success' },
          rating);
      }
    },
    meta: {
      class: {
        th: "text-center",
        td: "text-center"
      }
    }
  },
  {
    accessorKey: "brand",
    header: ({ column }) => getHeader(column, "Brand"),
    meta: {
      class: {
        th: "text-center",
        td: "text-center capitalize"
      }
    }
  },
  {
    accessorKey: "category",
    header: ({ column }) => getHeader(column, "Category"),
    meta: {
      class: {
        th: "text-center",
        td: "text-center capitalize"
      }
    }
  },
  {
    accessorKey: "thumbnail",
    header: "Image",
    cell: ({row}) => {
      return h("img", {
        src: row.getValue("thumbnail"),
        class: "w-50"
      })
    },
    meta: {
      class: {
        th: "text-center",
        td: "w-50 h-50"
      }
    }
  }
]

  // ===== All other smaller in size controls which can be actually perceived
// at once and not after minute of scrolling unlike some other variable =====

const pagination = ref ({
  pageIndex: 0,
  pageSize: 5
});
const globalFilter = ref ("");

watch(
  () => pagination.value.pageSize,
  (size) => { table.value?.tableApi?.setPageSize(size); }
);

// ===== Big grand truly awesome sorting algorithm =====

const sorting = ref([
  {
    id: 'title',
    desc: false
  }
])

function getHeader(column: Column<DummyProduct>, label: string) {
  const isSorted = column.getIsSorted()

  return h(
    UDropdownMenu,
    {
      content: {
        align: 'start'
      },
      'aria-label': 'Actions dropdown',
      items: [
        {
          label: 'Asc',
          type: 'checkbox',
          icon: 'i-lucide-arrow-up-narrow-wide',
          checked: isSorted === 'asc',
          onSelect: () => {
            if (isSorted === 'asc') {
              column.clearSorting()
            } else {
              column.toggleSorting(false)
            }
          }
        },
        {
          label: 'Desc',
          icon: 'i-lucide-arrow-down-wide-narrow',
          type: 'checkbox',
          checked: isSorted === 'desc',
          onSelect: () => {
            if (isSorted === 'desc') {
              column.clearSorting()
            } else {
              column.toggleSorting(true)
            }
          }
        }
      ]
    },
    () =>
      h(UButton, {
        color: 'neutral',
        variant: 'ghost',
        label,
        icon: isSorted
          ? isSorted === 'asc'
            ? 'i-lucide-arrow-up-narrow-wide'
            : 'i-lucide-arrow-down-wide-narrow'
          : 'i-lucide-arrow-up-down',
        class: '-mx-2.5 data-[state=open]:bg-elevated',
        'aria-label': `Sort by ${isSorted === 'asc' ? 'descending' : 'ascending'}`
      })
  )
}


</script>

<template>
  <div class="m-4 rounded-lg border-1 border-gray-300 overflow-hidden">
    <div class="bg-gray-100">
      <UInput v-model="globalFilter" class="max-w-sm p-2" placeholder="Filter" />
    </div>

    <hr class="border-gray-300" />

    <UTable
      ref="table"
      :data="products"
      :columns="columns"
      v-model:sorting="sorting"
      v-model:pagination="pagination"
      v-model:global-filter="globalFilter"
      :pagination-options="{
        getPaginationRowModel: getPaginationRowModel()
      }"
      :ui="{
        td: 'whitespace-normal',
        thead: 'bg-gray-100 text-gray-500',
        tr: 'bg-gray-0 hover:bg-gray-100 transition-colors'
      }"/>
    <hr class="border-gray-300" />
    <div class="flex p-2 justify-between">
      <div class="flex items-center">
        <p>Show </p>
        <UInput v-model="pagination.pageSize" class="max-w-12 mx-1.5"/>
        <p> of {{ products.length }} results</p>
      </div>
      <div>
        <UPagination
          :page="(table?.tableApi?.getState().pagination.pageIndex || 0) + 1"
          :items-per-page="table?.tableApi?.getState().pagination.pageSize"
          :total="table?.tableApi?.getFilteredRowModel().rows.length"
          @update:page="(p) => table?.tableApi?.setPageIndex(p - 1)"
        />
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
