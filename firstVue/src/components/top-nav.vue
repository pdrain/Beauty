<template>
    <div v-if="show" class="topnav">
        <a class="left" @click="navInfo.leftButton.cb">{{navInfo.leftButton.text}}</a>
        <span>{{navInfo.midTitle.text}}</span>
        <a class="right" @click="navInfo.rightButton.cb">{{navInfo.rightButton.text}}</a>
    </div>
</template>

<script>
import utils from "../utils";
export default {
  data() {
    return {
      show: utils.isNative(),
      navInfo:{leftButton:{text:'',cb:()=>{}},midTitle:{text:'',cb:()=>{}},rightButton:{text:'',cb:()=>{}}},
      
      backUrl:utils.getParams('target')
    };
  },
  mounted() {
    this.navInfo={
      leftButton: {
        text: "返回",
        cb: this.leftCb
      },
      midTitle: {
        text: "加载中"
      },
      rightButton: {
        text: "分享",
        cb: () => {}
      },
    }
    if (this.show) {
      document.getElementById("app").style.marginTop = "1.5rem";
    }
  },
  methods: {
    leftCb(){
      if(this.backUrl){
        location.href = this.backUrl
      }else(
        history.go(-1)
      )
    }
  }
};
</script>

<style scoped>
.topnav {
  height: 1.5rem;
  line-height: 1.5rem;
  position: fixed;
  top: 0rem;
  display: block;
  width: 100%;
  background-color:#f49cf3;
  color: #fff;
}
.topnav a.left,
.topnav a.right,
.topnav span {
  display: inline-block;
}
.topnav a.left {
  float: left;
  width: 2rem;
}
.topnav a.right {
  float: right;
  width: 2rem;
}
.topnav span {
  margin: auto;
  width: 5rem;
  text-align: center;
}
</style>

