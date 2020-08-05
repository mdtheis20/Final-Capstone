<template>
  <div id="filter" class="menu-bar">
      <label for="filter">Category</label>
      <ul>
          <li v-for="category in categories" :key="category.categoryID" >
              
              <input type="checkbox" :name="category.name" :value="category.name" v-model="filterSelections">
              <label :for="category.name"> {{category.name}}</label>
          </li>
      </ul>
      <!-- <label for="searchTitle">Title: </label>
      <input type="text" name="searchTitle" v-model="searchTitle" />  -->     
  </div>
</template>

<script>
// TODO: search by title?
export default {
    data() {
        return {          
            searchTitle: '',
            filterSelections: [],
        }
    },
    computed: {
        categories() {
            return this.$store.state.listOfCategories;
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