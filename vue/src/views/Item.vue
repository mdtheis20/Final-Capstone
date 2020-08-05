<template>
  <div>
      <auction-header />
      <item-detail :item ="found-item"/>
  </div>
</template>

<script>
import AuctionHeader from '@/components/AuctionHeader.vue';
import ItemDetail from '@/components/ItemDetail.vue';
export default {
    name: 'item',
    components: {
        AuctionHeader,
        ItemDetail,
    },
    computed: {
        foundItem(){
            const targetID = this.$route.params.itemID;
            return this.$store.state.listOfItems.find(i => i.itemID === targetID)
        }
    }
}
</script>

<style>

</style>