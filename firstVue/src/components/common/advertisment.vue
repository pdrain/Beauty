<template>
    <div class="banner-adv">
        <swiper :option="swiperOption" ref="com_advertisment">
            <swiper-slide class="swiper-slide" v-for="(item,index) in advList" :key="index">
               <img :src="'http://www.meilituibian.cn/app_img/uploadFile/'+item.path" />
            </swiper-slide>
        <!--     <swiper-slide class="swiper-slide">
                <img src="../../assets/banner/banner_01.png" />
             </swiper-slide>
             <swiper-slide class="swiper-slide">
                <img src="../../assets/banner/banner_01.png" />
             </swiper-slide>
              <swiper-slide class="swiper-slide">
                 <img src="../../assets/banner/banner_01.png" />
              </swiper-slide>-->
          </swiper>
    </div>
</template>
<script>
export default {
  props: ["code"],
  data() {
    return {
      swiperOption: {
        notNextTick: false,
        initialSlide: 0,
        loop: true,
        speed: 2000,
        direction: "horizontal",
        autoplay: true
      },
      advList:[]
    };
  },
  computed: {
    comp_adv: function() {
      return this.$refs.com_advertisment.swiper;
    }
  },
  mounted() {
    this.comp_adv.autoplay.start();
    this.initAdvData();
  },
  methods: {
    initAdvData() {
      var _this = this;
      this.$store
        .dispatch("getAdvertismentList", this.code)
        .then(function(result) {
          _this.advList = result;
        });
    }
  }
};
</script>
<style scoped lang="less">
.banner-adv {
  height: 5rem;
  width: 100%;
  background: #fff;
}
.banner-adv img {
  width: 100%;
}
</style>

