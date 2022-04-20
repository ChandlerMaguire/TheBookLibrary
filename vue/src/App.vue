<template>
  <div id="app">
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
    <div class="title-and-pic">
      <img class="title-pic" src="https://www.transparentpng.com/thumb/book/k1ANjs-light-book-picture-png.png" />
      <h1>The Book Library</h1>
    </div>
    <router-view />
  </div>
</template>

<script>
import bookService from "@/services/BookService.js";

export default {
  name: "app",
  // data() {
  //   return {
  //     tempBooks[],
  //     staffPicks: [],
  //   };
  // },
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
#nav {
  text-align: center;
  text-shadow: 0px 0px 5px white, 0px 0px 5px white;
}
h1,
h2 {
  text-align: center;
  text-shadow: 3px 2px 3px grey;
}
h1{
  margin-top: 10px;
  margin-bottom: 40px;
  text-align: center;
  text-shadow: 3px 2px 3px grey, 0px 0px 3px white, 0px 0px 6px white, 0px 0px 3px white;
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
}
img {
  width: 150px;
  height: 230px;
  margin: 10px;
  border: 1px solid var(--blue);
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
  font-size: 10px;
  align-self: center;
}
.toggleButton:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}
#addButton {
  min-width: fit-content;
  min-height: fit-content;
}

#removeButton {
  min-width: fit-content;
  min-height: fit-content;
}
</style>