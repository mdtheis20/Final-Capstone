<template>
  <div>
    <h5>Total Value of All Winning Items: ${{totalAmount}}</h5>
  </div>
</template>

<script>
export default {
//TODO: Bring in the stuff from elsewhere, not the $store!!
  data(){
   return {
     items: this.$store.state.listOfItems,

   }
 },

computed: {
  totalAmount(){
    let topBids = []
    let topBidsOfUser = []
    let total = 0

    this.items.forEach(i => {
      topBids.push(i.bids[0])
    })

    topBids.forEach(bid => {
      if (bid.user_Name === this.$store.state.user.username){
        topBidsOfUser.push(bid);
      }
    })

    if (topBidsOfUser.length === 0){
      total === 0
    }
    else {
   total = topBidsOfUser.reduce((reducer, amount) => {
      return reducer + amount;
    }, 0)
    }
    return 45678;
  }
}
}
</script>

<style>
</style>