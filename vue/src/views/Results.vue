<template>
  <div>
     <tbody>
        <tr v-for="book in $store.state.searchResult" v-bind:key="book.isbn">
          <td>{{ book.title }}</td>
          <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
        </tr>
      </tbody>
  </div>
</template>

<script>

export default {
  name: "results",
  data() {
    
  },
}
</script>

<style>
</style>