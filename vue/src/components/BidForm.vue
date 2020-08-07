<template>
  <form id="bid-form" v-on:submit.prevent="placeBid">
    <div>
      <label for="easyButton">Add: </label>  
      <button name="easyButton" v-on:click.prevent="() => newBid.amount += 1">$1</button>
      <button name="easyButton" v-on:click.prevent="() => newBid.amount += 5">$5</button>
      <button name="easyButton" v-on:click.prevent="() => newBid.amount += 10">$10</button>
      <button name="easyButton" v-on:click.prevent="() => newBid.amount += 20">$20</button>
    </div>

    <div id="highest-bid">
        Current Bid: ${{findHighestBid()}}
    </div>

    <div>
      <label for="amount">Enter Amount:</label>
      <input type="number" name="amount" id="custom-bid-amount" v-model.number="newBid.amount" :min="findHighestBid + 1"/>
      <input type="submit" value="Submit" />
      <input type="reset" value="Clear" v-on:click.prevent="() => newBid.amount = findHighestBid()" />
    </div>
  </form>
</template>

<script>
import apiService from '@/services/ApiService.js';
// TODO: items do not load if you go straight to the url without going to home
export default {
  data() {
    return {
      newBid: {
        bid_ID: 0,
        item_ID: this.$route.params.itemID,
        user_ID: 1, //TODO: make dynamic in API
        amount: 0,
        time_placed: null,
      }
    };
  },
  props: {
    itemID: Number,
  },
  methods: {
      placeBid() {
          // TODO: should server take care of adding user_ID?
          apiService.postBid(this.newBid.item_ID, this.newBid).then( r => {
              if (r.status === 201){
                  this.$store.commit('ADD_BID', r.data);
              }
          }).catch(e => {
        if (e.response) {
          console.error(e.response)
        } else if (e.request) {
          console.error(e.request)
        } else {
          console.error('There was an error!')
        }
      });
      },
      findHighestBid() {
        const foundItem = this.$store.state.listOfItems.find( item => item.item_ID === this.$route.params.itemID);      
        return foundItem.bids[foundItem.bids.length - 1].amount;
      }
  },
  created() {
      this.newBid.amount = this.findHighestBid();
  }
};
</script>

<style scoped>
#bid-form {
    display: flex;
    flex-wrap: wrap;
}
#bid-form input.radio-selector {
  display: inline-block;
  margin: 15px;
  
}
button {
  margin: 15px;
}
#custom-bid-amount {
  margin: 15px;
}
</style>