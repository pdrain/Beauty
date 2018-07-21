<template>
   <div  class="login-form" v-title='"美容店注册"'>
      <u-header  backurl="/user"  title="注册美容店"></u-header>
      
      <ul>
          <li class='line1'>
              <label>账号：</label>
              <input type="text" v-model="account.phone" placeholder="请输入常用手机号码">
          </li>
          <li class="tp0">
               <label>店名：</label>
              <input type="text" v-model="account.shopName" placeholder="请输入美容店名称">
          </li>
           <li class="tp0">
               <label>联系人：</label>
              <input type="text" v-model="account.contact"  placeholder="请输入美容店联系人">
          </li>
          <li class="tp0">
               <label>联系电话：</label>
              <input type="text" v-model="account.contractNo"  placeholder="请输入美容店联系电话">
          </li>
          <li class="tp0">
               <label>地址：</label>
              <input type="text" v-model="account.address"  placeholder="请输入美容店地址">
          </li>
           <li class="tp0">
               <label>纳税人编号：</label>
              <input type="text" v-model="account.taxpayerCode"  placeholder="请输入纳税人编号">
          </li>
          <!-- <li class="tp0 line2">
               <label>营业执照：</label>
              <input type="text" v-model="account.address"  placeholder="请上传营业执照复印件">
          </li> -->
      </ul>
       <button class='btn-login' @click="doReg">立即注册</button>
       <u-footer></u-footer>
  </div>
</template>

<script>
import Header from "../UserHeader";
import UserFooter from "../Footer";
export default {
  components: { "u-header": Header, "u-footer": UserFooter },
  data() {
    return {
      account: {
        openId:'',
        phone: "",        //手机
        shopName: "",     //店名
        contact: "",
        contractNo: "",
        address: "",
        taxpayerCode: ""
      }
    };
  },
  mounted() {
    let userInfo = JSON.parse(localStorage.getItem('userinfo'));
    this.account.openId ='11';// userInfo.openid;
  },
  methods:{
    doReg:function(){
      let _preCheck=this.regPreCheck();
      if(!_preCheck){
        return false;
      }
      this.$store.dispatch('savePartnerInfo',this.account).then(function(data){

      },function(msg){
        alert(msg)
      });
    },
    regPreCheck:function(){
      let _this = this;
      let flag=true;
        if(!_this.account.phone){
          alert('请输入手机号作为登陆账号。');
          return false;
        }
        if(!_this.account.shopName){
          alert('请输入美容店名称。');
          return false;
        }
        if(!_this.account.contact){
          alert('请输入常用联系人。');
          return false;
        }
        if(!_this.account.contractNo){
          alert('请输入常用联系电话。');
          return false;
        }
        if(!_this.account.address){
          alert('请输入店铺地址。');
          return false;
        }
        if(!_this.account.taxpayerCode){
          alert('请输入店铺纳税人编号。');
          return false;
        }
      return true;
    },
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
  border-bottom: 0.05rem #ccc dashed;
  background: #fff;
}
.login-form li.tp0 {
  border-top: 0rem;
}

.login-form li label {
  width: 3.6rem;
  height: 100%;
  display: block;
  /* border-right: 0.05rem #ccc dashed; */
  float: left;
  text-align:right;
}

.line1 {
  border-radius: 0.3rem 0.3rem 0rem 0rem;
}

.line2 {
  border-radius: 0rem 0rem 0.3rem 0.3rem;
}

.login-form li input {
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
  border:0px;
}
</style>

