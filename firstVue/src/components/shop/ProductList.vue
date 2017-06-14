<template>
  <div class="products">
    <div class="item" v-for="item in list">
     
         <div class="left">
        <img src="../../assets/none.jpg" />
      </div>
      <div class="right">
        <div class="title">{{item.Name}}</div>
        <div class="shortdesc">{{item.ShortDesc}}</div>
        <div class="price">￥0</div>
      </div>
      <div class="clr"></div>
     
    </div>
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.products{width: 100%;height: auto;}
.products .item{float: left; width: 100%; min-height: @listitem-min-height;  border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.products .item img{width: 90%; height: auto; margin: auto;}
.products .item .title,.products .item .price,.products .item .shortdesc{width:90%; margin: auto; min-height: @listitem-row-min-height; line-height: @listitem-line-height;}
.products .item .price,.products .item .shortdesc{font-size: 12px;}
.products .item .shortdesc{color:#ccc; line-height: 15px;}
.products .item .price{color:@listitem-font-hotcolor;}
.products .item .price span{float:right;}
.products .item a{text-decoration: none; color:@listitem-font-color;}
.products .item .left{width: 35%; float: left; padding-top: 8px;}
.products .item .right{width: 65%; float: right;text-align: left; padding-top: 8px;}
</style>


<script>
import * as api from '../../api'
import axios from '../../http'

import { mapGetters } from 'vuex'

export default {
  name: 'products-list',
  data() {
    return {}
  },
    computed: mapGetters({
    list: 'ProductList'
  }),
  mounted() {
    //获取分类数据
    //axios.get(api.PRODUCT_LIST).then(response => { this.list = response.data; });
    // this.$store.dispatch('queryProductList');
  }
}
</script>