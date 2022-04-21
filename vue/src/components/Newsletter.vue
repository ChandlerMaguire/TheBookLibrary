<template>
  <div class="newsletter">
    <form id="newsletter" action="#">
      <h4>Newsletter</h4>
      <h5>
        {{ this.$store.state.newsletterText.substring(0, 120) + "..."
        }}<router-link to='/newsletter'
          >read more</router-link
        >
      </h5>
      <!-- <label for="email"></label>
      <input type="email" id="email" name="email" placeholder="Email" /> -->
      <button v-show="!this.$store.state.isSubscribed" v-on:click.prevent="subscribe" id="signup" value="signup">Subscribe</button>
      <button v-show="this.$store.state.isSubscribed" v-on:click.prevent="unsubscribe" id="signup" value="signup">Unsubscribe</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "newsletter",
  methods: {
    subscribe(){
      this.$store.commit("SUBSCRIBE");
    },
    unsubscribe(){
      this.$store.commit("UNSUBSCRIBE");
    }
  }, 
  
};
</script>

<style scoped>
.news-container {
  margin-top: 13px;
  background-color: var(--yellow);
  padding: 5px;
  border: 1px solid var(--red);
  margin-right: 20px;
  border-radius: 10px;
}

#email {
  width: 100%;
  margin-bottom: 5px;
}
.news-container {
  display: flex;
  flex-direction: column;
}
#signup {
  margin-bottom: 0;
  padding-bottom: 0;
  background-color: var(--button);
  border-radius: 45px;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease 0s;
  cursor: pointer;
  width: 100px;
  margin-left: 30%;
}
#signup:hover {
  background-color: var(--blue);
  box-shadow: 0px 5px 10px var(--navy);
  color: #fff;
  transform: translateY(-1px);
  transition: all 0.3s ease 0s;
}
#readmore {
  color: var(--blue);
  text-decoration: underline;
}
</style>