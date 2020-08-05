import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
//import authService from '@/services/AuthService.js';
import apiService from '@/services/ApiService.js'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */

const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}


export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    listOfItems: [],
    listOfCategories: [],
    auctionInfo: {
      // TODO: get this data from database
      orgName: 'Tech Elevator Auctions',
      endTime: new Date(2020, 7, 14, 12)
    },
    listOfBids: [],
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
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
    },
    SET_CATEGORY_LIST(state, list) {
      state.listOfCategories = list;
    },
    /**
     * changes filteredItems in $store.state
     * 
     * @param {*} state 
     * @param {Array} arrayOfCategories 
     */
    FILTER_ITEMS_BY_CATEGORY(state, arrayOfCategories) {
      if (arrayOfCategories.length > 0 && state.listOfItems.length > 0) {
        arrayOfCategories.forEach(cat => {
          state.filteredItems = state.listOfItems.filter(i => {
            return i.categories.includes(cat.name);
          })
        });
      } else {
        state.filteredItems = state.listOfItems;
      }
    }
  },
  getters: {
    filteredItems() {
      if (this.$store.state.listOfCategories.length > 0 && this.$store.state.listOfItems.length > 0){
        let result = null;
        // if an item has a category that matches one in listOfCategories, add it to result
        // find a matching category name in listOfCategories and then add to 
        this.$store.state.listOfItems.forEach( i => {
          const categoryMatch = i.categories.find( cat => {
            const match = this.$store.state.listOfCategories.find( c => {
              return cat === c;
            });
            return match !== undefined;
          });
          if (categoryMatch !== undefined){
            result.unshift(i);
          }
        });
        return result;
      } else {
       return this.$store.state.listOfItems;
      }
    }
  },
  actions: {
    getAllItems() {
      apiService.getAllItems().then(r => {
        this.commit('SET_ITEM_LIST', r.data);
      }).catch(e => {
        if (e.response) {
          console.error(e.response)
        } else if (e.request) {
          console.error(e.request)
        } else {
          console.error('There was an error!')
        }
      });
    },
    getAllCategories() {
      apiService.getAllCategories().then(r => {
        this.commit('SET_CATEGORY_LIST', r.data);
      }).catch(e => {
        if (e.response) {
          console.error(e.response)
        } else if (e.request) {
          console.error(e.request)
        } else {
          console.error('There was an error!')
        }
      });
    }

  },
})

