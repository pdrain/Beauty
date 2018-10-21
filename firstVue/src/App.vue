<template>
  <div id="app">  
    <Loading></Loading>
    <router-view></router-view>
  </div>
</template>

<script>

import * as types from './store/types'
import Loading from './components/Loading'


export default {
  name: 'app',
  components: {Loading },
  data(){
      return {}

  },
  methods:{
      doLogout(){
         this.$store.commit(types.LOGOUT);
         this.$router.replace('/');
      }

  }
}
</script>

<style lang="less">
@import './assets/index.less';


#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: @font-normal-color;
  height: 100%;
}

.nav{position: fixed;width: 100%;margin: auto;top: 0px;}
.nav .logo{ width: 45px;height: auto; display: inline-block; vertical-align: middle;}
.nav ul{list-style: none;margin: 0;padding: 0;}
.nav ul li{display: inline-block;width: 108px;height: 48px;line-height: 48px;border:0px solid #dadada;text-align: center;list-style: none;}
.nav ul li a{
  text-decoration: none;
}

</style>
