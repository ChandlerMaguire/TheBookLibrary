<template>
  <div class="post-list">
    <table>
      <tbody>
        <tr v-for="post in this.allPosts" v-bind:key="post.postId">
          <td>
            <router-link
              v-bind:to="{ name: 'Post', params: { id: post.postId } }"
              >{{ post.title }}</router-link
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
    };
  },
  created() {
    forumService.getAllPosts().then((response) => {
      if (response.status == 200) {
        this.allPosts = response.data;
      }
    });
    // this.allPosts = forumService.getAllPosts.then((reponse));
  },
};
</script>

<style>
</style>
