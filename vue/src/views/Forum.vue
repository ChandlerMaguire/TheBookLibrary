<template>
  <div class="forum">
    <h2>Forum</h2>
    <post-list />
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