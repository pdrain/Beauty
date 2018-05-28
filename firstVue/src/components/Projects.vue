<template>
  <div v-title="'美容项目'">
    <SearchBox ></SearchBox>
     <div class="banner">
        <img src="../assets/banner-1.jpg" />
    </div>
    <div class="projects">
    <div class="item" v-for="item in list" :key="item.ID">
      <router-link :to="{ path: '/projects-detail', query: { id: item.id }}">
      <div class="left">
        <img src="../assets/none.jpg" />
      </div>
      <div class="right">
        <div class="title">{{item.name}}</div>
        <div class="shortdesc">{{item.desc}}</div>
        <div class="price">¥{{item.minPrice}}&nbsp;-&nbsp;{{item.maxPrice}}<span>已约 200 人</span></div>
      </div>
      <div class="clr"></div>
      </router-link>
    </div>
  </div>
  <c-footer></c-footer>
  </div>
</template>

<script>
import URL from "url";
import Footer from "./Footer";
import { mapGetters } from "vuex";
import SearchBox from "./SearchBox";

export default {
  name: "Projects",
  data() {
    return {
      urlParam: URL.parse(location.hash.replace("#", "")).search,
      list: []
    };
  },
  created() {
    this.initProjectList();
  },
  computed: {},
  components: { SearchBox ,'c-footer':Footer},
  methods: {
    initProjectList() {
      let _this = this;
      let _cids = _this.getQueryString("cIds");
      this.$store.dispatch("queryProjectList", _cids).then(function(data) {
        if (data) {
          _this.list = data;
          console.log(JSON.stringify(_this.list));
        }
      });
    },
    getQueryString(name) {
      var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
      var r = this.urlParam.substr(1).match(reg);
      if (r != null) return unescape(r[2]);
      return null;
    }
  }
};
</script>

<style scoped lang="less">
 @import '../assets/index.less';
 .banner{width:100%; height:150px; background:#fff; border-top:1px #f0f0f0 solid; border-bottom:1px #f0f0f0 solid;}
 .banner img{width:100%; height:100%;}



.projects{width: 100%;height: auto;}
.projects .item{float: left; width: 100%; min-height: @listitem-min-height;  border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.projects .item img{width: 90%; height: auto; margin: auto;}
.projects .item .title,.projects .item .price,.projects .item .shortdesc{width:90%; margin: auto; min-height: @listitem-row-min-height; line-height: @listitem-line-height;}
.projects .item .price,.projects .item .shortdesc{font-size: 12px;}
.projects .item .shortdesc{color:#ccc; line-height: 0.7rem;font-size: 0.5rem;
text-overflow:ellipsis;
display:-webkit-box;
-webkit-box-orient: vertical;
-webkit-line-clamp: 2;
overflow: hidden;}
.projects .item .price{color:@listitem-font-hotcolor;}
.projects .item .price span{float:right;}
.projects .item a{text-decoration: none; color:@listitem-font-color;}

.projects .item .left{width: 35%; float: left; padding-top: 8px;}
.projects .item .right{width: 65%; float: right;text-align: left; padding-top: 8px;}
</style>
