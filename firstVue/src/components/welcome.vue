<template>
    <div v-title="'邀请好友'" class="welcome-bg">
        <div  class="share">
 <a >马上分享，邀请好友</a>
        </div>
       
    </div>
</template>
<script>
import wx from "../config/WeXin";
export default {
  data() {
      return {}
  },
  mounted() {
    this.initShareInfo();
  },
  methods: {
    initShareInfo() {
      let shareOpt = {
        title: "邀请好友",
        desc: "大家一起来变美丽哦"
      };
      wx.initShare(shareOpt);
    }
  }
};
</script>
<style scoped>
.welcome-bg {
  background: url("../assets/welcome.jpeg") no-repeat;
  height: 100%;
  background-size: cover;
  position: relative;
}

.welcome-bg .share {
  width: 100%;
  height: 1.2rem;
  line-height: 1.2rem;
  position: absolute;
  bottom: 2rem;
  margin: auto;
}
.welcome-bg .share a {
  width: 80%;
  height: 1.2rem;
  line-height: 1.2rem;
  border: 0rem;
  background: #f60;
  border-radius: 5px;
  color: #fff;
  margin: auto;
  display: block;
}
</style>
