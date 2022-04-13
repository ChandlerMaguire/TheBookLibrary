<template>
  <div>
    <h3>Results</h3>
    <h3 v-if="$store.state.searchResult.length == 0">No Results Found</h3>
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
export default {
  name: "results",
  // data() {

  // },
};
</script>

<style>
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
tr:nth-child(even) {
  background-color: rgba(255, 182, 46, 0.8);
}
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 1);
}
th {
  padding: 5px;
  border-bottom: 2px solid var(--red);
}
img {
  width: 100px;
  margin: 10px;
}
</style>