<template>
  <div id="current-bid-table">
<table>
  <thead>
    <tr>
      <th>Bid Amount</th>
      <th>Item Name</th>
      <th>Time</th>
    </tr>
  </thead>
   <tr v-for="(bid) in currentBids" :key="bid.bid_ID" class="bid-container" >      
       <td> ${{bid.amount}}</td>
        <td>{{getItemTitle(bid.item_ID)}}&nbsp;</td>
        <td>{{bid.time_Placed}}</td>    
     </tr>
    </table>
  </div>
</template>

<script>
export default {
props: {
    currentBids: Array,
},
methods: {
  getItemTitle(itemID){
    if (this.$store.state.listOfItems === null || this.$store.state.listOfItems.length === 0){
      this.$store.dispatch('getAllItems').then(() => {
         let item = this.$store.state.listOfItems.find(i => i.item_ID === itemID);
         if (!item){
           return ``;
         }
    return item.title;
      });
    }
    else {
      let item = this.$store.state.listOfItems.find(i => i.item_ID === itemID);
    return item.title;
    }
  }
}
}
</script>

<style scoped>

table {
  border-spacing: 15px 5px;
}
</style>