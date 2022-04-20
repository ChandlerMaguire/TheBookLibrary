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
        >Add Book <font-awesome-icon icon="fa-solid fa-circle-plus" /></router-link
      >
      <span
        v-show="$store.state.token != ''"
        >&nbsp;|&nbsp;</span
      >
      <router-link
        v-bind:to="{ name: 'Forum' }"
        v-if="
          $store.state.token != ''
        "
        >Forum <font-awesome-icon icon="fa-solid fa-people-group" /></router-link
      >
       <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout <font-awesome-icon icon="fa-solid fa-right-from-bracket"
      /></router-link>
      <span v-show="$store.state.token == ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''"
        >Login <font-awesome-icon icon="fa-solid fa-right-to-bracket" /></router-link
      >
    </div>
    <h1 id="library-header">The Book Library</h1>
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
}
h1,
h2 {
  text-align: center;
  text-shadow: 3px 2px 3px grey;
}
img {
  width: 150px;
  height: 230px;
  margin: 10px;
  border: 1px solid var(--blue);
}
h2 {
  text-align: center;
}
table {
  width: 100%;
  border: 2px solid;
  border-color: var(--red);
  color: var(--navy);
  text-align: center;
  table-layout: fixed;
  /* background-color: var(--yellow); */
}
tr {
  border: 1px solid var(--pink);
}
/* tr:nth-child(even) {
  background-color:rgba(255, 182, 46, .8);
} */
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
<<<<<<< HEAD
}


/* @import './assets/styles/yourstyles.css';
<link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css"> */
</style>


/* /* SCSS RGB */
$middle-red-purple: rgba(175, 91, 91, 1);
$honey-yellow: rgba(255, 182, 46, 1);
$space-cadet: rgba(24, 48, 89, 1);
$celtic-blue: rgba(39, 111, 191, 1);
$queen-pink: rgba(238, 207, 212, 1); */
=======
}
>>>>>>> 55322462c75ee917babe7c4b6ee83d5d64b27848
