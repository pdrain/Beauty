<template>
  <div class="userheader">
    <div>
      <a class="goback" href="javascript:history.go(-1)">&lt;</a>
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
    title: ''
  },
  mounted(){
    
  }

}
</script>




<style scoped lang="less">
@import '../assets/index.less';
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