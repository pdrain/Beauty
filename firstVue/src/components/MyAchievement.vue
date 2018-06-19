<template>
  <div v-title='"我的业绩"'>
      <div class='total'>
          <div class="numbers">
              <p class="title">总业绩</p>
              <p class="detail">100万（个人）|&nbsp;1000万（美容店）</p>
          </div>
          <div class="items">
              <a @click="switchCLientType(0)">个人客户</a>
              <a @click="switchCLientType(1)">美容店</a>
          </div>
      </div>
      <div class="customers">
          <dl>
              <dd class="head"><span class="left">客户昵称</span><span class="right">总业绩</span></dd>
              <dd class="content" v-for="(c,index) in clientList" :key="index"><span class="left">XXXX</span><span class="right">10000</span></dd>
              <dd class="content"><span class="left">XXXX</span><span class="right">10000</span></dd>
              <dd class="content"><span class="left">XXXX</span><span class="right">10000</span></dd>
              <dd class="content"><span class="left">XXXX</span><span class="right">10000</span></dd>
          </dl>
        
         
      </div>
       <c-footer></c-footer>
  </div>
</template>

<script>
import Footer from "./Footer";
export default {
  components: { "c-footer": Footer },
  data() {
    return {
      clientType: 0, //客户类别
      clientList: []
    };
  },
  mounted() {
    this.getAchievements();
  },
  methods: {
    switchCLientType(_type) {
      this.clientType = _type;
    },
    //获取业绩
    getAchievements() {
      this.$store.dispatch('queryUserPerformance',window.UserInfo.openId).then(function(){

      });
    }
  }
};
</script>

<style scoped lang='less'>
.total {
  height: 6rem;
  background: -webkit-linear-gradient(#ff00fb, #f894f6); /* Safari 5.1 - 6.0 */
  background: -o-linear-gradient(#ff00fb, #f894f6); /* Opera 11.1 - 12.0 */
  background: -moz-linear-gradient(#ff00fb, #f894f6); /* Firefox 3.6 - 15 */
  background: linear-gradient(#ff00fb, #f894f6); /* 标准的语法 */
}
.total .numbers {
  height: 4.5rem;
  color: #fff;
}
.total .numbers .title {
  font-size: 1.1rem;
  padding-top: 0.7rem;
}
.total .numbers .detail {
  font-size: 0.7rem;
}
.total .items {
  height: 1.5rem;

  border-top: 0.01rem #f0f0f0 solid;
  background: #e206de;
  background: #e206de;
  color: #fff;
}
.total .items a {
  width: 49.4%;
  height: 1.1rem;
  line-height: 1.1rem;
  margin-top: 0.2rem;
  display: inline-block;
  border-right: 0.01rem #f0f0f0 solid;
}
.total .items a:last-child {
  border-right: 0rem;
}

.customers {
  padding: 0.3rem;
}

.customers dl {
  border: 1px #dfdfdf solid;
  border-radius: 5px 5px 0px 0px;
}
.customers dl dd {
  height: 1.4rem;
}
.customers dl dd.head {
  background: #dfdfdf;
}
.customers dl dd.content {
  background: #fff;
  height: 1.6rem;
  line-height: 1.6rem;
}
.customers dl dd .left {
  width: 70%;
  display: inline-block;
  margin-top: 0.14rem;
  height: 1rem;
  line-height: 1rem;
  border-right: 0.01rem #fff solid;
  box-sizing: border-box;
}
.customers dl dd .right {
  width: 27%;
  display: inline-block;
  margin-top: 0.14rem;
  height: 1rem;
  line-height: 1rem;
}
.customers dl dd.content .left {
  text-align: left;
  padding-left: 0.3rem;
  border-right: 0.01rem #dfdfdf solid;
}
.customers dl dd.content .right {
  text-align: right;
}
</style>

