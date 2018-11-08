<template>
    <div v-title="'用户中心'" class="usercenter">
        <header>
           <div class="nick" v-if=" UserInfo">{{UserInfo.nickName}}</div>
            <div class="icon">
                <img v-if=" UserInfo" :src="UserInfo.WX.headimgurl" />
            </div>
           
        </header>
        <div class="user-detail" >
          
            <ul class="my">
              <li v-for="(item,i) in menus" :key="i" @click="gotoDetail(item.path)">
                <i :class="item.class">&nbsp;</i>
                <span>
                {{item.name}}
                </span>
              </li>
            </ul>
        </div>
        <br/>
        <div class="adv">
            <img src="../assets/my/wode.jpg"/>
        </div>
<br/>
<br/>
<br/>
        <c-footer></c-footer>
    </div>
</template>



<script  type="application/ecmascript">
import { mapGetters } from "vuex";
import * as types from "../store/types";
import UserHeader from "./UserHeader";
import Footer from "./Footer";
import wx from "../config/WeXin";

export default {
  components: { UserHeader, "c-footer": Footer },
  data() {
    return {
      msg: "Welcome to User Center!",
      UserInfo: "",
      menus: [
            { name: "我的订单", path: "/user/myorders", class: "order" },
            { name: "我的客户", path: "/user/client", class: "about-us" },
            { name: "我的业绩", path: "/user/achievement", class: "upgrade" },
            { name: "我的积分", path: "/user/mypoints", class: "ticket" },
         
            { name: "用户保障", path: "/user/userrights", class: "safe" },
            { name: "优惠券", path: "/user/coupon", class: "ticket" },
            { name: "我要升级", path: "/user/upgrade", class: "upgrade" },
            { name: "邀请好友", path: "/user/placard", class: "welcome" },
        
            { name: "关于我们", path: "/user/aboutus", class: "about-us" },
            { name: "合作机构", path: "/partners/hospitals", class: "partner" },
            {
              name: "客服中心",
              path: "/user/servicecenter",
              class: "service-center"
            },
            { name: "设置", path: "/user/setting", class: "setting" },
            { name: "美容店加盟", path: "/partners/reg", class: "setting" },
            { name: "加盟协议", path: "/user/agreement", class: "agreement" }
      ]
    };
  },
  computed: {
    showMoreItem: function() {
      let show = false;
      if (this.UserInfo && this.UserInfo.jobTitle) {
        show = this.UserInfo.jobTitle >= 0;
      }
      return show;
    }
  },
  created() {},
  mounted() {
    let _this = this;
    _this.$store.dispatch("getLostorageUserInfo").then(function(uInfo) {
      _this.UserInfo = uInfo;
    });
  },
  updated() {},
  watch: {},
  methods: {
    gotoDetail(path) {
      this.$router.push(path);
    }
  }
};
</script>


<style scoped lang="less">
@import "../assets/index.less";
h2.title {
  line-height: 1.6rem !important;
  height: 40px;
  font-size: 0.6rem;
  font-weight: normal;
  text-align: left;
}
h2.title span {
  height: 20px;
  width: 5px;
  background: #ff00fb;
  margin-right: 5px;
}





header {
  width: 100%;
  text-align: center;
  padding: 20px 0px 10px 0px;
  background: url(../assets/tou.png) no-repeat;
  background-color:#fff;
  height: 6.3rem;
  background-size: cover;
}

header .nick {
  color: #fff;
  font-size: 0.8rem;
  line-height: 3rem;
  height: 3rem;
  width: 100%;
}

header .icon img {
  width: 3.5rem;
  height: 3.5rem;
  vertical-align: middle;
  border-radius: 3.5rem;
}

.usercenter {
  width: 100%;
  height: 100%;
}

.usercenter h1 {
  margin: 0px;
  padding: 0px;
  line-height: 30px;
  height: 30px;
  text-align: left;
  font-size: 14px;
  font-weight: normal;
}

.usercenter h1 span {
  border-left: 3px @font-hot-color solid;
  padding-left: 8px;
}

.usercenter table {
  background: @user-border-color;
  width: 100%;
  border-spacing: 1px;
  border-collapse: separate;
  margin-bottom: 8px;
}

.usercenter table td {
  width: @user-item-width;
  vertical-align: middle;
  background: @user-bg;
  height: 80px;
}
.usercenter table td:active {
  background-color: #f0f0f0;
}

.usercenter table td a {
  text-decoration: none;
  color: #666;
}

.usercenter ul li a {
  text-decoration: none;
  color: @font-normal-color;
  width: 100%;
  text-align: left;
  display: inline-block;
}

.usercenter .adv {
  width: 100%;
  height: 100px;
  background: @user-bg;
}

.usercenter .adv img{
  width: 100%;
}
</style> 