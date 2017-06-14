<template>
    <div class="cats" >
        <ul v-bind:style="{width:(cats.length)*catItemWidth+'px'}">
          <li  v-for="cat in cats">{{cat.Name}}</li>
      </ul>
  </div>

</template>

<style scoped lang="less">
@import '../../assets/index.less';

.cats{background: @cat-bgcolor; height: @cat-list-height; border-bottom:1px @cat-border-color solid; overflow-x:auto; overflow-y: hidden; }
.cats ul{width: auto; height: 100%; margin: 0px; padding:0px;}
.cats ul li{display: inline-block;width: @cat-item-width; padding: 0px; height: 100%; cursor: pointer; }
.cats ul li.active{border-bottom: 2px @cat-border-hot-color solid; color:@font-hot-color;}

</style>


<script>
import * as api from '../../api'
import axios from '../../http'

export default {
  name: 'product-cat',
  data () {
    return {
      cats:[],
      catItemWidth:100
    }
  },
  mounted(){
      //获取分类数据
      axios.get(api.PRODUCT_CAT).then(response => {   this.cats=response.data;  });
  },
  updated(){
    //根据数据动态获取 li 的宽度
    this.catItemWidth = this.$el.childNodes[0].firstChild.clientWidth;
  }
}
</script>