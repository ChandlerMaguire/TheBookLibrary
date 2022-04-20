<template>
  <div class="post-list">
    <form
      id="newPost"
      v-show="this.showForm == true"
      v-on:submit.prevent="addPost(newPost)"
    >
      <label for="title">Title</label>
      <input
        type="text"
        id="formTitle"
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
      <button id="submit" type="submit" value="Submit">Submit</button>
    </form>
    <div>
    <button id="addPost" v-show="this.showForm == false" @click="showForm = true">Add a Post</button>
    </div>
    <table>
      <tbody>
        <tr v-for="post in this.allPosts" v-bind:key="post.postId">
          <td>
            <button v-on:click="openPost(post)" id="title">{{ post.title }}</button><span id="post-date">{{ post.postDate }}</span>
            <span id="user">{{ post.username }}</span>
            <h5 v-if="post.message.length < 200" id ="message">{{ post.message }}</h5>
            <h5 v-if="post.message.length >= 200" id= "message">{{ post.message.substring(0, 200) + "..." }}</h5>            
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
        message: "",
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
      this.$router.push({ name: "Post", params: { id: post.postId } });
    },
    addPost(newPost) {
      console.log("newPost HIT");
      forumService.addPost(newPost).then((response) => {
        if (response.status == 200) {
          forumService.getAllPosts().then((response) => {
            if (response.status == 200) {
              this.allPosts = response.data;
              this.newPost.title = "";
              this.newPost.message = "";
              this.showForm = false;
            }
          });
        }
      });
    },
  },
};
</script>

<style scoped>
#addPost {
margin: 10px;
box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
font-size: 1rem;
position: absolute;
top: 120px;
}
#post-date {
text-align: right;
grid-area: date;
margin-right: 10px; 
color: var(--navy);
}
#title {
  grid-area: title;
  margin-left: 3px;
  text-align: left;
  font-size: 1.5rem;
}
#message {
  grid-area: message;
  margin-left: 10px;
  text-align: left;
  color: var(--navy);
}
#submit {
  margin-left: auto;
  margin-right: 10px;
  margin-bottom: 5px;
}
td > #user {
  grid-area: user;
  margin-left: 10px;
  text-align: left;
  margin-top: -10px;
  color: var(--blue);
}
#addPost:hover{
  transform: translateY(-3px);
  transition: all 0.3s ease 0s;
  box-shadow: 0px 5px 10px var(--navy);
}
h5 {
  font-size: 1rem;
}
td {
  margin: 10px;
  word-break: break-word;
  /* display: flex;
  flex-direction: column; */
  display: grid;
  grid-template-areas: "title date"
  "user user"
  "message message";
  background-color: rgba(255, 182, 46, 1);
  border-radius: 10px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
}
td:hover {
  box-shadow: 0px 5px 10px var(--navy);
  transform: translateY(-3px);
  transition: all 0.3s ease 0s;
}

button {
  max-width: fit-content;
  border: none;
  background-color: var(--yellow);
  color: var(--navy);
  border-radius: 10px;
  
}
button:hover {
  color: #fff;
  transition: all 0.3s ease 0s;
}

table {
  border: none;
}
tr:nth-child(odd) {
  background-color: rgba(255, 182, 46, 0);
}
form {
  display: flex;
  flex-direction: column;
  margin: 10px;
}
label {
  margin-left: 10px;
  margin-bottom: -10px;
}
textarea, #formTitle {
  margin: 10px;
}
</style>

    