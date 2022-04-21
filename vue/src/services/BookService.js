import axios from 'axios';

export default {

  updateMyBooks(myBooks) {
    return axios.put('/mybooks', myBooks)
  },

  getReadingList() {
    return axios.get('/mybooks')
  },
  getAllBooks() {
    return axios.get('/allbooks')
  },
  getStaffPicks() {
    return axios.get('/staffpicks')
  },
  getNewReleases() {
    return axios.get('/newreleases')
  },
  getHotTopics() {
    return axios.get('/hottopics')
  }
}