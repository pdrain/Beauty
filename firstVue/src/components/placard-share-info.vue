<template>
    <div v-title='"分享海报"'>
        <div id="qrcodeCanvas" class="qrcode"></div>
    </div>
</template>

<script>
import utils from "../utils/index";
export default {
  props: ["shareid", "catid"],
  data() {
    return {
      userInfo: null,
      qrCodeUrl: "",
      cats: []
    };
  },
  watch: {
    shareid: function() {
      console.log(11);
      if (!this.shareid) {
        this.shareid = utils.getParams("shareId");
      }
      this.init();
    }
  },
  created() {
    let _this = this;
    _this.$store.dispatch("getLostorageUserInfo").then(function(uInfo) {
      _this.userInfo = uInfo;
    });

    _this.getAllCatagories().then(() => {
      _this.qrCodeUrl = this.getQRcodeUrl();
      console.log(_this.qrCodeUrl)
    });
  },
  methods: {
    init() {
      let _this = this;
      _this.getShareInfo().then(result => {
        jQuery("#qrcodeCanvas").qrcode({
          //render: "canvas",
          render: "img",
          text: _this.qrCodeUrl,
          width: "200", //二维码的宽度
          height: "200", //二维码的高度
          background: "#ffffff", //二维码的后景色
          foreground: "#000000", //二维码的前景色
          src: "img/gray.jpg" //二维码中间的图片
        });
      });
    },
    getQRcodeUrl() {
      let _this = this;
      let url = "";
      let sCids = [];
      _this.cats.forEach(cat => {
        if (cat.id == _this.catid) {
          cat.second.forEach(item => {
            sCids.push(item.id);
          });
        }
      });

      url = location.origin + "/projects/?cIds=" + sCids.join(",");
      url += "&parent=" + _this.userInfo.openid;
      return url;
    },
    getShareInfo() {
      let _this = this;
      let promise = new Promise((resolve, reject) => {
        _this.$store
          .dispatch("getUserShareInfo", _this.shareid)
          .then(result => {
            resolve();
          });
      });
      return promise;
    },
    getAllCatagories() {
      let _this = this;
      let fn = (resolve, reject) => {
        _this.$store.dispatch("getAllCategories").then(function(data) {
          let _list = data.data;
          _this.cats = _list;
          resolve();
        });
      };
      return new Promise(fn);
    }
  }
};
</script>


<style lang="less" scoped>
.qrcode canvas{
  border:0.05rem #f0f0f0 solid;
}
</style>
