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
            v-show="!isBookInStore(book.isbn)"
            v-on:click.prevent="addToMyBooks(book)"
          >
            Add to My Books
          </button>
          <button
            id="removeButton"
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
  // computed:{
  //   inMyBooks(book){
  //     if(this.$store.state.myBooks.includes(book)){
  //       return true;
  //     }
  //     else{
  //       return false;
  //     }
  //   }
  // }
  // created(){
  //   let inMyBooks;
  //   if(this.$store.state.myBooks.includes(this.book)){
  //     inMyBooks = true;
  //   }
  //   else{
  //     inMyBooks = false;
  //   }
  //   return inMyBooks;
  // }
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

#addButton {
  padding-bottom: 0;
  margin-bottom: 10px;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  height: 25px;
  width: 100px;
  font-size: 10px;
  align-self: center;
}
#addButton:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}
#removeButton {
  padding-bottom: 0;
  margin-bottom: 10px;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  height: 35px;
  width: 100px;
  font-size: 10px;
  align-self: center;
}
#removeButton:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}
</style>