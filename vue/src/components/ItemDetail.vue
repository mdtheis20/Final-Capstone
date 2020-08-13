<template>
  <div id="item-detail">
    <button
      id="please-log-in"
      v-show="this.$store.state.token == ''"
      v-on:click="() => this.$router.push({name: 'login'})"
    >Log in to Place a Bid</button>
    <h2>{{item.title}}</h2>
    <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
    <h3>{{item.subtitle}}</h3>
    <p>{{item.description}}</p>
    <h4>Donated by: {{item.donor}}</h4>
    
    <h4 id="top-bid-message" v-if="topBidOfUser === 1">You have the top bid!</h4>
    <h4 id="out-bid-message" v-if="topBidOfUser === 2">You've been outbid!</h4>
    <h4 id="no-bid-message" v-if="topBidOfUser === 0"></h4>

    <!-- <category-bar :item_ID="this.item.item_ID" /> -->

    <bid-form :topBid="topBid" :item_ID="item_ID" @bidPlaced="refreshItem()" />
    <table>
      <thead>
        <tr>
          <th>Bid Amount</th>
          <th>UserName</th>
          <th>Time</th>
        </tr>
      </thead>
      <tr v-for="(bid) in bids" :key="bid.bid_ID" class="bid-container">
        <td>${{bid.amount}}</td>
        <td>{{bid.user_Name}}&nbsp;</td>
        <td>{{bid.time_Placed}}</td>
      </tr>
    </table>
    <button
      href="javascript:void(0)"
      id="bid-button"
      @click="simple_toggle(default_limit, item.bids.length)"
      v-if="item.bids.length > 5"
    >{{ limit_by===5?'Show all bids': 'Show \'Top 5\' Bids'}}</button>
    <p v-if="item.bids.length == 0">There are currently no bids</p>
  </div>
</template>

<script>
import BidForm from "./BidForm.vue";
import api from "@/services/ApiService.js";

export default {
  components: {
    BidForm,
  },
  title() {
    return `Auction Item - ${this.item.title}`;
  },
  data() {
    return {
      item: Object,
      default_limit: 5,
      limit_by: 5,
      //item: this.$store.state.listOfItems.find(i => i.item_ID === this.item_ID),
    };
  },
  props: {
    item_ID: Number,
  },
  computed: {
    bids() {
      return this.item.bids.slice(0, this.limit_by);
    },
    topBid() {
      return this.item.bids.length > 0
        ? this.item.bids[0].amount
        : this.item.starting_Bid;
    },
    topBidOfUser() {
      // Find the first bid from user
      let userBid = this.item.bids.find(
        (bid) => bid.user_Name === this.$store.state.user.username
      );
      if (!userBid) {
        return 0; //You haven't bid
      }
      if (userBid === this.item.bids[0]) {
        return 1; //`You have top bid!`
      }
      return 2; //`You've been outbid!`
    },
  },
  methods: {
    simple_toggle(default_limit, filters_length) {
      this.limit_by =
        this.limit_by === default_limit ? filters_length : default_limit;
    },
    refreshItem() {
      api
        .getSingleItem(this.item_ID)
        .then((r) => {
          if (r.status === 200) {
            this.item = r.data;
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
    },
  },
  created() {
    this.refreshItem();
  },
};
</script>

<style scoped>
/* #item-detail div.bid-container {
  display: flex;
  flex-direction: column-reverse;
} */
h2,
h3,
h4,
p {
  color: #e7dfd5;
}
.img-container {
  max-width: 95%;
}

.img-container img {
  max-width: 75%;
}
#please-log-in {
  width: 100%;
  background-color: red;
}
#bid-button {
  color: azure;
}
table {
  border-spacing: 10px 5px;
  overflow-wrap: break-word;
  max-width: 100%;
}
#top-bid-message {
  color: green;
}
#out-bid-message {
  color: red;
}
</style>