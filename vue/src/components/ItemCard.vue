<template>
  <div id="item-card">

      <h3>{{item.title}}</h3>
      <div id="card-stat">
        <h4>{{currentBid}}</h4>
        <category-bar :item_ID="this.item.item_ID" />
      </div>

      <img :src="item.pic" :alt="item.subtitle" />
      <p>{{item.subtitle}}</p>
      
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

<style>
 #item-card {
    height: 400px;
    width: 520px;
    /* margin: 20px; */
    background-color: lightblue; 
    border-radius: 5px;
    border: 1px solid navy;
    margin: 15px auto;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-rows: 1fr 2fr 1fr;
    grid-gap: 10px;
    grid-template-areas: 
    "title title title"
    "img img stats"
    "sub sub sub"
    ;
 }
/* TODO: make breakpoint for small screens */
 #item-card.has-bid {
     border: 5px solid greenyellow;
 }
 #item-card > h3 {
     grid-area: title;

 }
  #item-card > img {
     grid-area: img;
     border: 1px solid navy;
     border-radius: 5px;
     max-height: 250px;
     max-width: 100%;
     margin: 0px auto;
 }
 #item-card > p {
    grid-area: sub;
}
 #card-stats {
    grid-area: stats;
}
</style>