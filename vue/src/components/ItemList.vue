<template>
  <ul id="item-list">
      <li v-for="item in items" :key="item.itemID">
        <item-card :item="item" />
      </li>
  </ul>
</template>

<script>
import itemCard from '@/components/ItemCard.vue'

export default {
  data() {
    return {
      items: []
    }
  },
  components: {
    itemCard
  },
  created() {
    this.items = this.$store.state.listOfItems;
  }
}
</script>

<style>

</style>