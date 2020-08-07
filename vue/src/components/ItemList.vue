<template>
  <ul id="item-list">
      <li v-for="item in items" :key="item.item_ID">
        <router-link tag="a" :to="{name: 'item', params: {itemID: item.item_ID}}" >
        <item-card :item_ID="item.item_ID" />
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
      return this.$store.getters.filteredItems;
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
  padding: 0px;
}
#item-list >  li {
  list-style-type: none;
}
</style>