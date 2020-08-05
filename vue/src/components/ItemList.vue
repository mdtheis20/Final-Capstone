<template>
  <ul id="item-list">
      <li v-for="item in items" :key="item.item_ID">
        <router-link tag="a" :to="{name: 'item', params: {itemID: item.item_ID}}" >
        <item-card :item="item" />
        </router-link>
      </li>
  </ul>
</template>
<!-- this.$store.getters.filteredItems()" -->
<script>
import itemCard from '@/components/ItemCard.vue'


export default {
  data() {
    return {
      
    }
  },
  computed: {
    items(){
      return this.$store.state.listOfItems
    },
  }, 
  components: {
    itemCard
  },
/*   created() {
    this.items = this.$store.state.listOfItems;
  } */
}
</script>

<style>
#item-list {
  display: flex;
  flex-direction: column;
}
#item-list >  li {
  list-style-type: none;
}
</style>