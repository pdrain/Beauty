<template>
   <div  class="login-form" v-title='"用户升级"'>
       <h1>
           业务员升级
       </h1>
      <ul>
          <li class='line1'>
              <label>证件号码：</label>
              <input type="text" v-model="account.phone" placeholder="请输入身份证号码">
          </li>
          <li class="tp0">
               <label>身份证正面：</label>
              <img srf=''>
          </li>
           <li class="tp0">
               <label>身份证反面：</label>
               <img srf=''>
          </li>
          <li class="tp0">
               <label>升级级别：</label>
              <select>
                <option>--选择级别--</option>
                <option>A-级</option>
                <option>B-级</option>
                <option>C-级</option>
              </select>
          </li>
          <li class="tp0">
               <label>升级协议：</label>
              <input type='checkbox'>阅读升级 <a>《协议》</a>。
          </li>
           
      </ul>
       <button class='btn-login'>立即注册</button>
       <dl>
         <dd class="tp0">
              <div>
                <h2>升级须知</h2>
                <dl>
                  <dd>1、啊大煞风景啊；设计的发生的发生</dd>
                  <dd>2、啊大煞风景啊；设计的发生的发生</dd>
                  <dd>3、啊大煞风景啊；设计的发生的发生</dd>
                  <dd>4、啊大煞风景啊；设计的发生的发生</dd>
                  <dd>5、啊大煞风景啊；设计的发生的发生</dd>
                </dl>
              </div>
          </dd>
       </dl>
  </div>
</template>

<script>
export default {
  data() {
    return {
      account: {
        phone: "",
        nickName: "",
        contracttor: "",
        contracttor: "",
        contractNo: "",
        address: ""
      }
    };
  },
  mounted() {}
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
  border: 0.05rem #666 solid;
  background: #fff;
  text-align: left;
}
.login-form li.tp0 {
  border-top: 0rem;
}

.login-form li label {
  width: 4rem;
  height: 100%;
  display: block;
  border-right: 0.05rem #666 solid;
  float: left;
}

.line1 {
  border-radius: 0.3rem 0.3rem 0rem 0rem;
}

.line2 {
  border-radius: 0rem 0rem 0.3rem 0.3rem;
}

.login-form li input {
  height: 1.3rem;
  width: 10rem;
  float: left;
  margin-top: 0.04rem;
  border: 0px;
  outline: none;
  text-indent: 0.05rem;
}
.login-form li input[type='checkbox']{
  width: 1rem;
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

