<template>
  <div class="container">
    <div class="home">
      <h2 class="staff-picks-header">Staff Picks <font-awesome-icon class="flame" icon="fa-solid fa-fire-flame-curved"
      /></h2>
      <staff-picks id="staff-picks" />
      <h2 class="new-releases-header">New Releases <font-awesome-icon class="hand" icon="fa-solid fa-hand-sparkles"
      /></h2>
      <new-releases id="new-releases" />
    </div>
    <div>
      <Search class="search"></Search>
      <newsletter class="newsletter" />
    </div>
  </div>
</template>

<script>
import Search from "@/components/Search.vue";
import StaffPicks from "@/components/StaffPicks.vue";
import NewReleases from "../components/NewReleases.vue";
import Newsletter from "../components/Newsletter.vue";


export default {
  name: "Home",
  components: { Search, StaffPicks, NewReleases, Newsletter },
};
</script>

<style>

.container {
  display: grid;
  width: 100vw;
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
.newsletter {
  padding-left: 5%;
  padding-right: 5%;
  margin-top: -5%;
  width: 25vw;
}
#staff-picks {
  grid-area: "staff-picks";
  filter: drop-shadow(0 0 2px white) drop-shadow(0 0 2px white); 
}
.flame {
 color: var(--red);
 
 filter: opacity(1) drop-shadow(0px 5px 1px darkred) drop-shadow(3px 0px 2px darkorange) drop-shadow(-3px 0px 2px darkorange) drop-shadow(0px -4px 2px yellow); 
}
.hand {
 color: var(--blue);
 filter: drop-shadow(0px -4px 2px yellow) drop-shadow(0px 4px 2px var(--red)); 
}
#new-releases {
  grid-area: "new-releases";
  filter: drop-shadow(0 0 2px white) drop-shadow(0 0 2px white);
  margin-top: 40px;
}
.staff-picks-header {
  position: absolute;
  font-style: italic;
  font-size: 25px;
  margin-top: -5px;
  margin-left: 10px;
}
.new-releases-header {
  position: absolute;
  font-style: italic;
  margin-left: 10px;
  margin-top: 5px;
  font-size: 25px;
  
}

</style>