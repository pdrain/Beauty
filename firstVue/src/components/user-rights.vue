<template>
  <div  v-title='title'>
      <u-header  backurl="/user" :title="title"></u-header>
      <article class='user-rights' v-html="info"></article>
      <c-footer></c-footer>
  </div>
</template>

<script>
import Header from "./UserHeader";
import Footer from "./Footer";
export default {
  components: { "u-header": Header, "c-footer": Footer },
  data() {
    return {
      infoId: 1,
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
        _this.info =res.content || "";
        _this.title=res.title
      });
    }
  }
};
</script>


<style scoped lang='less'>
.user-rights {
  background: #fff;
  min-height: 15rem;
}
</style>