<template>
  <div class="home">
    
    <h1>Home</h1>
    <filter-bar />
    <item-list />
  </div>
</template>

<script>
import FilterBar from '@/components/FilterBar.vue';
import ItemList from '@/components/ItemList.vue';

export default {
  name: "home",  
  components: {
    FilterBar,
    ItemList
  },
  created() {
    // This uses an action in Vuex to call API and load to listOfItems
    this.$store.dispatch('getAllItems');
  }
};
</script>
