<template>
  <div class='hmn-dict' style="{'height':screenHeight}">
    <span class="navi">
      <dl>
        <dd></dd>
      </dl>
    </span>
    <span class="detail">222</span>
  </div>
</template>

<script>
export default {
  computed: {
    screenHeight: () => {
      return window.screen.height
    }
  }
}
</script>

<style scoped>
.hmn-dict {
  line-height: 35px;
  height: 100%;
}

.navi {
  flex: 0;
  float: left;
  width: 30%;
  border-right:1px #ccc solid;
  height: 100%;
  background: #fff;
  box-sizing: border-box;
}

.detail {
  flex: 0;
  float: left;
  width:70%;
  height: 100%;
  background: #fff;
  text-align: left;
  padding:0px 5px;
  box-sizing:border-box;

}
</style>
