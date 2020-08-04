<template>
  <header>
      <h1>{{organizationName}}</h1>
      <p>End time: {{endTime}}</p>
      
  </header>
</template>

<script>
export default {
  data(){
    return{
    /*   organizationName: this.$store.state.auctionInfo.orgName,
      endTime: this.$store.state.auctionInfo.endTime */
      //TODO: let's try to make this a countdown
    }
  },
  computed: {
    organizationName(){
      return this.$store.state.auctionInfo.orgName;
    },
    endTime(){
      return this.$store.state.auctionInfo.endTime;
    },
  }
}
</script>

<style>

</style>