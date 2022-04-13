import axios from 'axios';

export default {

  search(search) {
    return axios.post('/mybooks', $store.state.userBooks)
  }
}