<template>
  <div id="item-detail">
    <button id="please-log-in" v-show="this.$store.state.token == ''" v-on:click="() => this.$router.push({name: 'login'})">Log in to Place a Bid</button>
    <h2>{{item.title}}</h2>
    <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
    <h3>{{item.subtitle}}</h3>
    <p>{{item.description}}</p>
    <h4> Donated by: {{item.donor}}</h4>
    
    <!-- <category-bar :item_ID="this.item.item_ID" /> -->

    <bid-form :item_ID="item_ID" />

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

import BidForm from './BidForm.vue'

export default {
  components: {
    
    BidForm
  },
  title () {
    return `Auction Item - ${this.item.title}`
  },
  data() {
    return {

      item: this.$store.state.listOfItems.find(i => i.item_ID === this.item_ID),
     
    };
  },
  props: {
     item: Object
  },

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
#please-log-in {
  width: 100%;
  background-color: red;
}
</style>