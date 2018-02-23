<template>
  <div id="login-form" class="login-form">
    <h1><span class="close" @click="closeWindow">X</span>
      用户登录</h1>
      <form>
        <ul>
            <li>
              <label>登录名</label>
              <input type="text" placeholder="登录帐号或手机号码"/>
            </li>
            <li>
              <label>登录密码</label>
              <input type="password" placeholder="登录密码"/>
            </li>
        </ul>
        <p class="error">{{msg}}</p>
        <p class="agreement">
          <label for="agree">
            <input type="checkbox" name="agree" id="">
            接受画眉鸟美容的协议
          </label>

        </p>
        <button @click="doLogin">登录</button>
        
      </form>
  <div class="foot">
    <a href="">立即注册</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="">找回密码</a>
  </div>
  </div>
</template>

<script  type="application/ecmascript">
import store from "../store";
import * as api from "../api";
import axios from "../http";
import router from "../router";

import * as types from "../store/types";

export default {
  name: "user-login",
  data() {
    return {
      msg: "Welcome to Your Vue.js App"
    };
  },
  mounted() {},
  methods: {
    doLogin() {
      let self = this;
      var params = { account: "", password: "" };

      axios.post(api.DO_LOGIN + "?v=1", params).then(response => {
        let _data = response.data;
        if (_data.Code == 0) {
          
          self.$store.commit(types.LOGIN, _data.Token);
          //router.replace(decodeURIComponent(this.$route.query.redirect));
        } else {
          self.msg = response.Message
        }
      });
    },
    closeWindow: function() {
      this.$router.push("/projects");
    }
  }
};
</script>

<style scoped lang="less">
@import "../assets/index.less";

.login-form {
  width: 100%;
}
.login-form h1 {
  background: #ff00fb;
  height: 2.5rem;
  line-height: 2.5rem;
  font-size: 1.2rem;
  color: #fff;
}
.login-form h1 .close {
  float: left;
  font-weight: normal;
  margin-left: 0.3rem;
  display: inline-block;
  width: 2rem;
  height: 2rem;
  text-align: center;
}
.login-form ul {
  width: 100%;
  background: #fff;
}
.login-form ul li {
  display: flex;
  line-height: 3rem;
  width: 95%;
  border-bottom: 1px #f0f0f0 solid;
  margin: auto;
}
.login-form ul li label {
  width: 30%;
  text-align: left;
}
.login-form ul li input {
  width: 70%;
  text-align: right;
}
.login-form button {
  width: 90%;
  height: 2.5rem;
  margin-top: 0.5rem;
  background: @font-hot-color;
  border: 0px;
  color: #fff;
  border-radius: 0.3rem;
  font-size: 1.3rem;
}
.login-form .foot {
  margin-top: 1rem;
  text-align: center;
  color: #666;
}
.login-form .foot a {
  text-decoration: none;
}
.login-form .agreement {
  margin-top: 4rem;
  text-align: left;
  color: #666;
  text-indent: 1rem;
}
.login-form .error{
  color:#f00;
  padding:0px;
  margin: 0px;
  line-height: 16px;
  text-align: left;
}
</style>
