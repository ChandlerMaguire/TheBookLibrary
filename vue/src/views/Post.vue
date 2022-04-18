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
  </div>
</template>

<script>
import forumService from "@/services/ForumService.js";

export default {
  name: "Post",
  data() {
    return {
      comments: [],
    };
  },
  created() {
    forumService.getPost(this.$store.state.post.postId).then((response) => {
      if (response.status == 200) {
        this.comments = response.data;
      }
    });
  },
};
</script>

<style>
</style>
