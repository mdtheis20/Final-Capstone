<template>
  <div id="item-card" :class="{'has-bid': item.bids.length > 0}">
      <h3>{{item.title}}</h3>
      <h4>{{item.startingBid}}</h4>      
      <img :src="item.pic" :alt="item.subtitle" />
      <!-- <p>{{item.subtitle}}</p> -->
  </div>
</template>

<script>
export default {
    data() {
        return {          
            // TODO: display top bid instead of starting bid if there are bids
            // TODO: display how many bids have benn placed
        }
    },
    props: {
        item: Object
    },
}
</script>

<style >
 #item-card {
    height: 400px;
    width: 95%;
    background-color: lightblue; 
    border-radius: 5px;
    border: 1px solid navy;

    
 }
 .has-bid {
     border: 5px solid greenyellow;
 }
</style>