<template>
    <div class="placard-container content-body" v-title='"邀请好友"'>
        <UserHeader  backurl="/user"  title="我的分享海报"></UserHeader>
        <div>
          <a>个人好友</a>
          <a>美容店</a>
        </div>
        <div class="cats">
        <div class="item"   v-for="(item,index) in cats" :key="index"  @click="goToPlaCard(item)"><i :class='item.icon' ></i><span class="title">{{item.name}}</span></div>
      </div>
         <c-footer></c-footer>
    </div>
</template>

<script>
import Footer from "./Footer";
import UserHeader from "./UserHeader";
export default {
  components: { UserHeader ,"c-footer": Footer },
  data() {
    return {
      cats: []
    };
  },
  mounted(){
    this.getAllCatagories()
  },
  methods: {
    getAllCatagories() {
      let _this = this;
      _this.$store.dispatch("getAllCategories").then(function(data) {
        let _list = data.data;
        _this.cats = _list;
      });
    },
    goToPlaCard(item) {
      let url = "/user/placard/detail/?cat="+item.id
      this.$router.push(url);
    }
  }
};
</script>


<style scoped lang="less">
@import "../assets/index.less";
.placard-container{
}
.placard {
  display: flex;
  background: #fff;
  
}
.placard .item {
  width: 5rem;
  height: 4.5rem;
  line-height: 7rem;
}
</style>

