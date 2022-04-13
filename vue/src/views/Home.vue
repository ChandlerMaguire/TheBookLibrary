<template>
  <div>
    <h1 class="home">Home</h1>
    <div class="results">
      <p>Welcome to your new home.</p>
      <p>In the initial configuration, this page can only be seen when logged in.</p>
    </div>
      
    
    <Search class="search"></Search>
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
p {
  grid-area: "results";
}
</style>