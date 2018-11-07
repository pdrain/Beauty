<template>
    <div v-title='"分享海报"' >
    <share-placard :shareid="shareId"></share-placard>
    <c-footer></c-footer>
    </div>
</template>

<script>
import Footer from "./Footer";
import placardShareInfo from "./placard-share-info";
export default {
  data() {
    return {
      shareId: ""
    };
  },
  components: { "c-footer": Footer, "share-placard": placardShareInfo },
  mounted() {
    let _this = this;
    _this.saveShareInfo().then(id => {
      _this.shareId = id;
    });
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

<style>
</style>

