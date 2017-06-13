<template>
  <div class="cats">
    <ul v-bind:style="{width:(cats.length)*catItemWidth+'px'}">
      <li v-for="cat in cats" @click="chooseCat(cat.ID)" :class="{active:currentCat==cat.ID}">{{cat.Name}}-{{currentCat}}</li>
    </ul>
  
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';

.cats{background: @cat-bgcolor; height: @cat-header-height; line-height: @cat-header-line-height; border-bottom:1px @cat-border-color solid; overflow-x: auto; overflow-y: auto; }
.cats ul{width: auto; height: 100%; margin: 0px; padding:0px;}
.cats ul li{display: inline-block;width: @cat-item-width; padding: 0px; height: 100%; cursor: pointer; }
.cats ul li.active{border-bottom: 2px @cat-border-hot-color solid; color:@font-hot-color;}

</style>


<script   type="application/ecmascript">
import * as api from '../../api'
import axios from '../../http'
import * as types from '../../store/types'

import { mapGetters } from 'vuex'

export default {
  name: 'projects-cat',
  data() {
    return {
      catItemWidth: 100,//默认宽度
    }
  },
  computed: mapGetters({
    currentCat: 'ProjectCurrentCat',
    cats: 'ProjectCats',
  }),
  mounted() {
    //组件装载完成后获取分类数据;
    this.$store.dispatch('quereProjectCats');
  },
  updated() {
    //组件更新后根据数据动态获取 li 的宽度
    this.catItemWidth = this.$el.childNodes[0].firstChild.clientWidth;
    
    //分类加载完成后加载默认数据
     this.$store.dispatch("chooseProjectCat", this.currentCat);
  },
  methods: {
    chooseCat: function (catId) {
      this.$store.dispatch("chooseProjectCat", catId);
    }
  }
}
</script>