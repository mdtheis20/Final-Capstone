<template>
  <div class="home">
    <filter-bar />
    <amount-spent />
    <item-list />
  </div>
</template>

<script>
import FilterBar from "@/components/FilterBar.vue";
import ItemList from "@/components/ItemList.vue";
import AmountSpent from "@/components/AmountSpent.vue";

export default {
  name: "home",
  components: {
    FilterBar,
    ItemList,
    AmountSpent,
  },
  created() {
    if (this.$store.state.isAuctionOpen) {
      this.$store.dispatch("getAllItems");
      this.$store.dispatch("getAllCategories");
    }
    else {
      this.$store.dispatch("getAllWinnings");
    }
    // This uses an action in Vuex to call API and load to listOfItems
  },
};
</script>

<style>
</style>