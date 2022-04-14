<template>
  <div id="app" >
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <span v-show="$store.state.token == ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">Login</router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'my-books' }" v-if="$store.state.token != ''">My Books</router-link>
      <span v-show="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'add-book' }" v-if="$store.state.token != ''">Add Book</router-link>
    </div>
    <h1>The Book Library</h1>
    <router-view />
  </div>
</template>

<style>
:root {
--red: #A45151;
--yellow: #ffb62eff;
--navy: #183059ff;
--blue: #276fbfff;
--pink: #eecfd4ff;
--lightyellow: rgb(255, 211, 130);
--button: rgb(253, 203, 110);
}
html{
height: 100vh;
}
body {
background-image: linear-gradient(to bottom, var(--lightyellow), var(--yellow));
background-attachment: fixed;
  height: 100vh;
  margin: 0;
  background-repeat: no-repeat;
  font-family: 'Georgia', sans-serif;
  overscroll-behavior-y: none;
  
}

#nav { text-align: center;}
h1, h2{
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
  color: var(--blue);
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
  height: 25px;
}

#removeButton {
  height: 35px;
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
