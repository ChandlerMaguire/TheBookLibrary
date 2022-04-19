<template>
  <div>
    <h2>New Releases</h2>
    <table>
      <td v-for="book in $store.state.newReleases" v-bind:key="book.isbn">
        <img
          v-bind:src="
            'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
          "
        />
        <h4>{{ book.title }}</h4>
        <h5>{{ book.firstName }} {{ book.lastName }}</h5>
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
      </td>
    </table>
  </div>
</template>

<script>
import bookService from "@/services/BookService.js";

export default {
  name: "myBooks",
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

<style scoped>
h4,
h5 {
  text-align: center;
  color: var(--blue);
}
h4 {
  font-size: 1.2rem;
  font-style: italic;
}
h5 {
  font-size: 1rem;
}

img {
  align-self: center;
  justify-self: center;
}
td {
  margin: 10px;
  word-break: break-word;
  max-width: 180px;
  display: flex;
  flex-direction: column;
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
table {
  align-self: center;
  justify-self: center;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  border: 0;
}

</style>