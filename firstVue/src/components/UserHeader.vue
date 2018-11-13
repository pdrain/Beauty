<template>
  <div class="userheader">
    <div>
      <!--<a v-if="backurl"  class="goback" @click="goBack"></a>-->
      <img src="../assets/company.jpg" />
    </div>
    <h1>
      <span>{{title}}</span>
    </h1>
  </div>
</template>


<script>
export default {
  props: {
    title: "",
    backurl: ""
  },
  data(){
    return{
      redirectPath:''
    }
  },
  mounted() {
    this.redirectPath = this.backurl;
    let targetBack = this.$route.query.back;
    if (targetBack) {
      this.redirectPath = targetBack;
    }
  },
  methods: {
    goBack: function() {
      this.$router.push(this.redirectPath);
    }
  }
};
</script>




<style scoped lang="less">
.goback {
  background: url("../assets/left-arrow.png") !important;
  background-repeat: no-repeat;
  background-size: cover !important;
  width: 1.2rem !important;
  height: 1.2rem !important;
}
@import "../assets/index.less";
.userheader img {
  width: 100%;
  height: 150px;
}

.userheader h1 {
  margin: 0px;
  padding: 0px;
  line-height: 30px;
  height: 30px;
  text-align: left;
  font-size: 14px;
  font-weight: normal;
  background: #f0f0f0;
}

.userheader h1 span {
  border-left: 3px @font-hot-color solid;
  padding-left: 8px;
}
</style>