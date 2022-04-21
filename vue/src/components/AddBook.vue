<template>
  <div class="addBook">
    <h4
      id="notAuthorized"
      class="text-danger"
      v-if="this.$store.state.user.role == 'user'"
    >
      You do not have authorization to view this page.
    </h4>
    <form v-else id="addBook" action="#" @submit.prevent="insertBook">
      <label for="keyword">Add Keywords separated by commas:</label>
      <input
        type="text"
        id="keyword"
        name="keyword"
        placeholder="Keyword"
        v-model="addBook.keyword"
      />
      <label for="title">Add Book Title:</label>
      <input
        required
        type="text"
        id="title"
        name="title"
        placeholder="Title"
        v-model="addBook.title"
      />
      <label for="author">Add Author:</label>
      <input
        required
        type="text"
        id="firstName"
        name="firstName"
        placeholder="First Name"
        v-model="addBook.firstName"
      />
      <input
        required
        type="text"
        id="lastName"
        name="lastName"
        placeholder="Last Name"
        v-model="addBook.lastName"
      />
      <label for="genre">Select Genre:</label>
      <select required id="genre" name="genre" v-model="addBook.genre">
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
      <label for="character">Add Characters separated by commas:</label>
      <input
        type="text"
        id="character"
        name="character"
        placeholder="Character"
        v-model="addBook.character"
      />
      <label for="location">Add Location(s) separated by commas:</label>
      <input
        type="text"
        id="location"
        name="location"
        placeholder="Location"
        v-model="addBook.location"
      />
      <label for="isbn">Add ISBN:</label>
      <input
        required
        type="text"
        inputmode="numeric"
        id="isbn"
        name="isbn"
        placeholder="ISBN"
        v-model="addBook.isbn"
      />
      <button id="submit" type="submit" value="Submit">Submit</button>
      <h4 v-show="bookExists" id="notAuthorized" class="text-danger">
        This book already exists in the library.
      </h4>
      <h4 v-show="bookAdded" id="bookAdded" class="text-success">
        Book was successfully added to the library.
      </h4>
    </form>
  </div>
</template>
<script>
import addService from "../services/AddService";
import bookService from "../services/BookService";

export default {
  name: "add-book",
  data() {
    return {
      addBook: {
        keyword: "",
        title: "",
        firstName: "",
        lastName: "",
        genre: "",
        character: "",
        location: "",
        isbn: "",
      },
      bookExists: false,
      bookAdded: false,
    };
  },
  computed: {
    emptyParams() {
      if (
        this.addBook.keyword == "" &&
        this.addBook.title == "" &&
        this.addBook.firstName == "" &&
        this.addBook.lastName == "" &&
        this.addBook.genre == "" &&
        this.addBook.character == "" &&
        this.addBook.location == "" &&
        this.addBook.isbn == ""
      ) {
        return true;
      }
      return false;
    },
  },

  methods: {
    insertBook() {
      if (!this.emptyParams) {
        this.$store.commit("ADD_BOOK", this.addBook);
        addService
          .add(this.addBook)
          .then((response) => {
            if (response.status == 200) {
              this.addBook.keyword = "";
              this.addBook.title = "";
              this.addBook.firstName = "";
              this.addBook.lastName = "";
              this.addBook.genre = "";
              this.addBook.character = "";
              this.addBook.location = "";
              this.addBook.isbn = "";
              this.bookAdded = true;
              this.bookExists = false;
              bookService
                .getAllBooks()
                .then((response) => {
                  if (response.status == 200) {
                    this.$store.commit("GET_ALL_BOOKS", response.data);
                  }
                })
                .catch((error) => {
                  const response = error.response;

                  if (response.status === 401) {
                    this.invalidCredentials = true;
                  }
                });
            }
          })
          .catch((error) => {
            const response = error.response;

            if (response.status === 400) {
              this.invalidCredentials = true;
              this.bookExists = true;
              this.bookAdded = false;
            }
          });
      }
    },
  },
};
</script>

<style>
#addBook {
  display: flex;
  flex-direction: column;
  background-color: var(--yellow);
  padding: 5px;
  border: 1px solid var(--red);
  width: 50%;
  margin: auto;
  margin-top: 70px;
}
label {
  margin-bottom: -0.5px;
}
#notAuthorized {
  text-align: center;
  margin-top: 5px;
}
#bookAdded {
  text-align: center;
  margin-top: 5px;
}
</style>