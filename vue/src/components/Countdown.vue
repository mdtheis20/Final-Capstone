<template>
  <div id="countdown">
       <ul>
        <li><span id="days">{{days}} </span><div>days</div></li>
        <li><span id="hours">{{hours}} </span><div>hours</div></li>
        <li><span id="minutes">{{minutes}} </span><div>minutes</div></li>
        <li><span id="seconds">{{seconds}}</span> <div>seconds</div></li>
      </ul>
  </div>
</template>

<script>
export default {
      data(){
    return{
      timeRemaining: "",
      days: "",
      hours: "",
      minutes: "",
      seconds: "",
      counter: 0,
      timer: null
    /*   organizationName: this.$store.state.auctionInfo.orgName,
      endTime: this.$store.state.auctionInfo.endTime */
      //TODO: let's try to make this a countdown
    }
  },
 methods: {
    
     countdown(){


      const endTime = this.$store.state.auctionInfo.endTime;
      
      let now = new Date().getTime();
      let t = endTime - now;
      let days = Math.floor(t/ (1000 * 60 * 60 * 24));
      let hours = Math.floor((t%(1000*60*60*24))/(1000*60*60));
      let minutes = Math.floor((t%(1000*60*60))/(1000*60));
      let seconds = Math.floor((t%(1000*60))/1000);

       this.timeRemaining = `${days} days ${hours} hours ${minutes} minutes ${seconds} seconds`;
       this.days = `${days}`
       this.hours = `${hours}`
       this.minutes = `${minutes}`
       this.seconds = `${seconds}`
    }
    },
    

  created() {
  
    setInterval(function(vue){
      vue.countdown();
    }, 1000, this);


}
  
}
</script>

<style>
#countdown li {
  display: inline-block;
  list-style-type: none;
  padding: 1em;
  text-transform: uppercase;
  
}

#countdown li > span {
  font-size: 2em;
 
}
#countdown ul{
  width: 100%;
  position: fixed;
  top: 0;
  text-align: right;
}

#countdown div{
   position: relative;
}
</style>