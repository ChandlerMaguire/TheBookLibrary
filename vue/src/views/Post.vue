<template>
  <div class="post">
    <table>
      <tbody>
        <td id= "parentPost">
          <span id="postUser">{{this.$store.state.post.username}}</span>
          <span id="postDate">{{this.$store.state.post.postDate}}</span>
          <h4 id="title">{{this.$store.state.post.title}}</h4>
          <h5 id="message">{{this.$store.state.post.message}}</h5>
          </td>
          <td v-for="comment in this.comments" v-bind:key="comment.commentId" class="comment">
            <span class="commentUser">{{ comment.username }}</span>
            <span class="commentDate">{{ comment.commentDate }}</span>            
            <p class= "commentText">{{ comment.commentText }}</p>
          </td>
      </tbody>
    </table>
    <a v-show=" this.showForm==false " @click="showForm=true">Add a Comment</a>
    <form id="newComment" v-show=" this.showForm==true" v-on:submit.prevent="addComment(newComment)">
      <label for="comment">Comment</label>
      <textarea        
        id="comment"
        name="comment"
        placeholder="Add a comment..."
        v-model="newComment.commentText"
      ></textarea>
      <button id='submit' type="submit" value="Submit">Submit</button>
    </form>
  </div>
</template>

<script>
import forumService from "@/services/ForumService.js";

export default {
  name: "Post",
  data() {
    return {
      comments: [],
      showForm: false,
      newComment: {
        commentText: ""
      },
    };
  },
  created() {
    forumService.getPost(this.$store.state.post.postId).then((response) => {
      if (response.status == 200) {
        this.comments = response.data;
      }
    });
  },
  methods: {
    addComment(newComment) {        
      forumService.addComment(this.$store.state.post.postId, newComment);
      forumService.getPost(this.$store.state.post.postId).then((response) => {
      if (response.status == 200) {
        this.comments = response.data;
        this.newComment.commentText = "";

      }
    });
      
    },
  },
};
</script>

<style>
</style>
