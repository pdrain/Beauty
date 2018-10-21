<template>
  <div class="products">
    <div class="cats">
      <div class="catitem"  v-for="(t,index) in prdCats" :key=index>
        <img :src="t.icon"/>
        <a>{{t.name}}</a>
      </div>
    </div>
    <div class="prds">
  
      <div class="item" v-for="(item,index) in prdList" :key = "index">
      
        <div class="left">
          <img :src="item.icon" />
        </div>
        <div class="right">
           <div class="shortdesc">{{item.typeName}}</div>
          <div class="title">{{item.name}}</div>
          <div class="price">兑换：{{item.point}}积分；售价：{{item.price}}元<a class="exchange" @click="viewDetail(item.id)">详情</a></div>
        </div>
        <div class="clr"></div>
      
      </div>
      <div v-if="prdList.length==0">
        程序猿哥哥正在加班建设中...
      </div>
    </div>
    
  </div>
</template>

<script>
import * as api from "../../api";
import axios from "../../http";

import { mapGetters } from "vuex";

export default {
  name: "products-list",
  data() {
    return {
      prdCats: [],
      currentCatId: 0,
      prdList: []
    };
  },
  computed: mapGetters({
    list: "ProductList"
  }),
  watch: {
    currentCatId(val) {
      this.getProductList(val);
    }
  },
  mounted() {
    //获取产品列表数据
    this.getProductCats();
  },
  methods: {
    getProductCats() {
      let _this = this;
      this.$store.dispatch("queryProductCats").then(function(data) {
        debugger;
        _this.currentCatId = "";
        _this.prdCats = data;
      });
    },
    getProductList(catId) {
      let _this = this;
      this.$store.dispatch("queryProductList", catId).then(data => {
        _this.prdList = data.list;
      });
    },
    viewDetail(prdId) {
      location.href = "/shop/product-detail/?prdid=" + prdId;
    }
  }
};
</script>


<style scoped lang="less">
@import '../../assets/index.less';

.products{width: 100%;height: auto;}

.products .cats{height: 4rem; width: 100%;  overflow: auto; display: -webkit-box; background: #fff;}
.products .cats .catitem{width: 2.3rem; height: 3.5rem; margin:0.3rem 0.35rem; border:0px #f00 solid;}

.products .cats .catitem img{width: 2.3rem;height: 2.3rem;}


.products .prds{width: 100%;height: auto; background: #fff;}

.products .item{float: left; width: 100%; min-height: @listitem-min-height;  border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.products .item img{width: 90%; height: auto; margin: auto;}
.products .item .title,.products .item .price,.products .item .shortdesc{width:90%; margin: auto; line-height: 0.8rem;}
.products .item .price,.products .item .shortdesc{font-size: 12px;}
.products .item .shortdesc{color:#000; line-height: 15px; font-weight: bold}
.products .item .price{color:@listitem-font-hotcolor;}
.products .item .price span{float:right;}
.products .item a{text-decoration: none; color:@listitem-font-color;}
.products .item .left{width: 35%; float: left; padding-top: 8px;}
.products .item .right{width: 65%; float: right;text-align: left; padding-top: 8px;}

.products .item  .exchange{float: right;background: #ff00fb;
    height: 0.8rem;
    color: #fff;
    border-radius: 9px;
    padding: 0rem 0.4rem;
    line-height: 0.8rem;}
</style>

