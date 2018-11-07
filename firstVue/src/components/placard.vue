<template>
    <div class="placard-container">
        <UserHeader  backurl="/user"  title="我的分享海报"></UserHeader>
        <div class="cats">
        <div class="item"   v-for="(item,index) in cats" :key="index"  @click="gotoProjectList(item)"><i :class='item.icon' ></i><span class="title">{{item.name}}</span></div>
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
    goToPlaCard() {
      this.$router.push("/user/placard/detail");
    }
  }
};
</script>


<style scoped lang="less">
@import "../assets/index.less";
.placard-container{
padding-bottom: 2rem;
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

