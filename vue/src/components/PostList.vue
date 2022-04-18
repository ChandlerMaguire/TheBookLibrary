<template>
  <div class="post-list">
    <a v-show=" this.showForm==false " @click="showForm=true">Add a Post</a>
    <form id="newPost" v-show=" this.showForm==true" v-on:submit="addPost(newPost)">
      <label for="title">Title</label>
      <input
        type="text"
        id="title"
        name="title"
        placeholder="Title"
        v-model="newPost.title"
      />
      <label for="message">Message</label>
      <textarea        
        id="message"
        name="message"
        placeholder="Message"
        v-model="newPost.message"
      ></textarea>
      <button id='submit' type="submit" value="Submit">Submit</button>
    </form>
    <table>
      <tbody>
        <tr v-for="post in this.allPosts" v-bind:key="post.postId">
          <td>
            <h4
              
              v-on:click="openPost(post)"
              >{{ post.title }}</h4
            >
            <h5>{{ post.username }}</h5>
            <h5>{{ post.message }}</h5>
            <p id="post-date">{{ post.postDate }}</p>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import forumService from "@/services/ForumService.js";

export default {
  name: "post-list",
  data() {
    return {
      allPosts: [],
      showForm: false,
      newPost: {
        title: "",
        message: ""
      },
    };
  },
  created() {
    forumService.getAllPosts().then((response) => {
      if (response.status == 200) {
        this.allPosts = response.data;
      }
    });
  },
  methods: {
    openPost(post) {
      
      this.$store.commit("SET_CURRENT_POST", post);
      this.$router.push({ name: "Post", params: {id: post.postId }}); 
    },
    addPost(newPost) {      
      console.log("newPost HIT");
      forumService.addPost(newPost);
    },
  },
};
</script>

<style>
</style>

    