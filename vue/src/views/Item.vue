<template>
  <div>
      <bid-form :item_ID="foundItem_ID" />
      <item-detail :item_ID="foundItem_ID"/>

  </div>
</template>

<script>
import ItemDetail from '@/components/ItemDetail.vue';
import BidForm from '@/components/BidForm.vue';

export default {
    name: 'item',
    components: {
        ItemDetail,
        BidForm
    },
    computed: {
        foundItem_ID(){
            return this.$route.params.itemID;
        }
    }
}
</script>

<style>

</style>