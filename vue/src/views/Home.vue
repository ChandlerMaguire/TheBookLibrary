<template>
  <div class ="container">
    <div class="home">
      </div>
      <div>
    <Search class="search"></Search>
    </div>
  </div>
</template>

<script>
import Search from "@/components/Search.vue";

export default {
  name: "Home",
  components: { Search },
  // computed: {
  //   resetResult() {
  //     return this.$store.state.searchResults;
  //   }
  // }
};
</script>

<style>
.container {
  display: grid;
  grid-template-columns: 3fr 1.5fr;
  grid-template-areas: "... search";
  width: 100vw;
}

.search {
  grid-area: "search";
  padding: 5%;
}
</style>