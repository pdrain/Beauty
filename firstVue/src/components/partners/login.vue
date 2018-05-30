<template>
  <div  class="login-form" v-title='"美容店登录"'>
    <u-header title="美业老师登录"></u-header>
      <ul>
          <li class='line1'>
              <label>账号：</label>
              <input type="text" v-model="account.username">
          </li>
          <li class="tp0 line2">
               <label>密码：</label>
              <input type="password" v-model="account.password">
          </li>
      </ul>
       <button class='btn-login' @click="doLogin">立即登录</button>
       <u-footer></u-footer>
  </div>
  
</template>

<script>
import Header from "../UserHeader";
import UserFooter from '../Footer'
export default {
  data() {
    return {
      account: {
        username: "",
        password: ""
      }
    };
  },
  components: { "u-header": Header ,'u-footer':UserFooter},
  mounted() {},
  methods: {
    doLogin() {
      var _this = this;
      if (_this.account.username == "") {
        alert("登录账号不能为空。");
        return false;
      }
      if (_this.account.password == "") {
        alert("登录密码不能为空。");
        return false;
      }
      this.$store.dispatch("partnerLogin", this.account).then(function(result) {
        debugger;
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
  line-height: 1.5rem;
  border: 0.05rem #ccc solid;
  background: #fff;
}
.login-form li.tp0 {
  border-top: 0rem;
}

.login-form li label {
  width: 3rem;
  height: 100%;
  display: block;
  border-right: 0.05rem #ccc solid;
  float: left;
}

.line1 {
  border-radius: 0.3rem 0.3rem 0rem 0rem;
}

.line2 {
  border-radius: 0rem 0rem 0.3rem 0.3rem;
}

.login-form li input {
  height: 1.1rem;
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
}
</style>

