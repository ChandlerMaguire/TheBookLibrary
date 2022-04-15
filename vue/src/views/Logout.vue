<template>
  <div>
    <h1>Logout</h1>
    <p>This page should never be displayed</p>
  </div>
</template>

<script>
import searchService from "@/services/SearchService.js";
export default {
  created() {
    if (this.$store.state.userSearched) {
      searchService.updateSearchTime();
    }
    this.$store.commit("LOGOUT");
    this.$store.commit("RESET_MY_BOOKS");
    this.$router.push("/login");
  },
};
</script>
