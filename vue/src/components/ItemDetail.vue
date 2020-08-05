<template>
  <div id="item-detail">
    <h2>{{item.title}}</h2>
    <h3>{{item.subtitle}}</h3>
    <div class="img-container">
      <img :src="item.pic" :alt="item.subtitle" />
    </div>
    <ul class="category-container" v-for="cat in item.categories" :key="cat">
      <li>{{cat}}</li>
    </ul>
    <ol class="bid-container" v-for="bid in item.bids" :key="bid.bid_ID">
      <li>
        <span>{{bid.amount}}</span>
        <span>{{bid.user_Name}}</span>
      </li>
    </ol>
  </div>
</template>

<script>
export default {
  data() {
    return {
      // Dummy data
      item: {
        item_ID: 1,
        auction_ID: 1,
        title: "Josh's Waterbottle",
        subtitle: null,
        pic:
          "https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80",
        starting_Bid: 150.0,
        categories: ["Celebrity", "Sports Memorabilia", "Horcrux"],
        bids: [
          {
            item_ID: 1,
            bid_ID: 1,
            user_Name: "user",
            amount: 5.0,
          },
          {
            item_ID: 1,
            bid_ID: 2,
            user_Name: "admin",
            amount: 10.0,
          },
          {
            item_ID: 1,
            bid_ID: 3,
            user_Name: "user",
            amount: 15.0,
          },
        ]
      },
    };
  },
};
</script>

<style scoped>
.category-container > li {
    display: inline-block;
    list-style-type: none;
}
.bid-container > li {
    list-style-type: none;
    display: flex;
}
</style>