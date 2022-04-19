import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

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
    userSearched: false,
    loginTime: new Date(),
    searchResult: [],
    myBooks: [],
    allBooks: [],
    staffPicks: [],
    newReleases: [],
    addedBook: {
      keyword: "",
      title: "",
      firstName: "",
      lastName: "",
      genre: "",
      character: "",
      location: "",
      isbn: "",
    },
    post: []
  },

  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      state.userSearched = false;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      // state.userBooks.user = state.user.currentUser;
      // state.userBooks.books = state.myBooks;
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    GET_SEARCH_RESULT(state, searchResult) {
      state.searchResult = searchResult;
    },
    ADD_TO_MY_BOOKS(state, book) {
      state.myBooks.push(book);
    },
    REMOVE_FROM_MY_BOOKS(state, book) {
      let index = state.myBooks.indexOf(book);
      state.myBooks.splice(index, 1);
    },
    RESET_MY_BOOKS(state) {
      state.myBooks = [];
    },
    ADD_BOOK(state, book) {
      state.addedBook = book;
    },
    GET_ALL_BOOKS(state, books) {
      state.allBooks = books;
    },
    GET_STAFF_PICKS(state, staffPicks){
      state.staffPicks = staffPicks;
    },
    GET_NEW_RELEASES(state, newReleases){
      state.newReleases = newReleases;
    },
    UPDATE_USER_SEARCHED(state) {
      state.userSearched = true;
    },
    UPDATE_SEARCH_TIME(state) {
      state.user.lastSearch = Date.now();
    },
    SET_CURRENT_POST(state, post) {
      state.post = post;
    },
  }
})


/* {
  postId: "",
  posterId: "", 
  username: "",
  title: "",
  message: "",
  postDate: ""
} */

