<template>
  <div  v-title="'资讯详情'" class="article-detail">
    <div class="body">
      <h1>{{articleInfo.title}}</h1>
      <h2>
          <span>{{articleInfo.createDate}}</span>&nbsp;|&nbsp;
          <span v-if="articleInfo.source">{{articleInfo.source}}</span>
          <span v-else>画眉鸟美容</span>
      </h2>
      <article v-html="articleInfo.content">

      </article>
    </div>
      <c-footer></c-footer>
  </div>
</template>

<script>
import Footer from "./Footer";
export default {
  components: { "c-footer": Footer },
  data() {
    return {
      articleId: this.$route.query.newsId,
      articleInfo: ""
    };
  },
  created() {
    this.getNewsDetail();
  },
  methods: {
    getNewsDetail() {
      let _this = this;
      this.$store
        .dispatch("getNewsDetail", _this.articleId)
        .then(function(data) {
          _this.articleInfo = data;
        });
    }
  }
};
</script>

<style>
.article-detail {
  background: #fff;
}
.article-detail .body{
  padding: 0.5rem;
  margin-bottom:4rem;
}
.article-detail h1 {
  text-align: left;
  font-size: 1rem;
  font-weight: normal;
}
.article-detail h2 {
  text-align: left;
  font-size: 0.6rem;
  margin-top: 0.5rem;
  margin-bottom: 0.5rem;
  font-weight: normal;
}
article {
  text-align: left;
  font-size: 0.6rem;
  font-weight: normal;
  line-height: 1rem;
}
</style>