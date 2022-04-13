<template>
  <div>
     <tbody>
        <tr v-for="book in $store.state.searchResult" v-bind:key="book.isbn">
          <td>{{ book.title }}</td>
          <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
        </tr>
      </tbody>
      <h1 v-if="$store.state.searchResult.length == 0">No Results Found</h1>
  </div>
</template>

<script>

export default {
  name: "results",
  // data() {
    
  // },
}
</script>

<style>
</style>