<template>
  <div class="content-body" v-title="'画眉鸟美容'">
   
      <div class="banner-adv">
        <swiper :option="swiperOption" ref="hospitalSwiper">
            <swiper-slide class="swiper-slide">
               <img src="../assets/banner/banner_01.png" />
            </swiper-slide>
             <swiper-slide class="swiper-slide">
                <img src="../assets/banner/banner_01.png" />
             </swiper-slide>
             <swiper-slide class="swiper-slide">
                <img src="../assets/banner/banner_01.png" />
             </swiper-slide>
              <swiper-slide class="swiper-slide">
                 <img src="../assets/banner/banner_01.png" />
              </swiper-slide>
          </swiper>
           
      </div>
       <h2 class="title">
          <span>&nbsp;</span>
          热门项目
      </h2>
       <table class="hot-prd">
         <tr v-for="(group,index) in hotCats" :key="index">
			  <td  class="icons" :class='item.icon' v-for="(item,i) in group" :key="i"  @click="gotoProjectList(item)"><span class="title">{{item.name}}</span></td>
		  </tr>
         
          
      </table>
       <h2 class="title">
          <span>&nbsp;</span>
          推荐项目
      </h2>
       <table class="sugesit-prd">
          <tr v-for="(group,index) in recommendCats" :key="index">
			  <td  class="icons" :class='item.icon' v-for="(item,i) in group" :key="i"  @click="gotoProjectList(item)"><span class="title">{{item.name}}</span></td>
		  </tr>
          
          
      </table>
     
     
      <div class="partners">
         <h2 class="title">
          <span>&nbsp;</span>
          合作机构
        </h2>
        <div class="content">
          <swiper :option="swiperOption" ref="hospitalSwiper">
            <swiper-slide class="swiper-slide">aaa</swiper-slide>
             <swiper-slide class="swiper-slide">aaa</swiper-slide>
             <swiper-slide class="swiper-slide">aaa</swiper-slide>
              <swiper-slide class="swiper-slide">aaa</swiper-slide>
              <div class="swiper-pagination" slot="pagination"></div>
          </swiper>
        </div>
      </div>
      
      <div class="news">
        <h2 class="title">
          <span>&nbsp;</span>
          美丽资讯
          <a class="more">更多</a>
        </h2>
          <ul>
              <li @click="gotoNewsDetail(1)"><newslistitem></newslistitem></li>
               <li @click="gotoNewsDetail(1)"><newslistitem></newslistitem> </li>
               <li @click="gotoNewsDetail(1)"> <newslistitem></newslistitem></li>
          </ul>
      </div>
      <c-footer></c-footer>
  </div>
  
</template>

<script>
import Footer from "./Footer";
import newslistitem from "./news/news-list-item";
import { swiper, swiperSlide } from "vue-awesome-swiper";

import { mapGetters } from "vuex";
import { defaultCipherList } from "constants";

export default {
  components: { newslistitem, swiper, swiperSlide ,'c-footer':Footer},
  data() {
    return {
      swiperOption: {
        slidesPerView: 3,
        spaceBetween: 0,
        pagination: {
          el: ".swiper-pagination",
          clickable: true
        }
      },
      hotCats: [], //热门项目
      recommendCats: [] //推荐项目
    };
  },
  computed: {},

  created() {
    let _this = this;
    _this.initCategories();
  },
  methods: {
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
    gotoNewsDetail(newsId) {
      let url = "/news/detail/?newsId=" + newsId;
      this.$router.push(url);
    },
    //初始化分类列表
    initCategories() {
      let _this = this;
      _this.$store.dispatch("getAllCategories").then(function(data) {
        let _cats = data.data;
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
        _this.hotCats = result.slice(0, 1);
        //推荐项目
        _this.recommendCats = result.slice(1, result.length);
      });
    }
  }
};
</script>

<style scoped lang="less">
@import "../assets/index.less";
.icons {
  background: url(../assets/icons.png) no-repeat;
  background-size: 10rem;
  width: 1rem;
  height: 1rem;
}
.icons.eyes {
  background-position: 25px 20px;
}
.icons.nose {
  background-position: -5.6rem -3.3rem;
}
.icons.face {
  background-position: -5.5rem 0.5rem;
}
.icons.tooth {
  background-position: 1rem -7rem;
}
.icons.boniaosuan {
  background-position: -5.4rem -11rem;
}
.icons.skin {
  background-position: -2.3rem -10.9rem;
}
.icons.reduce-weight {
  background-position: 1rem -10.9rem;
}
.icons.chest {
  background-position: -2.3rem -7rem;
}
.icons.self-fat {
  background-position: -2.2rem -14.1rem;
}
.icons.liposuction {
  background-position: 1rem -7rem;
}
.icons.hair-regroup {
  background-position: -5.4rem -11rem;
}
.icons.wrinkle-remove {
  background-position: -5.6rem -6.9rem;
}
.icons.mans-secr {
  background-position: -2.24rem -3rem;
}
.icons.womens-secr {
  background-position: -2.3rem 1.1rem;
}
.icons.none {
  background: none;
}

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
</style>


