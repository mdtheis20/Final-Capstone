<template>
<div>
  <ul class="category-container" v-for="cat in item.categories" :key="cat">
      <li>{{cat}}</li>
  </ul>
</div>

</template>

<script>
export default {
    props: {
        item_ID: Number
    },
    data() {
        return {
            item: this.$store.state.listOfItems.find( i => i.item_ID === this.item_ID)
        }
    }
}
</script>

<style scoped>
.category-container {
    display: flex;
}
</style>