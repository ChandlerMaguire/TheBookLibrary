<template>
  <div>
    <h2>My Books</h2>
    <table>
        <td v-for="book in $store.state.myBooks" v-bind:key="book.isbn">
          <img
            v-bind:src="
              'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
            "
          />
          <h4>{{ book.title }}</h4>
          <h5>{{ book.firstName }} {{ book.lastName }}</h5>
        </td>
      </table>
  </div>
</template>

<script>

export default {
    name: 'my-books',
}
</script>
<style scoped>
h4, h5 {
text-align: center;
color: var(--blue);
}
h4{
  font-size: 1.2rem;
  font-style: italic;
}
h5{
  font-size: 1.0rem;
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