<template>
  <div>
    <tbody>
        <tr v-for="book in $store.state.myBooks" v-bind:key="book.isbn">
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
  </div>
</template>

<script>

export default {
    name: 'my-books',
}
</script>