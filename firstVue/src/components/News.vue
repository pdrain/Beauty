<template>
  <div v-title="'资讯列表'">
     <h2 class="title">
          <span>&nbsp;</span>
          美丽资讯
      </h2>
      <div class="news">
       
          <ul>
              <li @click="gotoNewsDetail(1)" v-for="(item,index) in newsList" :key='index' :articleinfo="item"><newslistitem :articleinfo="item"></newslistitem></li>
               <li v-if="newsList==0">暂无更多美丽资讯 </li>
          </ul>
      </div>
     <c-footer></c-footer>
  </div>
</template>

<script>
import Footer from "./Footer";
import newslistitem from "./news/news-list-item";
import { mapGetters } from "vuex";
export default {
  data() {
    return {
      newsList:[]
    };
  },
  components: { "c-footer": Footer, newslistitem },
  created(){
    this.getNewsList()
  },
  methods: {
    getNewsList() {
      let _this = this;
      this.$store.dispatch("getNewsList", 1, 3).then(function(data) {
        _this.newsList = data.list;
      });
    },
    gotoNewsDetail(newsId) {
      let url = "/news/detail/?newsId=" + newsId;
      this.$router.push(url);
    }
  }
};
</script>

<style scoped>

h2.title {
  line-height: 1.6rem !important;
  height: 40px;
  font-size: 0.6rem;
  font-weight: normal;
  text-align: left;
}
h2.title span {
  height: 20px;
  width: 5px;
  background: #ff00fb;
  margin-right: 5px;
}
h2.title a.more {
  float: right;
  color: #666;
  font-size: 0.5rem;
  margin-right: 8px;
}
</style>
