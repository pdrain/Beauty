<template>
  <div  v-title="'资讯详情'">
      <h1>每日美容资讯</h1>
      <h2>
          <span>2018-03-16</span>|
          <span>画眉鸟美容</span>
          <article>

          </article>

      </h2>
      
  </div>
</template>

<script>
export default {
  data() {
      return{
          articleId:''
      }
  },
  created() {},
  methods: {
    getNewsDetail() {
      let _this = this;
      this.$store.dispatch("getNewsList", 1, 3).then(function(data) {
        _this.newsList = data.list;
      });
    }
  }
};
</script>

<style>
</style>