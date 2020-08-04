import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

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

const http = axios.create({
  baseURL: process.env.VUE_APP_REMOTE_API
});

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    listOfItems: [
      {
        itemID: 1,
        title: 'Josh\'s Waterbottle',
        subtitle: 'Drank from by the one and only Josh Tucholski',
        pic: 'https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80',
        startingBid: 20,
        category: ['Celebrity', 'Sports Memorabilia', 'Horcrux']
      },   
      {
        itemID: 2,
        title: 'Clyde\'s Special Catnip',
        subtitle: 'A secret blend of herbs, spices, and proteins that every cat will love',
        pic: 'https://i.insider.com/5b2d07195e48eca9028b458d?width=750&format=jpeg&auto=webp',
        startingBid: 10,
        category: ['Celebrity', 'Animals']
      },
      {
        itemID: 3,
        title: 'Hotel Stay at the beach for 2',
        subtitle: 'One night with a lovely ocean view',
        pic: 'https://www.simplemost.com/wp-content/uploads/2016/08/beach-vacation-e1470663653924.jpeg',
        startingBid: 150,
        category: ['Vacation', 'Relaxation']
      }, 
      {
        itemID: 4,
        title: 'Baseball signed by Omar Vizquel',
        subtitle: 'Signed by the world\'s greatest shortstop',
        pic: 'https://i1.wp.com/www.cooperstowncred.com/wp-content/uploads/2018/12/OMAR-VIZQUEL-CHUCK-CROW.png?fit=922%2C644&ssl=1',
        startingBid: 250,
        category: ['Celebrity', 'Sports Memorabilia']
      }, 
      {
        itemID: 5,
        title: 'Fruit Basket',
        subtitle: 'You may not eat it all, but it looks nice',
        pic: 'https://www.bachatagifts.com/124-thickbox_default/fruit-basket-big-delivered-in-dominican-republic.jpg',
        startingBid: 5,
        category: ['Food', 'Relaxation']
      },      
    ]
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
    }
  }
})
