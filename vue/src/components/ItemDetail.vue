<template>
  <div id="item-detail">
    <h2>{{item.title}}</h2>
    <h3>{{item.subtitle}}</h3>
    <h4> Donated by: {{item.donor}}</h4>
    
    <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
    <p>{{item.description}}</p>
    
    <category-bar :item_ID="this.item.item_ID" />
    <div class="bid-container" v-for="bid in item.bids" :key="bid.bid_ID">
      <div class="bid-row">
        <span>{{bid.amount}}</span>&nbsp;
        <span>{{bid.user_Name}}</span>
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
      item: this.$store.state.listOfItems.find(i => i.item_ID === this.item_ID),
     
    };
  },
  
  props: {
    //TODO don't pass in whole item, go to store instead
     item_ID: Number
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
.img-container {
  max-width: 95%;
}

.img-container img {
    max-width: 75%;
}
</style>