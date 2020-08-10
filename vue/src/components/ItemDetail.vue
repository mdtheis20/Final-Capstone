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

    <!-- <category-bar :item_ID="this.item.item_ID" /> -->

    <bid-form :item_ID="item_ID" />
<table>
  <thead>
    <tr>
      <th>Bid Amount</th>
      <th>UserName</th>
      <th>Time</th>
    </tr>
  </thead>
   <tr v-for="(bid) in bids" :key="bid.bid_ID" class="bid-container" >      
       <td> ${{bid.amount}}</td>
        <td>{{bid.user_Name}}&nbsp;</td>
        <td>{{bid.time_Placed}}</td>    
     </tr>
    </table>
    <a
      href="javascript:void(0)"
      class="mt-1"
      @click="simple_toggle(default_limit, item.bids.length)" v-if="item.bids.length > 5"
    >{{ limit_by===5?'Show all bids': 'Show 5 most recent bids'}}</a>
  </div>
</template>

<script>
import BidForm from "./BidForm.vue";

export default {
  components: {
    BidForm,
  },
  title() {
    return `Auction Item - ${this.item.title}`;
  },
  data() {
    return {
      default_limit: 5,
      limit_by: 5,
      //item: this.$store.state.listOfItems.find(i => i.item_ID === this.item_ID),
    };
  },
  props: {
    item: Object,
  },
  computed: {
    bids() {
      return this.item.bids.slice(0, this.limit_by);
    },
  },
  methods: {
    simple_toggle(default_limit, filters_length) {
      this.limit_by =
        this.limit_by === default_limit ? filters_length : default_limit;
    },
  },
};
</script>

<style scoped>
#item-detail div.bid-container {
  display: flex;
  flex-direction: column-reverse;
}
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

table {
  border-spacing: 15px 5px;
}
</style>