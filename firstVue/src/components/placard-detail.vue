<template>
    <div v-title='"分享海报"' >
      <h2>企业分享给美容店的介绍页面</h2>
      <div>
        产品分类介绍<br/>
        产品分类介绍<br/>
        产品分类介绍<br/>
        产品分类介绍<br/>
      </div>
      <share-placard :shareid="shareId" :catid='catid'></share-placard>
      <c-footer></c-footer>
    </div>
</template>

<script>
import Footer from "./Footer";
import placardShareInfo from "./placard-share-info";
import utils from "../utils";
export default {
  data() {
    return {
      shareId: "",
      catid: utils.getParams("cat")
    };
  },
  components: { "c-footer": Footer, "share-placard": placardShareInfo },
  mounted() {
    let _this = this;
    _this.saveShareInfo().then(id => {
      _this.shareId = id;
    });
    console.log(this.catid);
  },
  methods: {
    saveShareInfo() {
      let _this = this;
      let promise = new Promise((resolve, reject) => {
        let param = {
          categoryId: 1,
          categoryName: "string",
          createTime: "2018-10-28T08:00:50.667Z",
          id: 0,
          openId: "string",
          status: 0,
          url: "string",
          userId: 1
        };
        _this.$store.dispatch("saveUserShareInfo", param).then(response => {
          resolve(response.id);
        });
      });
      return promise;
    }
  }
};
</script>

<style scoped>
h2{
padding-top:5rem;
padding-bottom:5rem;
}
</style>

