<template>
  <div class="search">
    <form id="search" action="#" @submit.prevent="searchBooks">
      <label for="keyword">Keyword</label>
      <input
        type="text"
        id="keyword"
        name="keyword"
        placeholder="Keyword"
        v-model="search.keyword"
      />
      <label for="title">Title</label>
      <input
        type="text"
        id="title"
        name="title"
        placeholder="Title"
        v-model="search.title"
      />
      <label for="author">Author</label>
      <input
        type="text"
        id="firstName"
        name="firstName"
        placeholder="First Name"
        v-model="search.firstName"
      />
      <input
        type="text"
        id="lastName"
        name="lastName"
        placeholder="Last Name"
        v-model="search.lastName"
      />
      <label for="genre">Genre:</label>
      <select id="genre" name="genre" v-model="search.genre">
        <option value="">Select a Genre...</option>
        <option value="Action">Action</option>
        <option value="Adventure">Adventure</option>
        <option value="Comedy">Comedy</option>
        <option value="Fantasy">Fantasy</option>
        <option value="Historical Fiction">Historical Fiction</option>
        <option value="Horror">Horror</option>
        <option value="Mystery">Mystery</option>
        <option value="Non-Fiction">Non-Fiction</option>
        <option value="Romance">Romance</option>
        <option value="Thriller">Thriller</option>
      </select>
      <label for="character">Character</label>
      <input
        type="text"
        id="character"
        name="character"
        placeholder="Character"
        v-model="search.character"
      />
      <label for="location">Location</label>
      <input
        type="text"
        id="location"
        name="location"
        placeholder="Location"
        v-model="search.location"
      />
      <label for="isbn">ISBN</label>
      <input
        type="text"
        inputmode="numeric"
        id="isbn"
        name="isbn"
        placeholder="ISBN"
        v-model="search.isbn"
      />
      <input v-show="!emptyParams" type="submit" value="Submit" />
      
    </form>
  </div>
</template>

<script>
import searchService from "../services/SearchService";

export default {
  name: "search",
  data() {
    return {
      search: {
        keyword: "",
        title: "",
        firstName: "",
        lastName: "",
        genre: "",
        character: "",
        location: "",
        isbn: "",
      },
    };
  },

  // computed: {
  //   searchResult() {
  //     return this.$store.state.searchResult;
  //   },
  // },
  computed: {
    emptyParams() {
      if (this.search.keyword == "" && this.search.title == "" && this.search.firstName == "" && this.search.lastName == "" && this.search.genre == "" && this.search.character == "" && this.search.location == "" && this.search.isbn == "") {
        return true;
      }
      return false;
    },
  },

  methods: {
    searchBooks() {
      searchService
        .search(this.search)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("GET_SEARCH_RESULT", response.data);
            this.$router.push("/results");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
    // sendHome() {
    //   if (this.emptyParams) {
    //     this.$router.push("/").catch(() => {});
    //   }
    // },
  },
};
</script>

<style>
form {
  background-color: var(--yellow);
}
#search {
  display: flex;
  flex-direction: column;
}
</style>