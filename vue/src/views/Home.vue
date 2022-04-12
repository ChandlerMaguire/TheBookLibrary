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
