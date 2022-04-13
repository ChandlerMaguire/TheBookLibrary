<template>
  <div class="home">
    <h1>The Book Library</h1>
    <Search  class="search"></Search>
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
  padding: 5%;
}
h1 {
  grid-area: "home";
}
.home p {
  grid-area: "results";
}
</style>