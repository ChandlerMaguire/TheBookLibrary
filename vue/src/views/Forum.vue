<template>
  <div class="forum">
    <h2 id="forum-title">Forum</h2>
    <post-list />
    <hot-topics/>
  </div>
</template>

<script>
import PostList from '@/components/PostList.vue';

export default {
  name: 'Forum',
  components: {
    PostList
  }
}
</script> 
<style scoped>
.forum {
  margin-top: 0px;
  display: grid;
  width: 74vw;
}
#forum-title {
  margin-top: -15px;
  margin-left: 10px;
  margin-bottom: -3px;
  text-align: left;
}
</style>