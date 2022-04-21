<template>
  <div class="post">
    <table>
      <tbody>
        <td id="parentPost">
          <span id="user">{{ this.$store.state.post.username }}</span>
          <span id="date">{{ this.$store.state.post.postDate }}</span>
          <h4 id="title">{{ this.$store.state.post.title }}</h4>
          <h5 id="message">{{ this.$store.state.post.message }}</h5>
        </td>
        <td
          v-for="comment in this.comments"
          v-bind:key="comment.commentId"
          class="comment"
        >
          <span id="commentUser">{{ comment.username }}</span>
          <span id="date">{{ comment.commentDate }}</span>
          <p id="message">{{ comment.commentText }}</p>
        </td>
      </tbody>
    </table>
    <button v-show="this.showForm == false" @click="showForm = true"
      >Add a Comment</button
    >
    <form
      id="newComment"
      v-show="this.showForm == true"
      v-on:submit.prevent="addComment(newComment)"
    >
      <label for="comment"></label>
      <textarea
        id="comment"
        name="comment"
        placeholder="Add a comment..."
        v-model="newComment.commentText"
      ></textarea> 
      <button id="submit" type="submit" value="Submit" @click="showForm = false">Submit</button>
      <font-awesome-icon id="x" icon="fa-solid fa-xmark" @click="showForm = false"/>
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
        commentText: "",
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
      forumService
        .addComment(this.$store.state.post.postId, newComment)
        .then((response) => {
          if (response.status == 200) {
            forumService
              .getPost(this.$store.state.post.postId)
              .then((response) => {
                if (response.status == 200) {
                  this.comments = response.data;
                  this.newComment.commentText = "";
                }
              });
          }
        });
    },
  },
};
</script>

<style scoped>
#x:hover{
  color: red;
  transition: all 0.2s ease 0s;
}
.post{
   margin-top: 60px;

  width: 74vw;
}
form {
  display: flex;
  flex-direction: column;
  margin: 10px;
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  border: none;
}
button {
  max-width: fit-content;
  border: none;
  background-color: var(--yellow);
  color: var(--navy);
  /*color: rgb(128,0,32);*/
  border-radius: 10px;
  margin-left: 10px;
}
button:hover {
  color: #fff;
  transition: all 0.3s ease 0s;
}
#parentPost {
  margin: 10px;
  word-break: break-word;
  padding: 5px;
  display: grid;
  grid-template-areas: "title date"
  "user user"
  "message message";
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
td.comment {
   margin: 10px;
  word-break: break-word;
  padding: 5px;
  display: grid;
  grid-template-areas: "commentUser date"
  "message message";
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
#title {
  grid-area: title;
  margin-left: 10px;
  text-align: left;
  font-size: 1.5rem;
  color: var(--navy);
}
#message {
  grid-area: message;
  margin-left: 10px;
  text-align: left;
  color: var(--navy);
}
#date {
text-align: right;
grid-area: date;
margin-right: 10px; 
color: var(--navy);
}
#submit {
margin: 10px;
box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
font-size: 1rem;

}
#commentUser {
  grid-area: commentUser;
  margin-left: 10px;
  text-align: left;
  color: var(--blue);
}
td > #user {
  grid-area: user;
  margin-left: 10px;
  text-align: left;
  margin-top: -10px;
  color: var(--navy);
}
table {
  border: none;
}
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 0);
}
textarea {
  margin: 10px;
}

</style>
