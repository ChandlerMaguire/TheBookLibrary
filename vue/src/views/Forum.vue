<template>
  <div class="forum">
    <h1>Forum</h1>
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