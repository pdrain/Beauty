<template>
   <div  class="login-form" v-title='"用户升级"'>
      <u-header backurl="/user"  title="业务员升级"></u-header>
      <ul>
          
          <li class="tp0">
               <label>真是姓名：</label>
             <input type="text" v-model="account.userName" placeholder="请输入真是姓名">
          </li>
           <li class="tp0">
               <label>常用联系方式：</label>
              <input type="text" v-model="account.phone" placeholder="请输入常用联系方式">
          </li>
          <li class='line1'>
              <label>证件号码：</label>
              <input type="text" v-model="account.numberId" placeholder="请输入身份证号码">
          </li>
         <li class="tp0" v-if="upgradeInfo">
              <label>当前级别：</label>
              <span class="lev l0" v-if='userInfo.jobTitle+1==0' >见习导师</span>
              <span class="lev l1" v-if='userInfo.jobTitle+1==1' >银牌导师</span>
              <span class="lev l2"  v-if='userInfo.jobTitle+1==2'  >金牌导师</span>
              <span class="lev l3"  v-if='userInfo.jobTitle+1==3'  >钻石导师</span>
          </li>
          <li class="tp0 multiLine" v-if="upgradeInfo" >
              <label>等级介绍：</label>
              <span class="lev l0"  >见习导师</span>
              <span style="display:block;line-height:0.8rem;">欢迎关注画眉鸟美丽联盟成为美丽见习导师！</span>
              <span class="lev l1"  >银牌导师</span>
              <span style="display:block;line-height:0.8rem;">只要你爱美丽，并喜欢帮助她人变美丽，并从中获得快乐，就可以成为我们的银牌导师！</span>
              <span class="lev l2"  >金牌导师</span>
              <span style="display:block;line-height:0.8rem;"> 连续6个月，每个月平均业绩达到300万即可升级成为金牌导师。</span>
              <span class="lev l3"  >钻石导师</span>
              <span style="display:block;line-height:0.8rem;">  连续6个月，每个月平均业绩达到600万即可升级成为钻石导师。</span>
          </li>
        
          
          <li class="tp0">
               <label>升级协议：</label>
              <input type='checkbox' v-model="isRead">阅读升级 <a class='agreement' @click="readUpgradeAgreement">《协议》</a>。
          </li>
           
      </ul>
       <button class='btn-login' v-if="upgradeInfo.upgrade" @click="doUpgrade">提交申请</button>
       <button class='btn-login' v-if="!upgradeInfo.upgrade" style='background:#ccc'>未达到升级条件</button>
       <dl class="upgrade-detail">
         <dd class="tp0">
              <div>
                <h2>升级须知</h2>
                <dl>
                  <dd>1、升级完全取决于个人意愿，我公司不何强制加入和收取任何费用</dd>
                  <dd>2、为了保证自己的利益，首次升级为业务员时请完整填写个人真实信息</dd>
                  <dd>3、本平台保证所有个人信息绝对隐私</dd>
                  <dd>4、请认真阅读本平台的升级协议，以了解升级后的相关权益</dd>
                </dl>
              </div>
          </dd>
       </dl>
       <u-footer></u-footer>
  </div>
</template>

