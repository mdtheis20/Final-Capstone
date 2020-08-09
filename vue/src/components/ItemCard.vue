<template>
  <div id="item-card">
      <div id="item-card-heading">
        <h3>{{item.title}}</h3>
        <span :class="{'bid-flag': this.item.bids.length > 0}">{{currentBid}}</span>
      </div>
         
      <img :src="item.pic" :alt="item.subtitle" />
      <!-- <p>{{item.subtitle}}</p> -->
      <category-bar :item_ID="this.item.item_ID" />
  </div>
</template>

<script>
import CategoryBar from './CategoryBar.vue'

export default {
    data() {
        return {      
            item: this.$store.state.listOfItems.find( i => i.item_ID === this.item_ID),    
            // TODO: display top bid instead of starting bid if there are bids
            // TODO: display how many bids have benn placed
        }
    },
    computed: {
        currentBid() {
            if (this.item.bids.length > 0) {
                return `Current Bid: ${this.item.bids[0].amount}`;
            } else {
                return `Starting Bid: ${this.item.starting_Bid}`;
            } 
        }
    },
    props: {
        item_ID: Number
    },
    components: {
        CategoryBar
    }
}
</script>

<style >
 #item-card {
    height: 400px;
    width: 95%;
    background-color: lightblue; 
    border-radius: 5px;
    border: 1px solid navy;
    margin: 15px auto;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
 }
 #item-card img {
     max-height: 200px;
     max-width: 100%;
 }
 #item-card.has-bid {
     border: 5px solid greenyellow;
 }
 .bid-flag {
     border: 3px solid yellow;
     border-radius: 5px;
 }
</style>