<template>
   <div  class="login-form" v-title='"用户升级"'>
      <u-header title="业务员升级"></u-header>
      <ul>
          
          <li class="tp0">
               <label>真是姓名：</label>
             <input type="text" v-model="account.phone" placeholder="请输入真是姓名">
          </li>
           <li class="tp0">
               <label>常用联系方式：</label>
              <input type="text" v-model="account.phone" placeholder="请输入常用联系方式">
          </li>
          <li class='line1'>
              <label>证件号码：</label>
              <input type="text" v-model="account.phone" placeholder="请输入身份证号码">
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
       <button class='btn-login'>提交申请</button>
       <dl>
         <dd class="tp0">
              <div>
                <h2>升级须知</h2>
                <dl>
                  <dd>1、升级完全取决于个人意愿，我任何强制和费用</dd>
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
  border: 0.05rem #ccc dashed;
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
  border-right: 0rem #666 solid;
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

