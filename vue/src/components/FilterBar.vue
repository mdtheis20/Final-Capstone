<template>
  <div id="filter" class="menu-bar">
      <label for="filter">Category</label>
      <select name="category">
          <option disabled>--choose categories--</option>
          <option v-for="category in categories" :key="category.categoryID" :value="category.name">{{category.name}}</option>
      </select>
      <label for="searchTitle">Title</label>
      <input type="text" name="searchTitle" v-model="searchTitle" />      
  </div>
</template>

<script>
// TODO: how can multiple categories be selected?
export default {
    data() {
        return {
            categories: [
                {categoryID: 1, name: 'Celebrity'},
                {categoryID: 2, name: 'Things Touched by Josh Tucholski'},
                {categoryID: 3, name: 'Musical'},
                {categoryID: 4, name: 'Having to do with the Browns'}
            ],
            searchTitle: '',
        }
    }
}
</script>

<style>

</style>