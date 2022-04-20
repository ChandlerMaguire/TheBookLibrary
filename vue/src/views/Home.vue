<template>
  <div class="container">
    <div class="home">
      <h2 class="staff-picks-header">Staff Picks</h2>
      <staff-picks id="staff-picks" />
      <h2 class="new-releases-header">New Releases</h2>
      <new-releases id="new-releases" />
    </div>
    <div>
      <Search class="search"></Search>
    </div>
  </div>
</template>

<script>
import Search from "@/components/Search.vue";
import StaffPicks from "@/components/StaffPicks.vue";
import NewReleases from "../components/NewReleases.vue";

export default {
  name: "Home",
  components: { Search, StaffPicks, NewReleases },
};
</script>

<style>
.container {
  display: grid;
  width: 100vw;
  height: 100vw;
  grid-template-columns: auto;
  grid-template-areas:
    "home search"
    "home search";
  margin: 0;
}

.home {
  width: 75vw;
  grid-area: "home";
  grid-template-areas:
    "staff-picks"
    "new-releases";
}

.search {
  width: 25vw;
  grid-area: "search";
  padding: 5%;
  min-width: fit-content;
  margin-right: 20%;
}
#staff-picks {
  grid-area: "staff-picks";
}
#new-releases {
  grid-area: "new-releases";
}
.staff-picks-header {
  position: absolute;
  margin-bottom: -30px;
  margin-left: 10px;
  font-style: italic;
  font-size: 25px;
}
.new-releases-header{
  position: absolute;
  font-style: italic;
  margin-left: 10px;
  margin-top: 2px;
  font-size: 25px;
}
</style>