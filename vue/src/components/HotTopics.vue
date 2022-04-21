<template>
  <div>
    <form id="topics">
    <h5 id="forum-topic">What's Your Take? <font-awesome-icon class="hot-topic-icon" icon="fa-solid fa-comments" /></h5>
      <h6 id ="topic-2">Listed down below are some thought provoking and "controversial" books. What do you all think? What did you take away? Share your thoughts and add a post! </h6>
    <h6 id ="topic-2">If you haven't read these books yet 
      Add them to you'r reading list today!!</h6>
    <table class="table-2">
      <td class="hot-topic-td" v-for="book in $store.state.hotTopics" v-bind:key="book.isbn">
        <img
        class="hot-topic-img"
          v-bind:src="
            'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
          "
        />
        <h4 class="book-title">{{ book.title }}</h4>
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
    </form>
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

#forum-topic{
  text-align: center;
  text-decoration: underline;
  color: var(--navy);
}
#topic-2{
  text-align: center;
color: var(--navy);
}
.hot-topic-td {
  margin-top: 10px;
  margin-bottom: 10px;
  margin-left: auto;
  margin-right: auto;
  word-break: break-word;
  width: 180px;
  display: flex;
  flex-direction: column;
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
.hot-topic-img {
  width: 150px;
  height: 230px;
  margin: 10px;
  border: 1px solid var(--blue);
}
.table-2{
 display: flex;
  flex-wrap: wrap;
  border-color: none;
}
#topics {
  margin-top: 68px;
  padding: 5px;
  border: 1px solid var(--red);
  margin-right: 50px;
  margin-left: 50px;
  border-radius: 10px;
  border-color: none;
}
.table-2{
  background-image: linear-gradient(
    to bottom,
    var(--blue),
    var(--navy)
  );
  border-radius: 10px;
  border-color: none;
}
.hot-topic-td{
padding: -20px;
}
.hot-topic-icon{
  color: var(--blue);
 
 filter: opacity(10) drop-shadow(0px 5px 1px rgb(25, 69, 94)) drop-shadow(3px 0px 2px rgb(255, 255, 255));
}


</style>