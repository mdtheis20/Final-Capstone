<template>
  <div id="active-bids">
    <current-bid-table v-bind:currentBids="currentBids"/>
      <bid-table  v-bind:bids="bids"/>
    </div>
</template>

<script>
import APIService from "@/services/ApiService.js"
import BidTable from "@/components/BidTable.vue"
import CurrentBidTable from "@/components/CurrentBidTable.vue"
export default {
    components: {
        BidTable,
        CurrentBidTable
    },
    data() {
        return {
            bids: Array,
            currentBids: Array,
        }
    },

    created() {
        APIService.getBidsForSingleUser().then( resp => {
            if (resp.status === 200){
                this.bids = resp.data;
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

      APIService.getHighestBidPerItemForSingleUser().then( resp => {
        if (resp.status === 200){
          this.currentBids = resp.data;

        }
      }).catch(e => {
        if (e.response) {
          console.error(e.response)
        }else if (e.request) {
          console.error(e.request)
        } else {
          console.error('There was an error!')
        }
      });

    }
    
    

};
</script>

<style>
#bid-table {
  display: flex;
  flex-direction: column;
  align-content: center;
  justify-content: right;
    
  border: cadetblue ridge;
}
</style>