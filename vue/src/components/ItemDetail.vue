<template>
  <div id="item-detail">
    <h2>{{item.title}}</h2>
    <h3>{{item.subtitle}}</h3>
    <h4> Donated by: {{item.donor}}</h4>
    
   <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
    <p>{{item.description}}</p>
    
    <category-bar />
    <div class="bid-container" v-for="bid in item.bids" :key="bid.bid_ID">
      <div class="bid-row">
        <span>{{bid.amount}}</span>&nbsp;
        <span>{{bid.user_Name}}</span>&nbsp;
        <span>{{bid.time_Placed}}</span>
      </div>
    </div>
  </div>
</template>

<script>
import CategoryBar from '@/components/CategoryBar.vue';

export default {
  components: {
    CategoryBar
  },
  title () {
    return `Auction Item - ${this.item.title}`
  },
  data() {
    return {
      // Dummy data
   
     
    };
  },
  
  props: {
    //TODO don't pass in whole item, go to store instead
     item: Object
  }
};
</script>

<style scoped>

#item-detail div.bid-container {
  display: flex;
  flex-direction: column-reverse;
}
h2, h3, h4, p {
      color: #e7dfd5;
}
</style>