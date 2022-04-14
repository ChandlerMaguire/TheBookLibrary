import axios from 'axios';

export default {

  add(book) {
    return axios.post('/addbook', book)
  }
}