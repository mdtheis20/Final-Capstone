<template>
  <div id="filter" class="menu-bar">
      <label for="filter">Category</label>
      <ul>
          <li v-for="category in categories" :key="category.categoryID" >
              
              <input type="checkbox" :name="category.name" :value="category.name" v-model="filterSelections">
              <label :for="category.name"> {{category.name}}</label>
          </li>
      </ul>
      <label for="searchTitle">Title: </label>
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
            filterSelections: [],
        }
    }
}
</script>

<style scoped>
div#filter li {
    list-style-type: none;
   /*  list-style-position: outside; */
}
</style>