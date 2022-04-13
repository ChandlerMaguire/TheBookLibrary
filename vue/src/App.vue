<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
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
body {
  background-color: var(--lightyellow);
}
#nav { text-align: center;}
h1{
  text-align: center;
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
