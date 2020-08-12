<template>
  <div id="auction">
    <auction-header />    
    
    <nav id="nav" :class="{'nav-active': isShow}">
      <img src="@/assets/icons8-menu-384.png" alt="hamburger menu icon" id="hamburger-menu" v-on:click="showHide()" />
      <div id="nav-menu" v-if="isShow" v-on:click="showHide()">
        <router-link class="link-box" :to="{ name: 'home' }"> <p>Home</p></router-link>
        <router-link class="link-box" :to="{ name: 'activity' }" v-if="isLoggedIn"><p>View My Bid History</p></router-link>
        <router-link class="link-box" :to="{ name: 'login' }" v-if="!isLoggedIn"><p>Login</p></router-link>
        <router-link class="link-box" v-bind:to="{ name: 'logout' }" v-if="isLoggedIn"><p>Logout</p></router-link>
        <router-link class="link-box" :to="{ name: 'register'}"  v-if="!isLoggedIn"><p>Register</p></router-link>
      </div> 
    </nav>
    <router-view />
  </div>
</template>

<script>
import AuctionHeader from './components/AuctionHeader.vue'
export default {
  components: {
    AuctionHeader
  },
  data() {
    return {
      isShow: false
    }
  },
  computed: {
    isLoggedIn() {
      return this.$store.state.token != '';
    },    
  },
  methods: {
    showHide() {
      this.isShow = !this.isShow;
    }
  }
}
</script>

<style>
body {
  /* background-color: #1b262c; */
  text-align: center;
  padding: 10px;
  background-image: linear-gradient( #0f4c75, #1b262c );
}
#auction {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #e7dfd5;  
  max-width: 90%;
  margin: 0 auto 0 auto;
}
#nav {
  display: inline-block;
  overflow: hidden;
  flex-wrap: nowrap;
  justify-content: space-evenly;
  margin-bottom: 10px;
  /* width: 50%; */

}
#nav a {
  padding: 5px;
  margin: 5px;
  color: white;
  font-size: 1.25em;
}
a {
  text-decoration: none;
  color: #28B2FC
}
#hamburger-menu {
  height: 50px;
  margin: 0px;
  cursor: pointer;  
}
.nav-active {
/* change this color   */
/* background-color: grey;
border: 1px solid grey; */
border-radius: 8px;
}
#nav-menu {
  display: flex;
  flex-direction: column;
}
button {
  padding: 15px;
  margin: 20px;
  background-color: #B0690E;
  cursor: pointer;
}

.link-box{
  border: 1px;
 padding: 5px;
  /* border-style: ridge;
  border-color: lightgray;
  background-color: #B0690E;
  width: 300px;
  border-radius: 2px;
  color: #B0690E;
   */
}
 .link-box p{
   color:#B0690E ;
   text-decoration-line: underline;
    margin: 5px;

 }

</style>