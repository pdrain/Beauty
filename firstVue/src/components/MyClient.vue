<template>
  <div v-title='"我的客户"'>
      <div class='total'>
          <div class="numbers">
              <p class="title">总客户数</p>
              <p class="detail">{{personalClientList.length}}（个人）|&nbsp;{{businessClientList.length}}（美容店）</p>
          </div>
          <div class="items">
              <a @click="switchCLientType(0)">个人客户</a>
              <a @click="switchCLientType(1)">美容店</a>
          </div>
      </div>
      <div class="customers">
          <dl v-show="clientType==0">
              <dd class="head"><span class="left">客户昵称</span><span class="right">加入时间</span></dd>
              <dd class="content"  v-for="(c,index) in personalClientList" :key="index"><span class="left">{{c.nickName}}</span><span class="right">{{c.createTime}}</span></dd>
              
          </dl>
        <dl v-show="clientType==1">
              <dd class="head"><span class="left">客户昵称</span><span class="right">加入时间</span></dd>
              <dd class="content"  v-for="(c,index) in businessClientList" :key="index"><span class="left">{{c.nickName}}</span><span class="right">{{c.createTime}}</span></dd>
              
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
      personalClientList: [],
      businessClientList: [],
      UserInfo: JSON.parse(localStorage.getItem("userinfo"))
    };
  },
  mounted() {
    this.getClientList();
  },
  methods: {
    switchCLientType(_type) {
      this.clientType = _type;
    },
    //获取客户列表
    getClientList() {
      var _this = this;
      let openid = this.UserInfo.openId;
      _this.$store.dispatch("getMyClient", openid).then(function(data) {
        data.forEach(function(item) {
          if (item.userType == "2") {
            _this.businessClientList.push(item);
          } else {
            _this.personalClientList.push(item);
          }
        });
        _this.clientList = data;
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
  width: 49.2%;
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
  text-align: left;
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

