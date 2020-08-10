<template>
  <div id="auction">
    <auction-header />    
    
    <nav id="nav" :class="{'nav-active': isShow}">
      <img src="@/assets/icons8-menu-384.png" alt="hamburger menu icon" id="hamburger-menu" v-on:click="showHide()" />
      <div id="nav-menu" v-if="isShow">
        <router-link :to="{ name: 'home' }">Home</router-link>
        <router-link :to="{ name: 'login' }" v-if="!isLoggedIn">Login</router-link>
        <router-link v-bind:to="{ name: 'logout' }" v-if="isLoggedIn">Logout</router-link>
        <router-link :to="{ name: 'register'}"  v-if="!isLoggedIn">Register</router-link>
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
  background-color: #1b262c;
  text-align: center;
  padding: 10px;
}
#auction {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #e7dfd5;  
  max-width: 1200px;
  margin: 0 auto 0 auto;
}
#nav {
  display: inline-block;
  overflow: hidden;
  flex-wrap: nowrap;
  justify-content: space-evenly;
  margin-bottom: 10px;
  width: 50%;

}
#nav a {
  padding: 15px;
  margin: 5px;
  color: white;
  font-size: 1.25em;
}
a {
  text-decoration: none;
}
#hamburger-menu {
  height: 50px;
  margin: 0px;
  cursor: pointer;  
}
.nav-active {
/* change this color   */
background-color: grey;
border: 1px solid grey;
border-radius: 8px;
}
#nav-menu {
  display: flex;
  flex-direction: column;
}
button {
  padding: 15px;
  margin: 20px;
  background-color: #0070F3;
  cursor: pointer;
}
</style>