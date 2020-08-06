import axios from 'axios'

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

export default {
    getAllItems() {
        return axios.get('/items')
      },
    getAllCategories() {
        return axios.get('/auction/categories')
    },
    postBid(id) {
        return axios.post(`/items/${id}/bids`)
    }
}