<template>
  <div>
    <div id="myBooksTitle">
    <h2 id="no-results" v-show="$store.state.myBooks.length == 0">Search for books to add them to your collection.</h2>
    <h2 id="my-books-header" v-show="$store.state.myBooks.length > 0">My Books <font-awesome-icon class="my-books-book-icon" icon="fa-solid fa-book-open"
      /></h2></div>
    <table id="my-books-table">
      <td v-for="book in $store.state.myBooks" v-bind:key="book.isbn">
        <img
          v-bind:src="
            'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
          "
        />
        <h4 class="book-title">{{ book.title }}</h4>
        <h5>{{ book.firstName }} {{ book.lastName }}</h5>
        <button
          id="removeButton"
          class="toggleButton"
          v-show="isBookInStore(book.isbn)"
          v-on:click.prevent="removeFromMyBooks(book)"
        >
          Remove from My Books <font-awesome-icon icon="fa-regular fa-circle-check" />
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
#myBooksTitle {
  width: 73vw;
  align-self: left;
  margin: 10px;
}
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
h2{
  margin-top: 70px;
}
img {
  align-self: center;
  justify-self: center;
}
td {
  margin: 10px;
  word-break: break-word;
  width: 180px;
  display: flex;
  flex-direction: column;
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
td:hover {
  background-color: var(--button);
  color: #fff;
  transition: all 0.9s ease 0s;
}
#my-books-table {
  width: 73vw;
  align-self: left;
  justify-self: center;
  display: flex;
  flex-wrap: wrap;
  justify-content: left;
  border: 0;
  margin-left: 10px;
  margin-right: 10px;
  margin-top: -17px;
}
.book-title{
  padding: 5px
}
#no-results {
  font-size: 25px;
  margin-left: 30%;
}
#my-books-header  {
  font-style: italic;
  font-size: 25px;
  margin-top: -5px;
  margin-left: 10px;
  text-align: left;
}
.my-books-book-icon{
  color: var(--blue);
 
 filter: opacity(1) drop-shadow(0px 5px 1px rgb(219, 182, 102)) drop-shadow(3px 0px 2px rgb(82, 125, 218)) drop-shadow(-3px 0px 2px rgb(255, 255, 255)) drop-shadow(0px -4px 2px rgb(218, 201, 201));
}
</style>