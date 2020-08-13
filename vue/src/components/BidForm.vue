<template>
  <form v-on:submit.prevent="placeBid" id="bid-form">
    <!-- <h2>Place Bid</h2> -->
    <div class="alert alert-danger" role="alert" v-if="bidErrors">{{ bidErrorMsg }}</div>

    <h2 id="highest-bid">Current Bid: ${{topBid}}</h2>
    <div class="bid-container">
      <div id="left-bid">
        <button name="easyButton" v-on:click.prevent="() => newBid.amount += 1">$1</button>
        <button name="easyButton" v-on:click.prevent="() => newBid.amount += 5">$5</button>
        <button name="easyButton" v-on:click.prevent="() => newBid.amount += 10">$10</button>
        <button name="easyButton" v-on:click.prevent="() => newBid.amount += 20">$20</button>
      </div>

      <div id="right-bid">
        <label for="amount">Enter Amount:</label>
        <input type="number" name="amount" id="custom-bid-amount" v-model.number="newBid.amount" />
        <input type="submit" value="Submit" id="btn-submit" />
        <input id="btn-clear" type="reset" value="Clear" v-on:click.prevent="clearForm" />
      </div>
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
        item_ID: this.item_ID,
        user_ID: 0, //TODO: make null
        amount: this.topBid,
        time_placed: null,
      },
      bidErrors: false,
      bidErrorMsg: "",
    };
  },
  computed: {},
  props: {
    topBid: Number,
    item_ID: Number,
    isUserWinning: Number,
  },
  methods: {
    placeBid() {
      if (this.$store.state.token == "") {
        this.$router.push({ name: "login" });
      } else if (this.newBid.amount < this.topBid + 1) {
        this.bidErrors = true;
        this.bidErrorMsg =
          "New bids must be at least $1 higher than the current bid";
      } else {
        apiService
          .postBid(this.newBid.item_ID, this.newBid)
          .then((r) => {
            if (r.status === 201) {
              this.$emit("bidPlaced");
              this.clearForm();
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
    clearForm() {
      this.newBid.amount = this.topBid;
      this.bidErrors = false;
    },
    /* findHighestBid() {
      const foundItem = this.$store.state.listOfItems.find(
        (item) => item.item_ID === this.$route.params.itemID
      );
      if (foundItem.bids.length > 0){
        return foundItem.bids[0].amount;
      } else {
        return foundItem.starting_Bid;
      }
    }, */
  },
  /* created() {
    this.newBid.amount = this.topBid;
  }, */
};
</script>

<style scoped>
#bid-form {
  margin: 40px auto;
}

button {
  font-size: 1.25em;
  padding: 20px;
  width: 70px;
  height: 60px;
  background-image: linear-gradient(
    to bottom right,
    silver,
    rgb(148, 148, 148)
  );
  border-radius: 12px;
}
#custom-bid-amount {
  text-align: center;
  font-size: 1.25em;
  padding: 10px;
  width: 60%;
  margin: 15px auto;
  border-radius: 5px;
}
.bid-container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
}
#left-bid {
  width: 35%;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  margin: 8px 0;
}
#right-bid {
  width: 55%;
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  margin: 8px 0;
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
  background-image: linear-gradient(
    to bottom left,
    rgb(255, 87, 87),
    rgb(243, 2, 2)
  );
  box-shadow: 1px 1px 4px rgba(192, 192, 192, 0.356);
  padding: 12px;
  margin: 8px auto;
  border-radius: 5px;
}
#btn-submit {
  background-image: linear-gradient(
    to bottom left,
    rgb(0, 200, 0),
    rgb(2, 134, 2)
  );
  box-shadow: 1px 1px 4px rgba(192, 192, 192, 0.356);
  padding: 12px;
  margin: 8px auto;
  border-radius: 5px;
}
.alert {
  color: red;
  text-align: center;
}
</style>