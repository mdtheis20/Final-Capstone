<template>
  <header>
      <h1>{{organizationName}}</h1>
      <p>Time Remaining: {{countdown}}</p>
      
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
    countdown(){
      const endTime = this.$store.state.auctionInfo.endTime;

      let now = new Date().getTime();
      let t = endTime - now;
      let days = Math.floor(t/ (1000 * 60 * 60 * 24));
      let hours = Math.floor((t%(1000*60*60*24))/(1000*60*60));
      let minutes = Math.floor((t%(1000*60*60))/(1000*60));
      let seconds = Math.floor((t%(1000*60))/1000);

      return `${days} days ${hours} hours ${minutes} minutes ${seconds} seconds`
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
}

</style>