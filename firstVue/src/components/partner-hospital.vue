<template>
  <div>
    <header>合作医院</header>
    <div class="hospital-item" @click="goToDetail()">
        <div class="desc">ss</div>
    </div>
    <div class="hospital-item" @click="goToDetail()">

      <div class="desc">ss</div>
    </div>
  </div>
</template>

<script>

export default {
  data() {
    return {}
  },
  mounted() {},
  methods: {
    goToDetail() {
      this.$router.push('/partner-hospital-detail')
    }
  }
};
</script>

<style scoped lang="less">
@import "../assets/index.less";

header {
  text-align: center;
  line-height: 3rem;
  border-bottom: @border-normal-color 1px solid;
  margin-bottom: 1rem;
}

.hospital-item {
  height: 10rem;
  background: #fff;
  margin-bottom: 1rem;
  position: relative;
}

.hospital-item .desc {
  width: 100%;
  position: absolute;
  bottom: 0px;
  height: 3rem;
  background: #666;
  opacity: 0.4;
  color: #fff;
}
</style>



