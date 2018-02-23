<template>
    <div class="search">
        <input type="text" placeholder="请搜索您感兴趣的项目" @click="showCats" />
        <transition  name="slide-fade">
            <div class="cats" v-show="displayCats">
                <div>
                    <a class="item" v-for="item in cats">{{item.Name}}</a>
                </div>
                <div class="buttons">
                    <button @click="hideCats">取消</button>
                </div>
            </div>
        </transition>
    </div>
</template>

<<script>
import { mapGetters } from 'vuex'

export default {
    data(){
        return{
        displayCats:false
        }
    },
   computed: mapGetters({
    cats: 'ProjectCats',
  }),  
   mounted() {
    //组件装载完成后获取分类数据
    this.$store.dispatch('queryProjectCats');
  },
  methods:{
    showCats:function(){        
        this.$set(this.$data,'displayCats',true);        
    },
    hideCats:function () {
         this.$set(this.$data,'displayCats',false);  
    }

  }
}
</script>

<style scoped lang="less">
@import '../assets/index.less';
.search{height:@search-height; background: @search-bgcolor; padding-top:4px; }
.search input{height: @search-input-height; line-height: @search-input-height; width: 90%; margin: auto; border-radius: 15px; border: 0px; text-align: center; text-indent: 10px; }
.search .cats{width: 100%;border-bottom:1px solid @search-border-color; height: 100%; position: absolute;background: #fff; margin-top:5px; z-index: 9999; text-align: left; font-size: 14px;}
.search .cats a.item{display: inline-block;height: 25px; line-height: 25px; width: 20%; border-radius: 12px; text-align: center;border:1px @search-border-color solid;margin: 8px;}
.search .cats .buttons{text-align: center;}
.search .cats .buttons button{width: 100px; height: 30px; border-radius: 5px; background: @search-button-bgcolor; border:0px; color:@seach-button-fontcolor;}

.slide-fade-enter-active { transition: all .3s ease;}
.slide-fade-leave-active {transition: all .3s cubic-bezier(1.0, 0.5, 0.8, 1.0);}
.slide-fade-enter, .slide-fade-leave-active {padding-top: 50px;opacity: 0;}

</style>


