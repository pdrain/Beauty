<template>
  <div v-title='title'>
      <u-header  backurl="/user" :title="title"></u-header>
      <div class='user-service' v-html="info"></div>
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
      infoId: 2,
      info:'',
      title:''
    };
  },
  mounted() {
      this.getInfor();
  },
  methods: {
    getInfor: function() {
        let _this =this;
      this.$store.dispatch("getBaseInfo", this.infoId).then(function(res) {
       _this.info = res.content||''
        _this.title=res.title
      });
    }
  }
};
</script>

<style scoped lang='less'>
.user-service {
  background: #fff;
  min-height: 15rem;
}
</style>

