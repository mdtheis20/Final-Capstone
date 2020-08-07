<template>
  <div id="auction">
    <auction-header />
    <nav id="nav">
      <router-link :to="{ name: 'home' }">Home</router-link>
      <router-link :to="{ name: 'login' }" v-if="!isLoggedIn">Login</router-link>
       <router-link :to="{ name: 'register' }">Register</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="isLoggedIn">Logout</router-link>
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
  computed: {
    isLoggedIn() {
      return this.$store.state.token != '';
    }
  }
}
</script>

<style>
body {
  background-color: #1b262c;

}
#auction {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #e7dfd5;  
  max-width: 800px;
  margin: 0 auto 0 auto;
}
#nav {
  display: flex;
  flex-wrap: nowrap;
  justify-content: space-evenly;
  margin-bottom: 10px;
}
#nav a {
  padding: 8px;
  background-color: white;
  border: 2px solid white;
  border-radius: 5px;
}
a {
  text-decoration: none;
}
</style>