<template>
  <div id="item-detail">
    <h2>{{item.title}}</h2>
    <h3>{{item.subtitle}}</h3>
<<<<<<< HEAD
    <h4> Donated by: {{item.donor}}</h4>
=======
    <h4>{{item.donor}}</h4>
>>>>>>> 8e415e9c6b81e07355736723f47ac97f65f32f67
    <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
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