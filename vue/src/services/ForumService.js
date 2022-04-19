import axios from 'axios';

export default {

  getAllPosts() {
    return axios.get('/forum')
  },
  getPost(id) {
    return axios.get(`/forum/${id}`);
  },
  addPost(newPost){
    return axios.post('/forum', newPost)
  }
}