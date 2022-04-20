<template>
  <div class ="container">
    <div class="home">
      </div>
      <div>
    <Search class="search"></Search>
    <staff-picks id="staff-picks" />
    <new-releases id="new-releases" />
    </div>
  </div>
</template>

<script>
import Search from "@/components/Search.vue";
import StaffPicks from "@/components/StaffPicks.vue";
import NewReleases from '../components/NewReleases.vue';


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
  grid-template-areas: "staff-picks search"
  "new-releases search";
  margin: 0;
 
}

.home {
  width: 75vw ;
  grid-area: "content";
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
</style>