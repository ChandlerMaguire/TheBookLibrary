<template>
  <div class="newsletterpage">
    <h2 id="news-header">Newsletter</h2>
    <img
      class="news-img"
      v-bind:src="'https://westervillelibrary.org/wp-content/uploads/sites/116/2021/12/Westerville-Public-Library-1930-1949.jpg'"
    />
    <p class="description">
      {{ this.$store.state.newsletterText.substring(475, 500) }}
    </p>
    <h5 id="news-text">
      {{ this.$store.state.newsletterText.substring(0, 150) }}
    </h5>
    <img
      class="news-img"
      v-bind:src="'https://westervillelibrary.org/wp-content/uploads/sites/116/2021/12/Westerville-Public-Library-1950-1969-Circulation-Desk.jpg'"
    />
    <p class="description">
      {{ this.$store.state.newsletterText.substring(475, 500) }}
    </p>
    <h5 id="news-text">
      {{ this.$store.state.newsletterText.substring(151, 300) }}
    </h5>
    <h5></h5>
    <h5 id="news-text">
      {{ this.$store.state.newsletterText.substring(301, 500) }}
    </h5>
    <img
      class="news-img"
      v-bind:src="'https://blog.library.si.edu/wp-content/uploads/2021/04/SIA-SIA_000095_B31_F38_002.jpg'"
    />
    <p class="description">
      {{ this.$store.state.newsletterText.substring(475, 500) }}
    </p>
  </div>
</template>

<script>
export default {
  name: "newsletterpage",
};
</script>

<style>
#news-header {
  margin-top: 60px;
}
#news-text {
  width: 50%;
  margin: auto;
}
.news-img {
  height: auto;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}
.description {
  width: 50%;
  margin-right: 50%;
  margin-left: 43%;
  margin-top: -10px;font-style: italic;
  
}
</style>