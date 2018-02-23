<template>
  <div class="login">
    <div class="login-form">
      <table>
        <tr>
          <td class='title'>用户登录</td>
        </tr>
        <tr>
          <td class='row'>
            <input type='text' placeholder="登录账号"  v-model="login.account"/>
          </td>
        </tr>
        <tr>
          <td class='row'>
            <input type='password' placeholder="登录密码"  v-model="login.password"/>
          </td>
        </tr>
        <tr>
          <td>
            <button @click="doLogin">登录</button>
            <button>取消</button>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>





<script>
export default {
data(){
  return{
    login:{account:'',password:''}
  }
},
  methods: {
    doLogin: function () {
      let _this = this;
      _this.$store.dispatch("doLogin", {account:_this.login.account,password:_this.login.password}).then(function(result){
        if (result) {
            
            let redirect_url = _this.$route.query.redirect;
            _this.$router.replace(redirect_url)
          }
      });

    }

  }
}
</script>

<style scoped>
.login {
  width: 100%;
  height: 100%;
  background: url('../assets/login-bg.jpg') repeat-x;
  overflow: hidden;
  position:absolute;
  left: 0px;
  top: 0px;
}

.login-form {
  width: 508px;
  height: 256px;
  margin: auto;
  margin-top: 10%;
  background: url('../assets/login-form.png')
}

.login-form table {
  width: 100%;
}

.login-form table .title {
  height: 50px;
  vertical-align: top;
  padding-top: 8px;
}

.login-form table .row {
  height: 40px;
  vertical-align: middle;
}

button{
  cursor: pointer;
  
}
</style>
