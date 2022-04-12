import axios from 'axios';

export default {

  search(search) {
    return axios.post('/book/search', search)
  }
}
