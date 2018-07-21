<template>
    <div v-title='title'>
        <UserHeader  backurl="/user" :title='title'></UserHeader>
        <article class="partners" v-html='info'></article>
        <UserFooter></UserFooter>
    </div>
</template>
<script>
import UserHeader from "../UserHeader";
import UserFooter from "../Footer";
export default {
  components: { UserHeader, UserFooter },
  data() {
    return {
      infoId: 4,
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

<style scoped>
.partners{
    background: #fff;
    min-height: 15rem;
}
</style>

