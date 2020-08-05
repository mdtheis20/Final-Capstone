<template>
  <div class="home">
    
    <auction-header />
    <filter-bar />
    <item-list />
  </div>
</template>

<script>
import FilterBar from '@/components/FilterBar.vue';
import ItemList from '@/components/ItemList.vue';
import AuctionHeader from '@/components/AuctionHeader.vue';

export default {
  name: "home",  
  components: {
    FilterBar,
    ItemList,
    AuctionHeader,
  },
  created() {
    // This uses an action in Vuex to call API and load to listOfItems
    this.$store.dispatch('getAllItems');
    this.$store.dispatch('getAllCategories');
  }
};
</script>
