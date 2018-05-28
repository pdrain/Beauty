<template>
    <div class="search">
        <input type="text" placeholder="请搜索您感兴趣的项目" @click="showCats" />
        <transition  name="slide-fade">
            <div class="cats" v-show="displayCats">
                <div class="container">
                    <div class="first-lv">
                        <ul>
                            <li v-for="(item,index) in cats.data" :key="index" @click="chooseFirstCat(index)" >{{item.name}}</li>
                        </ul>
                    </div>
                    <div class="sevcond-lv">
                        <div v-if="cats.data && cats.data.length>0">
                        <a href="" v-for="(item,index) in cats.data[defaultIndex].second" :key="index">{{item.name}}</a>
                        <div v-if="cats.data[defaultIndex].second.length==0">暂无分类</div>
                        </div>
                    </div>
                </div>
                
                <div class="buttons">
                    <button @click="doSearch">搜索</button>
                    <button @click="hideCats" >取消</button>
                     
                </div>
            </div>
        </transition>
    </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
    //props:['cats'],
    data(){
        return{
          cats:[],
            defaultIndex:0,
            displayCats:false,
        }
    },
   created(){
      let _this = this;
      this.$store.dispatch("getAllCategories").then(function(data) {
        if (data) {
          _this.cats = data;
        }
      });
   },
   mounted() {
      
    //组件装载完成后获取分类数据
    //this.$store.dispatch('queryProjectCats');
  },
  methods:{
    showCats:function(){  
        this.displayCats = true;      
        //this.$set(this.$data,'displayCats',true);        
    },
    hideCats:function () {
        this.displayCats = false; 
         //this.$set(this.$data,'displayCats',false);  
    },
    doSearch(){
        //TODO do search
    },
    chooseFirstCat(index){
        this.defaultIndex = index;
    }

  }
}
</script>

<style scoped lang="less">
@import "../assets/index.less";
.search {
  height: @search-height;
  background: @search-bgcolor;
  padding-top: 4px;
}
.search input {
  height: @search-input-height;
  line-height: @search-input-height;
  width: 90%;
  margin: auto;
  border-radius: 15px;
  border: 0px;
  text-align: center;
  text-indent: 10px;
}
.search .cats {
  width: 100%;
  border-bottom: 1px solid @search-border-color;
  height: 100%;
  position: absolute;
  background: #fff;
  margin-top: 5px;
  z-index: 9999;
  text-align: left;
  font-size: 14px;
}
.search .cats a.item {
  display: inline-block;
  height: 25px;
  line-height: 25px;
  width: 20%;
  border-radius: 12px;
  text-align: center;
  border: 1px @search-border-color solid;
  margin: 8px;
}
.search .cats .buttons {
  text-align: center;
}
.search .cats .buttons button {
  width: 100px;
  height: 30px;
  border-radius: 5px;
  background: @search-button-bgcolor;
  border: 0px;
  color: @seach-button-fontcolor;
}

.slide-fade-enter-active {
  transition: all 0.3s ease;
}
.slide-fade-leave-active {
  transition: all 0.3s cubic-bezier(1, 0.5, 0.8, 1);
}
.slide-fade-enter,
.slide-fade-leave-active {
  padding-top: 50px;
  opacity: 0;
}

.search .cats .container {
  display: flex;
  border: 0.03rem #ccc solid;
  margin-bottom: 0.3rem;
}
.search .cats .first-lv {
  width: 30%;
  border-right: 0.03rem #ccc solid;
 
}

.search .cats .container .first-lv li {
    line-height: 0.8rem;
    font-size: 0.3rem;
    border-bottom:0.03rem #ccc solid;
     padding: 0.3rem;
}
.search .cats .sevcond-lv {
    width: 80%;
  padding: 0.3rem;
}

.search .cats .sevcond-lv a {
  display: inline-block;
  border: 0.03rem #ccc solid;
  padding: 0.2rem 0.5rem;
  text-align: center;
  font-size: 0.3rem;
  color: #666;
  text-decoration: none;
  border-radius: 0.6rem;
  margin: 0.1rem 0.1rem;
}

.search .cats .sevcond-lv a:active {
  background-color: #f8c5f7;
}

</style>


