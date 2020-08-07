<template>
  <div>
      <item-detail :item_ID="foundItem_ID"/>

  </div>
</template>

<script>
import ItemDetail from '@/components/ItemDetail.vue';


export default {
    name: 'item',
    components: {
        ItemDetail,
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