<template>
  <div>
      <auction-header />
      <bid-form :itemID="foundItem.itemID" />
      <item-detail :item="foundItem"/>

  </div>
</template>

<script>
import AuctionHeader from '@/components/AuctionHeader.vue';
import ItemDetail from '@/components/ItemDetail.vue';
import BidForm from '@/components/BidForm.vue';

export default {
    name: 'item',
    components: {
        AuctionHeader,
        ItemDetail,
        BidForm
    },
    computed: {
        foundItem(){
            const targetID = this.$route.params.itemID;
            return this.$store.state.listOfItems.find(i => i.item_ID === targetID)
        }
    }
}
</script>

<style>

</style>