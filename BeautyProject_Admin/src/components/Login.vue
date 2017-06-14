<template>
  <div class="login">
    <div class="login-form">
      <table>
        <tr>
          <td class='title'>用户登录</td>
        </tr>
        <tr>
          <td class='row'>
            <input type='text' placeholder="登录账号"/>
          </td>
        </tr>
        <tr>
          <td class='row'> <input type='text' placeholder="登录密码"/></td>
        </tr>
        <tr>
          <td>
            <button>登录</button>
            <button>取消</button>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>





<script>
export default {

}
</script>

<style>
.login {
  width: 100%;
  height: 100%;
  background: url('../assets/login-bg.jpg') repeat-x;
  overflow: hidden;
}

.login-form {
  width: 508px;
  height: 256px;
  margin: auto;
  margin-top: 10%;
  background: url('../assets/login-form.png')
}
.login-form table{width: 100%;}
.login-form table .title{height: 50px; vertical-align: top; padding-top: 8px;}
.login-form table .row{height: 40px; vertical-align: middle;}
</style>
