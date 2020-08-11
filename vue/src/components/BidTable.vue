<template>
  <div id="bid-table">
<table>
  <thead>
    <tr>
      <th>Bid Amount</th>
      <th>Item ID</th>
      <th>Time</th>
    </tr>
  </thead>
   <tr v-for="(bid) in bids" :key="bid.bid_ID" class="bid-container" >      
       <td> ${{bid.amount}}</td>
        <td>{{bid.item_ID}}&nbsp;</td>
        <td>{{bid.time_Placed}}</td>    
     </tr>
    </table>
  </div>
</template>

<script>
export default {
props: {
    bids: Array,
}
}
</script>

<style scoped>

table {
  border-spacing: 15px 5px;
}
</style>