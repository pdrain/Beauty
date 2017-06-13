// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import Router from './router'
import Axios from './http'
import Store from "./store"  // 引入store 对象
import VueResource from 'vue-resource'
import VueMaterial from 'vue-material'

//import wx from 'weixin-js-sdk' 


Vue.use(VueResource);
Vue.use(VueMaterial);

Vue.directive('title', {
  inserted: function (el, binding) {;
    document.title = binding.value;;
  }
})

new Vue({
  el: '#app',
  axios:Axios,
  router:Router,
  store:Store,
  render:h=>h(App)
})



           


           
           