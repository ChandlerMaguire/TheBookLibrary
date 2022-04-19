<template>
  <div class ="container">
    <div class="home">
      </div>
      <div>
    <Search class="search"></Search>
    </div>
  </div>
</template>
faBookmark, faBookOpen, faBookOpenReader, faCirclePlus, faFireFlameCurved, faLeaf, faSpinner, faUser, faUserGear
<script>
import Search from "@/components/Search.vue";

export default {
  name: "Home",
  components: { Search },
};
</script>

<style>
.container {
  display: grid;
  width: 100vw;
  height: 100vw;
  grid-template-columns: auto;
  grid-template-areas: "content search";
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
</style>