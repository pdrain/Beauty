<template>
    <div v-title='"分享海报"'>
        <div id="qrcodeCanvas"></div>
    </div>
</template>

<script>
import utils from "../utils/index";
export default {
  props: ["shareid"],
  data() {
    return {
      id: this.shareid || utils.getParams("shareId")
    };
  },
  watch: {
    shareid: function() {
      console.log("aaaa" + this.shareid);
    }
  },
  created() {
      this.init()
    console.log(this.id);
  },
  methods: {
    init() {
      let _this = this;
      _this.getShareInfo().then(result => {
        jQuery("#qrcodeCanvas").qrcode({
          render: "canvas",
          text: location.origin + "/projects/?cIds=29,33,34,35,38,39&parent=",
          width: "200", //二维码的宽度
          height: "200", //二维码的高度
          background: "#ffffff", //二维码的后景色
          foreground: "#000000", //二维码的前景色
          src: "img/gray.jpg" //二维码中间的图片
        });
      });
    },
    getShareInfo() {
      let _this = this;
      let promise = new Promise((resolve, reject) => {
        _this.$store.dispatch("getUserShareInfo").then(result => {
          resolve();
        });
      });
      return promise;
    }
  }
};
</script>
