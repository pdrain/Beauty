<template>
  <div>
    <div class="banner">
      <img src="../../assets/banner-1.jpg" />
    </div>
    <div class="cats">
      <div class="item" v-for="cat in cats" @click="chooseProductCat(cat.ID)" >
        <span class="caticons icon-box" v-bind:class="cat.IconClass">&nbsp;</span>
        <label>{{cat.Name}}</label>
      </div>
    </div>
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.cats{background: @cat-bgcolor; height: @cat-list-height; border-bottom:1px @cat-border-color solid; overflow-x:auto; overflow-y: hidden; }

.cats  .item{display: block; float: left; width: @cat-item-width;  padding: 0px; height: 50%; cursor: pointer; padding-top: 6px; font-size: 14px; }

.caticons{background: url("../../assets/product-cat-icons.png") no-repeat;}
.caticons.all{ background-position:10px -255px;}//所有
.caticons.face{ background-position:10px 4px;}//面膜
.caticons.water{ background-position:10px -37px;}//化妆水
.caticons.split{ background-position:10px -82px;}//防晒隔离
.caticons.lipstick{ background-position:10px -130px;}//口红
.caticons.cream{ background-position:10px -180px;}//精华
.caticons.eyecream{ background-position:10px -220px;}//眼霜
.caticons.puffcake{ background-position:10px -298px;}//粉饼
.caticons.eyelash{ background-position:10px -360px;}//睫毛
.caticons.blusher { background-position:10px -410px;}//腮红
.cats  .item .icon-box{display: block;width: 40px; height: 40px; border-radius: 20px; border:1px #ccc solid;margin: auto;}

 .banner{width:100%; height:150px; background:#fff; border-top:1px #f0f0f0 solid; border-bottom:1px #f0f0f0 solid;}
 .banner img{width:100%; height:100%;}
</style>


<script>

import { mapGetters } from 'vuex'

export default {
  name: 'product-cat',
  data() {
    return {}
  },
  computed: mapGetters({
    currentCat: 'CurrentProductCat',
    cats: 'ProductCats'
  }),
  mounted() {
    //组件装载完成后获取分类数据;
    this.$store.dispatch('queryProductCats');
  },
  updated() {
    //分类加载完成后加载默认数据
    this.$store.dispatch("queryProductList", this.currentCat);
  },
  methods:{
    chooseProductCat:function(catId){
      this.$store.dispatch("queryProductList", catId);
    }

  }
}
</script>