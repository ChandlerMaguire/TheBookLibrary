<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
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
}
</style>


/* /* SCSS RGB */
$middle-red-purple: rgba(175, 91, 91, 1);
$honey-yellow: rgba(255, 182, 46, 1);
$space-cadet: rgba(24, 48, 89, 1);
$celtic-blue: rgba(39, 111, 191, 1);
$queen-pink: rgba(238, 207, 212, 1); */
