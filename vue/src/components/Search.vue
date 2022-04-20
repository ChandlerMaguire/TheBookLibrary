<template>
  <div class="search">
    <h4>Search For Books</h4>
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
      <button id='submit' type="submit" value="Submit">Submit</button>
      
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
      if (
        this.search.keyword == "" &&
        this.search.title == "" &&
        this.search.firstName == "" &&
        this.search.lastName == "" &&
        this.search.genre == "" &&
        this.search.character == "" &&
        this.search.location == "" &&
        this.search.isbn == ""
      ) {
        return true;
      }
      return false;
    },
  },

  methods: {
    searchBooks() {
      if (!this.emptyParams) {
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
      }
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
  margin-top: 13px;
  background-color: var(--yellow);
  padding: 5px;
  border: 1px solid var(--red);
  margin-right: 20px;
  border-radius: 10px;
}
input, select {
  margin-bottom: 5px;
}
#search {
  display: flex;
  flex-direction: column;
}
h4 {
  text-align: center;
  padding-top: 10px;
  padding-right: 10px;
  font-size: 22px;
  text-shadow: 3px 2px 3px grey;
  
}
#submit {
  margin-bottom: 0;
  padding-bottom: 0;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  width: 100px;
  align-self: center;
  
}
#submit:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}
</style>