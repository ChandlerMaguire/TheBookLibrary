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
    isSubscribed: false,
    loginTime: new Date(),
    searchResult: [],
    myBooks: [],
    allBooks: [],
    staffPicks: [],
    newReleases: [],
    hotTopics: [],
    newsletterText: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc dictum nulla in erat condimentum, sit amet eleifend quam accumsan. Donec nibh sapien, mollis et ipsum ac, pulvinar eleifend mi. Ut consectetur pharetra justo ultrices dapibus. Nam congue ornare aliquet. Phasellus viverra arcu vel sapien interdum, egestas accumsan metus dignissim. Nulla at dolor vitae nisl scelerisque congue. Vestibulum sagittis, est sit amet lacinia lobortis, dui urna congue lorem, vehicula tincidunt massa lectus sit amet quam. Mauris porta dui nec eros sodales fringilla. Nullam finibus nulla quis dolor mollis rhoncus. Pellentesque vel arcu suscipit, scelerisque ex vel, auctor odio. Curabitur nec risus rhoncus, aliquet arcu eu, porttitor quam. Mauris elementum magna turpis, sit amet congue magna lacinia et. Sed pellentesque vehicula egestas. Fusce malesuada congue gravida. Nulla bibendum libero mauris, in mattis metus suscipit et. Suspendisse potenti. Nulla venenatis enim eget dignissim tempor. Quisque at risus sit amet leo interdum finibus. Maecenas ut consectetur erat, rutrum fringilla nunc. In nec quam nulla. Donec vitae gravida urna. Maecenas facilisis quis sem ut interdum. Vestibulum vel ipsum in mauris dignissim euismod. Maecenas ac varius risus. Ut ac interdum dui. Maecenas quis elementum mi. Curabitur lobortis ipsum in ligula iaculis, sed elementum enim sagittis. Ut.",
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
    GET_STAFF_PICKS(state, staffPicks) {
      state.staffPicks = staffPicks;
    },
    GET_NEW_RELEASES(state, newReleases) {
      state.newReleases = newReleases;
    },
    GET_HOT_TOPICS(state, hotTopics){
      state.hotTopics = hotTopics;
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
    SUBSCRIBE(state) {
        state.isSubscribed = true;
    },
    UNSUBSCRIBE(state) {
      state.isSubscribed = false;
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

