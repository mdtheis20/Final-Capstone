<template>
  <header v-on:click="() => this.$router.push({name: 'home'})">
      <h1>{{organizationName}}</h1>
      <p>Time Remaining: {{timeRemaining}}</p>
      
  </header>
</template>

<script>
export default {
  data(){
    return{
      timeRemaining: "",
      counter: 0,
      timer: null
    /*   organizationName: this.$store.state.auctionInfo.orgName,
      endTime: this.$store.state.auctionInfo.endTime */
      //TODO: let's try to make this a countdown
    }
  },
  computed: {
    organizationName(){
      return this.$store.state.auctionInfo.orgName;
    },
    // TODO: finish countdown
  
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
header {
  /* background-color: #1b262c; */
  cursor: pointer;
}
header h1 {
    
    font-family: "Brush Script MT", cursive; font-size: 50px; font-style: normal; font-variant: normal; ;
    text-align: center;
  color: #fff;
  text-align: center;
  text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;
  
  animation: glow .75s ease-in-out infinite alternate;
    color: #e7dfd5;
        font-family: "Brush Script MT", cursive; font-size: 50px; font-style: normal; font-variant: normal; ;
    text-align: center;


  color: #fff;
  text-align: center;
 text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;

  animation: glow .75s ease-in-out infinite alternate;
}

@keyframes glow {
 from {
    text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;
  }
  to {
    text-shadow: 0 0 10px #fff, 0 0 20px #fff, 0 0 30px #0073e6, 0 0 40px #0073e6, 0 0 50px #0073e6, 0 0 60px #0073e6, 0 0 70px #0073e6;
  }
}
header p {
  text-align: center;
}

@keyframes glow {
  from {
    text-shadow: 0 0 5px #fff, 0 0 10px #fff, 0 0 15px #0073e6, 0 0 20px #0073e6, 0 0 25px #0073e6, 0 0 30px #0073e6, 0 0 35px #0073e6;
  }
  to {
    text-shadow: 0 0 10px #fff, 0 0 20px #fff, 0 0 30px #0073e6, 0 0 40px #0073e6, 0 0 50px #0073e6, 0 0 60px #0073e6, 0 0 70px #0073e6;
  }
}
header p {
  text-align: center;
}
</style>