<template>
  <div class="home">
    
    <filter-bar />
    <amount-spent/>
    <item-list />
  </div>
</template>

<script>
import FilterBar from '@/components/FilterBar.vue';
import ItemList from '@/components/ItemList.vue';
import AmountSpent from '@/components/AmountSpent.vue';


export default {
  name: "home",  
  components: {
    FilterBar,
    ItemList,
    AmountSpent,
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