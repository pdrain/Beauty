<template>
  <div class="cats">
    <div class="item"   v-for="cat in cats" @click="chooseCat(cat.Guid)" :key="cat.ID">
       <span class="caticons icon-box" v-bind:class="cat.IconClass">&nbsp;</span>
            <label>{{cat.Name}}</label>
    </div>
  
  </div>
</template>

<style scoped lang="less">
@import '../../assets/index.less';


.cats{background: @cat-bgcolor; height: @cat-list-height;  border-bottom:1px @cat-border-color solid; overflow-x:auto; overflow-y: hidden; }

.cats  .item{display: block; float: left; width: @cat-item-width;  padding: 0px; height: 50%; cursor: pointer; padding-top: 6px; font-size: 14px; }

.cats  .item .icon-box{display: block;width: 40px; height: 40px; border-radius: 20px; border:1px #ccc solid;margin: auto;}
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
      
    }
  },
  computed: mapGetters({
    cats: 'ProjectCats',
  }),
  mounted() {
    let self = this;
    //组件装载完成后获取分类数据;
    self.$store.dispatch('queryProjectCats').then(function(parentGuid){
      
      self.$store.dispatch("chooseProjectCat", parentGuid);
    });
  },
  updated() {    
    //分类加载完成后加载默认数据
     //this.$store.dispatch("chooseProjectCat", this.currentCat);
  },
  methods: {
    chooseCat: function (catId) {
      this.$store.dispatch("chooseProjectCat", catId);
    }
  }
}
</script>