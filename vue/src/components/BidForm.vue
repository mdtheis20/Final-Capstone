<template>
  <form id="bid-form">
    <div>
      <input type="radio" name="easyButtons" class="radio-selector" />
      <button>$1</button>
      <button>$5</button>
      <button>$10</button>
      <button>$20</button>
    </div>

    <div>
      <input type="radio" name="custom" class="radio-selector" />
      <label for="amount">Enter Amount:</label>
      <input type="number" name="amount" id="custom-bid-amount" />
    </div>
  </form>
</template>

<script>
// TODO: items do not load if you go straight to the url without going to home
export default {
  data() {
    return {
      bid: {
        bid_id: 0,
        item_id: 0,
        user_id: this.$store.state.user,
        amount: 0.0,
        time_placed: null,
      }
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