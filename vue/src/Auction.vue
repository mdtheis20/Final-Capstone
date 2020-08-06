<template>
  <div id="auction">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link :to="{ name: 'login' }">Login</router-link>&nbsp;|&nbsp;
       <router-link :to="{ name: 'register' }">Register</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>

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
  margin: 60px auto 0 auto;
}
</style>