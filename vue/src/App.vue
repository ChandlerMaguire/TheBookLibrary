<template>
  <div id="app">
    <img
      class="liner"
      src="https://i.pinimg.com/originals/82/8d/dd/828dddd2d589db12239013ff67c209db.png"
    />
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }"
        >Home <font-awesome-icon icon="fa-solid fa-home"
      /></router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link
        v-bind:to="{ name: 'my-books' }"
        v-if="$store.state.token != ''"
        >My Books <font-awesome-icon icon="fa-solid fa-book-open-reader"
      /></router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link
        v-bind:to="{ name: 'new-books' }"
        v-if="$store.state.token != ''"
        >New Books <font-awesome-icon icon="fa-solid fa-book"
      /></router-link>
      <span
        v-if="this.$store.state.user.role == 'admin'"
        v-show="$store.state.token != ''"
        >&nbsp;|&nbsp;</span
      >
      <router-link
        v-bind:to="{ name: 'add-book' }"
        v-if="
          $store.state.token != '' && this.$store.state.user.role == 'admin'
        "
        >Add Book <font-awesome-icon icon="fa-solid fa-circle-plus"
      /></router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'Forum' }" v-if="$store.state.token != ''"
        >Forum <font-awesome-icon icon="fa-solid fa-people-group"
      /></router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout <font-awesome-icon icon="fa-solid fa-right-from-bracket"
      /></router-link>
      <span v-show="$store.state.token == ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''"
        >Login <font-awesome-icon icon="fa-solid fa-right-to-bracket"
      /></router-link>
    </div>
    <span id="username-icon" v-show="$store.state.token != ''"
      >Hi, {{ this.$store.state.user.username }}.
      <font-awesome-icon icon="fa-solid fa-user"
    /></span>
    <div class="title-and-pic">
      <img
        class="title-pic"
        src="https://www.transparentpng.com/thumb/book/k1ANjs-light-book-picture-png.png"
      />
      <h1 id="library-header">The Book Library</h1>
    </div>
    <div class="container">
      <Search
        class="search"
        v-if="this.$route.name != 'login' && this.$route.name != 'add-book' && this.$route.name != 'newsletterpage' && this.$route.name !='Forum' && this.$route.name !='Post'"
      ></Search>
      <newsletter
        class="newsletter"
        v-if="this.$route.name != 'login' && this.$route.name != 'add-book'  && this.$route.name != 'newsletterpage'  && this.$route.name !='Forum' && this.$route.name !='Post'"/>
    </div>
    <router-view />
  </div>
</template>

<script>
import bookService from "@/services/BookService.js";
import Search from "@/components/Search.vue";
import Newsletter from "@/components/Newsletter.vue";

export default {
  components: { Search, Newsletter },
  name: "app",

  created() {
    bookService
      .getAllBooks()
      .then((response) => {
        if (response.status == 200) {
          this.$store.commit("GET_ALL_BOOKS", response.data);
        }
      })
      .catch((error) => {
        const response = error.response;

        if (response.status === 401) {
          this.invalidCredentials = true;
        }
      });
    bookService.getStaffPicks().then((response) => {
      if (response.status == 200) {
        this.$store.commit("GET_STAFF_PICKS", response.data);
      }
    });
    bookService.getNewReleases().then((response) => {
      if (response.status == 200) {
        this.$store.commit("GET_NEW_RELEASES", response.data);
      }
    });
    bookService.getHotTopics().then((response) => {
      if (response.status == 200) {
        this.$store.commit("GET_HOT_TOPICS", response.data);
      }
    });
  },
};
</script>

<style>
:root {
  --red: #a45151;
  --yellow: #ffb62eff;
  --navy: #183059ff;
  --blue: #276fbfff;
  --pink: #eecfd4ff;
  --lightyellow: rgb(255, 211, 130);
  --button: rgb(253, 203, 110);
}
html {
  height: 100vh;
}
body {
  background-image: linear-gradient(
    to bottom,
    var(--lightyellow),
    var(--yellow)
  );
  background-attachment: fixed;
  height: 100vh;
  margin: 0;
  background-repeat: no-repeat;
  font-family: "Georgia", sans-serif;
  overscroll-behavior-y: none;
}
.liner {
  opacity: 1;
  border: none;
  width: 100vw;
  height: 100%;  
  bottom: 0;
  border: none;
  box-shadow: none;
  position: fixed;
  margin: 0;
  z-index: -2; 
}
.notBook {
  width: initial;
  height: initial;
  border: none;
  box-shadow: none;
  position: absolute;
  margin: 0;
  z-index: -2; 
}
#nothing {
  transform: rotate(0deg) translate(0%, 100%);
}
#nav {
  text-align: center;
  filter: drop-shadow(0 0 2px white) drop-shadow(0 0 2px white);
}
h1,
h2 {
  text-align: center;
  text-shadow: 3px 2px 3px grey;
}
h1 {
  margin-top: 10px;
  margin-bottom: 40px;
  text-align: center;
  text-shadow: 3px 2px 3px grey, 0px 0px 3px white, 0px 0px 6px white,
    0px 0px 3px white;
}
.title-and-pic {
  margin-top: 20px;
  margin-bottom: -20px;
}
.title-pic {
  width: auto;
  height: auto;
  border: none;
  position: absolute;
  z-index: -1;
  margin: 0;
  left: 50%;
  transform: translate(-50%, -40%);
  box-shadow: none;
  filter: drop-shadow(0 -6mm 4mm var(--pink));
}
img {
  width: 150px;
  height: 230px;
  margin: 10px;
  border: 1px solid var(--blue);
  box-shadow: 8px 8px 5px rgba(0, 0, 0, 0.1);
}
#search {
  width: 25vw;
  grid-area: "search";
  padding: 10px;
  /* min-width: fit-content; */
  right: 0;
  margin-top: 30px;
  position: absolute;
  display: flex;
  flex-direction: column;
}
#newsletter {
  width: 25vw;
  grid-area: "search";
  padding: 10px;
  right: 0;
  top: 680px;
  position: absolute;
}

table {
  width: 100%;
  border: 2px solid;
  border-color: var(--red);
  color: var(--navy);
  text-align: center;
  table-layout: fixed;
}
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 1);
}
th {
  padding: 5px;
  border-bottom: 2px solid var(--red);
}
.toggleButton {
  padding-bottom: 0;
  margin-bottom: 10px;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  width: 100px;
  font-size: 0.7em;
  align-self: center;
}
.toggleButton:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.9s ease 0s;
}
#addButton {
  min-height: fit-content;
  margin-top: auto;
}
#removeButton {
  min-height: fit-content;
  margin-top: auto;
}
form {
  margin-top: 13px;
  background-color: var(--yellow);
  padding: 5px;
  border: 1px solid var(--red);
  margin-right: 10px;
  border-radius: 10px;
}
input,
select {
  margin-bottom: 5px;
}

h4 {
  text-align: center;
  padding-top: 10px;
  padding-right: 10px;
  font-size: 22px;
  text-shadow: 0px 0px 4px white;
}
#submit {
  margin-bottom: 0;
  padding-bottom: 0;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  width: 100px;
  align-self: center;
}
#submit:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}


#username-icon {
  float: right;
  margin-top: -22px;
  margin-right: 10px;
  color: #007bff;
  filter: drop-shadow(0 0 2px white) drop-shadow(0 0 2px white);
}
</style>
