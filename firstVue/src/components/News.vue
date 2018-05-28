<template>
  <div v-title="'资讯列表'">
      <div class="news">
       
          <ul>
              <li @click="gotoNewsDetail(1)"><newslistitem></newslistitem></li>
               <li @click="gotoNewsDetail(1)"><newslistitem></newslistitem> </li>
               <li @click="gotoNewsDetail(1)"> <newslistitem></newslistitem></li>
          </ul>
      </div>
      <Footer></Footer>
  </div>
</template>

<script>
import Footer from "./Footer";
import newslistitem from "./news/news-list-item";
export default {
  data() {
    return {};
  },
  components: { Footer, newslistitem },
  methods: {
    gotoNewsDetail(newsId) {
      let url = "/news/detail/?newsId=" + newsId;
      this.$router.push(url);
    }
  }
};
</script>

<style scoped>

</style>
