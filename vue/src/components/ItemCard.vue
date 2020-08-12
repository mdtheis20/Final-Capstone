<template>
  <div id="item-card">
    <h3>{{item.title}}</h3>
    <div id="card-stat">
      <h4>{{currentBid}}</h4>
      
      <div id="bid-message">
      <h4 id="top-bid-message" v-if="topBid === 1">You have the top bid!</h4>
      <h4 id="out-bid-message" v-if="topBid === 2">You've been outbid!</h4>
      <h4 id="no-bid-message" v-if="topBid === 0"></h4>
      </div>
      <!-- You have top bid message or you've been outbid message, only shown if you have placed bid in first place-->
      </div>
    
    <img :src="item.pic" :alt="item.subtitle" />
    <p>{{item.subtitle}}</p>
  </div>
</template>

<script>


export default {
  data() {
    return {
      // TODO: display top bid instead of starting bid if there are bids
      // TODO: display how many bids have benn placed
    };
  },
  computed: {
    item() {
      return this.$store.state.listOfItems.find(
        (i) => i.item_ID === this.item_ID
      );
    },
    currentBid() {
      if (this.item.bids.length > 0) {
        return `Current Bid: $${this.item.bids[0].amount}`;
      } else {
        return `Starting Bid: $${this.item.starting_Bid}`;
      }
    },
    topBid() {
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

    // topBid() {
    //   // See if item has any bids at all
    //   if (this.item.bids.length === 0) {
    //     // If 'yes', return empty string message
    //     return ``;
    //     // If 'no, then see if logged in user has placed bid on item
    //   } else if (this.item.bids[0].user !== this.$store.state.user) {
    //     // If user has not placed bid on item, return empty string message
    //     return ``;
    //     // If user has placed bid on item, check to see if they are the current bid at this.item.bids[0]
    //   } else if (this.item.bids[0].user === this.$store.state.user) {
    //     // If 'yes', return message 'You have top bid!'
    //     return "You have the top bid!";
    //     // If 'no', return message, 'You've been outbid!'
    //   } else return `You've been outbid!`;
    // },
  },
  props: {
    item_ID: Number,
  },
  components: {
    
  },
};
</script>

<style>
#item-card {
  height: 550px;
  width: 450px;
  /* margin: 20px; */
  border-radius: 5px;
  /* border: 3px solid #B0690E; */
  background-color: #0072B0;
  padding: 30px;
  margin: 15px auto;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  /* grid-template-rows: 1fr 2fr 1fr 1fr; */
  grid-gap: 10px;
  grid-template-areas:
    "title title title"
    "img img img"
    "sub sub sub"
    "stats stats stats"
    "bid bid bid";
  
}
/* TODO: make breakpoint for small screens */
#item-card.has-bid {
  border: 5px solid greenyellow;
}
#item-card > h3 {
  grid-area: title;
  align-self: center;
  text-align: center;
  color: aliceblue
}
#item-card > img {
  grid-area: img;
  /* border: 1px solid navy; */
  border-radius: 5px;
  max-height: 250px;
  max-width: 100%;
  margin: 0px auto;
}
#item-card > p {
  grid-area: sub;
  text-align: center;
  color: aliceblue;
  height: 20px;
}
#card-stat {
  grid-area: stats;
  display: flex;
  flex-direction: column;
}
#top-bid-message {
  color: rgb(80, 219, 80);
}
#out-bid-message {
  color: red;
}

h4{
  color:aliceblue;
  text-align: center;
}

#bid-message{
  grid-area: bid;
  text-align: center;
}

@media screen and (max-width: 630px) {
  #item-card {
    height: 350px;
    width: 300px;
  }
}
</style>