<template>
  <div class="content-body" v-title="'画眉鸟美容'">
   
        <top-banner :code='1001'></top-banner>
         <c-footer></c-footer>
       <h2 class="title">
          热门项目
          <a class="more">更多&gt;</a>
      </h2>
      
      <div class="hot-prd">
        <div class="item"  v-for="(item,index) in hotCats" :key="index">
          <img src="../assets/icons/tupian-1.jpg"/>
          <span>&nbsp;</span>
          <span class="title">{{item.name}}</span>
        </div>
      </div>
       <h2 class="title">
          推荐项目
          <a class="more">更多&gt;</a>
      </h2>

     <div class="cats">
        <div class="item"   v-for="(item,index) in recommendCats" :key="index"  @click="gotoProjectList(item)"><i :class='item.icon' ></i><span class="title">{{item.name}}</span></div>
      </div>
     <div class="clear"></div>
      <div class="partners">
         <h2 class="title">
          合作机构
        </h2>
        <div class="content">
           <swiper :option="swiperOption" ref="hospitalbanner">
         <swiper-slide class="swiper-slide" v-for="(item,index) in partners" :key="index">
           <img :src="'/static/data/'+item.image"/>
         </swiper-slide>
           
          </swiper>
        </div>
      </div>
      
      <div class="news">
        <h2 class="title">
          <span>&nbsp;</span>
          美丽资讯
          <a class="more" @click="moreNewsList">更多</a>
        </h2>
          <ul>
              <li @click="gotoNewsDetail(item.id)" v-for="(item,index) in newsList" :key="index" :articleinfo="item">
                <newslistitem :articleinfo='item'></newslistitem></li>
               <li v-if="newsList.length==0"> 暂无推荐文章</li>
          </ul>
      </div>
     
  </div>
  
</template>

<script>
import Footer from "./Footer";
import newslistitem from "./news/news-list-item";
import { swiper, swiperSlide } from "vue-awesome-swiper";
import topBanner from "./common/advertisment";

import { mapGetters } from "vuex";
import { defaultCipherList } from "constants";

import jssdk from "weixin-js-sdk";
import wx from "../config/WeXin";

export default {
  components: {
    newslistitem,
    swiper,
    swiperSlide,
    "c-footer": Footer,
    topBanner
  },
  data() {
    return {
      swiperOption: {
        notNextTick: false,
        initialSlide: 0,

        loop: true,
        speed: 2000,
        direction: "horizontal",
        //autoplay: 1000,
        autoplay: true

        //autoplayDisableOnInteraction: true,
        //observer: true,
        //observeParents: true,
      },
      hotCats: [], //热门项目
      recommendCats: [], //推荐项目
      newsList: [], //推荐资讯
      partners:[]
    };
  },
  computed: {
    hospitalSwiper() {
      return this.$refs.hospitalbanner.swiper;
    }
  },

  created() {
    let _this = this;
    _this.initCategories();
    _this.getNewsList();
    _this.initShareInfo();
    _this.getPartners();
  },
  mounted() {
    let _this = this;
    this.hospitalSwiper.autoplay.start();
    //this.swiper.slideTo(1, 1000, false);
  },
  methods: {
    initShareInfo() {
      let shareOpt = {
        title: "画眉鸟美丽联盟",
        desc: "每时每刻遇见美丽的自己"
      };
      wx.initShare(shareOpt);
    },
    gotoProjectList(item) {
      let sCids = [];
      item.second.forEach(function(sItem) {
        sCids.push(sItem.id);
      });
      if (item.second.length == 0) {
        sCids.push(item.id);
      }

      this.$router.push("/projects/?cIds=" + sCids.join(","));
    },
    getNewsList() {
      let _this = this;
      this.$store.dispatch("getNewsList", 1, 3).then(function(data) {
        _this.newsList = data.list;
      });
    },
    gotoNewsDetail(newsId) {
      let url = "/news/detail/?newsId=" + newsId;
      this.$router.push(url);
    },
    moreNewsList() {
      this.$router.push("/news/");
    },
    getPartners(){
      let _this = this;
      _this.$store.dispatch("getPartners",{}).then((data)=>{
        _this.partners = data
      })
    },
    //初始化分类列表
    initCategories() {
      let _this = this;
      _this.$store.dispatch("getAllCategories").then(function(data) {
        let _cats = data.data;
        _this.recommendCats = _cats;
        _this.hotCats =_cats.slice(0, 4);
        var result = [];

        for (var i = 0, len = _cats.length; i < len; i += 3) {
          let g = _cats.slice(i, i + 3);

          if (g.length < 3) {
            for (var j = 0; j < 3 - g.length; j++) {
              g.push({ icon: "none", name: "" });
            }
          }
          result.push(g);
        }
        // 热门项目
        //_this.hotCats = result.slice(0, 1);
        //推荐项目
        //_this.recommendCats = result.slice(1, result.length);
      });
    }
  }
};
</script>

<style scoped lang="less">
@import "../assets/index.less";

.banner-adv {
  height: 5rem;
  width: 100%;
  background: #fff;
}
.banner-adv img {
  width: 100%;
}
h2.title {
  line-height: 1.6rem !important;
  height: 40px;
  font-size: 0.6rem;
  font-weight: normal;
  text-align: left;
  text-indent: 0.25rem;
}

h2.title a.more {
  float: right;
  color: #666;
  font-size: 0.5rem;
  margin-right: 8px;
}
.hot-prd,
.sugesit-prd {
  width: 100%;
  background: #fff;
  border-spacing: 0px;
  border-collapse: collapse;
}
.hot-prd tr td,
.sugesit-prd tr td {
  height: 100px;
  width: 33.3%;
  border-bottom: 1px #f0f0f0 solid;
  border-right: 1px #f0f0f0 solid;
}
.hot-prd tr td:active,
.sugesit-prd tr td:active {
  background-color: #f0f0f0;
}
.hot-prd tr td:last-child,
.sugesit-prd tr td:last-child {
  border-right: 0px #f0f0f0 solid;
}

.hot-prd td .title,
.sugesit-prd td .title {
  margin-top: 2rem;
  display: block;
}

//合作机构
.partners {
  min-height: 2rem;
}
.partners .content {
  background: #fff;
  min-height: 1rem;
  padding: 0.3rem;
  overflow: hidden;
}
.partners .content .swiper-container {
  height: 3rem;
  text-align: center;
}

.partners .content .swiper-slide {
  //float: left;
  //width: 7rem !important;
  border: 0.03rem #f0f0f0 solid;
  border-radius: 0.3rem;
  height: 3rem;
  //margin-right:0.3rem;
  display: -webkit-box;
  display: -ms-flexbox;
  display: -webkit-flex;
  display: flex;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  -webkit-justify-content: center;
  justify-content: center;
  -webkit-box-align: center;
  -ms-flex-align: center;
  -webkit-align-items: center;
  align-items: center;
}

.swiper-slide img{
  width: 100%;
}
</style>


