<template>
  <div class="search">
    <form id="search" action ="#">
    <h3>Search</h3>
    <label for="keyword">Keyword</label>
    <input type="text" id="keyword" name="keyword" placeholder="Keyword">
    <label for="title">Keyword</label>
    <input type="text" id="keyword" name="keyword" placeholder="Keyword">
    <label for="author">Author</label>
    <input type="text" id="author" name="author" placeholder="Author">
    <label for="character">Character</label>
    <input type="text" id="character" name="character" placeholder="Character">
    <label for="location">Location</label>
    <input type="text" id="location" name="location" placeholder="Location">
    <label for="isbn">ISBN</label>
    <input type="number" id="isbn" name="isbn" placeholder="ISBN">
    <input type="submit" value="Submit">
   </form>
  </div>
</template>

<script>
name: "search",
  //props: ["topicId"],
  data() {
    return {
      search: {
        keyword: "",
        author: "",
        title: "",
        isbn: "",
        character: "",
        loaction: "",
      }
    };
  },
  methods: {
    saveMessage() {
      messageService
      .post(this.message)
      .then(response => {
        if (response.status == 201) {
          this.$router.push({name: 'Messages', params:{ id: this.message.topicId }});
        }
      })
      .catch(error => {
        if (error.response.status == 404) {
          this.$router.push({name: 'NotFound'});
        }
      });
    }
  }
};
</script>



<style>
form { background-color: var(--yellow); }
</style>