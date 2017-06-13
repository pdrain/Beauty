<template>
  <div class="products">
    <div class="item" v-for="item in list">
     
        <img src="../../assets/none.jpg" />
        <div class="title"></div>
        <div class="price">0</div>
     
    </div>
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.products{width: 100%;height: auto;}
.products .item{float: left; width: 50%; min-height: @listitem-min-height; border:@listitem-border-width @listitem-border-color solid; background: @listitem-bgcolor}
.products .item img{width: 90%; height: auto; margin: auto;padding-top: 8px;}
.products .item .title,.products .item .price{width:90%; margin: auto; min-height: @listitem-row-min-height; line-height: @listitem-line-height;}

</style>


<script>
import * as api from '../../api'
import axios from '../../http'

export default {
  name: 'products-list',
  data() {
    return {
      list: []
    }
  },
  mounted() {
    //获取分类数据
    axios.get(api.PRODUCT_LIST).then(response => { this.list = response.data; });
  }
}
</script>