<template>
  <header>
      <h1>{{organizationName}}</h1>
      <div class="header-times">
        <p>End time: {{endTime}}</p>
        <p>Countdown: </p>
      </div>
      
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
header {
  background-color: #1b262c;
}
header h1 {
    color: #e7dfd5;
    font-size: 3em;
    margin-bottom: 0px;
}
header .header-times {
  display: flex;
  justify-content: space-between;
}

</style>