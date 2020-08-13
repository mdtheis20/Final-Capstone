<template>
  <div id="current-bid-table">
<table>
  <thead>
    <tr>
      <th>Bid Amount</th>
      <th>Item Name</th>
      <th>Time</th>
      <th id="jump-header">Jump To Item</th>
    </tr>
  </thead>
   <tr v-for="(bid) in currentBids" :key="bid.bid_ID" class="bid-container" >      
       <td> ${{bid.amount}}</td>
        <td>{{getItemTitle(bid.item_ID)}}&nbsp;</td>
        <td>{{bid.time_Placed}}</td>
        <td><router-link id="jump-button" tag="button" :to="{name: 'item', params: {itemID: bid.item_ID}}"
    >Go</router-link></td>    
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
  justify-content: center;
 align-content: right;
 
}
thead {
   text-decoration: underline;
}
#jump-button {
  max-width: 100%;
  color: #fff;
  text-align: center;
  text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;
  
  animation: glow .75s ease-in-out infinite alternate;
    color: #e7dfd5;
        font-family: Arial, Helvetica, sans-serif; font-size: 50px; font-style: normal; font-variant: normal; ;
    text-align: center;


  color: #fff;
  text-align: center;
 text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;
}

@media only screen and (max-width: 500px) {
  table {
  border-spacing: 10px 5px;

  max-width: 100%;
  font-size: 60%;
 overflow-wrap: break-word;
}
#jump-button {
  width: 40%;
  height: 30px;
  font-size: 10px;
  display: flex;
  justify-content: center;

}
#jump-header {
  
  justify-content: center;
  overflow-wrap: break-word;
}
}
</style>