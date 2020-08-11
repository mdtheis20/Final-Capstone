<template>
  <form v-on:submit.prevent="placeBid">
    <h3>Place Bid</h3>
    <h4 id="highest-bid">Current Bid: ${{findHighestBid()}}</h4>
    <div id="bid-form">
      <div id="left-bid">
        <div>
          <button name="easyButton" v-on:click.prevent="() => newBid.amount += 1">$1</button>
          <button name="easyButton" v-on:click.prevent="() => newBid.amount += 5">$5</button>
        </div>
        <div>
          <button name="easyButton" v-on:click.prevent="() => newBid.amount += 10">$10</button>
          <button name="easyButton" v-on:click.prevent="() => newBid.amount += 20">$20</button>
        </div>
      </div>

      <div id="right-bid">
        
        <label for="amount">Enter Amount:</label>
        <input
          type="number"
          name="amount"
          id="custom-bid-amount"
          v-model.number="newBid.amount"
          :min="findHighestBid + 1"
        />
        <input type="submit" value="Submit" id="btn-submit" />
        <input
          id="btn-clear"
          type="reset"
          value="Clear"
          v-on:click.prevent="() => newBid.amount = findHighestBid()"
        />
      </div>

      <div></div>
    </div>
  </form>
</template>

<script>
import apiService from "@/services/ApiService.js";
// TODO: items do not load if you go straight to the url without going to home
export default {
  data() {
    return {
      newBid: {
        bid_ID: 0,
        item_ID: this.$route.params.itemID,
        user_ID: 0, //TODO: make null
        amount: 0,
        time_placed: null,
      },
    };
  },
  props: {
    item_ID: Number,
  },
  methods: {
    placeBid() {
      if (this.$store.state.token == "") {
        this.$router.push({ name: "login" });
      } else if (this.newBid.amount < this.findHighestBid() + 1) {
        alert('You must bid at least $1 more than the current bid')
      } else {
        apiService
          .postBid(this.newBid.item_ID, this.newBid)
          .then((r) => {
            if (r.status === 201) {
              this.$store.commit("ADD_BID", r.data);
            }
          })
          .catch((e) => {
            if (e.response) {
              console.error(e.response);
            } else if (e.request) {
              console.error(e.request);
            } else {
              console.error("There was an error!");
            }
          });
      }
    },
    findHighestBid() {
      const foundItem = this.$store.state.listOfItems.find(
        (item) => item.item_ID === this.$route.params.itemID
      );
      if (foundItem.bids.length > 0){
        return foundItem.bids[0].amount;
      } else {
        return foundItem.starting_Bid;
      }
    },
  },
  created() {
    this.newBid.amount = this.findHighestBid();
  },
};
</script>

<style scoped>
#bid-form {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-evenly;
  align-items: center;
  margin-bottom: 20px;
}
#left-bid {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  margin: 8px auto;
}
button {
  padding: 20px;
  margin: 15px;
  width: 60px;
  height: 60px;
}
#custom-bid-amount {
  margin: 15px;
}
#right-bid {
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  margin: 8px auto;
}
input {
  width: 100%;
}
h3,
h4 {
  color: #e7dfd5;
  text-align: center;
}
#btn-clear {
  background-color: red;
}
#btn-submit {
  background-color: green;
}
</style>