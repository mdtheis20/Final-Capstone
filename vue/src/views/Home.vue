<template>
  <div class="home">
    
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
    ItemList,

  },
  created() {
    // This uses an action in Vuex to call API and load to listOfItems
    this.$store.dispatch('getAllItems');
    this.$store.dispatch('getAllCategories');
  }
};
</script>

<style>

</style>