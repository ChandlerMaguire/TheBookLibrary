<template>
  <div class="book">
    <tbody>
        <tr v-for="book in $store.state.myBooks" v-bind:key="book.isbn">
          <td>{{ book.title }}</td>
          <img
            v-bind:src="
              'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
            "
          />
          <td>{{ book.firstName }} {{ book.lastName }}</td>
          <td>{{ book.genre }}</td>
          <td>{{ book.dateAdded }}</td>
        </tr>
      </tbody>
  </div>
</template>

<script>
export default {
 name: 'book',
    props: {
        book: Object,
        enableAdd: {
            type: Boolean,
            default: true
        }
    },
}
</script>

<style>

</style>