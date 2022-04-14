import axios from 'axios';

export default {

  updateMyBooks(userBooks) {
    return axios.put('/mybooks', userBooks)
  }
}