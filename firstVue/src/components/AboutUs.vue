<template>
    <div class="aboutus" v-title="title">
         <UserHeader  backurl="/user" :title="title"></UserHeader>
       
        <article>
            深圳市画眉鸟美容发展有限公司拥有汇美美容设备科技有限公司，广尔整形医院，多美勒整形医院以及第六元素皮肤管理中心。是一家集医美、科研、教学、皮肤管理位一体的美容发展公司。公司拥有一流的整形专家和微整专家，坚持“良心医美，厚德奉献”为精神，倾力打造中国美容事业。
        </article>
        <article v-html="info"></article>
         <UserFooter></UserFooter>
    </div>
</template>


<script>
import UserHeader from "./UserHeader";
import UserFooter from "./Footer";
export default {
  components: { UserHeader, UserFooter },
  data() {
    return {
      infoId: 3,
      info: "",
      title:''
    };
  },
  mounted() {
    this.getInfor();
  },
  methods: {
    getInfor: function() {
      let _this = this;
      this.$store.dispatch("getBaseInfo", this.infoId).then(function(res) {
        _this.info = res.content || "";
        _this.title=res.title
      });
    }
  }
};
</script>

<style>
.aboutus {
  height: 100%;
  background: #fff;
}
.aboutus h1 {
  font-size: 2rem;
  color: #666;
}

.aboutus article {
  font-size: 0.6rem;
  color: #666;
  line-height: 1.2rem;
  text-align: left;
  text-indent: 1.2rem;
  padding: 0.5rem;
}
</style>

