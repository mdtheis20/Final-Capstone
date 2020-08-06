<template>
  <form id="bid-form" v-on:submit.prevent="placeBid">
    <div>
      <input type="radio" name="easyButtons" class="radio-selector" />
      <button type="submit" v-on:click="() => newBid.amount = 1">$1</button>
      <button type="submit" v-on:click="() => newBid.amount = 5">$5</button>
      <button type="submit" v-on:click="() => newBid.amount = 10">$10</button>
      <button type="submit" v-on:click="() => newBid.amount = 20">$20</button>
    </div>

    <div>
      <input type="radio" name="custom" class="radio-selector" />
      <label for="amount">Enter Amount:</label>
      <input type="number" name="amount" id="custom-bid-amount" :value="newBid.amount" />
    </div>
  </form>
</template>

<script>
// TODO: items do not load if you go straight to the url without going to home
export default {
  data() {
    return {

    };
  },
  props: {
    itemID: Number,
  },

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