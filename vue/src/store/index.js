import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import authService from '@/services/AuthService.js';

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */

const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}


export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    listOfItems: [],
    // TODO: grab data from API
    auctionInfo: {
      orgName: 'Tech Elevator Auctions',
      endTime: new Date(2020, 7, 14, 12 )
    }
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_ITEM_LIST(state, list) {
      state.listOfItems = list;
    }
  },
  actions: {
    getAllItems(){
      authService.getAllItems().then( r => {
          this.commit('SET_ITEM_LIST', r.data);
      }).catch( e => {
        if (e.response){
          console.error(e.response)
        } else if (e.request) {
          console.error(e.request) 
        } else {
          console.error('There was an error!')
        }
      });
    },
    
  }
})

