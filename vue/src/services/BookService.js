import axios from 'axios';

export default {

  updateMyBooks(myBooks) {
    return axios.put('/mybooks', myBooks)
  }
}