<script>
import Header from "./UserHeader";
import UserFooter from "./Footer";
export default {
  components: { "u-header": Header, "u-footer": UserFooter },
  data() {
    return {
      userInfo: "", //JSON.parse(localStorage.getItem('userinfo')),
      account: {
        phone: "",
        nickName: "",
        numberId: ""
      },
      upgradeInfo: {},
      isRead: false
    };
  },
  mounted() {
    let _this = this;
    _this.$store.dispatch("getLostorageUserInfo").then(function(uInfo) {
      //console.log(JSON.stringify(uInfo))
      _this.userInfo = uInfo;
      _this.account.phone = _this.userInfo.phone;
      _this.account.userName = _this.userInfo.userName;
      _this.account.numberId = _this.userInfo.numberId;
      //console.log(JSON.stringify(_this.account))
      _this.getUpgradeInfo();
    });
  },
  methods: {
    getUpgradeInfo: function() {
      let _this = this;
      this.$store
        .dispatch("getUpgradeInfo", this.userInfo.openId)
        .then(function(res) {
          _this.upgradeInfo = res;
        });
    },
    doUpgrade: function() {
      let _this = this;
      if (!this.precheck()) {
        return false;
      }
      this.$store
        .dispatch("doUpgrade", this.userInfo.openId)
        .then(function(res) {
          if (res.data.code == 0) {
            alert("升级成功！");
            _this.$router.push("/user");
          }
        });
    },
    precheck: function() {
      let _this = this;
      if (!_this.account.userName) {
        alert("请输入真实姓名。");
        return false;
      }
      if (!_this.account.phone) {
        alert("请输入常用联系方式。");
        return false;
      }

      if (!_this.account.numberId) {
        alert("请输入证件号码。");
        return false;
      }
      if (!_this.isRead) {
        alert("请输入阅读升级协议。");
        return false;
      }
      return true;
    },
    readUpgradeAgreement: function() {
      this.$router.push({
        path: "/user/upgrade-agreement",
        query: { back: location.hash.replace("#", "") }
      });
    }
  }
};
</script>

<style scoped>
.login-form ul {
  width: 98%;
  margin: auto;
  padding: 0px;
}
.login-form li {
  margin: 0px;
  padding: 0px;
  list-style: none;
  height: 1.5rem;
  line-height: 1.6rem;
  margin-bottom: 0.03rem;
  background: #fff;
  text-align: left;
  border-radius: 0px;
  text-indent: 0.05rem;
}
.login-form li.tp0 {
  border-top: 0rem;
}

.login-form li label {
  width: 4rem;
  height: 100%;
  display: block;
  border-right: 0rem #666 solid;
  float: left;
}
.login-form li.multiLine {
  line-height: 1rem;
  height: 12rem;
}

.line1 {
  border-radius: 0.3rem 0.3rem 0rem 0rem;
}

.line2 {
  border-radius: 0rem 0rem 0.3rem 0.3rem;
}

.login-form li input[type="text"] {
  height: 1.2rem;
  width: 10rem;
  float: left;
  margin-top: 0.04rem;
  border: 0px;
  outline: none;
  text-indent: 0.05rem;
}

.login-form .btn-login {
  width: 98%;
  margin: auto;
  border-radius: 0.2rem;
  height: 1.5rem;
  margin-top: 0.5rem;
  background: #ff00fb;
  font-size: 0.6rem;
  color: #fff;
  border: 0px;
}
.upgrade-detail {
  background: #fff;
  margin-bottom: 2rem;
}
.upgrade-detail h2 {
  margin-top: 0.5rem;
  margin-bottom: 0.5rem;
  font-size: 0.6rem;
  font-weight: normal;
  text-align: center;
}
.upgrade-detail dd {
  text-align: left;
  line-height: 1.2rem;
  padding: 0.2rem;
}

.upgrade-detail input[type="checkbox"] .login-form .lev {
  display: inline-block;
  width: 3rem;
  height: 1rem;
  line-height: 1rem;
  background: #f0f0f0;
  text-align: center;
  color: #fff;
  padding-left: 0.2rem;
  padding-right: 0.2rem;
  font-size: 0.1rem;
}

.login-form .lev.l0{
  background: #f8e1f8;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
  color: #fff;
}
.login-form .lev.l1 {
  background: #f5adf4;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
  color: #fff;
}
.login-form .lev.l2 {
  background: #f771f6;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
  color: #fff;
}
.login-form .lev.l3 {
  background: #ff00fb;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
  color: #fff;
}
.login-form .lev.l3 {
  background: #ec06e8;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
  color: #fff;
}
.login-form .lev.l-no {
  background: #ccc;
  padding-left: 0.4rem;
  padding-right: 0.4rem;
}

.agreement {
  color: blue;
}
</style>

