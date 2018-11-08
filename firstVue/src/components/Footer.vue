<template>
    <div class="bottom-menu">
        <a class="footer-icon home" :class="{'active':homeActive}" @click="goHome">发现美丽</a>
        <a class="footer-icon shop" :class="{'active':shopActive}" @click="goShop">积分商城</a>
        <a class="footer-icon shop" :class="{'active':newsActive}" @click="goNews">常识</a>
        <a class="footer-icon mine" :class="{'active':mineActive}" @click="goMy">我</a>
    </div>
</template>


<script>
export default {
  data() {
    return {
      homeActive: true,
      shopActive: false,
      mineActive: false,
      newsActive: false
    };
  },
  created(){
      this.homeActive = location.pathname=='/'
      this.shopActive = location.pathname.indexOf('/shop')>-1
      this.mineActive = location.pathname.indexOf('/user')>-1
      this.newsActive = location.pathname.indexOf('/news')>-1
  },
  methods: {
    goHome() {
      this.$router.push("/");
    },
    goShop() {
      this.$router.push("/shop");
    },
    goNews() {
      this.$router.push("/news");
    },
    goMy() {
      this.$router.push("/user");
    }
  }
};
</script>

<style scoped>
.footer-icon {
  background-size: 0.2rem !important;
  background-size: 1rem !important;
  background-position-x: center !important;
  background-position-y: 0.2rem !important;
}
.home {
  background: url(../assets/dibu-1.png) no-repeat;
}
.home.active {
  background: url(../assets/dibu-2.png) no-repeat;
}
.shop {
  background: url(../assets/dibu-3.png) no-repeat;
}
.shop.active {
  background: url(../assets/dibu-4.png) no-repeat;
}
.mine {
  background: url(../assets/dibu-5.png) no-repeat;
}
.mine.active {
  background: url(../assets/dibu-6.png) no-repeat;
}
</style>

