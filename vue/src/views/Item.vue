<template>
  <div>
      <item-detail :item="item"/>

  </div>
</template>

<script>
import ItemDetail from '@/components/ItemDetail.vue';
import api from '@/services/ApiService.js';

export default {
    name: 'item',
    data() {
        return {
            item: Object,
        }
    },
    components: {
        ItemDetail,
    },
   /*  computed: {        
        foundItem_ID(){
            return this.$route.params.itemID;
        }
    }, */
    created() {
        // TODO: should this update the list of all items?
        api.getSingleItem(this.$route.params.itemID).then( r => {
            if (r.status === 200){
                this.item = r.data;
            }
        }).catch(e => {
        if (e.response) {
          console.error(e.response)
        } else if (e.request) {
          console.error(e.request)
        } else {
          console.error('There was an error!')
        }
      });
    }
}
</script>

<style>

</style>