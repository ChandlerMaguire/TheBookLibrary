<template>
  <div>
    <h2 v-if="$store.state.searchResult.length == 0">No Results Found</h2>
    <table v-if="$store.state.searchResult.length > 0">
      <tr>
        <th></th>
        <th>Title</th>
        <th>Author</th>
        <th>Genre</th>
        <th>Added to Collection</th>
      </tr>
      <tbody>
        <tr v-for="book in $store.state.searchResult" v-bind:key="book.isbn">
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
            Add to My Books
          </button>
          <button
            id="removeButton"
            class="toggleButton"
            v-show="isBookInStore(book.isbn)"
            v-on:click.prevent="removeFromMyBooks(book)"
          >
            Remove from My Books
          </button>

          <td>{{ book.title }}</td>
          <td>{{ book.firstName }} {{ book.lastName }}</td>
          <td>{{ book.genre }}</td>
          <td>{{ book.dateAdded }}</td>
        </tr>
      </tbody>
      <h1 v-if="$store.state.searchResult.length == 0">No Results Found</h1>
    </table>
  </div>
</template>

<script>
import bookService from "@/services/BookService.js";

export default {
  name: "results",
  methods: {
    addToMyBooks(book) {
      this.$store.commit("ADD_TO_MY_BOOKS", book);
      bookService
        .updateMyBooks(this.$store.state.myBooks);
    },
    removeFromMyBooks(book) {
      this.$store.commit("REMOVE_FROM_MY_BOOKS", book);
      bookService
        .updateMyBooks(this.$store.state.myBooks);
    },
    isBookInStore(isbn){
      console.log(isbn);
      return this.$store.state.myBooks.find(item => {
        return item.isbn == isbn;
      });
    },
  },
};
</script>

<style>
h2 {
  text-align: center;
}
table {
  width: 100%;
  border: 2px solid;
  border-color: var(--red);
  color: var(--blue);
  text-align: center;
  table-layout: fixed;
  /* background-color: var(--yellow); */
}
tr {
  border: 1px solid var(--pink);
}
/* tr:nth-child(even) {
  background-color:rgba(255, 182, 46, .8);
} */
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 1);
}
th {
  padding: 5px;
  border-bottom: 2px solid var(--red);
}


</style>