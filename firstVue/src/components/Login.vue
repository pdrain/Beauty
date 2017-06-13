<template>
  <div id="login-form">
    <h1>用户登录</h1>
    <h2>{{msg}}</h2>
      <form>
        <ul>
            <li><input type="text" placeholder="登录帐号或手机号码"/></li>
            <li><input type="password" placeholder="登录密码"/></li>
            <li><button @click="doLogin">登录</button></li>
        </ul>
        
        
      </form>
  </div>
</template>

<script  type="application/ecmascript">

import store from '../store'
import * as api from '../api'
import axios from '../http'
import router from '../router'

import * as types from '../store/types'


export default {
  name: 'user-login',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
    }
  },  
   mounted(){
    
    },
  methods:{
      doLogin() {
          var params={};
        
          axios.get(api.DO_LOGIN+'?v=1', params)
                  .then(response => {
                      let _data = response.data;   
                      this.$store.commit(types.LOGIN,  _data.Token)
                      router.replace(decodeURIComponent(this.$route.query.redirect));
                  })

        
      }
  }
}
</script>

