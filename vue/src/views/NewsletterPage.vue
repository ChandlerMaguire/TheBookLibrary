<template>
  <div class="newsletterpage">
    <h2 id="news-header">Newsletter</h2>
    <h3 id="story-title">The History of Libraries</h3>
    <img
      class="news-img"
      v-bind:src="'https://westervillelibrary.org/wp-content/uploads/sites/116/2021/12/Westerville-Public-Library-1930-1949.jpg'"
    />
    <p class="description">
      A young librarian hard at work.
    </p>
    <h5 id="news-text">
      Library history is a subdiscipline within library science and library and information science focusing on the history of libraries and their role in societies and cultures.[1] Some see the field as a subset of information history.[2] Library history is an academic discipline and should not be confused with its object of study (history of libraries): the discipline is much younger than the libraries it studies.
    </h5>
    <img
      class="news-img"
      v-bind:src="'https://westervillelibrary.org/wp-content/uploads/sites/116/2021/12/Westerville-Public-Library-1950-1969-Circulation-Desk.jpg'"
    />
    <p class="description">
      A bustling library.
    </p>
    <h5 id="news-text">
      Library history begins in ancient societies through contemporary issues facing libraries today.[3] Topics include recording mediums, cataloguing systems, scholars, scribes, library supporters and librarians.
    </h5>
    <h5></h5>
    <h5 id="news-text">
      The earliest records of a library institution as it is presently understood can be dated back to around 5,000 years ago in the Southwest Asian regions of the world. One of the oldest libraries found is that of the ancient library at Ebla (circa 2500 BCE) in present-day Syria. In the 1970s, the excavation at Ebla's library unearthed over 20,000 clay tablets written in cuneiform script.
    </h5>
    <img
      class="news-img"
      v-bind:src="'https://blog.library.si.edu/wp-content/uploads/2021/04/SIA-SIA_000095_B31_F38_002.jpg'"
    />
    <p class="description">
      An old library.
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
  text-indent: 50px;
}
.news-img {
  height: auto;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
  border: 1px solid var(--blue);
  border-radius: 2px;
}
.description {
  width: 50%;
  margin: auto;
  margin-top: -10px;
  font-style: italic;
}
#story-title{
  text-align: center;
}
</style>