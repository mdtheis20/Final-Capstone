<template>
  <div id="item-card">
      <h3>{{item.title}}</h3>
      <h4>{{item.startingBid}}</h4>      
      <img :src="item.pic" :alt="item.subtitle" />
      <!-- <p>{{item.subtitle}}</p> -->
  </div>
</template>

<script>
export default {
    data() {
        return {
            /* item: {
                itemID: Number,
                title: '',
                subtitle: '',
                pic: '',
                startingBid: Number,
                category: []
            } */
            // TODO: display top bid instead of starting bid if there are bids
            // TODO: display how many bids have benn placed
        }
    },
    props: {
        item: {
                itemID: Number,
                title: '',
                subtitle: '',
                pic: '',
                startingBid: Number,
                category: []
            }
    }
}
</script>

<style>

</style>