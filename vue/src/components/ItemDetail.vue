<template>
  <div id="item-detail">
    <h2>{{item.title}}</h2>
    <h3>{{item.subtitle}}</h3>
    <h4> Donated by: {{item.donor}}</h4>
    
   <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>

    <h5>{{item.description}}</h5>
    <ul class="category-container" v-for="cat in item.categories" :key="cat">
      <li>{{cat}}</li>
    </ul>
    <ol class="bid-container" v-for="bid in item.bids" :key="bid.bid_ID">
      <li>
        <span>{{bid.amount}}</span>
        <span>{{bid.user_Name}}</span>
      </li>
    </ol>
  </div>
</template>

<script>
export default {
  title () {
    return `Auction Item - ${this.item.title}`
  },
  data() {
    return {
      // Dummy data
   
     
    };
  },
  
  props: {
     item: Object
  }
};
</script>

<style scoped>
.category-container > li {
    display: inline-block;
    list-style-type: none;
}
.bid-container > li {
    list-style-type: none;
    display: flex;
}
</style>