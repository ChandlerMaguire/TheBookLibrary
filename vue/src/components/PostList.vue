<template>
  <div class="post-list">
    <table>
      <tbody>
        <tr v-for="post in this.allPosts" v-bind:key="post.id">
          <td>
            <router-link v-bind:to="{ name: 'Post', params: { id: post.id } }">{{ post.title }}</router-link>
            <h5>{{ post.username }}</h5>
            <p id="post-date">{{post.date}}</p>
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
    this.allPosts = forumService.getAllPosts();
  },
};
</script>

<style>
</style>
