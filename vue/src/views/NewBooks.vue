<template>
  <div class ="newBooksContainer">
    <h2 id="no-new-books" v-if="this.newBooks.length == 0">No New Books.</h2>
    <h2 id="new-books-title" v-if="this.newBooks.length > 0">New Books <font-awesome-icon class="new-books-title-icon" icon="fa-solid fa-book"
      /></h2>
    <table v-if="this.newBooks.length > 0">
      <tr>
        <th></th>
        <th>Title</th>
        <th>Author</th>
        <th>Genre</th>
        <th>Added to Collection</th>
      </tr>
      <tbody>
        <tr v-for="book in this.newBooks" v-bind:key="book.isbn">
          <img
            v-bind:src="
              'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
            "
          />
          <button
            id="addButton"
            class="toggleButton"
            v-show="!isBookInStore(book.isbn)"
            v-on:click.prevent="addToMyBooks(book)"
          >
            Add to My Books <font-awesome-icon icon="fa-regular fa-circle" />
          </button>
          <button
            id="removeButton"
            class="toggleButton"
            v-show="isBookInStore(book.isbn)"
            v-on:click.prevent="removeFromMyBooks(book)"
          >
            Remove from My Books <font-awesome-icon icon="fa-regular fa-circle-check" />
          </button>

          <td>{{ book.title }}</td>
          <td>{{ book.firstName }} {{ book.lastName }}</td>
          <td>{{ book.genre }}</td>
          <td>{{ book.dateAdded }}</td>
        </tr>
      </tbody>
      <!--  <h1 v-if="$store.state.newBooks.length == 0">No Results Found</h1> -->
    </table>
  </div>
</template>

<script>
import bookService from "@/services/BookService.js";
import searchService from "@/services/SearchService.js";

export default {
  name: "new-books",
  data() {
    return {
      newBooks: [],
    };
  },
  created() {
    this.$store.commit("UPDATE_USER_SEARCHED");

    if (this.$store.state.userSearched && this.didDateChange) {
      searchService.updateSearchTime();
      this.$store.commit("UPDATE_SEARCH_TIME");
    }
    this.newBooksSearch();
    console.log("reached search");
  },
  computed: {
    didDateChange() {
      let then = this.$store.state.loginTime;
      then.setHours(0, 0, 0, 0);
      let now = new Date();
      now.setHours(0, 0, 0, 0);
      return then < now;
    },
  },
  methods: {
    addToMyBooks(book) {
      this.$store.commit("ADD_TO_MY_BOOKS", book);
      bookService.updateMyBooks(this.$store.state.myBooks);
    },
    removeFromMyBooks(book) {
      this.$store.commit("REMOVE_FROM_MY_BOOKS", book);
      bookService.updateMyBooks(this.$store.state.myBooks);
    },
    newBooksSearch() {
      this.newBooks = this.$store.state.allBooks.filter(
        (book) => this.$store.state.user.lastSearch <= book.dateAdded
      );
    },
    isBookInStore(isbn) {
      console.log(isbn);
      return this.$store.state.myBooks.find((item) => {
        return item.isbn == isbn;
      });
    },
  },
};
</script>

<style scoped>
.newBooksContainer {
 margin: 10px;
 padding-right: 10px;
 width: 74vw;
}
h2 {
  text-align: center;
}
table {
  margin-top: 70px;
  width: 98%;
  border: 2px solid;
  border-color: var(--red);
  color: var(--blue);
  text-align: center;
  table-layout: fixed;
}
tr {
  border: 1px solid var(--pink);
}
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 1);
}
th {
  padding: 5px;
  border-bottom: 2px solid var(--red);
}
#no-new-books{
  margin-top: 70px;
  font-size: 25px;
  margin-left: 33%;
}
#new-books-title{
  margin-top: 20px;
  margin-left: 12px;
  margin-bottom: -70px;
  text-align: left;
}
.new-books-title-icon {
 color: var(--blue);
 font-size: 25px;
 filter: opacity(1) drop-shadow(0px 3px 1px rgb(219, 182, 102)) drop-shadow(3px 0px 2px rgb(82, 125, 218)) drop-shadow(-3px 0px 2px rgb(255, 255, 255)) drop-shadow(0px -4px 2px rgb(218, 201, 201));
}
</style>