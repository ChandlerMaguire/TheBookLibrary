import axios from 'axios';

export default {

  search(search) {
    return axios.post('/search', search)
  },
  updateSearchTime() {
    return axios.put('/newbooks')
  }

}
