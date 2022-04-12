<template>
  <div class="home">
    <h1>Home</h1>
    <p>Welcome to your new home.</p>
    <p>
      In the initial configuration, this page can only be seen when logged in.
    </p>
    <Search></Search>
  </div>
</template>

<script>
import Search from "@/components/Search.vue";

export default {
  name: "Home",
  components: { Search },
};
</script>

<style>
.home {
  display: grid;
  grid-template-columns: 3fr 1.5fr;
  grid-template-areas:
    "home home"
    "results search";
}
.search {
  grid-area: "search";
}
h1 {
  grid-area: "home";
}
h1 > p {
  grid-area: "results";
}
</style>